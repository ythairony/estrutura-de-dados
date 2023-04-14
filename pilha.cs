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

  public void Empty() {
    topRed = -1;
    topDark = length;
  }

  public void Resize() {
    int[] newStack = new int[length * 2];
    for (int i = 0; i < topDark; i++) {
      newStack[i] = pilha[i];
    } 
    for (int j = topDark + length; j < length * 2; j++) {
      newStack[j] = pilha[j-length];
    }
    pilha = newStack;
    topDark += length;
    length *= 2;
  }
  
  public void PushRed(int n) {
    Console.WriteLine("Push RED"); 
    
    if (topRed + 1 == topDark) {
      Resize();
    } 
    pilha[++topRed] = n;
  }

  public void PushDark(int n) {
    Console.WriteLine("Push DARK"); 
    
    if (topRed + 1 == topDark) {
      Resize();
    } 
    pilha[--topDark] = n;
  }

  public void PopRed() {
    Console.WriteLine("Pop RED");
    Console.WriteLine(pilha[topRed]);
    topRed-=1;
  }

  public void PopDark() {
    Console.WriteLine("Pop DARK");
    Console.WriteLine(pilha[topDark]);
    topDark+=1;
  }
  
  public static int IsFull(int topRed, int topDark) {
    if (topRed + 1 == topDark) {
      return 1;
    } else { return 0; }
  }

  public void Mostrar(Pilha p) {
    for (int i = 0; i < length ; i++) {
      Console.Write($"{p.pilha[i]} ");
    }
    Console.WriteLine();
    Console.Write("topRed = ");
    Console.WriteLine(p.topRed);
    Console.Write("topDark = ");
    Console.WriteLine(p.topDark);
    Console.WriteLine();
    
  }
}

public class Program {
  public static void Main() {
    Pilha p = new Pilha(1);
    int red = 10;
    int dark = 99;
    int option = -1;

    Console.WriteLine("-----------------");
    Console.WriteLine("Pilha rubro negra");
    Console.WriteLine("-----------------");

    Console.WriteLine(); 
    while (option != 0) {
      Console.WriteLine("[0] Sair");
      Console.WriteLine("[1] Push RED");
      Console.WriteLine("[2] Push DARK");
      
      Console.Write("Escolha uma opção: ");
      option = int.Parse(Console.ReadLine());
      Console.WriteLine();

      switch (option) {
      case 0 : 
        break;
      case 1 :
        p.PushRed(red);
        p.Mostrar(p);
        red++;
        break;
      case 2 :
        p.PushDark(dark);
        p.Mostrar(p);
        dark--;
        break;
      }
    }
    }
  }