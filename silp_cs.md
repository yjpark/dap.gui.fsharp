# FABULOUS_CONTROL_BINDING_PROPERTY(type, valueType, key, defaultValue) #
```C#
public static BindableProperty ${key}Property =
    BindableProperty.Create("${key}", typeof(${valueType}), typeof(${type}), ${defaultValue});
```

# FABULOUS_CONTROL_BINDING_PROPERTY_MEMBER(type, valueType, key) #
```C#
public ${valueType} ${key} {
    get { return (${valueType})GetValue(${key}Property); }
    set { SetValue(${key}Property, value); }
}
```