using System;
using UnityEngine;

using uGUIs.Extension;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class ColorAttribute : System.Attribute {
    public Color color;

    public ColorAttribute(Type type){
      var color = Activator.CreateInstance(type) as ColorBook.Color;
      this.color = color.toColor();
    }
  }
}