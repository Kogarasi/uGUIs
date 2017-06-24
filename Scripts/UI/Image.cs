using uGUIs.Attribute;
using uGUIs.Style.Element;

namespace uGUIs.UI {
  public class Image : UI<Image, UnityEngine.UI.Image> {
    [Connect(typeof(ColorElement))]
    void applyTextColor(ColorElement elem){
      ui.color = elem.color;
    }

    [Connect(typeof(ImageElement))]
    void applyImage(ImageElement elem){
      ui.sprite = elem.sprite;
    }
  }
}
