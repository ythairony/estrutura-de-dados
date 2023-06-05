using System;
using System.Collections;

class MainClass {
  public static void Main (string[] args) {
   // Console.WriteLine ("Hello World");
    ArvoreSimples simples=new  ArvoreSimples(1);
    simples.addChild(simples.root(),2);
    simples.addChild(simples.root(),3);
    simples.addChild(simples.root(),4);
    simples.addChild(simples.root(),5);

    IEnumerator Filhos=simples.children(simples.root());

    while(Filhos.MoveNext()){
      ArvoreSimples.No x=(ArvoreSimples.No)(Filhos.Current);
      int z=(int)x.element();
      Console.WriteLine(">"+z);
    }
   // for(int i=0;i<Filhos.Count;i++){
     // Console.WriteLine(">,"+Filhos[i].element());
    //}

    Console.WriteLine("");
    Console.WriteLine(simples.root().element());
    
  }
}