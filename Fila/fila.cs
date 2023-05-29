using System;

public class FilaVazia : Exception {
  public FilaVazia(string message) : base(message) {}
}

public class Item {
  
}

public class Fila {
  private int capacity;
  private int first = 0;
  private int end = 0;
  private Object[] fila;
  
  
  public Fila(int capacity) {
    this.capacity = capacity;
    fila = new Object[capacity];
  }
  
  public void Enqueue(Object obj) {
    if (Size() == capacity - 1) {
      Resize();
    }
    fila[end] = obj;
    this.end = (end + 1) % capacity;
  }

  public void Resize() {
    Object[] newFila = new Object[capacity * 2];
    for (int i = 0; i < capacity; i++) {
      int j = (first + i) % capacity;
      newFila[i] = fila[j];
    }
    this.fila = newFila;
    this.capacity = capacity * 2;
    this.first = 0;
    this.end = Size();
  }

  
  public Object Dequeue() {
    if (isEmpty()) {
      throw new FilaVazia("A fila está vazia");
    }
    Object o = fila[first];
    this.first = (first + 1) % capacity;
    return o;
  }
  
  
  public int First() {
    return first;
  }

  
  public int Size() {
    if (isEmpty()) {
      return 0;
    }
    return (capacity - first + end) % capacity;
  }


  public bool isEmpty() {  
    return first == end; 
  }

}



public class Program {
  public static void Main() {
    int capacity = 3;
    Fila fila = new Fila(capacity);
    Item o1 = new Item();
    Item o2 = new Item();
    Item o3 = new Item();
    Item o4 = new Item();
    Item o5 = new Item();
    Item o6 = new Item();    

    // colocando 1º da fila
    fila.Enqueue(o1);
    Console.WriteLine(fila.First());
    Console.WriteLine(fila.Size());
    Console.WriteLine();

    // colocando 1º da fila
    fila.Enqueue(o2);
    Console.WriteLine(fila.First());
    Console.WriteLine(fila.Size());
    Console.WriteLine();

    // Retirando o 1º da fila
    fila.Dequeue();
    Console.WriteLine(fila.First());
    Console.WriteLine(fila.Size());
    Console.WriteLine();

    // colocando outro na fila e lotando a fila
    fila.Enqueue(o3);
    Console.WriteLine(fila.First());
    Console.WriteLine(fila.Size());
    Console.WriteLine();

    // colocando +1 na fila, reorganizando-a e o 1º sendo o index 0
    fila.Enqueue(o4);
    Console.WriteLine(fila.First());
    Console.WriteLine(fila.Size());
    Console.WriteLine();

    fila.Enqueue(o5);
    Console.WriteLine(fila.First());
    Console.WriteLine(fila.Size());
    Console.WriteLine();

    fila.Enqueue(o6);
    Console.WriteLine(fila.First());
    Console.WriteLine(fila.Size());
    Console.WriteLine();

    fila.Enqueue(o6);
    Console.WriteLine(fila.First());
    Console.WriteLine(fila.Size());
    Console.WriteLine();

    fila.Enqueue(o6);
    Console.WriteLine(fila.First());
    Console.WriteLine(fila.Size());
    Console.WriteLine();
  }
}