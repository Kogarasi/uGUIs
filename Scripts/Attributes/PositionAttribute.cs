using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uGUIs.Attribute {
  
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class PositionAttribute : System.Attribute {
    public Vector3 position;

    public PositionAttribute(float x, float y){
      position = new Vector3(x, y, 0);
    }
  }
}