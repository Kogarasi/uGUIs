using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

using uGUIs.Attribute;

namespace uGUIs.UI {
  public class Toggle : UI<Toggle, UnityEngine.UI.Toggle> {

    [ObjectName("Label")]
    [Optional]
    Text innerText;

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent, Style.Constructor styleRoot){
      base.init(fieldInfo, parent, styleRoot);

      bindCallback(parent);
    }

    public override void bindChild(Style.Constructor styleRoot){
      var fieldInfo = Util.Expression.getInfo<Toggle,FieldInfo>(c=>c.innerText);

      innerText = new Text();
      innerText.init(fieldInfo, ui, styleRoot);
    }

    void bindCallback(MonoBehaviour parent){
      var callbackMethod = getCallbackMethod(parent, typeof(Toggle));
      if(callbackMethod != null){
        ui.onValueChanged.AddListener((isOn)=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier, isOn});
        });
      }
    }
  }
}