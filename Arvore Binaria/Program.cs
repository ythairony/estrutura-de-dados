using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        ArvoreBinaria pinheiro = new ArvoreBinaria(10);
        
        // INSERÇÕES
        Node seis = pinheiro.Incluir(6);
        Node dois = pinheiro.Incluir(2);
        Node quatorze = pinheiro.Incluir(14);
        Node dezenove = pinheiro.Incluir(19);
        Node oito = pinheiro.Incluir(8);
        Node tres = pinheiro.Incluir(3);
        Node dezessete = pinheiro.Incluir(17);
        Node vinte_um = pinheiro.Incluir(21);
        Node um = pinheiro.Incluir(1);
        Node quadro = pinheiro.Incluir(4);
        Node vinto = pinheiro.Incluir(20);
        Node dezoito = pinheiro.Incluir(18);
        
        // TESTE REMOVE
        // Console.WriteLine($"Removido o elemento -> {pinheiro.Remove(8)}");
 
        // TESTE ELEMENTS()
        Console.WriteLine();
        Console.WriteLine("PRINT ELEMENTOS");
        IEnumerator elementos = pinheiro.Elements();
        int i = 1;
        while (elementos.MoveNext()) {
            Console.WriteLine($"{i}º elemento da árvore -> {elementos.Current}");
            i++;
        }

        // TESTE PROXIMO
        pinheiro.Proximo(dezenove);

        // TESTE MOSTRAR
        pinheiro.Mostrar();
    }
}
