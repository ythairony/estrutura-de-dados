using System;
using System.Collections;

class MainClass {
  public static void Main (string[] args) {
    ArvoreSimples paizao =new ArvoreSimples("Adao");

    Console.WriteLine($"Tamanho = {paizao.size()}"); // tamanho 1
    Console.WriteLine($"Está vazio? {paizao.isEmpty()}"); // False
    Console.WriteLine($"É interno? {paizao.isInternal(paizao.root())}"); // False, por enquanto ainda não tem filhos
    Console.WriteLine($"É externo? {paizao.isExternal(paizao.root())}"); // True, por enquanto ainda não tem filhos
    Console.WriteLine($"Profundidade = {paizao.depth(paizao.root())}"); // 0
    paizao.addChild(paizao.root(), "João");
    paizao.addChild(paizao.root(), "José");
    paizao.addChild(paizao.root(), "Maria");
    Console.WriteLine($"Tamanho = {paizao.size()}"); // tamanho 4
    ArvoreSimples.No f4 = paizao.addChild(paizao.root(), "Chico");

    ArvoreSimples.No neto1 = paizao.addChild(f4, "Adao Neto"); // ADICIONANDO COMO FILHO DE CHICO
    ArvoreSimples.No neto2 = paizao.addChild(f4, "Chico Filho"); // Criando Chico Filho
    paizao.addChild(f4, neto2.GetElem()); // ADICIONANDO COMO FILHO DE CHICO

    // preparando pra printar cada filho de Adao
    // paizao.remove(f4); //"REMOVENDO" O NÓ (DECREMENTANDO) MAS AINDA PRINTA COMO FILHO
    Console.WriteLine();
    Console.WriteLine("FILHOS DE ADAO");
    IEnumerator filhos = paizao.children(paizao.root());
    while (filhos.MoveNext()) {
      ArvoreSimples.No filho = (ArvoreSimples.No)(filhos.Current); //perguntar a coleguinha
      string rank = (string)filho.GetElem(); //converter o elemento pra string
      Console.WriteLine($"O pai de {rank} é {paizao.parent(filho).GetElem()}");
      Console.WriteLine($"{rank} é filho de {paizao.root().GetElem()}"); // printando cada filho

      Console.WriteLine();
    }
    
      Console.WriteLine($"Tamanho = {paizao.size()}"); // tamanho 7
      Console.WriteLine();
      Console.WriteLine("TESTE DE INTERNO, EXTERNO E RAIZ");
      // Testes de chico e Adao Neto não internos, externos e raiz
      Console.WriteLine($"{f4.GetElem()} É interno? {paizao.isInternal(f4)}"); // True
      Console.WriteLine($"{neto1.GetElem()} É interno? {paizao.isInternal(neto1)}"); // False
      Console.WriteLine($"{f4.GetElem()} É raiz? {paizao.isRoot(f4)}"); // False
      Console.WriteLine($"{neto2.GetElem()} É raiz? {paizao.isRoot(neto2)}"); // False
      Console.WriteLine($"{f4.GetElem()} É externo? {paizao.isExternal(f4)}"); // False
      Console.WriteLine($"{neto1.GetElem()} É externo? {paizao.isExternal(neto1)}"); // True

      Console.WriteLine();

      // printando filhos de chico
      Console.WriteLine($"Tamanho = {paizao.size()}"); // tamanho 6
      Console.WriteLine("FILHOS DE CHICO");
      IEnumerator filhos_de_chico = paizao.children(f4);

      while (filhos_de_chico.MoveNext()) {
        ArvoreSimples.No filho_de_chico = (ArvoreSimples.No)(filhos_de_chico.Current);
      string rank = (string)filho_de_chico.GetElem();
      Console.WriteLine($"{rank} é filho de {f4.GetElem()}");
     }

     Console.WriteLine($"Pai de {neto1.GetElem()} é {paizao.parent(neto1).GetElem()}");
     Console.WriteLine($"Profundidade a partir de Adao neto = {paizao.depth(neto1)}"); // 2
     Console.WriteLine($"Profundidade a partir de chico = {paizao.depth(f4)}"); // 1

     Console.WriteLine($"Altura a partir do raiz é {paizao.height(paizao.root())}"); // 1


    
  }
}