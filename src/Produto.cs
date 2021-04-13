#pragma warning disable CS0414
using System;

public class Produto: Tabela {
	// atributos
	private string nome;
    private string descricao;
    private string codigo;
    private int    estoque;
    private double valorUnitario;



	// metodos
	public Produto() {
		this.codigo        = String.Empty;
        this.nome          = String.Empty;
        this.descricao     = String.Empty;
		this.estoque       = 0;
		this.valorUnitario = 0.0;
	} // fim construtor padrao

	public Produto(string nome, string codigo) {
		this.nome   = nome;
		this.codigo = codigo;

        this.estoque       = 0;
        this.valorUnitario = 0.0;
		this.descricao     = String.Empty;
	} // fim construtor

	public override
	string IdParaBusca() {
		return this.codigo;
	} // fim IdParaBusca


} // fim classe Cliente
