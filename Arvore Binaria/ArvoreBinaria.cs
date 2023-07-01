using System;
using System.Collections;

public class TadArvoreException : Exception {
  public TadArvoreException(string message) : base(message) {}
}

public class ArvoreBinaria {
    Node raiz;
    int length = 0;
    private ArrayList print;


    // Construtor    
    public ArvoreBinaria(object elem) {
        this.raiz = new Node(null, elem);
        this.length++;
    }

    public int Tamanho() { // Tamanho
        return length;
    }

    public bool EstaVazio(Node no) { // Está vazio?
        return no == null;
    }

    public Node Root() { // Retorna o raiz
        return this.raiz;
    }

    public bool Eraiz(Node no) { // Verifica se é o raiz
        return (no == this.raiz);
    }

    public bool Interno(Node no) { // Verifica se é interno
        return no.GetFilhoEsquerdo() != null || no.GetFilhoDireito() != null ;
    }

    public bool Externo(Node no) { // Verifica se é externo
        return no.GetFilhoEsquerdo() == null && no.GetFilhoDireito() == null;
    }

    private Node Pesquisar(Node no, object obj) { // Rodando
        if ((int)obj < (int)no.GetElem()) {
            if(ComparadorEsquerdo(no)){
                return Pesquisar(no.GetFilhoEsquerdo(), obj);
            }else{
                return no;
            }
        } else if ((int)obj == (int)no.GetElem()) {
            return no;
        } else {
            if(ComparadorDireito(no)){
                return Pesquisar(no.GetFilhoDireito(), obj);
            }else{
                return no;
            }
        }
    }

    public Node Incluir(object elem) { // Inserindo elementos 
        Node pai = Pesquisar(raiz, elem);
        Node novo_no = new Node(pai, elem);
        if ((int)elem < (int)pai.GetElem()) {
            pai.SetFilhoEsquerdo(novo_no);
        } else {
            pai.SetFilhoDireito(novo_no);
        }
        length++;
        return novo_no;
    }

    public void EmOrdem(Node no) { // Ordena da esquerda pra direita
        if(Interno(no)) {
            if(no.GetFilhoEsquerdo() != null) {
                EmOrdem(no.GetFilhoEsquerdo());
            }
        }
        print.Add(no.GetElem());
        if(Interno(no)) {
            if(no.GetFilhoDireito() != null) {
                EmOrdem(no.GetFilhoDireito());
            }
        }
    }

    private void Matriz(Node no) { // Ordena da esquerda pra direita
        if(Interno(no)) {
            if(no.GetFilhoEsquerdo() != null) {
                Matriz(no.GetFilhoEsquerdo());
            }
        }
        print.Add(no);
        if(Interno(no)) {
            if(no.GetFilhoDireito() != null) {
                Matriz(no.GetFilhoDireito());
            }
        }
    }

    public void PreOrdem(Node no) { // Visita e segue pro próximo
        print.Add(no);
        if(Interno(no)) {
            if(no.GetFilhoEsquerdo() != null) {
                PreOrdem(no.GetFilhoEsquerdo());
            }
        }
        if(Interno(no)) {
            PreOrdem(no.GetFilhoDireito());
        }
    }

    public void PosOrdem(Node no) { // Segue pro próxim e dps visita
        if(Interno(no)) {
            if(no.GetFilhoEsquerdo() != null) {
                PosOrdem(no.GetFilhoEsquerdo());
            }
        }
        if(Interno(no)) {
            PosOrdem(no.GetFilhoDireito());
        }
        print.Add(no.GetElem());

    }

    public int Altura(Node no) { // Retorna a altura
        if (Externo(no)) {
            return 0;
        } else {
            int altura = 0;
            int altura_filho; 
            if (no.GetFilhoEsquerdo() != null) {
                altura_filho = Altura(no.GetFilhoEsquerdo());
                altura = Math.Max(altura, altura_filho);
            } 
            if (no.GetFilhoDireito() != null) {
                altura_filho = Altura(no.GetFilhoDireito());
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
        if (no == raiz) {
            return 0;
        } 
        else {
            return (1 + this.Fundura(no.GetPai()));
        }
    }

    public void Mostrar() {
        object[,] matriz = new object[Altura(raiz)+1, length];
        print = new ArrayList();
        Matriz(raiz);
        // Console.WriteLine(Altura(raiz)+1);
        // Console.WriteLine(length);
        for (int i = 0; i < length; i++) {
            // int linha = Fundura(print[i]);
            object o = ((Node)print[i]).GetElem();
            matriz[Profundidade((Node)print[i]),i] = o;
        }
        for (int i = 0; i < Altura(raiz)+1; i++) {
            for (int j = 0; j < length; j++) {
                if (matriz[i,j] == null) {
                    Console.Write(" ");
                } else {
                    Console.Write(matriz[i,j]);
                }
                if (j == length - 1) {
                    Console.WriteLine();
                }
            }
        }
    }

    public IEnumerator Nos() { // printa os nós
        print = new ArrayList();
        PreOrdem(raiz);
        return print.GetEnumerator();
    }

    public IEnumerator Elements() { // printa os elementos 
        print = new ArrayList();
        EmOrdem(raiz);
        return print.GetEnumerator();
    }

    public object Remove(object elem) {
        Node no = Pesquisar(raiz, elem);
        Node pai = no.GetPai();
        if (Externo(no)) { // Se o nó for folha, descobre qual que lado ele é filho e anula ele
            if (pai.GetFilhoEsquerdo().Equals(no)) {
                pai.SetFilhoEsquerdo(null);
            } else if (pai.GetFilhoDireito().Equals(no)) {
                pai.SetFilhoDireito(null);
            }
        } else if (Interno(no) && no.GetQntFilhos() == 1) { // Se não houver filho direito, esquerco sobe
            if (no.GetFilhoDireito() == null) { 
                if (Externo(no.GetFilhoEsquerdo())) {
                    no.SetElem(no.GetFilhoEsquerdo().GetElem());
                    no.SetFilhoEsquerdo(null);
                }
            } else if (no.GetFilhoEsquerdo() == null) { // Se houver apenas o filho direito, sobe o nó
                no.GetFilhoDireito().SetPai(no.GetPai());
                no = no.GetFilhoDireito();
                if (pai.GetFilhoEsquerdo().GetElem().Equals(elem)) {
                    pai.SetFilhoEsquerdo(no);
                } else {
                    pai.SetFilhoDireito(no);
                }
            }
        } else if (Interno(no) && no.GetQntFilhos() == 2) { // Se tiver dois filhos, pega o próximo nó
                Node proximo = Proximo(no);
                no.SetElem(proximo.GetElem());
                if (SouFilhoDireito(proximo)){
                    proximo.GetPai().SetFilhoDireito(null);
                } else if (SouFilhoEsquerdo(proximo)) {
                    proximo.GetPai().SetFilhoEsquerdo(null);
                }
            }
        this.length--;
        return elem;
    }

    private bool SouFilhoDireito(Node filho) {
        return filho.GetPai().GetFilhoDireito() == filho;
    } 

    private bool SouFilhoEsquerdo(Node filho) {
        return filho.GetPai().GetFilhoEsquerdo() == filho;
    }

    private Node Proximo(Node no) {
        print = new ArrayList();
        Matriz(raiz);
        for (int i = 0; i < length; i++) {
            if (no.Equals(print[i])) {
                no = (Node)print[i+1];
                break;
            }
        }
        return no;
    }

    public bool ComparadorEsquerdo(Node no) { // comparador esquerdo
        return no.GetFilhoEsquerdo() != null;
    }

    public bool ComparadorDireito(Node no) { // comparador direito
        return no.GetFilhoDireito() != null;
    }
}


public class Node {
    private Node pai;
    private Node filhoDireito = null;
    private Node filhoEsquerdo = null;
    private object elem;
    private int qntFilhos = 0;

    public Node(Node pai, object elem) {
        this.pai = pai;
        this.elem = elem;
    }

    public object GetElem() {
        return this.elem;
    }
    
    public Node GetFilhoDireito() {
        return filhoDireito;
    } 

    public Node GetFilhoEsquerdo() {
        return filhoEsquerdo;
    }

    public void SetFilhoDireito(Node fd) {
        this.filhoDireito = fd;
        this.qntFilhos++;
    }

    public void SetFilhoEsquerdo(Node fe) {
        this.filhoEsquerdo = fe;
        this.qntFilhos++;
    }

    public void SetPai(Node pai) {
        this.pai = pai;
    }

    public Node GetPai() {
        return pai;
    }

    public void SetElem(object key) {
        this.elem = key;
    }

    public int GetQntFilhos() {
        return qntFilhos;
    }

}