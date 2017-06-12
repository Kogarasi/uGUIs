using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Attribute;

namespace uGUIs.UI {

  public class Button : UI<Button, UnityEngine.UI.Button> {

    [ObjectName("Text")]
    [Optional]
    Text innerText;

    [Connect(typeof(PositionAttribute))]
    public void applyPosition(PositionAttribute attr){
      var rect = ui.GetComponent<RectTransform>();
      rect.localPosition = attr.position;
    }
    
    [Connect(typeof(SizeAttribute))]
    public void applySize(SizeAttribute attr){
      var rect = ui.GetComponent<RectTransform>();
      rect.sizeDelta = attr.size;
    }

    [Connect(typeof(TextAttribute))]
    public void applyText(TextAttribute attr){
      bindText(attr.text);
    }

    void bindText(string text){
      var fieldinfo = typeof(Button).GetField("innerText", BindingFlags.NonPublic|BindingFlags.Instance);

      innerText = new Text();
      innerText.init(fieldinfo, ui.transform);
      innerText.setText(text);
    }
  }
}