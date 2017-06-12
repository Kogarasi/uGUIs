using System;
using UnityEngine;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
  public class ColorAttribute : System.Attribute {
    public Color color;

    public ColorAttribute(float red, float green, float blue, float alpha){
      this.color = new Color(red, green, blue, alpha);
    }
  }
}