//Antes de C# 13 (usando \u001b o \x1b):

// Usando \u001b:
string escapeString = "\u001b[31mTexto en rojo\u001b[0m";
Console.WriteLine(escapeString);

// Usando \x1b:
string escapeStringHex = "\x1b[31mTexto en rojo\x1b[0m";
Console.WriteLine(escapeStringHex);

// Problema potencial con \x1b:
string problematic = "\x1b123"; // Esto puede interpretarse como un único carácter con valor hexadecimal 1b123.
Console.WriteLine(problematic);

//Con C# 13 (usando \e):

// Cambiar texto a rojo utilizando el carácter ESCAPE
string textInRed = "\e[31mEste texto es rojo\e[0m";
Console.WriteLine(textInRed);

// Cambiar texto a azul
string textInBlue = "\e[34mEste texto es azul\e[0m";
Console.WriteLine(textInBlue);
