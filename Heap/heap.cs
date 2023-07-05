
// CLASS HEAP
public class Heap {

    Node root;
    Node last_node;
    private int len = 0;

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
        return root.GetKey();
    }

    public object Key(Node node) {
        return node.GetKey();
    }

    public object Value(Node node) {
        return node.GetValue();
    }

    public Node Insert(object key) {
        Node new_last_node = NextNode();
        Node new_node = new Node(new_last_node, key);
        if (new_last_node.GetChildren() == 0) {
            new_last_node.SetLeftChild(new_node);
            new_last_node.AddChildren();
        } else if (new_last_node.GetChildren() == 1) {
            new_last_node.SetRightChild(new_node);
            new_last_node.AddChildren();
        }
        last_node = new_node;
        return new_node;
    }

    private Node NextNode() {
        Node atual = last_node;
        
        while (!IsRoot(atual) && atual.GetParent().GetRightChild() == null) {
            atual = atual.GetParent();
        }
        if (IsRoot(atual)) {
            atual = root; // Alterei para que returne a própria raiz.
        } else {
            atual = atual.GetParent().GetRightChild();
        }
        while (atual.GetLeftChild() != null) {
            atual = atual.GetLeftChild();
        }
        return atual;
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
    private Node leftChild = null;
    private Node rightChild = null;
    private int children = 0;
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

    public int GetChildren() {
        return children;
    }

    public void SetKey(object key) {
        this.key = key;
        this.value = key;
    }

    public void SetLeftChild(Node node) {
        this.leftChild = node;
    }
    
    public void SetRightChild(Node node) {
        this.rightChild = node;
    }

    public void AddChildren() {
        this.children++;
    }
}