using UnityEngine;

namespace uGUIs.Extension {
  public static class CanvasScaler {
    public static void apply(this UnityEngine.UI.CanvasScaler scaler, Attribute.ScalerAttribute attr){
      scaler.uiScaleMode = attr.uiScaleMode;
      scaler.referencePixelsPerUnit = attr.referencePixelsPerUnit;

      scaler.referenceResolution = new Vector2(attr.referenceWidth, attr.referenceHeight);
      scaler.screenMatchMode = attr.screenMatchMode;
      scaler.matchWidthOrHeight = attr.matchWidthOrHeight;

      scaler.physicalUnit = attr.physicalUnit;
      scaler.fallbackScreenDPI = attr.fallbackScreenDPI;
      scaler.defaultSpriteDPI = attr.defaultSpriteDPI;
    }
  }
}