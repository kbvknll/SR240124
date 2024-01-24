// Уровень сложности 1
string sequence1 = "(())()";
string sequence2 = "())()";
string sequence3 = " ((2+3)*5 - (7-3) / 3) * 8";

Console.WriteLine("Проверка для 1 уровня из ()()()(()()()" + "\n");


Console.WriteLine("Правильная последовательность 1: " + CheckBracketSequence(sequence1));
Console.WriteLine("Правильная последовательность 2: " + CheckBracketSequence(sequence2));
Console.WriteLine("Правильная последовательность 3: " + CheckBracketSequence(sequence3) + "\n");


//Уроыень сложности 2
string sequence4 = "({})([])";
string sequence5 = "[()}";

Console.WriteLine("Проврерка для 2 уровня {}{}}{()()()]][][][" + "\n");


Console.WriteLine("Правильная последовательность 4: " + IsValid(sequence4));
Console.WriteLine("Правильная последовательность 5: " + IsValid(sequence5) + "\n");

//Доп баллы уфффффф 
string mytext= "Д1, Б2, R3/ L7] п2 ъ1 z2 v7";

CheckTextOnSybmols(mytext);


//Уровень сложности 1. Статичная функция, которая проверяет скобочки, принимающая выражение exspression 
static bool CheckBracketSequence(string expression)
{
    int count = 0;

    foreach (char ch in expression)
    {
        if (ch == '(')
        {
            count++;
        }
        else if (ch == ')')
        {
            if (count == 0)
            {
                return false;
            }
            count--;
        }
    }

    return count == 0;
}

//Уровень сложности 2, с помощью свитчкейса проверяет кол-во открытых скобок, если оно отрицательное - бан
static bool IsValid(string s)
{
    Stack<char> stack = new Stack<char>();
    foreach (char c in s)
    {
        if (c == '(' || c == '{' || c == '[')
        {
            stack.Push(c);
        }
        else if (c == ')' || c == '}' || c == ']')
        {
            if (stack.Count == 0)
            {
                return false;
            }
            char top = stack.Pop();
            if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '['))
            {
                return false;
            }
        }
    }
    return stack.Count == 0;
}

void CheckTextOnSybmols(string text)
{
    int CountOfUpperENCases = text.Count(c => char.IsUpper(c) && (c >= 'A' && c <= 'Z'));
    int CountOfLowerENCases = text.Count(c => char.IsLower(c) && (c >= 'a' && c <= 'z'));
    int CountOfUpperRUCases = text.Count(c => char.IsUpper(c) && (c >= 'А' && c <= 'Я'));
    int CountOfLowerRUCases = text.Count(c => char.IsLower(c) && (c >= 'а' && c <= 'я'));
    int CountOfDigits = text.Count(c => char.IsDigit(c));
    int CountOfLettersAndDigits = text.Count(c => !char.IsLetterOrDigit(c));

    int GeneralCountOfSymbols = text.Length;

    int CountOfOthersSymbols = text.Length - (CountOfUpperENCases + CountOfLowerENCases + CountOfUpperRUCases + CountOfLowerRUCases + CountOfDigits);

    Console.WriteLine($"Английская большая раскладка: {CountOfUpperENCases}");
    Console.WriteLine($"Английская маленькая: {CountOfLowerENCases}");
    Console.WriteLine($"Русская большая: {CountOfUpperRUCases}");
    Console.WriteLine($"Русская маленькая: {CountOfLowerRUCases}");
    Console.WriteLine($"Числа: {CountOfDigits}");
    Console.WriteLine($"Другие символы (включая пробелы): {CountOfLettersAndDigits}");
    Console.WriteLine($"Общее кол-во символов {GeneralCountOfSymbols}");

}