using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using uGUIs.Attribute;
using uGUIs.Style.Element;

namespace uGUIs.UI {
  public class Toggle : UI<Toggle, UnityEngine.UI.Toggle> {

    [ObjectName("Label")]
    [Optional]
    Text innerText;

    UnityAction<bool> onValueChangedCallback;

    public override void bindChild(Style.Style styleRoot){
      var fieldInfo = Util.Expression.getInfo<Toggle,FieldInfo>(c=>c.innerText);

      innerText = new Text();
      innerText.init(fieldInfo, ui, styleRoot);
    }

    public void bind(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(Toggle));
      if(callbackMethod != null){
        onValueChangedCallback = (isOn)=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier, isOn});
        };

        ui.onValueChanged.AddListener(onValueChangedCallback);
      }
    }

    public void unbind(){
      if(onValueChangedCallback != null){
        ui.onValueChanged.RemoveListener(onValueChangedCallback);
      }
    }

    [Connect(typeof(ColorElement))]
    void applyTextColor(ColorElement elem){
      innerText.ui.color = elem.color;
    }
    
    [Connect(typeof(FontElement))]
    void applyTextFont(FontElement elem){
      innerText.ui.font = elem.font;
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