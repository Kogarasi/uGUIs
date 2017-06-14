using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace uGUIs.Style {

  [ExecuteInEditMode]
  public class Constructor : MonoBehaviour {

    Dictionary<string, Node> nodeIndex;

    void Awake(){
      var nodes = gameObject.GetComponentsInChildren<Node>();
      nodeIndex = nodes.ToDictionary(x=>x.gameObject.name, x=>x);
    }

    public void apply(UIBehaviour ui){
      var name = ui.gameObject.name;
      var classNames = name.Split('.');
      var useNodes = classNames.Skip(1).Select(x=>"."+x).Where(x=>nodeIndex.ContainsKey(x)).Select(x=>nodeIndex[x]);

      useNodes.ToList().ForEach(node=>node.getElements().ToList().ForEach(x=>Debug.Log(x.GetType().Name)));
    }
  }
}