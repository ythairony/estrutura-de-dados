using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        ArvoreBinaria pinheiro = new ArvoreBinaria(10);
        
        Console.WriteLine($"Tamanho = {pinheiro.Tamanho()}"); // tamanho 1
        Console.WriteLine($"10 é o raiz? {pinheiro.Eraiz(pinheiro.root())}"); // True

        Node seis = pinheiro.Incluir(6);
        Node dois = pinheiro.Incluir(2);
        Node quatorze = pinheiro.Incluir(14);
        Node dezenove = pinheiro.Incluir(19);
        Node oito = pinheiro.Incluir(8);
        Console.WriteLine($"Tamanho = {pinheiro.Tamanho()}"); // tamanho 6
    }
}
