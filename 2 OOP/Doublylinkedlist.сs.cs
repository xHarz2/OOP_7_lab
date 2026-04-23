using System;
 
class Node
{
    public long Value;
    public Node Prev, Next;
    public Node(long val) { Value = val; }
}
 
class DoublyLinkedList
{
    private Node head, tail;
    private int count;
    
    public void AddToEnd(long value)
    {
        var node = new Node(value);
        if (head == null) { head = tail = node; }
        else { node.Prev = tail; tail.Next = node; tail = node; }
        count++;
    }
 
    public void Print(string label = "Список")
    {
        Console.Write($"{label}: ");
        var cur = head;
        while (cur != null)
        {
            Console.Write(cur.Value + (cur.Next != null ? " <-> " : ""));
            cur = cur.Next;
        }
        Console.WriteLine();
    }
    
    public void FindFirstMultipleOf5()
    {
        var cur = head;
        int pos = 1;
        while (cur != null)
        {
            if (cur.Value % 5 == 0)
            {
                Console.WriteLine($"Завдання 1: Перший елемент, кратний 5 = {cur.Value} (позиція {pos})");
                return;
            }
            cur = cur.Next;
            pos++;
        }
        Console.WriteLine("Завдання 1: Елементів, кратних 5, не знайдено.");
    }
    
    public void SumAtEvenPositions()
    {
        long sum = 0;
        var cur = head;
        int pos = 1;
        while (cur != null)
        {
            if (pos % 2 == 0) sum += cur.Value;
            cur = cur.Next;
            pos++;
        }
        Console.WriteLine($"Завдання 2: Сума елементів на парних позиціях = {sum}");
    }
    
    public DoublyLinkedList GetListGreaterThan(long threshold)
    {
        var newList = new DoublyLinkedList();
        var cur = head;
        while (cur != null)
        {
            if (cur.Value > threshold) newList.AddToEnd(cur.Value);
            cur = cur.Next;
        }
        return newList;
    }
    
    public static long ReadLong(string prompt)
    {
        long result;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
 
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("  Помилка: введення не може бути порожнім. Спробуйте ще раз.");
                continue;
            }
 
            if (!long.TryParse(input.Trim(), out result))
            {
                Console.WriteLine("  Помилка: введіть ціле число (наприклад: 10, -5, 0). Спробуйте ще раз.");
                continue;
            }
 
            return result;
        }
    }
    
    public static int ReadPositiveInt(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
 
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("  Помилка: введення не може бути порожнім. Спробуйте ще раз.");
                continue;
            }
 
            if (!int.TryParse(input.Trim(), out result) || result <= 0)
            {
                Console.WriteLine("  Помилка: введіть ціле додатне число (наприклад: 5, 10). Спробуйте ще раз.");
                continue;
            }
 
            return result;
        }
    }
    
    public static int ReadChoice(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
 
            if (int.TryParse(input?.Trim(), out result) && (result == 1 || result == 2))
                return result;
 
            Console.WriteLine("  Помилка: введіть 1 або 2.");
        }
    }
    
    public void RemoveAboveAverage()
    {
        if (head == null) return;
 
        double avg = 0;
        int cnt = 0;
        var cur = head;
        while (cur != null) { avg += cur.Value; cnt++; cur = cur.Next; }
        avg /= cnt;
 
        Console.WriteLine($"Завдання 4: Середнє значення = {avg:F2}");
 
        cur = head;
        while (cur != null)
        {
            var next = cur.Next;
            if (cur.Value > avg)
            {
                if (cur.Prev != null) cur.Prev.Next = cur.Next;
                else head = cur.Next;
 
                if (cur.Next != null) cur.Next.Prev = cur.Prev;
                else tail = cur.Prev;
 
                count--;
            }
            cur = next;
        }
    }
}
