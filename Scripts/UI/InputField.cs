using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Attribute;

namespace uGUIs.UI {
  public class InputField : UI<InputField, UnityEngine.UI.InputField> {

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent, Style.Constructor styleRoot){
      base.init(fieldInfo, parent, styleRoot);

      bindCallback(parent);
    }

    void bindCallback(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(InputField));
      if(callbackMethod != null){
        ui.onValueChanged.AddListener((value)=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier, value});
        });
      }
    }
  }
}