using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        Heap h = new Heap(10);
        Node um = h.Insert(1);
        Node tres = h.Insert(3);
        Node doze = h.Insert(12);
        // Node onze = h.Insert(11);
        // Node trinta = h.Insert(30);
        Console.WriteLine($"O pai de 1 é {um.GetParent().GetKey()}"); // 10
        Console.WriteLine($"O pai de 3 é {tres.GetParent().GetKey()}"); // 10
        Console.WriteLine($"O pai de 12 é {doze.GetParent().GetKey()}"); // 1
        // Console.WriteLine($"O pai de 11 é {onze.GetParent().GetKey()}"); // 1
        // Console.WriteLine($"O pai de 33 é {trinta.GetParent().GetKey()}"); // 3


    }
}
