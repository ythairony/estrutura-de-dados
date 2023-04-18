using System;
using System.Collections;


public class PilhaVazia : Exception {
  public PilhaVazia(string message) : base(message) {}
}

public class Object {
  public override string ToString() {
    return "Item";
  }
}


public class Pilha {
  private ArrayList pilha = new ArrayList(1);
  private int top = -1;


  public void Push(Object obj) {
    pilha.Add(obj);
    top++;
  }
  

  public object Pop() {
    if (top == -1) {
      throw new PilhaVazia("A pilha está vazia");
    }
    object temp = pilha[top];
    pilha.RemoveAt(top);
    top--;
    return temp;
  }
  
  
  public object Top() {
    if (top == -1) {
      throw new PilhaVazia("A pilha está vazia");
    }
    return pilha[top];
  }

  
  public int Size() {
    return top + 1;
  }
}


public partial class Program {
  public static void Main() {
    Pilha p = new Pilha();
    Object a = new Object();
    Console.WriteLine(p.Size());
    p.Push(a);
    Object b = new Object();
    Console.WriteLine(p.Size());
    p.Push(b);
    Console.WriteLine(p.Size());
    Console.WriteLine(p.Top());
    Console.WriteLine(p.Size());
    Console.WriteLine(p.Pop());
    Console.WriteLine(p.Size());
    Console.WriteLine(p.Top());
    Console.WriteLine(p.Size());    
  }
}