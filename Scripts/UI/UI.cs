using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using uGUIs.Attribute;

namespace uGUIs.UI {
  public class UI<T,U>: UIBase where T: UI<T,U> where U: UIBehaviour {
    public U ui;
    protected object identifier;

    public override void init(FieldInfo fieldInfo, MonoBehaviour parent, Style.Constructor styleRoot){
      var name = getObjectName(fieldInfo);

      var components = parent.gameObject.GetComponentsInChildren<U>();
      ui = components.FirstOrDefault(x=>x.gameObject.name.Split('.').First() == name);
      if(ui == null){
        var optional = Util.Attribute.getAttributes<Attribute.OptionalAttribute>(fieldInfo);
        if(!optional.Any()){
          throw new Exception("Can't find GameObject(" + name + ")");
        }
      }
      
      bindChild(styleRoot);

      applyStyle(styleRoot);
      applyAttribute(fieldInfo);
    }

    public override void bindChild(Style.Constructor styleRoot){}

    string getObjectName(FieldInfo fieldInfo){
      var name = fieldInfo.Name;
      var classAttr = Util.Attribute.getAttribute<Attribute.ObjectNameAttribute>(typeof(T));
      if(classAttr != null){
        name = classAttr.name;
      }

      var fieldAttr = Util.Attribute.getAttributes<Attribute.ObjectNameAttribute>(fieldInfo);
      if(fieldAttr.Any()){
        name = fieldAttr.First().name;
      }

      return name;      
    }

    void applyStyle(Style.Constructor root){
      if(root==null){
        return;
      }

      var connectMethods = getConnectMethods();

      var nodes = root.getCompatibleNode(ui.gameObject.name);
      var elements = nodes.SelectMany(x=>x.getElements());

      elements.Where(x=>connectMethods.ContainsKey(x.GetType()))
      .ToList().ForEach(x=>connectMethods[x.GetType()].Invoke(this, new object[]{x}));
    }

    void applyAttribute(FieldInfo fieldInfo){
      var connectMethods = getConnectMethods();

      var classAttributes = typeof(T).GetCustomAttributes(false) as System.Attribute[];
      var fieldAttributes = fieldInfo.GetCustomAttributes(false) as System.Attribute[];
      var attributes = classAttributes.Concat(fieldAttributes);

      attributes.Where(x=>connectMethods.ContainsKey(x.GetType()))
      .ToList().ForEach(x=>connectMethods[x.GetType()].Invoke(this, new object[]{x}));

    }

    Dictionary<Type, MethodInfo> getConnectMethods(){
      var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      var methods = typeof(T).GetMethods(flags);
      var connectType = typeof(Attribute.ConnectAttribute);

      return methods.Where(x=>x.GetCustomAttributes(connectType, true).Any())
      .Select(x=> new { method = x, attr = x.GetCustomAttributes(connectType, true).First() as Attribute.ConnectAttribute })
      .ToDictionary(x=>x.attr.type, x=>x.method);
    }    

    protected MethodInfo getCallbackMethod(MonoBehaviour parent, Type uiType){
      var flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
      var type = parent.GetType();
      var methods = type.GetMethods(flags);
      var attributeType = typeof(CallbackAttribute);

      return methods.Where((x)=>{
        var attributes = x.GetCustomAttributes(attributeType, false) as CallbackAttribute[];
        if(attributes.Any()){
          return uiType.IsAssignableFrom(attributes.First().type) && this.identifier.Equals(attributes.First().identifier);
        } else {
          return false;
        }
      }).FirstOrDefault();
    }

    [Connect(typeof(IdentifierAttribute))]
    public void applyIdentifier(IdentifierAttribute attr){
      identifier = attr.identifier;
    }
  }
}