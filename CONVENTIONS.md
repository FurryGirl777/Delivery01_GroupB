## Unity C# Coding Style Conventions

Recommended to use the standard C# language [code conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions#style-guidelines). Here a small summary:

Code element | Convention | Example
--- | :---: | ---
Classes | TitleCase | `class Player`
`public` Fields | TitleCase | `public float Speed;`
`private` Fields | lowerCase | `private float targetFrameTime;`
Methods | TitleCase | `public Update()`, `private GetMaxHeight()`
Methods parameters | lowerCase | `width`, `height`
Constants | lowerCase | `const int maxValue = 8;`
`float` values | _Use always x.xf_ | `float gravity = 10.0f`
Operators | value1 * value2 | `int product = value * 6;`
Operators | value1 / value2 | `float division = value / 4.0f;`
Operators | value1 + value2 | `int sum = value + 10;`
Operators | value1 - value2 | `int res = value - 5;`
Enum | TitleCase | `enum GameScreen`
Enum members | TitleCase | `ScreenTitle`
Struct | TitleCase | `struct Material`
Ternary Operator | (condition)? result1 : result2 | `printf("Value is 0: %s", (value == 0)? "yes" : "no");`

Other conventions:
 - All defined Fields SHOULD BE ALWAYS initialized
 - Four spaces are used, instead of TABS
 - Trailing spaces are always avoided
 - Control flow statements are followed **by a space**:
```c
if (condition) value = 0;

while (!WindowShouldClose())
{

}

for (int i = 0; i < NUM_VALUES; i++) printf("%i", i);

switch (value)
{
    case 0:
    {

    } break;
    case 2: break;
    default: break;
}
```
 - All conditions are always between parenthesis, but not boolean values:
```c
if ((value > 1) && (value < 50) && valueActive)
{

}
```
 - Braces and curly brackets always open-close in aligned mode:
```c
void SomeFunction()
{
   // TODO: Do something here!
}
```

## Files and Directories Naming Conventions

  - Directories are named using `TitleCase`: `Assets/Sprites`, `Assets/Fonts`
  - Files are named using `snake_case`: `main_title.png`, `cubicmap.png`, `sound.wav`

**_NOTE: Spaces and special characters MUST BE ALWAYS avoided in the files/dir naming!_**

## Games/Examples Directories Organization Conventions

 - Resource files are organized by context and usage in the game. Loading requirements for data are also considered (grouping data when required).
 - Descriptive names are used for the files, just reading the name of the file it should be possible to know what is that file and where fits in the game.

```
Assets/Audio/Fx/long_jump.wav
Assets/Audio/Music/main_theme.ogg
Assets/Screens/Logo/logo.png
Assets/Screens/Title/title.png
Assets/Screens/Gameplay/background.png
Assets/Sprites/player.png
Assets/Sprites/enemy_slime.png
Assets/Common/font_arial.ttf
Assets/Common/gui.png
```
_NOTE: Some resources require to be loaded all at once while other require to be loaded only at initialization (gui, font)._
