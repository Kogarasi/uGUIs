using System.Reflection;
using UnityEngine;

namespace uGUIs.UI{
  public abstract class UIBase {
    public abstract void init(FieldInfo fieldInfo, MonoBehaviour parent, Style.Style styleRoot);
    public abstract void deinit();
    public abstract void bindChild(Style.Style styleRoot);
  }
}