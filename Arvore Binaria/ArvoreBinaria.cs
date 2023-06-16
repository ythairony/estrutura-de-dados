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

    public bool EstaVazio() { // Está vazio?
        return raiz.GetElem() == null;
    }

    public Node root() { // Retorna o raiz
        return this.raiz;
    }

    public bool Eraiz(Node no) { // Verifica se é o raiz
        return (no == this.raiz);
    }

    public void SetComparator(Comparador c) {

    }

    public int GetComparator() {
        return 1;
    }

    public Node Pesquisar(Node no, object chave) {
        return null;
    }

    public Node Incluir(Node pai, object elem) { // funcionando
        Node novo = new Node(pai, elem);
        if (TemFilhoEsquerdo(pai) == false) {
            pai.SetFilhoEsquerdo(novo);
        } 
        else if (TemFilhoDireito(pai) == false) {
            pai.SetFilhoDireito(novo);
        } 
        else {
            throw new TadArvoreException($"{pai.GetElem()} já possui 2 filhos");
        }
        this.length++;
        return novo;
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
    private Node filhoDireito, filhoEsquerdo;
    private object elem;

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

    public object GetChave() {
        return null;
    }

    public void SetFilhoDireito(Node fd) {
        this.filhoDireito = fd;
    }

    public void SetFilhoEsquerdo(Node fe) {
        this.filhoEsquerdo = fe;
    }

    public void SetPai(Node pai) {

    }

    public void SetElem(object key) {
        this.elem = key;
    }

}