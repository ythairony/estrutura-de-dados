using System;
using System.Collections;

public class ArvoreSimples {
    
    // Atributos da Árvore
    No raiz;
    
    int tamanho = 0;
    
    // Construtor
    public ArvoreSimples(object o) { //ok
        this.raiz = new No(null, o);
        this.tamanho++;
    }
    
    public No root() { // rodando ok
        return this.raiz;
    }
    
    public No parent(No v) { // rodando ok
        return v.GetPai();
    }
    
    public IEnumerator children(No v) { //rodando ok
        return v.filho();
    }
    
    public bool isInternal(No v) { //rodando ok
        return (v.childrenNumber() > 0);
    }
    
    public bool isExternal(No v) { //rodando ok
        return (v.childrenNumber() == 0);
    }
    
    public bool isRoot(No v) { //ok rodando ok
        return (v == this.raiz);
    }
    
    public void addChild(No v, object o) { //rodando ok
        No novo = new No(v, o);
        v.addChild(novo);
        this.tamanho++;
    }
    
    public object remove(No v) { //ok
        No pai = v.GetPai();
        if (((pai != null) || this.isExternal(v))) {
            pai.removeChild(v);
        }
        else {
            throw new SystemException();
        }
        
        object o = v.GetElem();
        this.tamanho--;
        return o;
    }
    
    public void swapElements(No v, No w) { //implementar
        //método exercício
    }
    
    public int depth(No v) { // rodando ok
        int profundidade = this.profundidade(v);
        return profundidade;
    }
    
    private int profundidade(No v) { // rodando ok
        if ((v == this.raiz)) {
            return 0;
        }
        else {
            return (1 + this.profundidade(v.GetPai()));
        }
        
    }
    
    public int height(No v) { //parcialmente rodando
        if (isExternal(v)) {
            return 0;
        } else {
        int altura = 0;
        for (int i = 0; i < v.childrenNumber(); i++) {
            int altura_filho = height(v.GetFilho(i));
            altura = Math.Max(altura, altura_filho);
        }
        return altura + 1;
        }
    }
    
    public IEnumerator elements() { //implementar
        //Verificar se o No tem filhos, se tiver faz recursivo
        //Ou verificar se é externo
        return null;
    }
    
    public IEnumerator Nos() { //implementar
          //método exercício
        return null;
    }
    
    public int size() { // rodando ok
        return tamanho;
    }
    
    public bool isEmpty() { // rodando ok
        return raiz.GetElem() == null;
    }
    
    public object replace(No v, object o) { //implementar
      //método exercício 
        return null;
    }
    
      public class No { //ok
        
        private object elem;
        
        private No pai;
        
        private ArrayList filhos = new ArrayList();
        
        public No(No pai, object o) {
            this.pai = pai;
            this.elem = o;
        }
        
        public Object GetElem() { // retorna o elemento do nó
            return this.elem;
        }
        
        public No GetPai() { // retorna o pai do nó
            return this.pai;
        }

        public No GetFilho(int i) {
            return (ArvoreSimples.No)filhos[i];
        }
        
        public void SetElement(Object o) { // setta o elemento do nó
            this.elem = o;
        }
        
        public void addChild(No o) { // adiciona um filho ao nó
          this.filhos.Add(o);
        }
        
        public void removeChild(No o) { // remove um filho do nó
            this.filhos.Remove(o);
        }
        
        public int childrenNumber() { // conta quantos filhos tem o nó
            return this.filhos.Count;
        }
        
        public IEnumerator filho() { // retorna os filhos do nó
            return this.filhos.GetEnumerator();
        }
    }
}
