# uGUIs - uGUI Support Tools

uGUIを利用するのを便利にするツール群

* Auto Binding UI Components.
* Attribute-base Styling Feature.

## How to use

### Basic

* Create UI Button from GameObject->UI->Button
* Attach this Script to Canvas Object

```
[uGUIs.Attribute.ObjectName("Canvas")]
public class SampleCanvas: uGUIs.UI.Canvas<SampleCanvas> {
  [uGUIs.Attribute.Size(300,300)]
  uGUIs.UI.Button Button = new uGUIs.UI.Button(); // name-based binding.
}
```

### Advanced

1. together your code without Canvas Component
2. inherited-class for UI Components

