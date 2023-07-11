using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        Heap h = new Heap(8);
        
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
        Console.WriteLine($"Elemento {h.RemoveMin()} removido da lista"); // 1
        Console.WriteLine($"O novo último nó é o {h.GetLastNode()} "); // 7

        // Mostrar árvore depois do remove
        h.Mostrar();

        Console.WriteLine();
        Console.WriteLine($"Elemento {h.RemoveMin()} removido da lista"); // 2
        Console.WriteLine($"O novo último nó é o {h.GetLastNode()} "); // 9
        h.Mostrar();

        Console.WriteLine();
        Console.WriteLine($"Elemento {h.RemoveMin()} removido da lista"); // 5
        Console.WriteLine($"O novo último nó é o {h.GetLastNode()} "); // 8
        h.Mostrar();

        Console.WriteLine(); // ERRO TÁ AQUI NÃO TA RETORNANDO PRO LADO DIREITO
        Console.WriteLine($"Elemento {h.RemoveMin()} removido da lista"); // 6
        Console.WriteLine($"O novo último nó é o {h.GetLastNode()} "); // 9
        h.Mostrar();

    }
}
