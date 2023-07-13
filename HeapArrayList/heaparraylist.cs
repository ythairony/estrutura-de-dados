using System.Collections;
using System;

class HeapArrayList{
    private int root;
    private int last_key;
    // private int key;
    private int len = 0;
    private ArrayList heap = new ArrayList();

    public HeapArrayList(int key) { 
        this.root = key;
        this.last_key = root;
        len++;
        heap.Add(null);
        heap.Add(key);
    }

    
    public int Size() {
        return len;
    }


    public bool IsEmpty() {
        return len == 0;
    }


    public int Min() {
        return root;
    }


    public int LastNode() {
        return last_key;
    }


    public void Insert(int key) {
        this.heap.Add(key);
        len++;
        // this.heap[0] = len;
        UpHeap(key);
        this.last_key = (int)heap[len];
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


    public int RemoveMin() {
        int value = (int)heap[1];
        this.heap[1] = heap[len];
        this.heap.RemoveAt(len);
        this.len--;
        // this.heap[0] = len;
        DownHeap((int)heap[1]);
        this.last_key = (int)heap[len];
        return value;
    }


    public void DownHeap(int last_key) {
        int index = 2;
        int indexaux = 1;
        int aux, min, indexmin;
        while (index <= len) {
            if (index == len) {
                min = (int)heap[index];
            } else {
                min = Math.Min((int)heap[index], (int)heap[index+1]);
            }
            indexmin = heap.IndexOf(min);
            if (last_key > min) {
                aux = last_key;
                heap[indexaux] = min;
                heap[indexmin] = aux;
                indexaux = indexmin;
                index = indexmin;
            }
            index = index * 2;
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