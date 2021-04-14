using System;
using System.Collections.Generic;

class ArvoreBinaria {
	// atributos
	private	NoArvore raiz;



	// metodos abertos
	public
	ArvoreBinaria() {
		this.raiz = null;
	} // fim construtor padrao

	public
	bool EstaVazia() {
		return this.raiz == null;
	} // fim EstaVazia

	public
	void Inserir( Tabela dados ) {
		this.Inserir(new NoArvore(dados));
	} // fim Inserir a partir da tabela

	public
	void Inserir( NoArvore no ) {
		if ( this.EstaVazia() ) this.InserirRaiz(no);
		else                    this.InserirNo(no);
	} // fim Inserir a partir de no

	public
	int Contar() {
		return this.EstaVazia()?
			0:
			this.prepararContagem();
	} // fim Contar

	public
	NoArvore Buscar( string elemento ) {
		return this.EstaVazia()?
			null:
			this.buscar(elemento);
	} // fim Buscar

	Tabela Remover( string elemento ) {
		// implementar
		return null;
	} // fim Remover, e retornar os dados




	// metodos fechados
	private
	void InserirRaiz( NoArvore novoNo ) {
		this.raiz = novoNo;
	} // fim InserirRaiz


	private
	void InserirNo( NoArvore novoNo ) {
		var pai  = this.BuscarPaiPara(novoNo);
		if( pai.Comparar(novoNo) < 0 ) {
			pai.Esquerda(novoNo);
		} else { pai.Direita(novoNo); }
	} // fim InserirNo


	private
	NoArvore BuscarPaiPara( NoArvore novoNo ) {
		NoArvore atual = this.raiz;
		var proximoNo  = novoNo.AssumeQualRamoDo(atual);

		while( proximoNo != null ) {
			atual     = proximoNo;
			proximoNo = novoNo.AssumeQualRamoDo(atual);
		}
		return atual;
	} // fim BuscarPaiPara


	private
	int prepararContagem() {
		var nos = new Stack<NoArvore>();
			nos.Push(this.raiz);

		return this.contar(nos, 0);
	} // fim prepararContagem


	private
	int contar(Stack<NoArvore> nos, int contagem) {
		while( nos.Count != 0 ) {
			NoArvore no = nos.Pop();
			contagem ++;

			if( no.HaEsquerda() ) nos.Push(no.Esquerda());
			if( no.HaDireita()  ) nos.Push(no.Direita() );
		}
		return contagem;
	} // fim contar


	private
	NoArvore buscar( string idBuscado ) {
		var noAtual = this.raiz;

		while(  noAtual != null  ) {
			if( noAtual.ID().Equals(idBuscado) ) break;
			noAtual = noAtual.Proximo(idBuscado);
		}
		return noAtual;
	} // fim buscar

} // fim classe ArvoreBinaria
