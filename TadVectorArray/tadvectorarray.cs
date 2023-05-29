using System;

public class VectorException : Exception {
  public VectorException(string message) : base(message) {}
}


// tad vector com array
public class Vector {
  private int capacity;
  private int len = 0;
  private Object[] vector;

  public Vector(int capacity) {
    this.capacity = capacity;
    vector = new object[capacity];
  }

  public void insertAtRank(int rank, object obj) { //ok
    if (rank < 0 || rank > size()) {
      throw new VectorException("Índice fora do alcance do vector");
    }
    if (capacity == size()) {
      resize(vector);
    }
    if (vector[rank] == null) {
      this.vector[rank] = obj;
    } else {
      Object[] new_array = new Object[capacity]; 
      int j = 0;
      for (int i = 0; i < size(); i++) {
        if (i == rank) {
          new_array[j] = obj;
          j++;
        }
        new_array[j] = vector[i];
        j++;
      }
      this.vector = new_array;
    }
    this.len++;
  } 
  
  public object elemAtRank(int rank) { //ok
    if (isEmpty()) {
      throw new VectorException("TADVector está vazia."); 
    }
    if (rank < 0 || rank > size()) {
      throw new VectorException("Índice fora do alcance do vector");
    }
    return this.vector[rank];
  }

  public object replaceAtRank(int rank, object obj) { //ok
    if (isEmpty()) {
      throw new VectorException("TADVector está vazia.");
    }
    if (rank < 0 || rank > size()) {
      throw new VectorException("Índice fora do alcance do vector");
    }
    Object old = vector[rank];
    this.vector[rank] =  obj;
    return old;
  }

  public object removeAtRank(int rank) {
    if (isEmpty()) {
      throw new VectorException("TADVector está vazia.");
    }
    if (rank < 0 || rank >= size()) {
      throw new VectorException("Índice fora do alcance do vector");
    }
    if (rank == size()-1) {
      Object old = vector[rank];
      this.len--;
      return old;
    } else {
      Object old = vector[rank];
      int j = 0;
      for (int i = 0; i < size(); i++) {
        if (Object.Equals(vector[rank], old)) {
            j++;
        }
        vector[i] = vector[j];
        j++;
      }
      this.len--;
      return old;
    }
  }

  public void resize(object[] vector) { //ok
    Object[] new_array = new Object[capacity * 2];
    for (int i = 0; i < capacity ; i++) {
      new_array[i] = vector[i];
    }
    this.vector = new_array;
    this.capacity = capacity * 2;
  } 

  public int size() { //ok
    return len;
  } 
  
  public Boolean isEmpty() { //ok
    return len == 0;
  } 
}


public class Program {
  public static void Main() {
    Vector A = new Vector(2);
    A.insertAtRank(0, 100);
    A.insertAtRank(1, 200);
    Console.WriteLine(A.replaceAtRank(1,0));
    Console.WriteLine(A.replaceAtRank(1,1000));
    Console.WriteLine($"Tamanho do array = {A.size()}");
    A.insertAtRank(1, 1000);
    Console.WriteLine($"Tamanho do array = {A.size()}");
    Console.WriteLine($"O objeto removido foi = {A.removeAtRank(0)}");
  }
}