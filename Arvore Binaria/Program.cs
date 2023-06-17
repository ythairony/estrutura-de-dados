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
        Node tres = pinheiro.Incluir(3);
        Node dezessete = pinheiro.Incluir(17);
        Node vinte_um = pinheiro.Incluir(21);
        Node um = pinheiro.Incluir(1);
        Console.WriteLine($"Tamanho = {pinheiro.Tamanho()}"); // tamanho 10
        // Console.WriteLine($"Fundura do nó 6 = {pinheiro.Profundidade(seis)}"); // 1

        // TESTE DE PATERNIDADE
        Console.WriteLine(seis.GetPai().GetElem()); // 10
        Console.WriteLine(dois.GetPai().GetElem()); // 6 - 2
        Console.WriteLine(quatorze.GetPai().GetElem()); // 10
        Console.WriteLine(dezenove.GetPai().GetElem()); // 14 - 19
        Console.WriteLine(oito.GetPai().GetElem()); // 6 - 8
        Console.WriteLine(tres.GetPai().GetElem()); // 2 - 3
        Console.WriteLine(dezessete.GetPai().GetElem()); // 19 - 19
        Console.WriteLine(vinte_um.GetPai().GetElem()); // 19 - 21
        Console.WriteLine(um.GetPai().GetElem()); // 2 - 1
        // Console.WriteLine($"Fundura do nó 2 = {pinheiro.Profundidade(quatorze)}"); // 3
    }
}
