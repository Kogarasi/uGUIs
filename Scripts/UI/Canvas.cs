using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Extension;

namespace uGUIs.UI {

  //[ExecuteInEditMode]
  public class Canvas<T> : MonoBehaviour where T: Canvas<T> {
    public UnityEngine.Canvas canvas;

    void Awake(){
      setupCanvas();
      setupScaler();

      scanUI();
    }

    void setupCanvas(){
      canvas = GetComponent<UnityEngine.Canvas>();

      var renderModeAttr = getAttribute<Attribute.RenderModeAttribute>();
      if(renderModeAttr != null){
        canvas.renderMode = renderModeAttr.renderMode;
      }

      var sortOrderAttr = getAttribute<Attribute.SortOrderAttribute>();
      if(sortOrderAttr != null){
        canvas.sortingOrder = sortOrderAttr.order;
      }
    }

    void setupScaler(){
      var scalerComponent = canvas.GetComponent<UnityEngine.UI.CanvasScaler>();
      var scalerAttr = Util.Attribute.getAttribute<Attribute.ScalerAttribute>(this.GetType());

      scalerComponent.apply(scalerAttr);
    }

    void scanUI(){
      var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      var fields = typeof(T).GetFields(flags);
      var uiInfo = fields.Where((x)=>typeof(UIBase).IsAssignableFrom(x.FieldType));

      uiInfo.ToList().ForEach((x)=>{
        var ui = x.GetValue(this) as UIBase;
        ui.init(x, this);
      });
    }

    T getAttribute<T>() where T:System.Attribute {
      return Util.Attribute.getAttribute<T>(this.GetType());
    }
  }
}