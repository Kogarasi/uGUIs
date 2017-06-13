using System;
using System.Reflection;
using UnityEngine;

using uGUIs.Extension;

namespace uGUIs.Attribute {
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class OutlineAttribute : System.Attribute {
    public Color color;
    public Vector2 distance;

    public OutlineAttribute(Type colorType, float x, float y){
      var color = Activator.CreateInstance(colorType) as ColorBook.Color;
      this.color = color.toColor();

      this.distance = new Vector2(x,y);
    }
  }
}