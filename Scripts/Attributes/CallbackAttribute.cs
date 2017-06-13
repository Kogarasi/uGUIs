using System;
using System.Reflection;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
  public class CallbackAttribute : System.Attribute {
    public Type type;
    public object identifier;

    public CallbackAttribute(Type type, object identifier){
      this.type = type;
      this.identifier = identifier;
    }
  }
}