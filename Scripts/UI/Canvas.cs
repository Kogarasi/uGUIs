using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Extension;

namespace uGUIs.UI {

  [ExecuteInEditMode]
  public class Canvas : MonoBehaviour {
    public Style.Constructor styleRoot;

    UnityEngine.Canvas canvas;

    void Awake(){
      setupCanvas();
      setupScaler();

      initUI();
    }

    void Update(){
      if(runInEditMode){
        initUI();
      }
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
      var uiInfo = fields.Where((x)=>typeof(UIBase).IsAssignableFrom(x.FieldType));

      uiInfo.ToList().ForEach((x)=>{
        var ui = x.GetValue(this) as UIBase;
        ui.init(x, this, styleRoot);
      });
    }

    T getAttribute<T>() where T:System.Attribute {
      return Util.Attribute.getAttribute<T>(this.GetType());
    }
  }
}