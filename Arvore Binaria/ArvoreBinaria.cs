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
            EmOrdem(no.GetFilhoDireito());
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

    // public void Mostrar() {
    //     int eixoX, eixoY;
    //     eixoX = (int)Math.Pow(2, (Altura(raiz)) + 1) - 1;
    //     eixoY = Altura(raiz);
    //     // Console.WriteLine(eixoX);
    //     // Console.WriteLine(eixoY);

    // }

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
        Console.WriteLine($"No {no.GetElem()}");
        Console.WriteLine($"Pai {no.GetPai().GetElem()}");
        if (Externo(no)) {
            if (pai.GetFilhoEsquerdo().Equals(no)) {
                pai.SetFilhoEsquerdo(null);
            } else if (pai.GetFilhoDireito().Equals(no)) {
                pai.SetFilhoDireito(null);
            }
        }
        Console.WriteLine($"FE {pai.GetFilhoEsquerdo() == null}");
        Console.WriteLine($"FD {pai.GetFilhoDireito() == null}");
        return elem;
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