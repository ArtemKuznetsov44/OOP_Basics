using HomeTask_7;

Acoder acoder = new();
Bcoder bcoder = new();
string newString = String.Empty;
Console.WriteLine("=================== Acoder ===================");
Console.Write("Введите строку: ");
string? defString = Console.ReadLine();
if (defString != null)
{
    newString = acoder.Encode(defString);
    Console.WriteLine("После кодирования: " + newString);
    Console.WriteLine("После декодирования: " + acoder.Decode(newString));
}
Console.WriteLine("=================== Bcoder ===================");
Console.Write("Введите строку: ");
defString = Console.ReadLine();
if (defString != null)
{
    newString = bcoder.Encode(defString);
    Console.WriteLine("После кодирования: " + newString);
    Console.WriteLine("После декодирования: " + bcoder.Decode(newString));
}
Console.WriteLine("===============================================");
Console.Read();
