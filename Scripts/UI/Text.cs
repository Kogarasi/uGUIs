using uGUIs.Attribute;
using uGUIs.Style.Element;

namespace uGUIs.UI {

  public class Text : UI<Text, UnityEngine.UI.Text> {
    public string value {
      set { setText(value); }
    }

    public void setText(string text){
      if(ui==null)return;
      ui.text = text;
    }

    [Connect(typeof(ColorElement))]
    void applyTextColor(ColorElement elem){
      ui.color = elem.color;
    }
    [Connect(typeof(FontElement))]
    void applyTextFont(FontElement elem){
      ui.font = elem.font;
    }

  }
}