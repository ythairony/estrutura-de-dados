using System;

public class TadSequenciaException : Exception {
  public TadSequenciaException(string message) : base(message) {}
}

// Nó
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

public class TadSequencia {
  private int len = 0;
  private Node head, tail;

  // Constructor
  public TadSequencia() {
    head = new Node(null, null, null);
    tail = new Node(head, null, null);
    head.SetNext(tail);
  }

  // TadVector Methods
  public bool isEmpty() {
    return head.GetNext() == tail;
  }

  public int size() {
    return len;
  }

  public Node insertRank(int rank, object obj) {
    if (obj == null) {
      throw new TadSequenciaException("You cannot insert null value");
    }
    if (rank < 0 || rank > size()) {
      throw new TadSequenciaException("Index out of range");
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
      throw new TadSequenciaException("TadVector is empty");
    }
    if (rank < 0 || rank >= size()) {
      throw new TadSequenciaException("Index out of range");
    }
    Node node = head.GetNext();
    for (int i = 0; i < rank; i++) {
      node = node.GetNext();
    }
    return node.GetElem();
  }

  public object replaceAtRank(int rank, object obj) {
    if (isEmpty()) {
      throw new TadSequenciaException("TadVector is empty");
    }
    if (rank < 0 || rank >= size()) {
      throw new TadSequenciaException("Index out of range");
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
      throw new TadSequenciaException("TadVector is empty");
    }
    if (rank < 0 || rank >= size()) {
      throw new TadSequenciaException("Index out of range");
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

  // TadList Methods  
  public bool isFirst(Node node) {
    if (isEmpty()) {
      throw new TadSequenciaException("Queue is empty");
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
      throw new TadSequenciaException("Queue is empty");
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
    Node new_node = new Node(node.GetPrev(), obj, node); 
    if (isEmpty()) {
      throw new TadSequenciaException("Queue is empty");
    }
    node.GetPrev().SetNext(new_node);
    node.SetPrev(new_node);
    this.len++;
  }

  public void insertAfter(Node node, object obj) {
    Node new_node = new Node(node, obj, node.GetNext()); 
    if (isEmpty()) {
      throw new TadSequenciaException("Queue is empty");
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
      throw new TadSequenciaException("Queue is empty");
    }
    no.GetNext().SetPrev(no.GetPrev());
    no.GetPrev().SetNext(no.GetNext());
    this.len--;

    return temp;
  }

  //TadSequence Methods
  public Node AtRank(int rank) {
    Node node = head.GetNext();
    for (int i = 0; i < rank; i++) {
      node = node.GetNext();
    }
    return node;
  }

  public int RankOf(Node node) {
    int rank = 0;
    Node no = head.GetNext();
    while (no != node && no != tail) {
      no = no.GetNext();
      rank++;
    }
    return rank;
  }
  
}


class Program {
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
  }
}