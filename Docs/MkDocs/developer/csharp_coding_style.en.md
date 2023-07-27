# C\# Coding Style

As an open-source project, setting up the coding style for Tactics at the very beginning can help to guarantee the readability and maintainability of code. Tactics project customs its coding style based on [Microsoft's C\# coding convention](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). The detailed coding style is as follows.

## Naming Conventions

In Tactics, the naming conventions of **the variable** are consistent with [Microsoft's C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). Here are the makeup rules for details.

### Naming of files and folders

Please use CamelCase to name files and folders related to C\# language.

### Prefix

- Abbreviations with only two letters like `UI` and `ID` should be treated specially. When using PascalCase, they should be written in all capital letters (e.g., `UIElement`, `IDCard`). When using camelCase, they should be written in all lowercase letters (e.g., `uiElement`, `idCard`).
- It is generally not recommended to use type names as prefixes for identifiers, for example, `string strText` or `float fPower`. However, interfaces are an exception to this rule. Interface names should have a capital letter `I` as a prefix, for example, `IInventoryHolder` or `IDamageable`.

### Variable name

- Class names should be nouns or noun phrases.
- Method names should be verb-object/preposition phrases.
- Boolean variables should start with a lowercase prepositional phrase to indicate their logical type.
- When variable names are less than 20 characters, there is no need to abbreviate any words in the name.

## Layout Conventions

In Tactics, the layout conventions are consistent with [Microsoft's C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). Here are the makeup rules for details.

### Order of `using`

The imported namespaces should be arranged in alphabetical order, which can help identify the target namespace among multiple imports quickly and easily.

### Layout of braces

Please follow [Allman's style]((https://en.wikipedia.org/wiki/Indentation_style#Allman_style)) to arrange the braces. A single line statement block can go without braces but the block must be properly indented on its own line and must not be nested in other statement blocks that use braces.

### Indentation

Use **four spaces** for indentation instead of tabs (soft tabs).

### Line breaks

If a single line of code exceeds 90 characters, consider breaking it into multiple lines. The line break rules are prioritized as follows; however, if following a rule would result in confusing code, feel free to adopt a more flexible approach to line breaks:

- Break the line after a comma.
- Break the line before an operator.

Use the line feed character `LF` for line breaks, not `CRLF` or `CR`.

### Space line

Insert two blank lines in the following cases:

- Between the interface and class definitions when they are in the same file.
- Between the enum and class definitions when they are in the same file.
- Between multiple class definitions when they are in the same file.

Insert one blank line in the following cases:

- After a `using` block.
- Between method, property, and inner type declarations.
- Between different logical blocks within a method.
- At the end of each file.

Field declarations and constant declarations can be grouped together based on relevance. In such cases, consider inserting blank lines between the groups to enhance readability.

Avoid inserting blank lines in the following cases:

- Immediately after an opening brace `{` or `(`.
- Immediately before a closing brace `}` or `)`.
- Immediately after a block of comments or single-line comments.

### Spacing

Insert one space in the following cases:

- Around binary and ternary operators.
- Between left parentheses and keywords `if`, `for`, `foreach`, `catch`, `while`, `lock`, `using`.
- Before and inside single-line accessor blocks.
- Between accessors inside a single-line accessor block.
- After commas that are not at the end of a line.
- After semicolons in a `for` statement.
- After colons in single-line case statements.
- Around colons in type declarations.
- After the single-line comment symbol `//`.

Do not insert spaces in the following cases:

- After type-casting parentheses.
- Inside single-line initialization parentheses.

## Commenting conventions

In Tactics, the commenting conventions are consistent with [Microsoft's C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). Here are the makeup rules for details.

### File header

Tactics project uses [special commands from Doxygen](https://doxygen.nl/manual/commands.html) to help generate the development document automatically. The commands are preferred to start with `@` sign.

At the beginning of every script file, the following information should be included before defining any classes or functions:

```csharp
/**
  * @file [FileName].cs
  * @brief [A brief description of the file.]
  * @author [Contributor's name. Write an author per line. Every line should start with @author]
  * @version 0.0.0
  * @date [The last modified date]
  * @copyright GNU Public License
  */
```

### Function header

At the beginning of every class or function, besides the basic functions in Unity like `Start()` and `Update()`, the following information should be included:

```csharp
/// @class ExampleClass
/// @brief [Brief description of the class.]
public class ExampleClass
{
    /// @fn ExampleFunction
    /// @brief [Brief description of the function.]
    /// @param [Name, type, and brief description if necessary. Write one variable per line. 
    ///     If there is no input variable, this identifier can be ignored.]
    /// @return [Name, type, and brief description if necessary. Write one variable per line.
    ///     If there is no output variable, this identifier can be ignored.]
    public void ExampleFunction()
    {
        // Explain the codes that may be hard to understand.
    }
}
```

## Class Conventions

Regarding how to choose appropriate variable types based on their usage, please refer to the **Language Guidelines** section in [Microsoft's C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions). Here we provide additional explanations of common variable types used in Unity projects.

- `public`: Can be accessed both through the Unity editor and by other scripts.
- `[HideInInspector] public`: Cannot be accessed through the Unity editor but can be called by other scripts.
- `[SerializeField] private`: Can be accessed through the Unity editor but cannot be called by other scripts.
- `private`: Cannot be accessed through the Unity editor and cannot be called by other scripts.

When defining variables within a class, arrange them in the following order from top to bottom:

1. `public`
2. `protected`
3. `private`
4. The reserved methods in Unity, such as `void Start()`, sorted by their call time.
5. Other methods.

## Others

### File encoding

All the files should be encoded in **UTF-8**.

### File content

In general, a script should define only one class, interface, enumeration, or structure. In special cases, multiple class definitions can be included in the same `.cs` file, such as code generated by a code generator or two closely related classes. Additionally, class names should match the `.cs`` file names to facilitate finding class names through file names.
