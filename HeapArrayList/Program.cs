using System;

class Program {
    static void Main(string[] args) {
        HeapArrayList h = new HeapArrayList(3);
        h.Insert(2);
        h.ShowTree();
    }
}
