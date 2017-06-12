using System;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class TextAttribute: System.Attribute {
    public string text;

    public TextAttribute(string text){
      this.text = text;
    }
  }
}