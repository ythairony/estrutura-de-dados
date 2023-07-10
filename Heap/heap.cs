
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
    
    //TESTE COM A Height
    public bool IsExternal(Node node) {
        return node.GetLeftChild() == null && node.GetRightChild() == null;
    }

    public Node Root() {
        return root;
    }

    public int Height(Node no) { // Retorna a Height
        if (IsExternal(no)) {
            return 0;
        } else {
            int height = 0;
            int child_height; 
            if (no.GetLeftChild() != null) {
                child_height = Height(no.GetLeftChild());
                height = Math.Max(height, child_height);
            } 
            if (no.GetRightChild() != null) {
                child_height = Height(no.GetRightChild());
                height = Math.Max(height, child_height);
            }
            return height + 1;
        }
    }

    public bool IsRoot(Node node) {
        return node.Equals(root);
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


    private void SwapKeys(Node node1, Node node2) {
        object aux = node1.GetKey();
        node1.SetKey(node2.GetKey());
        node2.SetKey(aux);
    }


    public Node Insert(object key) {
        Node old_last_node = NextNode();
        Node new_node = new Node(old_last_node, key);

        if (old_last_node.GetLeftChild() == null) {
            old_last_node.SetLeftChild(new_node);
        } else {
            old_last_node.SetRightChild(new_node);
        }

        // UpHeap(new_node); // fazer o UpHead
        this.last_node = new_node;
        this.len++;
        return new_node;
    }


    private void UpHeap(Node node) {
        while ((int)node.GetKey() < (int)node.GetParent().GetKey()) {
            SwapKeys(node, node.GetParent());
            node = node.GetParent();
        }
    }

    
    private Node NextNode() {
        Node atual = last_node;

        if (IsRoot(atual)) {
            return atual;
        }

        while (!IsRoot(atual) && !atual.GetParent().GetLeftChild().Equals(atual)) { // enquanto não for filho esquerdo ou raiz, atualiza com o pai
            atual = atual.GetParent();
        }

        if (!IsRoot(atual) && atual.GetParent().GetRightChild() == null) { // se ele tiver chegado num irmão único, retorna o pai para inserir
            return atual.GetParent();
        } else if (!IsRoot(atual) && atual.GetParent().GetRightChild() != null) { // se tiver irmão direito, atualiza com o mesmo
            atual = atual.GetParent().GetRightChild();
        }

        while (atual.GetLeftChild() != null) { //Vai descendo pelo irmão esquerdo
            atual = atual.GetLeftChild();
        }

        return atual;
    }


    public object RemoveMin() {
        object print = root.GetKey();
        SwapKeys(root, last_node);

        
        return print;
    }


    private Node NewLastNode() {
        Node atual = last_node;

        if (IsRoot(atual)) {
            return atual;
        }

        while (!IsRoot(atual) && !atual.GetParent().GetRightChild().Equals(atual)) { // enquanto não for filho esquerdo ou raiz, atualiza com o pai
            atual = atual.GetParent();
        }

        if (!IsRoot(atual) && atual.GetParent().GetLeftChild() == null) { // se ele tiver chegado num irmão único, retorna o pai para inserir
            return atual.GetParent();
        } else if (!IsRoot(atual) && atual.GetParent().GetLeftChild() != null) { // se tiver irmão direito, atualiza com o mesmo
            atual = atual.GetParent().GetLeftChild();
        }

        while (atual.GetRightChild() != null) { //Vai descendo pelo irmão esquerdo
            atual = atual.GetRightChild();
        }

        return atual;
    }


    private void DownHeap(Node node) {
        // se for menor que os filhos ou ele for folha, para
        // senão 
    }


}


// CLASS NODE 
public class Node {
    private Node parent;
    private Node leftChild = null;
    private Node rightChild = null;
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


    public void SetLeftChild(Node node) {
        this.leftChild = node;
    }

    
    public void SetRightChild(Node node) {
        this.rightChild = node;
    }
}