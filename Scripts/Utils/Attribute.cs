using System;
using System.Reflection;

namespace uGUIs.Util{
  public static class Attribute {
    public static T getAttribute<T>(Type t) where T: System.Attribute {
      return System.Attribute.GetCustomAttribute(t, typeof(T)) as T;
    }

    public static T[] getAttributes<T>(FieldInfo fi){
      return fi.GetCustomAttributes(typeof(T), false) as T[];
    }
  }
}