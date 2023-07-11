using System.Collections;

// CLASS HEAP
public class Heap {

    Node root;
    Node last_node;
    private int len = 0;

    //Apagar dps
    public object GetLastNode() {
        return last_node.GetKey();
    }

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
    

    public Node Root() {
        return root;
    }


    // MOSTRAR
    private ArrayList print;

    public bool Externo(Node no) { // Verifica se é externo
        return no.GetLeftChild() == null && no.GetRightChild() == null;
    }


    public bool Interno(Node no) { // Verifica se é interno
        return no.GetLeftChild() != null || no.GetRightChild() != null ;
    }


    public void Mostrar() {
        object[,] matriz = new object[Altura(root)+1, len];
        print = new ArrayList();
        Matriz(root);
        for (int i = 0; i < len; i++) {
            // int linha = Fundura(print[i]);
            object o = ((Node)print[i]).GetKey();
            matriz[Profundidade((Node)print[i]),i] = o;
        }
        for (int i = 0; i < Altura(root)+1; i++) {
            for (int j = 0; j < len; j++) {
                if (matriz[i,j] == null) {
                    Console.Write(" ");
                } else {
                    Console.Write(matriz[i,j]);
                }
                if (j == len - 1) {
                    Console.WriteLine();
                }
            }
        }
    }


    public int Altura(Node no) { // Retorna a altura
        if (Externo(no)) {
            return 0;
        } else {
            int altura = 0;
            int altura_filho; 
            if (no.GetLeftChild() != null) {
                altura_filho = Altura(no.GetLeftChild());
                altura = Math.Max(altura, altura_filho);
            } 
            if (no.GetRightChild() != null) {
                altura_filho = Altura(no.GetRightChild());
                altura = Math.Max(altura, altura_filho);
            }
            return altura + 1;
        }
    }


    public int Profundidade(Node no) { // retorna a fundura
        int profundidade = this.Fundura(no);
        return profundidade;
    }


    private int Fundura(Node no) { // entrega a fundura pra profundidade
        if (no == root) {
            return 0;
        } 
        else {
            return (1 + this.Fundura(no.GetParent()));
        }
    }


    private void Matriz(Node no) { // Ordena da esquerda pra direita
        if(Interno(no)) {
            if(no.GetLeftChild() != null) {
                Matriz(no.GetLeftChild());
            }
        }
        print.Add(no);
        if(Interno(no)) {
            if(no.GetRightChild() != null) {
                Matriz(no.GetRightChild());
            }
        }
    }
    // ACABOU O MOSTRAR


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

        UpHeap(new_node); // fazer o UpHead
        this.last_node = new_node;
        this.len++;
        return new_node;
    }


    private void UpHeap(Node node) {
        while (!IsRoot(node) && (int)node.GetKey() < (int)node.GetParent().GetKey()) {
            SwapKeys(node, node.GetParent());
            node = node.GetParent();
        }
    }

    
    private Node NextNode() {
        Node atual = last_node;

        if (IsRoot(atual)) {
            return atual;
        }

        while (!IsRoot(atual) && !atual.GetParent().GetLeftChild().Equals(atual)) { // enquanto não for filho esquerdo ou root, atualiza com o pai
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
        Node new_last_node = NewLastNode();

        if (last_node.GetParent().GetRightChild() == null) {
            last_node.GetParent().SetLeftChild(null);
        } else {
            last_node.GetParent().SetRightChild(null);
        }

        DownHeap();
        this.len--;
        this.last_node = new_last_node;
        
        return print;
    }


    private Node NewLastNode() {
        Node atual = last_node;

        if (IsRoot(atual)) {
            return atual;
        }

        while (!IsRoot(atual) && atual.GetParent().GetRightChild() == null) { // enquanto não for filho esquerdo ou root, atualiza com o pai
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


    private void DownHeap() {
        Node node = root;
        Node old_node = root;
        while (!Externo(node)) {
            node = Down(node);
            if ((int)node.GetKey() < (int)old_node.GetKey()) {
                SwapKeys(old_node, node); 
            } else { break; }
        }
    }


    private Node Down(Node node) {
        if (Interno(node)) {
            if (node.GetLeftChild() == null && node.GetRightChild() != null) {
                node = node.GetRightChild();
            } else if (node.GetLeftChild() != null && node.GetRightChild() == null){ 
                node = node.GetLeftChild(); 
            } else if ((int)node.GetLeftChild().GetKey() < (int)node.GetRightChild().GetKey()) {
                node = node.GetLeftChild(); 
            } else { 
                node = node.GetRightChild(); 
            }
        }
        return node;
        
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