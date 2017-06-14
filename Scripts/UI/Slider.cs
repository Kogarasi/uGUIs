using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Attribute;

namespace uGUIs.UI {
  public class Slider : UI<Slider, UnityEngine.UI.Slider> {

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent, Style.Constructor styleRoot){
      base.init(fieldInfo, parent, styleRoot);

      bindCallback(parent);
    }

    void bindCallback(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(Slider));
      if(callbackMethod != null){
        ui.onValueChanged.AddListener((value)=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier, value});
        });
      }
    }
  }
}