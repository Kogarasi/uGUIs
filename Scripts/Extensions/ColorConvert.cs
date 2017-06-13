using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace uGUIs.Extension {
  public static class ColorConvert {
    public static UnityEngine.Color toColor(this uGUIs.ColorBook.Color color){
      return new UnityEngine.Color(color.red(), color.green(), color.blue(), color.alpha());
    }
  }
}