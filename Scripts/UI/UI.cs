using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace uGUIs.UI {
  public class UI<T,U>: UIBase where T: UI<T,U> where U: UIBehaviour {
    protected U ui;

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent){
      var name = getObjectName(fieldInfo);
      var partsTransform = parent.transform.Find(name);
      if(partsTransform != null){
        ui = partsTransform.GetComponent<U>();
      } else {
        var optional = Util.Attribute.getAttributes<Attribute.OptionalAttribute>(fieldInfo);
        if(!optional.Any()){
          throw new Exception("Can't find GameObject(" + name + ")");
        }
      }

      applyAttribute(fieldInfo);
    }

    string getObjectName(FieldInfo fieldInfo){
      var name = fieldInfo.Name;
      var classAttr = Util.Attribute.getAttribute<Attribute.ObjectNameAttribute>(typeof(T));
      if(classAttr != null){
        name = classAttr.name;
      }

      var fieldAttr = Util.Attribute.getAttributes<Attribute.ObjectNameAttribute>(fieldInfo);
      if(fieldAttr.Any()){
        name = fieldAttr.First().name;
      }

      return name;      
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