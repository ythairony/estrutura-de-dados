
// CLASS HEAP
public class Heap {

    Node raiz;
    private int len;

    public int Size() {
        return len;
    }

    public bool IsEmpty() {
        return true;
    }

    public object Min() {

    }

    public object Key(Node node) {
        return node.GetKey();
    }

    public object Value(Node node) {
        return node.GetValue();
    }

    public Node Insert(Node node, object key) {

    }

    public object RemoveMin() {
        return raiz.GetKey();
    }

    // PERGUNTAR SOBRE COMPARADOR 
    // PERGUNTAR SOBRE ORDENAÇÃO DA FILA 'PQ-SORT'

}


// CLASS NODE 
public class Node {
    private Node parent;
    private Node leftChild;
    private Node rightChild;
    private object key;
    private object value;

    public Node(Node parent, object key, object value) {
        this.parent = parent;
        this.key = key;
        this.value = value;
    }

    public object GetKey() {
        return key;
    }

    public object GetValue() {
        return value;
    }

    public Node GetParent() {
        return parent;
    }

    public Node GetLeftChild() {
        return leftChild;
    }

    public Node GetRightChild() {
        return rightChild;
    }
}