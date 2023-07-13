using System.Collections;
using System;

class HeapArrayList{
    private int root;
    private int last_node;
    private int key;
    private int len = 0;
    private ArrayList heap = new ArrayList();

    public HeapArrayList(int key) { 
        this.root = key;
        this.last_node = root;
        len++;
        heap.Add(len);
        heap.Add(key);
    }

    
    public int Size() {
        return (int)heap[0];
    }


    public bool IsEmpty() {
        return len == 0;
    }


    public int Min() {
        return root;
    }


    public int LastNode() {
        return last_node;
    }


    public void Insert(int key) {
        this.heap.Add(key);
        len++;
        this.heap[0] = len;
        UpHeap(key);
        this.last_node = (int)heap[len];
    }


    public void UpHeap(int key) {
        int index = len; 
        int indexaux = len;
        int aux;
        while (index != 1) {
            index = index / 2;
            if (key < (int)heap[index]) {
                aux = (int)heap[index];
                heap[index] = key;
                heap[indexaux] = aux;
                indexaux = index;
            }
        }
    }


    public void ShowTree() {
        Console.Write("{");
        for (int i = 1; i <= len; i++) {
            Console.Write($"[{heap[i]}]");
        }
        Console.Write("}");
    }
}