using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Attribute;

namespace uGUIs.UI {

  [Text("Button")]
  [Size(160,30)]
  public class Button : UI<Button, UnityEngine.UI.Button> {

    [Alignment(TextAnchor.MiddleCenter)]
    [Anchor(0,0,1,1)]
    [Color(0,0,0,1)]
    [Size(0,0)]
    [ObjectName("Text")]
    Text innerText;

    public override UnityEngine.UI.Button create(string name, Transform parent){
      var button = base.create(name, parent);
      var image = button.gameObject.AddComponent<UnityEngine.UI.Image>();
      button.image = image;

      return button;
    }

    void creataText(string text){
      var fieldinfo = typeof(Button).GetField("innerText", BindingFlags.NonPublic|BindingFlags.Instance);

      innerText = new Text();
      innerText.init(fieldinfo, ui.transform);
      innerText.setText(text);
    }

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
      creataText(attr.text);
    }
  }
}