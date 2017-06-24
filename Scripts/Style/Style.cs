using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace uGUIs.Style {

  public class Style : MonoBehaviour {
    public IEnumerable<Node> getCompatibleNode(string name) {
      var nodes = gameObject.GetComponentsInChildren<Node>();
      var index = nodes.ToDictionary(x=>x.gameObject.name, x=>x);

      var classNames = name.Split('.');
      return classNames.Skip(1).Select(x=>"."+x).Where(x=>index.ContainsKey(x)).Select(x=>index[x]);
    }
  }
}