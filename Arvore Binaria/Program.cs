using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        ArvoreBinaria pinheiro = new ArvoreBinaria(10);
        
        Console.WriteLine($"Tamanho = {pinheiro.Tamanho()}"); // tamanho 1
        Console.WriteLine($"10 é o raiz? {pinheiro.Eraiz(pinheiro.root())}"); // True

        Node seis = pinheiro.Pesquisar(pinheiro.root(), 6);
        Console.WriteLine($"FE de 10 {pinheiro.root().GetFilhoEsquerdo().GetElem()}"); // 6

        Node dois = pinheiro.Pesquisar(pinheiro.root(), 2);
        Console.WriteLine($"FE de 6 {seis.GetFilhoEsquerdo().GetElem()}"); // 6
        
    }
}
