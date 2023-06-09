using System;
using System.Collections;

class MainClass {
  public static void Main (string[] args) {
    ArvoreSimples paizao =new ArvoreSimples("Adao");
    ArvoreSimples.No f4 = new ArvoreSimples.No(paizao.root(), "Chico"); // depois colocar como neto de Adao

    Console.WriteLine($"Tamanho = {paizao.size()}"); // tamanho 1
    Console.WriteLine($"Está vazio? {paizao.isEmpty()}"); // False
    Console.WriteLine($"É interno? {paizao.isInternal(paizao.root())}"); // False, por enquanto ainda não tem filhos
    Console.WriteLine($"É externo? {paizao.isExternal(paizao.root())}"); // True, por enquanto ainda não tem filhos
    Console.WriteLine($"Profundidade = {paizao.depth(paizao.root())}"); // 0
    paizao.addChild(paizao.root(), "João");
    paizao.addChild(paizao.root(), "José");
    paizao.addChild(paizao.root(), "Maria");
    Console.WriteLine($"Tamanho = {paizao.size()}"); // tamanho 4
    // paizao.addChild(f4.GetPai(), f4.GetElem());

    // preparando pra printar cada filho de Adao
    IEnumerator filhos = paizao.children(paizao.root());
    while (filhos.MoveNext()) {
      ArvoreSimples.No filho = (ArvoreSimples.No)(filhos.Current); //perguntar a coleguinha
      string rank = (string)filho.GetElem(); //converter o elemento pra string
      Console.WriteLine($"{rank} é filho de {paizao.root().GetElem()}"); // printando cada filho
    }
    // Console.WriteLine($"Tamanho = {paizao.size()}"); // tamanho 5
    





    // simples.addChild(simples.root(),2);
    // simples.addChild(simples.root(),3);
    // simples.addChild(simples.root(),4);
    // simples.addChild(simples.root(),5);

  //   IEnumerator Filhos=simples.children(simples.root());

  //   while(Filhos.MoveNext()){
  //     ArvoreSimples.No x=(ArvoreSimples.No)(Filhos.Current);
  //     int z=(int)x.element();
  //     Console.WriteLine(">"+z);
  //   }
  //  // for(int i=0;i<Filhos.Count;i++){
  //    // Console.WriteLine(">,"+Filhos[i].element());
  //   //}

  //   Console.WriteLine("");
  //   Console.WriteLine(simples.root().element());
    
  }
}