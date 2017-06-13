using System.Reflection;
using UnityEngine;

using uGUIs.Attribute;

namespace uGUIs.UI {

  public class Button : UI<Button, UnityEngine.UI.Button> {

    [ObjectName("Text")]
    [Optional]
    Text innerText;

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent){
      base.init(fieldInfo, parent);

      bindCallback(parent);
    }

    [Connect(typeof(TextAttribute))]
    public void applyText(TextAttribute attr){
      bindText(attr.text);
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

    void bindText(string text){
      var fieldInfo = Util.Expression.getInfo<Button,FieldInfo>(c=>c.innerText);

      innerText = new Text();
      innerText.init(fieldInfo, ui);
      innerText.setText(text);
    }

    void bindCallback(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(Slider));
      if(callbackMethod != null){
        ui.onClick.AddListener(()=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier});
        });
      }
    }

  }
}