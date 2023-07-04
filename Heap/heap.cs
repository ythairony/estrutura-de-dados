
// CLASS HEAP
public class Heap {

    Node root;
    Node last_node;
    private int len = 0;

    public Heap() {}

    public Heap(object key) {
        this.root = new Node(null, key);
        this.len++;
        this.last_node = root;
    }

    public int Size() {
        return len;
    }

    public bool IsEmpty() {
        return len == 0;
    }
    
    public bool IsRoot(Node node) {
        return node == root;
    }

    public object Min() {
        return 1;
    }

    public object Key(Node node) {
        return node.GetKey();
    }

    public object Value(Node node) {
        return node.GetValue();
    }

    public Node Insert(object key) {
        Node parent = NextNode(root);
        Node new_node = new Node(parent, key);
        return new_node;
    }

    private Node NextNode(Node node) {
        Node parent = node.GetParent();
        if (parent.GetLeftChild().Equals(node) || IsRoot(parent)) {
            node = parent.GetRightChild();
            return node;
        } else {
            NextNode(node.GetParent());
        }
        return node;
    }

    public object RemoveMin() {
        return root.GetKey();
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

    public Node(Node parent, object key) {
        this.parent = parent;
        this.key = key;
        this.value = key;
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

    public void SetKey(object key) {
        this.key = key;
        this.value = key;
    }
}