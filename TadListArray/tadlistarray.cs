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

  public int findObj(object obj) {
    int rank = -1;
    int c = 0;
    for (int i = 0; i < size(); i++) {
      if(Object.Equals(tadlist[i], obj)) {
        rank = c;
      }
     
      Console.WriteLine($"{tadlist[i]} = {obj} ///  { Object.Equals(tadlist[i] , obj)}");
      c++;
    }
    Console.WriteLine(size());
    Console.WriteLine(rank);
    return rank;
  }
  
  public int size() {
    return len;
  }

  public bool isEmpty() {
    return len == 0;
  }

  public object isFirst(object obj) {
    return obj = tadlist[0];
  } 

  public object isLast(object obj) {
    return obj = tadlist[capacity-1];
  }

  public object first() {
    return tadlist[0];
  }

  public object last() {
    return tadlist[size()-1];
  }

  public object before(object obj) {
    if (isEmpty()) {
      throw new TadFilaException("TADList is empty");
    }
    int rank = findObj(obj);
    if (rank == -1) {
      throw new TadFilaException("Object not is in the list.");
    } else {
      return tadlist[rank-1];
    }
  } // ok

  public object after(object obj) {
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

  public void replaceElement(object old_obj, object new_obj) {
    if (isEmpty()) {
      throw new TadFilaException("TADList is empty");
    }
    for (int i = 0; i < size(); i++) {
      if (tadlist[i] == old_obj) {
        tadlist[i] = new_obj;
      }
    }
  } //ok

  public void swapElement(object obj1, object obj2) {
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
    int rank = findRank(obj);
    reorganize(rank);
    this.tadlist[rank] = new_obj;
    Console.WriteLine(tadlist[0]);
    Console.WriteLine(tadlist[1]);
    Console.WriteLine(tadlist[2]);
    Console.WriteLine(tadlist[3]);
    Console.WriteLine(tadlist[4]);
    Console.WriteLine(tadlist[5]);
    this.len++;
  } 

  public void insertAfter(object obj, object new_obj) {
    if (isEmpty()) {
      this.tadlist[0] = new_obj;
    }
    if (size() == capacity) {
      resize();
    }
    int rank = findRank(obj) + 1;
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

  public void insertLast(object obj) {
    if (size() == capacity) {
      resize();
    }
    this.tadlist[size()] = obj;
    this.len++;
  }

  public void remove(object obj) {
    if (isEmpty()) {
      throw new TadFilaException("List is empty");
    }
    int rank = findRank(obj);
    if (rank == size()) {
      this.tadlist[rank] = null;
      this.len--;
    }
    int j = 0;
    for (int i = 0; i < capacity; i++) {
      if (i == rank) {
        j++;
      }
      this.tadlist[i] = tadlist[j];
      j++;
    }
    this.tadlist[size()] = null;
    this.len--;
  }

  public void reorganize(int rank) {
    for (int i = size(); i > rank; i--) {
      this.tadlist[i] = tadlist[i-1];
    }
  }

  public int findRank(object obj) {
    int rank = 0;
    for (int i = 0; tadlist[i] != obj; i++) {
      rank++;
      if (rank == size()) {
        throw new TadFilaException("Object not in the list");
      }
    }
    return rank;
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