using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Extension;

namespace uGUIs.UI {

  [ExecuteInEditMode]
  public class Canvas : MonoBehaviour {
    public Style.Style styleRoot;

    UnityEngine.Canvas canvas;
    List<FieldInfo> uiInfo;

    void Awake(){
      setupCanvas();
      setupScaler();

      initUI();
    }

    [Conditional("UNITY_EDITOR")]
    void Update(){
      if(!Application.isPlaying){
        initUI();
      }
    }

    void OnDestroy(){
      deinitUI();
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

    void initUI(){
      var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      var fields = this.GetType().GetFields(flags);
      uiInfo = fields.Where((x)=>typeof(UIBase).IsAssignableFrom(x.FieldType)).ToList();

      uiInfo.ForEach((x)=>{
        var ui = x.GetValue(this) as UIBase;
        ui.init(x, this, styleRoot);
      });
    }

    void deinitUI(){
      if(uiInfo == null){
        return;
      }

      uiInfo.ForEach((x)=>{
        var ui = x.GetValue(this) as UIBase;
        ui.deinit();
      });
    }

    T getAttribute<T>() where T:System.Attribute {
      return Util.Attribute.getAttribute<T>(this.GetType());
    }
  }
}