using System;
using System.Collections;

public class ArvoreSimples {
    
    // Atributos da �rvore
    No raiz;
    
    int tamanho;
    
    // Construtor
    public ArvoreSimples(Object o) { //ok
        this.raiz = new No(null, o);
        this.tamanho = 1;
    }
    
    public No root() { //ok
        return this.raiz;
    }
    
    public No parent(No v) { //ok
        return v.parent();
    }
    
    public IEnumerator children(No v) { //ok
        return v.children();
    }
    
    public bool isInternal(No v) { //ok
        return (v.childrenNumber() > 0);
    }
    
    public bool isExternal(No v) { //ok
        return (v.childrenNumber() == 0);
    }
    
    public bool isRoot(No v) { //ok
        return (v == this.raiz);
    }
    
    public void addChild(No v, Object o) { //ok
        No novo = new No(v, o);
        v.addChild(novo);
        this.tamanho++;
    }
    
    public Object remove(No v) { //ok
        No pai = v.parent();
        if (((pai != null) || this.isExternal(v))) {
            pai.removeChild(v);
        }
        else {
            throw new SystemException();
        }
        
        Object o = v.element();
        this.tamanho--;
        return o;
    }
    
    public void swapElements(No v, No w) { //implementar
        //método exercício
    }
    
    public int depth(No v) { //ok
        int profundidade = this.profundidade(v);
        return profundidade;
    }
    
    private int profundidade(No v) { //ok
        if ((v == this.raiz)) {
            return 0;
        }
        else {
            return (1 + this.profundidade(v.parent()));
        }
        
    }
    
    public int height(No v) { //implementar
        if (isExternal(v)) {
            return 0;
        } else {
        int altura = 0;
        // arrumar o else
        return altura;
        }
    }
    
    public IEnumerator elements() { //implementar
        //método exercício
        return null;
    }
    
    public IEnumerator Nos() { //implementar
          //método exercício
        return null;
    }
    
    public int size() { //implementar
        //método exercício
        return 0;
    }
    
    public bool isEmpty() { //ok
        return raiz.element() == null;
    }
    
    public Object replace(No v, Object o) { //implementar
      //método exercício 
        return null;
    }//implementar
    
      public class No { //ok
        
        private Object o;
        
        private No pai;
        
        private ArrayList filhos = new ArrayList();
        
        public No(No pai, Object o) {
            this.pai = pai;
            this.o = o;
        }
        
        public Object element() {
            return this.o;
        }
        
        public No parent() {
            return this.pai;
        }
        
        public void setElement(Object o) {
            this.o = o;
        }
        
        public void addChild(No o) {
          
          this.filhos.Add(o);
        }
        
        public void removeChild(No o) {
            this.filhos.Remove(o);
        }
        
        public int childrenNumber() {
            return this.filhos.Count;
        }
        
        public IEnumerator children() {
            return this.filhos.GetEnumerator();
        }
    }
}
