using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using uGUIs.Attribute;

namespace uGUIs.UI {

  public class Text : UI<Text, UnityEngine.UI.Text> {
    
    public void setText(string text){
      if(ui==null)return;
      ui.text = text;
    }

    [Connect(typeof(FontAttribute))]
    public void applyFont(FontAttribute attr){
      ui.font = attr.font;
    }

    [Connect(typeof(FontSizeAttribute))]
    public void applyFontSize(FontSizeAttribute attr){
      ui.fontSize = attr.size;
    }

    [Connect(typeof(AlignmentAttribute))]
    public void applyAlignment(AlignmentAttribute attr){
      ui.alignment = attr.alignment;
    }

    [Connect(typeof(ColorAttribute))]
    public void applyColor(ColorAttribute attr){
      ui.color = attr.color;
    }
  }
}