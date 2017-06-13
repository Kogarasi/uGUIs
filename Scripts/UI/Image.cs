using uGUIs.Attribute;

namespace uGUIs.UI {
  public class Image : UI<Image, UnityEngine.UI.Image> {

    [Connect(typeof(ColorAttribute))]
    public void applyColor(ColorAttribute attr){
      ui.color = attr.color;
    }
  }
}
