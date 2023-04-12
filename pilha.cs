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

  public void PushRed(int n) {
    Console.WriteLine("Push RED"); // apagar dps
    Boolean x = true;
    
    if (topRed + 1 == topDark) {
      int[] novaPilha = new int[length * 2];
      int j = 0;
      
      for (int i = 0; i < length ; i++) {
        if (i > topRed && x) {
          x = false;
          i+=length;
        }
        novaPilha[i] = pilha[j];
        j++;
      }
      pilha = novaPilha;
      topDark+=length;
      length*=2;
    } 
    pilha[++topRed] = n;
  }

  public void PushDark(int n) {
    Console.WriteLine("Push DARK"); // apagar dps
    Boolean x = true;
    
    if (topRed + 1 == topDark) {
      int[] novaPilha = new int[length * 2];
      int j = 0;
      
      for (int i = 0; i < length * 2 ; i++) {
        if (i > topRed && x) {
          x = false;
          i+=length;
        }
        novaPilha[i] = pilha[j];
        j++;
      }
      pilha = novaPilha;
      topDark+=length;
      length*=2;
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
    Console.Write("length = ");
    Console.WriteLine(p.length);
    Console.WriteLine();
    
  }
}

public class Program {
  public static void Main() {
    Pilha p = new Pilha(1);
    
    p.PushRed(10); // incrementar 
    p.Mostrar(p); // mostrar pilha pos incremento

    p.PushRed(11); // incrementar 
    p.Mostrar(p); // mostrar pilha pos incremento

    p.PushRed(12); // incrementar 
    p.Mostrar(p); // mostrar pilha pos incremento

    p.PushRed(13); // incrementar 
    p.Mostrar(p); // mostrar pilha pos incremento

    p.PushRed(14); // incrementar 
    p.Mostrar(p);

    p.PushDark(20); // incrementar 
    p.Mostrar(p);

    p.PushDark(21); // incrementar 
    p.Mostrar(p);

    p.PushDark(22); // incrementar 
    p.Mostrar(p);

    p.PushDark(23); // incrementar 
    p.Mostrar(p);

    p.PopRed();
    p.PopDark();
    p.Mostrar(p);


    p.PushRed(15); // incrementar 
    p.Mostrar(p);
    
  }
}