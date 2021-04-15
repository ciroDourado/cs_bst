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

	public
	Tabela Remover( string elemento ) {
		var no = this.Buscar(elemento);
		return no != null?
			this.remover(no):
			null;
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


	private
	Tabela remover( NoArvore no ) {

		switch( no.TemQuantosFilhos() ) {
			case 0: this.RemoverFolha(no);     break;
			case 1: this.RemoverPaiDeUm(no);   break;
			case 2: this.RemoverPaiDeDois(no); break;
		}
		return no.Dados();
	} // fim remover


	private
	void RemoverFolha( NoArvore no ) {
		if( no == this.raiz ) this.RemoverRaiz();
		else                  this.removerFolha(no);
	} // fim RemoverFolha


	private
	void RemoverRaiz() {
		this.raiz = null;
	} // fim RemoverRaiz


	private
	void removerFolha( NoArvore no ) {
		var pai = BuscarPaiDe(no);

		if( pai.Esquerda() == no ) {
			pai.Esquerda(null);
		} else pai.Direita(null);
	} // fim removerFolha


	private
	void RemoverPaiDeUm( NoArvore no ) {
		if( no == this.raiz ) this.RemoverRaizComUm();
		else                  this.removerPaiDeUm(no);
	} // fim RemoverPaiDeUm


	private
	void RemoverRaizComUm() {
		if( this.raiz.HaEsquerda() )
			this.raiz  = this.raiz.Esquerda();
		else this.raiz = this.raiz.Direita();
	} // fim RemoverRaizComUm


	private
	void removerPaiDeUm( NoArvore no ) {
		var pai   = BuscarPaiDe(no);
		var filho = no.HaDireita()?
			no.Direita():
		 	no.Esquerda();

		if( pai.Esquerda() == no )
			pai.Esquerda(filho);
		else pai.Direita(filho);
	} // fim removerPaiDeUm


	private
	void RemoverPaiDeDois( NoArvore removido ) {
		var noSubstituto    = removido.NoAnterior();
		var paiNoSubstituto = this.BuscarPaiDe(noSubstituto);

		if( paiNoSubstituto.Esquerda() == noSubstituto ) {
			paiNoSubstituto.Esquerda(null);
		} else paiNoSubstituto.Direita(null);

		noSubstituto.Esquerda( removido.Esquerda());
		noSubstituto.Direita ( removido.Direita ());

		if( removido != this.raiz ) {
			var paiNoRemovido = this.BuscarPaiDe(removido);
			if( paiNoRemovido.Esquerda() == removido ) {
				paiNoRemovido.Esquerda(noSubstituto);
			} else paiNoRemovido.Direita(noSubstituto);
		} else this.raiz = noSubstituto;

		removido.Esquerda(null);
		removido.Direita (null);
	} // fim RemoverPaiDeDois


	private
	NoArvore BuscarPaiDe( NoArvore no ) {
		var noAtual = this.raiz;
		var proximo = noAtual.Proximo(no);

		while( proximo != no ) {
			noAtual = proximo;
			proximo = noAtual.Proximo(no);
		}
		return noAtual;
	} // fim NoPaiDe


} // fim classe ArvoreBinaria
