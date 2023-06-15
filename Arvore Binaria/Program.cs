using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        ArvoreBinaria dark = new ArvoreBinaria("Helge");

        Console.WriteLine($"Tamanho = {dark.Tamanho()}"); // tamanho 1
        Console.WriteLine($"Está vazio? {dark.EstaVazio()}"); // False
        Console.WriteLine($"{dark.root().GetElem()} é raiz? {dark.Eraiz(dark.root())}"); // True
    }
}
