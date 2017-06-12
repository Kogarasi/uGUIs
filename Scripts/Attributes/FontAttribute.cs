using System;
using UnityEngine;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class FontAttribute : System.Attribute {
    public Font font;

    public FontAttribute(string fontName, bool isBuiltin=false){
      if(isBuiltin){
        this.font = Resources.GetBuiltinResource<Font>(fontName);
      } else {
        this.font = Resources.Load<Font>(fontName);
      }
    }
  }
}