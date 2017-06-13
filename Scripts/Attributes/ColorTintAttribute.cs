using System;
using UnityEngine;

using uGUIs.Extension;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class ColorTintAttribute : System.Attribute {
    public Type normal { get; set; }
    public Type highlighted { get; set; }
    public Type pressed { get; set; }
    public Type disabled { get; set; }

    public Color getNormalColor(){
      return convertColor(normal);
    }

    public Color getHighlightedColor(){
      return convertColor(highlighted);
    }

    public Color getPressedColor(){
      return convertColor(pressed);
    }

    public Color getDisabledColor(){
      return convertColor(disabled);
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