using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using uGUIs.Attribute;
using uGUIs.Style.Element;

namespace uGUIs.UI {

  public class Button : UI<Button, UnityEngine.UI.Button>, Interface.Callback {

    [ObjectName("Text")]
    [Optional]
    Text innerText;

    UnityAction onClickCallback;

    public override void bindChild(Style.Style styleRoot){
      var fieldInfo = Util.Expression.getInfo<Button,FieldInfo>(c=>c.innerText);

      innerText = new Text();
      innerText.init(fieldInfo, ui, styleRoot);
    }

    public void bind(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(Button));
      if(callbackMethod != null){
        onClickCallback = ()=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier});
        };
        ui.onClick.AddListener(onClickCallback);
      }
    }

    public void unbind(){
      if(onClickCallback != null ){
        ui.onClick.RemoveListener(onClickCallback);
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

    [Connect(typeof(ImageElement))]
    void applyImage(ImageElement element){
      ui.GetComponent<UnityEngine.UI.Image>().sprite = element.sprite;
    }
  }
}