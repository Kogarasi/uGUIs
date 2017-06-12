using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uGUIs.UI {
  public class UI<T>: UIBase where T: MonoBehaviour {
    protected T ui;

    public override void init(FieldInfo fieldInfo, Transform parent){
      var name = fieldInfo.Name;
      var nameAttr = Util.Attribute.getAttribute<Attribute.ObjectNameAttribute>(this.GetType());
      if(nameAttr != null){
        name = nameAttr.name;
      }

      var partsTransform = parent.Find(name);
      if(partsTransform != null){
        ui = partsTransform.GetComponent<T>();
      } else {
        ui = create(name, parent);
      }
    }

    public virtual T create(string name, Transform parent){
      var go = new GameObject(name, typeof(T));
      go.transform.SetParent(parent, false);

      return go.GetComponent<T>();
    }
  }
}