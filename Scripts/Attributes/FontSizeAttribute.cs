using System;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class FontSizeAttribute : System.Attribute {
    public int size;

    public FontSizeAttribute(int size){
      this.size = size;
    }
  }
}