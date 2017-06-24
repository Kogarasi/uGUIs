using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace uGUIs.Editor.Style {
  [CustomEditor(typeof(uGUIs.Style.Style))]
  public class StyleEditor : UnityEditor.Editor {
    public override void OnInspectorGUI(){
      base.OnInspectorGUI();
    }
  }
}