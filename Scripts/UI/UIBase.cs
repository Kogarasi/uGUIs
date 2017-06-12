using System.Reflection;
using UnityEngine;

namespace uGUIs.UI{
  public abstract class UIBase {
    public abstract void init(FieldInfo fieldInfo, Transform parent);
  }
}