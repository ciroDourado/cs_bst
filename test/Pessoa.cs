using System;

public class Pessoa: Tabela {
	// atributos
	private string nome;
    private string cpf;



	// metodos
	public Pessoa() {
		this.nome = String.Empty;
		this.cpf  = String.Empty;
	} // fim construtor padrao

	public Pessoa(string nome, string cpf) {
		this.nome = nome;
		this.cpf  = cpf;
	} // fim construtor

	public override
	string IdParaBusca() {
		return this.nome;
	} // fim IdParaBusca


} // fim classe Pessoa
