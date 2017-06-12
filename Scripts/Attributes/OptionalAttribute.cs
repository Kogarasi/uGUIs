using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uGUIs.Attribute {
  
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple=false)]
  public class OptionalAttribute : System.Attribute {
  }
}