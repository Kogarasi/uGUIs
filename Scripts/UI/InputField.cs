using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using uGUIs.Attribute;

namespace uGUIs.UI {
  public class InputField : UI<InputField, UnityEngine.UI.InputField>, Interface.Callback {

    UnityAction<String> onValueChangedCallback;

    public void bind(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(InputField));
      if(callbackMethod != null){
        onValueChangedCallback = (value)=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier, value});
        };

        ui.onValueChanged.AddListener(onValueChangedCallback);
      }
    }

    public void unbind(){
      if(onValueChangedCallback != null){
        ui.onValueChanged.RemoveListener(onValueChangedCallback);
      }
    }
  }
}