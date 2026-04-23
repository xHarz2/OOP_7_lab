using System;
 
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
 
        var list = new DoublyLinkedList();
 
        Console.WriteLine("=== Двозв'язний список ===");
        Console.WriteLine("Оберіть спосіб заповнення:");
        Console.WriteLine("  1 — ввести елементи вручну");
        Console.WriteLine("  2 — використати тестові дані");
 
        int choice = DoublyLinkedList.ReadChoice("Ваш вибір (1 або 2): ");
 
        if (choice == 1)
        {
            int n = DoublyLinkedList.ReadPositiveInt("Введіть кількість елементів: ");
            for (int i = 1; i <= n; i++)
            {
                long val = DoublyLinkedList.ReadLong($"  Елемент [{i}]: ");
                list.AddToEnd(val);
            }
        }
        else
        {
            long[] data = { 3, 10, 7, 15, 2, 20, 8, 25, 1, 5 };
            foreach (var d in data)
                list.AddToEnd(d);
            Console.WriteLine("Використано тестові дані: 3, 10, 7, 15, 2, 20, 8, 25, 1, 5");
        }
 
        list.Print("\nПочатковий список");
        Console.WriteLine();
        
        list.FindFirstMultipleOf5();
        
        list.SumAtEvenPositions();
        
        long threshold = DoublyLinkedList.ReadLong("\nЗавдання 3 — введіть порогове значення: ");
        var filtered = list.GetListGreaterThan(threshold);
        filtered.Print($"Завдання 3: Елементи > {threshold}");
        
        Console.WriteLine();
        list.RemoveAboveAverage();
        list.Print("Завдання 4: Список після видалення");
    }
}