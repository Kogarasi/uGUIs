using System.Reflection;
using UnityEngine;

using uGUIs.Attribute;

namespace uGUIs.UI {
  public class Slider : UI<Slider, UnityEngine.UI.Slider> {

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent){
      base.init(fieldInfo, parent);

      bindCallback(parent);
    }

    [Connect(typeof(ColorTintAttribute))]
    public void applyColorTint(ColorTintAttribute attr){
      var colors = ui.colors;
      colors.normalColor = attr.getNormalColor();
      colors.highlightedColor = attr.getHighlightedColor();
      colors.pressedColor = attr.getPressedColor();
      colors.disabledColor = attr.getDisabledColor();

      ui.colors = colors;
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