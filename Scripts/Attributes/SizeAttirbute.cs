using System;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Field, AllowMultiple=false)]
  public class SizeAttribute : System.Attribute {
    public float width;
    public float height;

    public SizeAttribute(float width, float height){
      this.width = width;
      this.height = height;
    }
  }
}