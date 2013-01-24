## ConvertSafe

Safe version of System.Convert, also includes Enum and generic type conversion. 
No exceptions thrown.

## Problem
It is always a problem converting incoming parameters, especially in web programming. 
While reading value from a textbox, or from querystring you can never trust the user. 
So, to read a parameter you should first check if it can be converted to needed type. 
Same problem occurs on converting object to generic types.

## Solution
ConvertSafe converts the given parameter to needed type without throwing any exceptions, but gives the default value
of the type, or optionally second parameter as the default value.

## usage

To integer
```
int i = ConvertSafe.ToInt("123");
```

To Boolean
```
bool b = ConvertSafe.ToBoolean("true");
```

With default value
```
int i = ConvertSafe.ToInt(myTextBox.Text, -1);
```

Convert to Enum
```
string obj = "TEST";
MyEnum e = ConvertSafe.ToGeneric(obj, MyEnum.DEFAULT_VALUE);
```

