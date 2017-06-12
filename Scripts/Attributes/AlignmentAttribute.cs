using System;
using UnityEngine;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class AlignmentAttribute : System.Attribute {
    public TextAnchor alignment;

    public AlignmentAttribute(TextAnchor alignment){
      this.alignment = alignment;
    }
  }
}