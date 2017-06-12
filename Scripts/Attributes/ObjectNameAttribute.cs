using System;

namespace uGUIs.Attribute {
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class ObjectNameAttribute : System.Attribute {
    public string name;

    public ObjectNameAttribute(string name){
      this.name = name;
    }
  }
}