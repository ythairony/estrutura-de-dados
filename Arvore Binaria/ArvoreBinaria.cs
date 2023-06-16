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

    public Node Pesquisar(Node no, object obj) {
        Node novo_no = new Node(no, obj);
        if ((int)obj < (int)no.GetElem()) {
            if (no.GetFilhoEsquerdo() == null) {
                no.SetFilhoEsquerdo(novo_no);
            } else {
                Pesquisar(no, obj);
            }
        }
        return novo_no;
    }

    // public void SetComparator(Comparador c) {

    // }

    // public int GetComparator() {

    //     return 1;
    // }


    public Node Incluir(object elem) { 
        Node novo_no = new Node(null, elem);
        return novo_no;
    }

    // public Node GetRaiz() {
    //     return raiz;
    // }

    // public void SetRaiz() {

    // }

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
        return 1;
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

    }

    public void SetElem(object key) {
        this.elem = key;
    }

}