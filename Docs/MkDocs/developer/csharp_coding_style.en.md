# C\# Coding Style

As an open-source simulator project welcomes community contribution, setting up the coding style for Tactics at the very beginning can help to guarantee readability and maintainability. Tactics project customs its coding style based on [Microsoft's C\# coding convention](https://learn.microsoft.com/zh-cn/dotnet/csharp/fundamentals/coding-style/coding-conventions). The detailed coding style is as follows.

## Naming

## Layout

## Commenting

- Place the comment on a separate line, not at the end of a line of code.
- Begin comment text with an uppercase letter.
- End comment text with a period.
- Insert one space between the comment delimiter (//) and the comment text.

Tactics project uses [special commands from Doxygen](https://doxygen.nl/manual/commands.html) to help generate the development document automatically. The commands are preferred to start with `@` sign.

The minimalist information that should be put at the beginning of every file is as follows

```csharp
/**
 * @file FileName.cs
 * @brief A brief description of the file.
 * @author Contributor's name. One file can have multiple contributors.
 * @date The last modified date
 * @copyright GNU Public License
 */
```

Except 
If you don't want Doxygen to detect the in-function comments, please use `//` to start the comment line.

```csharp
/**
 * @class GraphicsSetting
 * @brief Controls the graphics settings including full-screen, vSync, resolution, quality, and FPS.
 */
public class GraphicsSetting : MonoBehaviour
{
    /// The toggle for the full screen option.
    [SerializeField] private Toggle fullScreenToggle;
    ...

    void Start ()
    {
        // Initialize the full screen option from the player's preference.
        // If the player has not set the option, set it to full screen.
        if (PlayerPrefs.HasKey("FullScreen"))
        {
            LoadFullScreen();
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 1);
            SetFullScreen();
        }
    }
        
    /// @fn SetFullScreen
    /// @brief Immediately sets the screen to full screen or windowed mode and updates 
    /// the setting to the player's preference.
    /// @details The corresponding key is "FullScreen".
    public void SetFullScreen ()
    {
        Screen.fullScreenMode = fullScreenToggle.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
        PlayerPrefs.SetInt("FullScreen", fullScreenToggle.isOn ? 1 : 0);
    }
    ...
}
```