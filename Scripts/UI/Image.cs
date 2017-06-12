using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using uGUIs.Attribute;

namespace uGUIs.UI {
  public class Image : UI<Image, UnityEngine.UI.Image> {

    [Connect(typeof(ColorAttribute))]
    public void applyColor(ColorAttribute attr){
      ui.color = attr.color;
    }

    [Connect(typeof(PositionAttribute))]
    public void applyPosition(PositionAttribute attr){
      var rect = ui.GetComponent<RectTransform>();
      rect.localPosition = attr.position;
    }

    [Connect(typeof(SizeAttribute))]
    public void applySize(SizeAttribute attr){
      var rect = ui.GetComponent<RectTransform>();
      rect.sizeDelta = attr.size;
    }

    [Connect(typeof(AnchorAttribute))]
    public void applyAnchor(AnchorAttribute attr){
      var rect = ui.GetComponent<RectTransform>();
      rect.anchorMin = attr.min;
      rect.anchorMax = attr.max;
    }
  }
}
