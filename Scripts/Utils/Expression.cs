using System;
using System.Linq.Expressions;
using System.Reflection;

namespace uGUIs.Util {
  public static class Expression {
    public static U getInfo<T,U>(Expression<Func<T,object>> exp) where T: class where U: MemberInfo{
      return ((MemberExpression)exp.Body).Member as U;
    }
  }
}