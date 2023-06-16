using System;
using System.Collections;

public class TadArvoreException : Exception {
  public TadArvoreException(string message) : base(message) {}
}

public class ArvoreBinaria {
    Node raiz;
    int length = 0;


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

    public Node root() { // Retorna o raiz
        return this.raiz;
    }

    public bool Eraiz(Node no) { // Verifica se é o raiz
        return (no == this.raiz);
    }

    private Node Pesquisar(Node no, object obj) { // implementado
        Node novo_no = new Node(no, obj);
        if ((int)obj < (int)no.GetElem()) {
            if (no.GetFilhoEsquerdo() == null) {
                no.SetFilhoEsquerdo(novo_no);
                this.length++;
            } else {
                no = no.GetFilhoEsquerdo();
                Pesquisar(no, obj);
            }
        }
        if ((int)obj > (int)no.GetElem()) {
            if (no.GetFilhoDireito() == null) {
                no.SetFilhoDireito(novo_no);
                this.length++;
            } else {
                no = no.GetFilhoDireito();
                Pesquisar(no, obj);
            }
        }
        novo_no.SetPai(no);
        return novo_no;
    }

    public Node Incluir(object elem) { // Implementado 
        Node novo_no = Pesquisar(raiz, elem);
        return novo_no;
    }

    public void EmOrdem(Node no) {

    }

    public void PreOrdem(Node no) {
        
    }

    public void PosOrdem(Node no) {
        
    }

    public int Altura(Node no) {
        return 1;
    }

    public int Profundidade(Node no) {
        int profundidade = this.Fundura(no);
        return profundidade;
    }

    private int Fundura(Node no) {
        if (no == raiz) {
            return 0;
        } 
        else {
            return (1 + this.Fundura(no.GetPai()));
        }
    }

    public void Mostrar() {

    }

    public IEnumerable Nos() {
        return null;
    }

    public IEnumerator Elements() {
        return null;
    }

    public Node FilhoDireito(Node pai) { // Falta testar
        return pai.GetFilhoDireito();
    }

    public Node FilhoEsquerdo(Node pai) { // Falta testar
        return pai.GetFilhoEsquerdo();
    }

    public bool TemFilhoDireito(Node pai) { // Falta testar
        return (pai.GetFilhoDireito() != null);
    }

    public bool TemFilhoEsquerdo(Node pai) { // Falta testar
        return (pai.GetFilhoEsquerdo() != null);
    }
}

public class Comparador {

}

public class Node {
    private Node pai;
    private Node filhoDireito = null;
    private Node filhoEsquerdo =  null;
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

}