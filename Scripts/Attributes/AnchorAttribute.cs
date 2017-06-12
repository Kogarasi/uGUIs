using System;
using UnityEngine;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class AnchorAttribute : System.Attribute {
    public Vector2 min;
    public Vector2 max;

    public AnchorAttribute(float minX, float minY, float maxX, float maxY){
      this.min = new Vector2(minX, minY);
      this.max = new Vector2(maxX, maxY);
    }
  }
}