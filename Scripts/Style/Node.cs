using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uGUIs.Style {
  public class Node : MonoBehaviour {
    public Element.Element[] getElements(){
      return GetComponents<Element.Element>();
    }
  }
}