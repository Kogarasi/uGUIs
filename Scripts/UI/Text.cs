using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uGUIs.UI {
  public class Text : UI<UnityEngine.UI.Text> {
    const string defaultFont = "Arial.ttf";

    public override void init(FieldInfo fieldInfo, Transform parent){
      base.init(fieldInfo, parent);

      var alignmentAttr = Util.Attribute.getAttributes<Attribute.AlignmentAttribute>(fieldInfo);
      if(alignmentAttr.Any()){
        ui.alignment = alignmentAttr.First().alignment;
      }

      var colorAttr = Util.Attribute.getAttributes<Attribute.ColorAttribute>(fieldInfo);
      if(colorAttr.Any()){
        ui.color = colorAttr.First().color;
      }

      var sizeAttr = Util.Attribute.getAttributes<Attribute.SizeAttribute>(fieldInfo);
      if(sizeAttr.Any()){
        var size = new Vector2(sizeAttr.First().width, sizeAttr.First().height);
        var rectTransform = ui.GetComponent<RectTransform>();
        rectTransform.sizeDelta = size;
      }

      var anchorAttr = Util.Attribute.getAttributes<Attribute.AnchorAttribute>(fieldInfo);
      if(anchorAttr.Any()){
        var rectTransform = ui.GetComponent<RectTransform>();
        rectTransform.anchorMin = anchorAttr.First().min;
        rectTransform.anchorMax = anchorAttr.First().max;
      }
    }

    public override UnityEngine.UI.Text create(string name, Transform parent){
      var text = base.create(name, parent);

      text.font = Resources.GetBuiltinResource<Font>(defaultFont);
      return text;
    }

    public void setText(string text){
      ui.text = text;
    }

    public void setColor(Color color){
      ui.color = color;
    }
  }
}