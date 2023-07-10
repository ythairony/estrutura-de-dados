using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        Heap h = new Heap(8);
        
        //Inserções
        // Node a = h.Insert(1);
        // Node b = h.Insert(3);
        // Node a11 = h.Insert(11);
        // Node a12 = h.Insert(12);
        // Node b31 = h.Insert(31);
        // Node b32 = h.Insert(32);
        // Node a111 = h.Insert(111);
        // Node a112 = h.Insert(112);
        // Node a121 = h.Insert(121);
        // Node a122 = h.Insert(122);
        // Node b311 = h.Insert(311);

        // Novas inserções
        h.Insert(7);
        h.Insert(2);
        h.Insert(5);
        h.Insert(9);
        h.Insert(6);
        h.Insert(1);

        // Raiz
        Console.WriteLine($"O raiz é o elemento {h.Root().GetKey()}"); // 1

        // Mostrar árvore
        h.Mostrar();

        // Remove
        Console.WriteLine($"Elemento {h.RemoveMin()} removido da lista");
        Console.WriteLine($"O novo último nó é o {h.GetLastNode()} ");

        // Mostrar árvore depois do remove
        h.Mostrar();

        Console.WriteLine($"Elemento {h.RemoveMin()} removido da lista");
        Console.WriteLine($"O novo último nó é o {h.GetLastNode()} ");

        h.Mostrar();
    }
}
