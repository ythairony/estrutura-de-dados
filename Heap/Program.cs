using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        Heap h = new Heap(10);
        Node a = h.Insert(1);
        Node b = h.Insert(3);
        Node a11 = h.Insert(11);
        Node a12 = h.Insert(12);
        Node b31 = h.Insert(31);
        Node b32 = h.Insert(32);
        Node a111 = h.Insert(111);
        Node a112 = h.Insert(112);
        Node a121 = h.Insert(121);
        Node a122 = h.Insert(122);
        Node b311 = h.Insert(311);
        Console.WriteLine($"O pai de 1 é {a.GetParent().GetKey()}"); // 10
        Console.WriteLine($"O pai de 3 é {b.GetParent().GetKey()}"); // 10
        Console.WriteLine($"O pai de 11 é {a11.GetParent().GetKey()}"); // 1
        Console.WriteLine($"O pai de 12 é {a12.GetParent().GetKey()}"); // 1
        Console.WriteLine($"O pai de 31 é {b31.GetParent().GetKey()}"); // 3
        Console.WriteLine($"O pai de 32 é {b32.GetParent().GetKey()}"); // 3
        Console.WriteLine($"O pai de 111 é {a111.GetParent().GetKey()}"); // 11
        Console.WriteLine($"O pai de 112 é {a112.GetParent().GetKey()}"); // 11
        Console.WriteLine($"O pai de 121 é {a121.GetParent().GetKey()}"); // 12
        Console.WriteLine($"O pai de 122 é {a122.GetParent().GetKey()}"); // 12
        Console.WriteLine($"O pai de 311 é {b311.GetParent().GetKey()}"); // 31
        Console.WriteLine(h.Root().GetKey());
        h.RemoveMin();


    }
}
