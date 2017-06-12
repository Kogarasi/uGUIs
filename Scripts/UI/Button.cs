using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace uGUIs.UI {
  public class Button : UI<UnityEngine.UI.Button> {

    [Attribute.Alignment(TextAnchor.MiddleCenter)]
    [Attribute.Anchor(0,0,1,1)]
    [Attribute.Color(0,0,0,1)]
    [Attribute.Size(0,0)]
    Text innerText;

    public override void init(FieldInfo fieldInfo, Transform parent){
      base.init(fieldInfo, parent);

      var textAttr = Util.Attribute.getAttributes<Attribute.TextAttribute>(fieldInfo);
      if(textAttr.Any()){
        creataText(textAttr.First().text);
      }
    }

    public override UnityEngine.UI.Button create(string name, Transform parent){
      var button = base.create(name, parent);
      var image = button.gameObject.AddComponent<Image>();
      button.image = image;

      return button;
    }

    void creataText(string text){
      var fieldinfo = typeof(Button).GetField("innerText", BindingFlags.NonPublic|BindingFlags.Instance);

      innerText = new Text();
      innerText.init(fieldinfo, ui.transform);
      innerText.setText(text);
    }
  }
}