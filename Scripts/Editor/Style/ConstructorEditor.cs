using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace uGUIs.Editor.Style {
  [CustomEditor(typeof(uGUIs.Style.Constructor))]
  public class ConstructorEditor : UnityEditor.Editor {
    public override void OnInspectorGUI(){
      base.OnInspectorGUI();
    }
  }
}