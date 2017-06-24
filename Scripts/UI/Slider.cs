using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using uGUIs.Attribute;
using uGUIs.Style.Element;

namespace uGUIs.UI {
  public class Slider : UI<Slider, UnityEngine.UI.Slider>, Interface.Callback {

    UnityAction<float> onValueChangedCallback;

    public void bind(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(Slider));
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

    [Connect(typeof(ColorTintElement))]
    void applyColorTintFont(ColorTintElement elem){
      ui.transition = Selectable.Transition.ColorTint;

      var colors = ui.colors;
      colors.normalColor = elem.normal;
      colors.highlightedColor = elem.highlighted;
      colors.pressedColor = elem.pressed;
      colors.disabledColor = elem.disabled;
      ui.colors = colors;
    }
  }
}