using System;

public class TadFilaException : Exception {
  public TadFilaException(string message) : base(message) {}
}

// Lista com array

public class TadFila {
  private int len = 0;
  private int capacity;
  private object[] tadlist;
  

  public TadFila(int capacity) {
    this.capacity = capacity;
    tadlist = new object[capacity];
  }

  public int findObj(object obj) { //ok
    int rank = -1;
    int c = 0;
    for (int i = 0; i < size(); i++) {
      if(Object.Equals(tadlist[i], obj)) {
        rank = c;
      }
      c++;
    }
    Console.WriteLine(size());
    Console.WriteLine(rank);
    return rank;
  }
  
  public int size() { //ok
    return len;
  }

  public bool isEmpty() { //ok
    return len == 0;
  }

  public object isFirst(object obj) { //ok
    return obj = tadlist[0];
  } 

  public object isLast(object obj) { //ok
    return obj = tadlist[capacity-1];
  }

  public object first() { //ok
    return tadlist[0];
  }

  public object last() { //ok
    return tadlist[size()-1];
  }

  public object before(object obj) { //ok
    if (isEmpty()) {
      throw new TadFilaException("TADList is empty");
    }
    int rank = findObj(obj);
    if (rank == -1) {
      throw new TadFilaException("Object not is in the list.");
    } else {
      return tadlist[rank-1];
    }
  } 

  public object after(object obj) { //ok
    if (isEmpty()) {
      throw new TadFilaException("TADList is empty");
    }
    int rank = findObj(obj);
    if (rank == -1) {
      throw new TadFilaException("Object not is in the list.");
    } else {
      return tadlist[rank+1];
    }
  } // ok

  public void replaceElement(object old_obj, object new_obj) { //ok
    if (isEmpty()) {
      throw new TadFilaException("TADList is empty");
    }
    for (int i = 0; i < size(); i++) {
      if (tadlist[i] == old_obj) {
        tadlist[i] = new_obj;
      }
    }
  } //ok

  public void swapElement(object obj1, object obj2) { //ok
    int cont = 0;
    int index1 = 0 , index2 = 0;
    for (int i = 0; i < size(); i++) {
      if (tadlist[i] == obj1) { 
        index1 = i;
        cont++;
      }
      if (tadlist[i] == obj2) { 
        index2 = i;
        cont++;
      }
    }
    if (cont == 2) {
      this.tadlist[index1] = obj2;
      this.tadlist[index2] = obj1;
    } else {
      throw new TadFilaException("Any objects not contain in list");
    }
  } //ok

  public void insertBefore(object obj, object new_obj) {
    if (isEmpty()) {
      this.tadlist[0] = new_obj;
    }
    if (size() == capacity) {
      resize();
    }
    int rank = findObj(obj);
    reorganize(rank);
    this.tadlist[rank] = new_obj;
    this.len++;
  } 

  public void insertAfter(object obj, object new_obj) {
    if (isEmpty()) {
      this.tadlist[0] = new_obj;
    }
    if (size() == capacity) {
      resize();
    }
    int rank = findObj(obj) + 1;
    reorganize(rank);
    this.tadlist[rank] = new_obj;  
    this.len++;
  } 

  public void insertFirst(object obj) {
    if (size() == capacity) {
      resize();
    }
    reorganize(0);
    this.tadlist[0] = obj;
    this.len++;
  }

  public void insertLast(object obj) { //ok
    if (size() == capacity) {
      resize();
    }
    this.tadlist[size()] = obj;
    this.len++;
  }

  public object remove(object obj) { //ok 
    if (isEmpty()) {
      throw new TadFilaException("List is empty");
    }
    int rank = findObj(obj);
    if (rank == size()-1) {
      Object old = tadlist[rank];
      this.len--;
      return old;
    } else {
      Object old = tadlist[rank];
      int j = 0;
      for (int i = 0; i < size(); i++) {
        if (Object.Equals(tadlist[rank], old)) {
            j++;
        }
        tadlist[i] = tadlist[j];
        j++;
      }
      this.len--;
      return old;
    }
  }

  public void reorganize(int rank) {
    for (int i = size(); i > rank; i--) {
      this.tadlist[i] = tadlist[i-1];
    }
  }

  
  public void resize() {
    Object[] newTadFila = new Object[capacity * 2];
    for (int i = 0; i < capacity; i++) {
      newTadFila[i] = tadlist[i];
    }
    this.tadlist = newTadFila;
    this.capacity = capacity * 2;
  }
  
} 

public class Program {
  public static void Main() {
    TadFila fila = new TadFila(2);
    
    fila.insertLast("10");
    fila.insertLast(30);
    fila.insertLast(50);
    fila.insertLast("FIM");
    
    Console.WriteLine("Tamanho da fila: " + fila.size()); // 4
    
    Console.WriteLine("Primeiro objeto: " + fila.first()); // 10
    Console.WriteLine("Último objeto: " + fila.last()); // FIM
    
    Console.WriteLine("O anterior do 30 é " + fila.before(30)); // 30
    Console.WriteLine("Tamanho da fila: " + fila.size());
    fila.swapElement("FIM", "10");
    Console.WriteLine("Primeiro objeto: " + fila.first()); // FIM
    fila.replaceElement("FIM", "INICIO");
    Console.WriteLine("Primeiro objeto: " + fila.first()); // INICIO
    fila.insertAfter("10", 1);
    Console.WriteLine("Último objeto: " + fila.last()); // 1
    }
}