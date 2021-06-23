# EgyptianHieroglyphsProcessing
This is an example code of simple visualization of ancient Egyptian hieroglyphs using .NET C# and a [font](https://mjn.host.cs.st-andrews.ac.uk/egyptian/fonts/newgardiner.html) developed by [Mark-Jan Nederhof](https://mjn.host.cs.st-andrews.ac.uk/). Another font is available [here](https://www.dafont.com/ancient-egyptian-hieroglyphs.font).

1) Install the NewGardiner font (also provided here as a backup copy)
2) Compile and launch application in Visual Studio

The Egyptian hieroglyphs are in the extended version of Unicode: the [Supplementary Multilingual Plane (SMP)](https://en.wikipedia.org/wiki/Plane_(Unicode)#Supplementary_Multilingual_Plane). You can find a full reference [here](http://unicode.org/charts/PDF/U13000.pdf). So the first hieroglyph starts at 0x13000 (hex). Setting an hieroglyph to a char is impossible in .NET. This is because the char is not designed to hold the values that we need. Char is 16 bit in .NET and we want to refer to 0x1300 hex (77824 decimal) which is bigger than 65565. String on the other hand can handle this, but we need to use the \U (not \u) and create a 32bit character (note the leading zeros). The following code displays the first hieroglyph in the table.
```
string single_character = "\U00013000";
label1.Text = single_character;
```
So now we have our single character (glyph) encoded as 4 bytes instead of 2. Also two hieroglyphs will be encoded like this:
```
string two_characters = "\U00013000\U00013010";
```

