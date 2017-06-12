using System;

namespace uGUIs.Attribute {
  
  [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
  public class SortOrderAttribute: System.Attribute {
    public int order;

    public SortOrderAttribute(int order){
      this.order = order;
    }
  }
}