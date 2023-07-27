# C\# 语言风格

作为一个开源项目，在开始之初确定一套编程约定有助于保证代码的可维护性和易读性。Tactics项目以[Microsoft的C\#编码约定](https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/coding-conventions)作为基础，并对部分细节进行了补全。具体的语言风格说明如下。

## 命名规范

Tactics对**变量名**的命名约定与[Microsoft的C\#编码约定](https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/coding-conventions)完全一致。以下是额外追加的规则：

### 文件和文件夹的命名

使用大驼峰命名**文件和文件夹**。

### 前缀

- 类似 `UI`、`ID` 这种只有两个字母的首字母缩写应特殊处理，使用大驼峰时都应写作大写字母，使用小驼峰时应写作小写字母。
- 通常不建议将类型名称用作标识符的前缀，例如 `string strText` 或 `float fPower`。但是，接口是个例外，应该在其名称前加上大写字母 `I`，例如 `IInventoryHolder` 或 `IDamageable`。

### 变量名称

- 类名应该是名词或者名词性短语；
- 方法名应该是动宾/介宾短语；
- 布尔变量由小写介词短语开头，表示逻辑类型；
- 当变量名小于20字符的时候，没有必要对名称中任何单词进行缩写。

## 布局规范

Tactics的布局规范与[Microsoft的C\#编码约定](https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/coding-conventions)完全一致。以下是额外追加的规则：

### `using` 排序

引入的命名空间应该按照字母音序排列，这样做的目的在于方便在引入的多个命名空间中直接快速的找到命名空间。

### 括号布局

括号布局请遵循[Allman风格](https://en.wikipedia.org/wiki/Indentation_style#Allman_style)。单行语句块可以省略大括号，但该块必须在自己的行上正确缩进，并且不能嵌套在其他使用大括号的语句块中。

### 缩进

使用 **四个空格** 代替制表符进行缩进（软制表符）。

### 换行

如果单行代码长度超过90个字符, 请考虑将其分成几行。换行规则按优先级排列如下，当规则会导致代码混乱的时，请自己采取更灵活的换行规则：

- 在逗号后换行；
- 在操作符前换行。

使用换行符 `LF` 来换行, 而不是 `CRLF` 或 `CR`。

### 空白行

**一般不需要超过一行的空白行。**

以下情况需要插入两行空行：

- 当接口和类定义在同一文件中时，接口和类的定义之间；
- 当枚举和类定义在同一文件中时，枚举和类的定义之间；
- 当多个类定义在同一文件中时，类与类的定义之间。

以下情况需要插入一行空行：

- 在 `using` 段落后；
- 在方法、属性、和内部类型声明之间；
- 方法中不同的逻辑块之间；
- 每个文件的末尾。

字段声明和常量声明可以根据相关性编组在一起。在这种情况下，请考虑在编组之间插入空白行以便于阅读。

以下情况请避免插入空白行：

- 在开括号 `{`，`(` 之后；
- 在闭括号 `}`，`)` 之前；
- 在注释块或单行注释之后。

### 空格

以下情况需要插入一个空格：

- 在二元和三元运算符的两侧；
- 在左括号和 `if`、`for`、`foreach`、`catch`、`while`、`lock`、`using`关键字之间；
- 在单行访问器块之前和之内；
- 在单行访问器块中的访问器之间；
- 在不是在行尾的逗号之后；
- 在 `for` 语句中的分号之后；
- 在单行 case 语句中的冒号之后；
- 在类型声明中的冒号周围；
- 在单行注释符号 `//` 之后。

以下情况不需要插入空格：

- 在类型转换括号后；
- 在单行初始化括号内侧。

## 注释规范

Tactics的注释规范与[Microsoft的C\#编码约定](https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/coding-conventions)完全一致。以下是额外追加的规则：

### 文件头

为了方便通过Doxygen直接生成文档，Tactics使用了[Doxygen的标识符系统](https://doxygen.nl/manual/commands.html)，偏好用 **@** 标识指令。

在每份文件开头至少应该包含以下注释信息：

```csharp
/**
  * @file [FileName].cs
  * @brief [Brief description of the file.]
  * @author [Contributor's name. Write an author per line. Every line should start with @author]
  * @version 0.0.0
  * @date [The last modified date]
  * @copyright GNU Public License
  */
```

### 函数注释

除了 `Start()`、`Update()` 等属于Unity基类的函数以外，每个类或函数的开头至少应该包含以下信息：

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

## 类型规范

关于如何根据用途选择合适的变量类型，请参考[Microsoft的C\#编码约定](https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/coding-conventions)中**语言准则**章节。这里补充一些Unity项目中常见变量类型的说明：

- `public`：既可以通过Unity编辑器访问，也可以被其他脚本调用；
- `[HideInInspector] public`：不能通过Unity编辑器访问，但可以被其他脚本调用；
- `[SerializeField] private`：可以通过Unity编辑器访问，但不能被其他脚本调用；
- `private`：既不能通过Unity编辑器访问，也不能被其他脚本调用；

在类中定义变量时，根据类型，变量自上而下按以下顺序排列：

1. `public`
2. `protected`
3. `private`
4. Unity保留方法，如 `void Start()`，按调用时间前后排序；
5. 方法

## 其他

### 文件编码

所有文件使用 **UTF-8** 编码。

### 文件内容

通常情况下，一个脚本只能定义一个类、接口、枚举、结构体。特殊情况可将多个类定义在同一 `.cs` 文件，如代码生成器生成的代码或紧密关联的两个类。此外，类名应该与 `.cs` 文件名保持一致，以便于通过文件名查找类名。
