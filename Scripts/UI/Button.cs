using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Attribute;

namespace uGUIs.UI {

  public class Button : UI<Button, UnityEngine.UI.Button> {

    [ObjectName("Text")]
    [Optional]
    Text innerText;

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent, Style.Constructor styleRoot){
      base.init(fieldInfo, parent, styleRoot);

      bindCallback(parent);
    }

    public override void bindChild(Style.Constructor styleRoot){
      var fieldInfo = Util.Expression.getInfo<Button,FieldInfo>(c=>c.innerText);

      innerText = new Text();
      innerText.init(fieldInfo, ui, styleRoot);
    }

    void bindCallback(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(Button));
      if(callbackMethod != null){
        ui.onClick.AddListener(()=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier});
        });
      }
    }

  }
}