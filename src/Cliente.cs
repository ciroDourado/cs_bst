using System;

public class Cliente: Tabela {
	// atributos
	private string nome;
    private string cpf;



	// metodos
	public Cliente() {
		this.nome = String.Empty;
		this.cpf  = String.Empty;
	} // fim construtor padrao

	public Cliente(string nome, string cpf) {
		this.nome = nome;
		this.cpf  = cpf;
	} // fim construtor

	public override
	string IdParaBusca() {
		return this.nome;
	} // fim IdParaBusca


} // fim classe Cliente
