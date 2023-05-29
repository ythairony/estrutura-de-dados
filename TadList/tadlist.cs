using System;

// Exception
public class TadListException : Exception {
  public TadListException(string message) : base(message) {}
}

public class Node {
  private Node next;
  private Node prev;
  private object elem;

  public Node(Node p, object e, Node n) {
    elem = e;
    prev = p;
    next = n;
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


public class TadList {
  private int len = 0;
  private Node head, tail;

  public TadList() {
    head = new Node(null, null, null);
    tail = new Node(head, null, null);
    head.SetNext(tail);
  }

  public Node findNode(object o) {
    Node new_node = head.GetNext();
    while (new_node.GetElem() != o) {
      new_node = new_node.GetNext();
      if (new_node.GetNext() == null) {
        throw new TadListException("Object not is in this list.");
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
  
  public bool isFirst(Node node) {
    if (isEmpty()) {
      throw new TadListException("Queue is empty");
    }
    return node == head.GetNext();
  }

  public Node insertFirst(object obj) {
    Node new_first = new Node(null, obj, null);
    new_first.SetElem(obj);
    Node old_first;
    old_first = head.GetNext();
    new_first.SetNext(old_first);
    new_first.SetPrev(head);
    old_first.SetPrev(new_first);
    head.SetNext(new_first);
    this.len++;

    return new_first;
  }

  public object first() {
    return head.GetNext().GetElem();
  }

  public bool isLast(Node node) {
    if (isEmpty()) {
      throw new TadListException("Queue is empty");
    }
    return node == tail.GetPrev();
  }

  public Node insertLast(object obj) {
    Node new_last = new Node(null, obj, null);
    new_last.SetElem(obj);
    Node old_last;

    old_last = tail.GetPrev();
    new_last.SetNext(tail);
    new_last.SetPrev(old_last);
    old_last.SetNext(new_last);
    tail.SetPrev(new_last);
    this.len++;

    return new_last;
  }

  public object last() {
    return tail.GetPrev().GetElem();
  }

  public void insertBefore(Node node, object obj) {
    Node new_node = new Node(node.GetPrev(), obj, node); // arrumar
    if (isEmpty()) {
      throw new TadListException("Queue is empty");
    }
    node.GetPrev().SetNext(new_node);
    node.SetPrev(new_node);
    this.len++;
  }

  public void insertAfter(Node node, object obj) {
    Node new_node = new Node(node, obj, node.GetNext()); // arrumar
    if (isEmpty()) {
      throw new TadListException("Queue is empty");
    }
    node.GetNext().SetPrev(new_node);
    node.SetNext(new_node);
    this.len++;
  }

  public Node before(Node node) {
    return node.GetPrev();
  }

  public Node after(Node node) {
    return node.GetNext();
  }

  public object replaceElement(Node old_node, object obj) {
    object temp = old_node.GetElem();
    old_node.SetElem(obj);
    return temp;
  }

  public void swapElement(Node old_node, Node new_node) {
    object obj_temp = old_node.GetElem();
    old_node.SetElem(new_node.GetElem());
    new_node.SetElem(obj_temp);
  }

  public object remove(Node no) {
    object temp = no.GetElem();
    if (isEmpty()) {
      throw new TadListException("Queue is empty");
    }
    no.GetNext().SetPrev(no.GetPrev());
    no.GetPrev().SetNext(no.GetNext());
    this.len--;

    return temp;
  }

  
}

class Program {
  public static void Main (string[] args) {
    TadList test = new TadList();
    Console.WriteLine($"Está vazio? {test.isEmpty()}"); // True
    Console.WriteLine($"Tamanho da lista = {test.size()}"); // 0
    
    
    Node no1 = test.insertFirst(25);
    Console.WriteLine($"No1 é o primeiro? {test.isFirst(no1)}"); // sim 
    Console.WriteLine($"O primeiro elemento da lista é = {test.first()}"); // 25
    Console.WriteLine($"Tamanho da lista = {test.size()}"); // 1
    Node no2 = test.insertLast(40);
    Console.WriteLine($"O último elemento da lista é = {test.last()}"); // 40
    Console.WriteLine($"Tamanho da lista = {test.size()}"); // 2
    Console.WriteLine($"O anterior de No1 é = {test.before(no1)}");
    Console.WriteLine($"Removendo o No com elemento = {test.remove(no1)}");
    Console.WriteLine($"Tamanho da lista = {test.size()}"); // 1
    Console.WriteLine($"O primeiro elemento da lista é = {test.first()}"); // 40
    Console.WriteLine($"O último elemento da lista é = {test.last()}"); // 40
    test.insertAfter(no2, 93);
    test.insertBefore(no2, "ABC");
    Console.WriteLine($"Tamanho da lista = {test.size()}"); // 3
    Console.WriteLine($"O primeiro elemento da lista é = {test.first()}"); // ABC
    Console.WriteLine($"O último elemento da lista é = {test.last()}"); // 93
    Node no3 = test.insertFirst("Coleguinha");
    Console.WriteLine($"O primeiro elemento da lista é = {test.first()}"); // COLEGUINHA
    Console.WriteLine($"Tamanho da lista = {test.size()}"); // 4
    test.replaceElement(no2, 400);
    test.swapElement(no2, no3);
    Console.WriteLine($"O primeiro elemento da lista é = {test.first()}"); // 400
  
  }
}