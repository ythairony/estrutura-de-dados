using System;
using System.Collections;

public class ArvoreBinaria {
    Node raiz;
    int length = 0;


    public void SetComparator(Comparador c) {

    }

    public int GetComparator() {
        return 1;
    }

    public Node Pesquisar(Node no, object chave) {
        return null;
    }

    public Node Incluir(object key) {
        return null;
    }

    public Node GetRaiz() {
        return raiz;
    }

    public void SetRaiz() {

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
        return 1;
    }

    public void Mostrar() {

    }

    public IEnumerable Nos() {

    }

    public IEnumerator Elements() {

    }

    public int Size() {

    }

    public bool EstaVazio() {
        
    }
}

public class Comparador {

}

public class Node {
    
    
    public Node GetFilhoDireito() {
        return null;
    } 

    public Node GetFilhoEsquerdo() {
        return null;
    }

    public object GetChave() {
        return null;
    }

    public void SetFilhoDireito(Node fd) {

    }

    public void SetFilhoEsquerdo(Node fe) {
        
    }

    public void SetPai(Node pai) {

    }

    public void SetChave(object key) {

    }
}