using System;

public class Pilha {
  public int topRed, topDark, length;
  public int[] pilha;
  
  
  public Pilha(int length) {
    this.length = length;
    pilha = new int[length];
    topRed = -1;
    topDark = length;
  }

  public void PushRed(int n) {
    if (topRed + 1 == topDark) {
      int[] novaPilha = new int[length * 2];
      for (int i = 0; i < length ; i++) {
        novaPilha[i] = pilha[i];
        // if (pilha[i] == 1) {
        //   novaPilha[i] = pilha[i];
        // }
        if (pilha[i] == 2) {
          novaPilha[i + length] = pilha[i];
        }
      }
      pilha = novaPilha;
      topDark+=length;
      length*=2;
    } 
    pilha[++topRed] = n;
  }

  public void PushDark(int n) {
    if (topRed + 1 == topDark) {
      int[] novaPilha = new int[length * 2];
      for (int i = 0; i < length ; i++) {
        novaPilha[i] = pilha[i];
        // if (pilha[i] == 1) {
        //   novaPilha[i] = pilha[i];
        // }
        if (pilha[i] == 2) {
          novaPilha[i + length] = pilha[i];
        }
      }
      pilha = novaPilha;
      topDark+=length;
      length*=2;
    } 
    pilha[--topDark] = n;
  }
  
  public static int IsFull(int topRed, int topDark) {
    if (topRed + 1 == topDark) {
      return 1;
    } else { return 0; }
  }

  public void Mostrar(Pilha p) {
    // for (int i = 0; i < length ; i++) {
    //   Console.Write($"{p.pilha[i]} ");
    // }
    Console.WriteLine();
    Console.Write("topRed = ");
    Console.WriteLine(p.topRed);
    Console.Write("topDark = ");
    Console.WriteLine(p.topDark);
    Console.Write("length = ");
    Console.WriteLine(p.length);
    
  }
  
  
}

public class Program {
  public static void Main() {
    Pilha p = new Pilha(1);
    
    p.Mostrar(p); // mostrar pilha vazia
    
    p.PushRed(1); // incrementar red
    Console.WriteLine();
    p.Mostrar(p); // mostrar pilha pos incremento

    p.PushDark(2); // incrementa dark
    Console.WriteLine();
    p.Mostrar(p); // mostrar pilha pos incremento

    p.PushDark(2); // incrementa dark
    Console.WriteLine();
    p.Mostrar(p); // mostrar pilha pos incremento

    p.PushRed(1); // incrementar red
    Console.WriteLine();
    p.Mostrar(p); // mostrar pilha pos incremento
    
  }
}