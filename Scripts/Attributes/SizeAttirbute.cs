using System;
using UnityEngine;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class SizeAttribute : System.Attribute {
    public Vector2 size;

    public SizeAttribute(float width, float height){
      this.size = new Vector2(width, height);
    }
  }
}