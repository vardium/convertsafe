## ConvertSafe

Safe version of System.Convert, also includes Enum and generic type conversion. 
No exceptions thrown.

## Problem
//TODO : 

## Solution
//TODO : 

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

