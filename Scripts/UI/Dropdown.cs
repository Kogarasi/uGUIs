using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Attribute;

namespace uGUIs.UI {
  public class Dropdown : UI<Dropdown, UnityEngine.UI.Dropdown> {

    [ObjectName("Label")]
    Text innerText;

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent, Style.Constructor styleRoot){
      base.init(fieldInfo, parent, styleRoot);

      bindCallback(parent);
    }

    void bindCallback(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(Dropdown));
      if(callbackMethod != null){
        ui.onValueChanged.AddListener((value)=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier, value});
        });
      }
    }
  }
}