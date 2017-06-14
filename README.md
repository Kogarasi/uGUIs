# uGUIs - uGUI Support Tools

uGUIを利用するのを便利にするツール群

* Auto Binding UI Components.

## How to use

### Basic

* Create UI Button from GameObject->UI->Button
* Attach this Script to Canvas Object

```csharp
using uGUIs.Attribute;

public class SampleCanvas: uGUIs.UI.Canvas {
  [Identifier(1)] // Set anything object for callback.
  uGUIs.UI.Button Button = new uGUIs.UI.Button(); // name-based binding.
  
  [Callback(typeof(uGUIs.UI.Button), 1] // 2nd Parameter is identifier.
  void onClickCallback(object identifier){
    Debug.Log("Clicked");
  }
}
```

### Advanced

1. use ui component in your code without Canvas Component
2. inherit-class for UI Components

