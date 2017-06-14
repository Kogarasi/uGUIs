using uGUIs.Attribute;

namespace uGUIs.UI {

  public class Text : UI<Text, UnityEngine.UI.Text> {
    public string value {
      set { setText(value); }
    }

    public void setText(string text){
      if(ui==null)return;
      ui.text = text;
    }
  }
}