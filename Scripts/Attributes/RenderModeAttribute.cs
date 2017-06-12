using System;
using UnityEngine;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
  public class RenderModeAttribute : System.Attribute {
    public RenderMode renderMode;

    public RenderModeAttribute(RenderMode renderMode){
      this.renderMode = renderMode;
    }
  }
}