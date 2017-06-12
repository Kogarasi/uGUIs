using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using uGUIs.Attribute;

namespace uGUIs.UI {

  [Font("Arial.ttf", true)]
  public class Text : UI<Text, UnityEngine.UI.Text> {

    public override void init(FieldInfo fieldInfo, Transform parent){
      base.init(fieldInfo, parent);
    }
    
    public void setText(string text){
      ui.text = text;
    }

    [Connect(typeof(FontAttribute))]
    public void applyFont(FontAttribute attr){
      ui.font = attr.font;
    }

    [Connect(typeof(AlignmentAttribute))]
    public void applyAlignment(AlignmentAttribute attr){
      ui.alignment = attr.alignment;
    }

    [Connect(typeof(ColorAttribute))]
    public void applyColor(ColorAttribute attr){
      ui.color = attr.color;
    }

    [Connect(typeof(SizeAttribute))]
    public void applySize(SizeAttribute attr){
      var rect = ui.GetComponent<RectTransform>();
      rect.sizeDelta = attr.size;
    }

    [Connect(typeof(AnchorAttribute))]
    public void applyAnchor(AnchorAttribute attr){
      var rect = ui.GetComponent<RectTransform>();
      rect.anchorMin = attr.min;
      rect.anchorMax = attr.max;
    }
  }
}