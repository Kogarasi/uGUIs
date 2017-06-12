using System;
using UnityEngine;
using UnityEngine.UI;

namespace uGUIs.Attribute {

  [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
  public class ScalerAttribute : System.Attribute {
    public CanvasScaler.ScaleMode uiScaleMode { get; set; }
    public float referencePixelsPerUnit { get; set; }
    
    // ConstantPixelSize
    public float scaleFactor { get; set; }

    // ScaleWithScreenSize
    public float referenceWidth { get; set; }
    public float referenceHeight { get; set; }
    public CanvasScaler.ScreenMatchMode screenMatchMode { get; set; }
    public float matchWidthOrHeight { get; set; }

    // ConstantPhysicalSize
    public CanvasScaler.Unit physicalUnit { get; set; }
    public float fallbackScreenDPI { get; set; }
    public float defaultSpriteDPI { get; set; }

    public ScalerAttribute(){
      uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
      referencePixelsPerUnit = 100;

      referenceWidth = 800;
      referenceHeight = 600;
      screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
      matchWidthOrHeight = 0;

      physicalUnit = CanvasScaler.Unit.Points;
      fallbackScreenDPI = 96;
      defaultSpriteDPI = 06;
    }
  }
}