using System;
using System.Collections;

class Program {
    public static void Main(string[] args) {
        ArvoreBinaria dark = new ArvoreBinaria("Helge");

        Console.WriteLine($"Tamanho = {dark.Tamanho()}"); // tamanho 1
        Console.WriteLine($"Está vazio? {dark.EstaVazio()}"); // False
        Console.WriteLine($"{dark.root().GetElem()} é raiz? {dark.Eraiz(dark.root())}"); // True

        Node peter = dark.Incluir(dark.root(), "Peter"); // Colocando Petter como filho esquerdo
        Node charlotte = dark.Incluir(dark.root(), "Charlotte"); // Colocando Charlotte com filho direito

        // filhos Helge
        Console.WriteLine();
        Console.WriteLine("COLOCANDO FILHOS DE HELGE");
        Console.WriteLine($"Filho da esquerdo = {dark.root().GetFilhoEsquerdo().GetElem()}"); // Peter     
        Console.WriteLine($"Filho da direito = {dark.root().GetFilhoDireito().GetElem()}"); // Charlotte

        Node beth = dark.Incluir(charlotte, "Beth");
        Node franziska = dark.Incluir(charlotte, "Franziska");

        // filhos da charlotte
        Console.WriteLine();
        Console.WriteLine("COLOCANDO FILHOS DE CHARLOTTE");
        Console.WriteLine($"Filha da esquerdo = {charlotte.GetFilhoEsquerdo().GetElem()}"); // Peter     
        Console.WriteLine($"Filha da direito = {charlotte.GetFilhoDireito().GetElem()}"); // Charlotte

    }
}
