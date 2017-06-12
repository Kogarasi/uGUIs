using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uGUIs.UI {
  public class UI<T,U>: UIBase where T: UI<T,U> where U: MonoBehaviour {
    protected U ui;

    public override void init(FieldInfo fieldInfo, Transform parent){
      var name = fieldInfo.Name;
      var nameAttr = Util.Attribute.getAttribute<Attribute.ObjectNameAttribute>(typeof(T));
      if(nameAttr != null){
        name = nameAttr.name;
      }

      var partsTransform = parent.Find(name);
      if(partsTransform != null){
        ui = partsTransform.GetComponent<U>();
      } else {
        ui = create(name, parent);
      }

      applyAttribute(fieldInfo);
    }

    public virtual U create(string name, Transform parent){
      var go = new GameObject(name, typeof(U));
      go.transform.SetParent(parent, false);

      return go.GetComponent<U>();
    }

    void applyAttribute(FieldInfo fieldInfo){
      var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      var methods = typeof(T).GetMethods(flags);
      var connectType = typeof(Attribute.ConnectAttribute);

      // Attributeが付与されているものに絞る
      // { ConnectAttribute => Method }に加工
      var connectMethods = methods.Where(x=>x.GetCustomAttributes(connectType, false).Any())
      .Select(x=> new { method = x, attr = x.GetCustomAttributes(connectType, false).First() as Attribute.ConnectAttribute })
      .ToDictionary(x=>x.attr.type, x=>x.method);

      var classAttributes = typeof(T).GetCustomAttributes(false) as System.Attribute[];   
      var fieldAttributes = fieldInfo.GetCustomAttributes(false) as System.Attribute[];
      var attributes = classAttributes.Concat(fieldAttributes);

      attributes.Where(x=>connectMethods.ContainsKey(x.GetType()))
      .ToList().ForEach(x=>connectMethods[x.GetType()].Invoke(this, new object[]{x}));

    }

  }
}