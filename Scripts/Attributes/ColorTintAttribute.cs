using System;
using UnityEngine;

using uGUIs.Extension;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class ColorTintAttribute : System.Attribute {
    public Type normalColor { get; set; }
    public Type highlightedColor { get; set; }
    public Type pressedColor { get; set; }
    public Type disabledColor { get; set; }

    public Color getNormalColor(){
      return convertColor(normalColor);
    }

    public Color getHighlightedColor(){
      return convertColor(highlightedColor);
    }

    public Color getPressedColor(){
      return convertColor(pressedColor);
    }

    public Color getDisabledColor(){
      return convertColor(disabledColor);
    }

    Color convertColor(Type type){
      if(type==null){
        type = typeof(ColorBook.White);
      }

      var color = Activator.CreateInstance(type) as ColorBook.Color;
      return color.toColor();
    }
  }
}