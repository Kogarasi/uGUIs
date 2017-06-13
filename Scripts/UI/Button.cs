using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

using uGUIs.Attribute;

namespace uGUIs.UI {

  public class Button : UI<Button, UnityEngine.UI.Button> {
    object identifier;
    UnityAction callback;

    [ObjectName("Text")]
    [Optional]
    Text innerText;

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent){
      base.init(fieldInfo, parent);

      bindCallback(parent);
    }

    [Connect(typeof(IdentifierAttribute))]
    public void applyIdentifier(IdentifierAttribute attr){
      identifier = attr.identifier;
    }

    [Connect(typeof(PositionAttribute))]
    public void applyPosition(PositionAttribute attr){
      var rect = ui.GetComponent<RectTransform>();
      rect.localPosition = attr.position;
    }
    
    [Connect(typeof(SizeAttribute))]
    public void applySize(SizeAttribute attr){
      var rect = ui.GetComponent<RectTransform>();
      rect.sizeDelta = attr.size;
    }

    [Connect(typeof(TextAttribute))]
    public void applyText(TextAttribute attr){
      bindText(attr.text);
    }

    void bindText(string text){
      var fieldInfo = Util.Expression.getInfo<Button,FieldInfo>(c=>c.innerText);

      innerText = new Text();
      innerText.init(fieldInfo, ui);
      innerText.setText(text);
    }

    void bindCallback(MonoBehaviour parent){
      var type = parent.GetType();
      var methods = type.GetMethods();
      var attributeType = typeof(CallbackAttribute);

      var callbackMethod = methods.Where((x)=>{
        var attributes = x.GetCustomAttributes(attributeType, false) as CallbackAttribute[];
        if(attributes.Any()){

          return typeof(Button).IsAssignableFrom(attributes.First().type) && this.identifier.Equals(attributes.First().identifier);
        } else {
          return false;
        }
      }).FirstOrDefault();

      if(callbackMethod != null){
        callback = ()=>{
          callbackMethod.Invoke(parent, new object[]{this.identifier});
        };
        ui.onClick.AddListener(callback);
      }
    }
  }
}