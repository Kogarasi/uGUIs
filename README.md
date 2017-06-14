# uGUIs - uGUI Support Tools

## What's this?

uGUIs is useful plugin for uGUI.

### Feature

* Auto Binding UI.
* Dynamic Styling UI.

## How to use

### Auto-Binding

* Create UI Button from GameObject->UI->Button
* Attach this Script to Canvas Object

```csharp
using uGUIs.Attribute;

public class SampleCanvas: uGUIs.UI.Canvas {

  [Identifier(1)] // all types supported.
  uGUIs.UI.Button Button = new uGUIs.UI.Button();
  
  [Callback(typeof(uGUIs.UI.Button), 1]
  void onClick(int identifier){
    Debug.Log(identifier); // display "1"
  }
}
```
