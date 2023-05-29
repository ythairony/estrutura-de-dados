using System;

public class TadVectorException : Exception {
  public TadVectorException(string message) : base(message) {}
}

public class Node {
  private object elem;
  private Node next;
  private Node prev;

  public Node(Node p, object o, Node n) {
    elem = o;
    next = n;
    prev = p;
  }

  public void SetNext(Node n) {
    this.next = n;
  }

  public void SetPrev(Node n) {
    this.prev = n;
  }

  public void SetElem(object o) {
    this.elem = o;
  }

  public Node GetNext() {
    return next;
  } 

  public Node GetPrev() {
    return prev;
  }

  public object GetElem() {
    return elem;
  }
}


public class TadVector {
  private int len = 0;
  private Node head, tail;

  public TadVector() {
    head = new Node(null, null, null);
    tail = new Node(head, null, null);
    head.SetNext(tail);
  }

  public Node findNode(object o) {
    Node new_node = head.GetNext();
    while (new_node.GetElem() != o) {
      new_node = new_node.GetNext();
      if (new_node.GetNext() == null) {
        throw new TadVectorException("Object not is in this Vector");
      }
    } 
    return new_node;
  }

  public bool isEmpty() {
    return head.GetNext() == tail;
  }

  public int size() {
    return len;
  }

  public Node insertRank(int rank, object obj) {
    if (obj == null) {
      throw new TadVectorException("You cannot insert null value");
    }
    if (rank < 0 || rank > size()) {
      throw new TadVectorException("Index out of range");
    }
    Node new_node = new Node(null, obj, null);
    Node node = head.GetNext();
    for (int i = 0; i < rank; i++) {
      node = node.GetNext();
    }
    if (node == tail) {
      head.SetNext(new_node);
      tail.SetPrev(new_node);
      new_node.SetPrev(head);
      new_node.SetNext(tail);
      this.len++;
    } else {
      new_node.SetPrev(node.GetPrev());
      new_node.SetNext(node);
      node.GetPrev().SetNext(new_node);
      node.SetPrev(new_node);
      this.len++;
    }

    return new_node;
  }

  public object elemAtRank(int rank) {
    if (isEmpty()) {
      throw new TadVectorException("TadVector is empty");
    }
    if (rank < 0 || rank >= size()) {
      throw new TadVectorException("Index out of range");
    }
    Node node = head.GetNext();
    for (int i = 0; i < rank; i++) {
      node = node.GetNext();
    }
    return node.GetElem();
  }

  public object replaceAtRank(int rank, object obj) {
    if (isEmpty()) {
      throw new TadVectorException("TadVector is empty");
    }
    if (rank < 0 || rank >= size()) {
      throw new TadVectorException("Index out of range");
    }
    Node node = head.GetNext();
    for (int i = 0; i < rank; i++) {
      node = node.GetNext();
    }
    object temp = node.GetElem();
    node.SetElem(obj);
    return temp;
  }

  public object removeAtRank(int rank) {
    if (isEmpty()) {
      throw new TadVectorException("TadVector is empty");
    }
    if (rank < 0 || rank >= size()) {
      throw new TadVectorException("Index out of range");
    }
    Node node = head.GetNext();
    for (int i = 0; i < rank; i++) {
      node = node.GetNext();
    }
    node.GetPrev().SetNext(node.GetNext());
    node.GetNext().SetPrev(node.GetPrev());
    this.len--;
    return node.GetElem();
  }
  
}


class Program {
  public static void Main (string[] args) {
    TadVector test = new TadVector();
    Console.WriteLine($"Está vazio? {test.isEmpty()}"); // True
    Console.WriteLine($"Tamanho da lista = {test.size()}"); // 0

    Node n1 = test.insertRank(0, 25); // 1 = 25
    Node n2 = test.insertRank(0, "ABC"); // 1 = abc, 2 = 25
    Node n3 = test.insertRank(1, 99); // 1 abc, 2 = 99, 3 = 25
    Node n4 = test.insertRank(0, 1); // 1 = 1 ...
    Console.WriteLine($"Tamanho da lista = {test.size()}"); // 4
    Console.WriteLine($"O elemento na posição 1 = {test.elemAtRank(1)}"); // ABC
    Console.WriteLine($"O elemento na posição 0 = {test.elemAtRank(0)}"); // 1
    Console.WriteLine($"O elemento na posição 2 = {test.elemAtRank(2)}"); // 99
    Console.WriteLine($"O elemento na posição 3 = {test.elemAtRank(3)}"); // 25
    Console.WriteLine($"Troque o elemento da posição 3 por 250 e retorne o antigo = {test.replaceAtRank(3, 250)}");
    Console.WriteLine($"Remover elemento na posição 1 = {test.removeAtRank(1)}"); // 25
    Console.WriteLine($"O elemento na posição 0 = {test.elemAtRank(0)}"); // 1
    Console.WriteLine($"O elemento na posição 1 = {test.elemAtRank(1)}"); // 99
    Console.WriteLine($"Tamanho da lista = {test.size()}"); // 3
    Console.WriteLine($"Está vazio? {test.isEmpty()}"); // False
  }
}