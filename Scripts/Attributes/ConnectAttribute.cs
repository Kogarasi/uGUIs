using System;
using System.Linq.Expressions;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
  public class ConnectAttribute : System.Attribute {
    public Type type;

    public ConnectAttribute(Type type){
      this.type = type;
    }
  }
}