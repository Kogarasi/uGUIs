using System;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class IdentifierAttribute : System.Attribute {
    public object identifier;

    public IdentifierAttribute(object identifier){
      this.identifier = identifier;
    }
  }
}