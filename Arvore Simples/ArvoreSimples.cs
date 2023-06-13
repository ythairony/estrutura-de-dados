using System;
using System.Collections;

public class ArvoreSimples {
    
    // Atributos da Árvore
    No raiz;
    
    int tamanho = 0;

    private ArrayList a;
    
    // Construtor
    public ArvoreSimples(object o) { //ok
        this.raiz = new No(null, o);
        this.tamanho++;
    }
    
    public No root() { // raiz
        return this.raiz;
    }
    
    public No parent(No v) {  // retornar o pai
        return v.GetPai();
    }
    
    public IEnumerator children(No v) { // Iterar os filhos
        return v.filho();
    }
    
    public bool isInternal(No v) { // É nó interno?
        return (v.childrenNumber() > 0);
    }
    
    public bool isExternal(No v) { // É nó externo?
        return (v.childrenNumber() == 0);
    }
    
    public bool isRoot(No v) { // É nó raiz?
        return (v == this.raiz);
    }
    
    public No addChild(No v, object o) { // Adicionado filho
        No novo = new No(v, o);
        v.addChild(novo);
        this.tamanho++;
        return novo;
    }
    
    public object remove(No v) { // removendo nó
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
    
    public void swapElements(No v, No w) { // Trocando nós de posição
        object aux = w.GetElem();
        w.SetElement(v.GetElem());
        v.SetElement(aux);
    }
    
    public int depth(No v) { // retornando profundidade
        int profundidade = this.profundidade(v);
        return profundidade;
    }
    
    private int profundidade(No v) { // private do depth
        if ((v == this.raiz)) {
            return 0;
        }
        else {
            return (1 + this.profundidade(v.GetPai()));
        }
        
    }
    
    public int height(No v) { // retornando altura
        if (isExternal(v)) {
            return 0;
        }else {
            int altura = 0;
            for (int i = 0; i < v.childrenNumber(); i++) {
                int altura_filho = height(v.GetFilho(i));
                altura = Math.Max(altura, altura_filho);
        }
        return altura + 1;
        }
    }
    
    public IEnumerator elements() { // mostrar elementos
        a = new ArrayList();
        preOrderE(root());
        return a.GetEnumerator();
    }
    
    public IEnumerator nos() { // mostra nós
        a = new ArrayList();
        preOrderN(root());
        return a.GetEnumerator();
    }

    private void preOrderE(No v) { //pre order de element
        No novo = v;
        a.Add(v.GetElem());           
        for (int i = 0; i < v.childrenNumber(); i++) {
            novo = v.GetFilho(i);
            preOrderE(novo);
        }
    }

    public void preOrderN(No v) { // pre order de nós
        No novo = v;
        a.Add(v);        
        for (int i = 0; i < v.childrenNumber(); i++) {
            novo = v.GetFilho(i);
            preOrderN(novo);
        }
    }
    
    public int size() { // tamanho
        return tamanho;
    }
    
    public bool isEmpty() { // está vazio?
        return raiz.GetElem() == null;
    }
    
    public object replace(No v, object o) { //implementar
        object aux = v.GetElem();
        v.SetElement(o); 
        return aux;
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
