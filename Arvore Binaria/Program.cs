using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        ArvoreBinaria pinheiro = new ArvoreBinaria(10);
        
        Console.WriteLine($"Tamanho = {pinheiro.Tamanho()}"); // tamanho 1
        Console.WriteLine($"10 é o raiz? {pinheiro.Eraiz(pinheiro.Root())}"); // True

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
        Console.WriteLine(dois.GetPai().GetElem()); // 6
        Console.WriteLine(quatorze.GetPai().GetElem()); // 10
        Console.WriteLine(dezenove.GetPai().GetElem()); // 14
        Console.WriteLine(oito.GetPai().GetElem()); // 6
        Console.WriteLine(tres.GetPai().GetElem()); // 2
        Console.WriteLine(dezessete.GetPai().GetElem()); // 19
        Console.WriteLine(vinte_um.GetPai().GetElem()); // 19
        Console.WriteLine(um.GetPai().GetElem()); // 2
        Console.WriteLine($"Fundura = {pinheiro.Profundidade(dezenove)}"); // 3

        Console.WriteLine($"Altura = {pinheiro.Altura(oito)}"); // 3

        Console.WriteLine(pinheiro.Interno(oito)); // false
        Console.WriteLine(pinheiro.Interno(dois)); // true

        Console.WriteLine(pinheiro.Externo(oito)); // true
        Console.WriteLine(pinheiro.Externo(dois)); // false

        Console.WriteLine();
        Console.WriteLine("PRINT ELEMENTOS");
        IEnumerator elementos = pinheiro.Elements();
        int i = 1;
        while (elementos.MoveNext()) {
            Console.WriteLine($"{i}º elemento da árvore -> {elementos.Current}");
            i++;
        }

        Console.WriteLine();
        Console.WriteLine("PRINT NÓS");
        IEnumerator nos = pinheiro.Nos();
        int j = 1;
        while (nos.MoveNext()) {
            Console.WriteLine($"{j}º elemento da árvore -> {nos.Current}");
            j++;
        }

    }
}
