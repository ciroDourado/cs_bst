using System;

class Principal {


	static void Main() {
		var clientes = new ArvoreBinaria();

		Console.WriteLine( clientes.EstaVazia()?
			"O cadastro de clientes esta vazio":
			"O sistema possui clientes cadastrados"
		);
		clientes.Inserir(new Cliente("Ciro"  , "123.456.789-01"));
		clientes.Inserir(new Cliente("Lara"  , "456.789.012-34"));
		clientes.Inserir(new Cliente("Ester" , "345.678.901-23"));
		clientes.Inserir(new Cliente("Daniel", "789.012.345-67"));
		clientes.Inserir(new Cliente("Nathan", "012.345.678-90"));

		Console.WriteLine( "Clientes cadastrados: {0} ",
			clientes.Contar()
		); // 5 clientes

		var ana = "Ana";
		Console.WriteLine( "{0} esta cadastrada? {1}",
			ana,
			clientes.Buscar(ana) != null? "Sim":"Nao"
		); // não foi encontrada

		var ciro = "Ciro";
		clientes.Remover(ciro); // encontrado e removido

		Console.WriteLine( "Clientes cadastrados: {0} ",
			clientes.Contar()
		); // 4 clientes
		Console.WriteLine( "{0} esta cadastrado? {1}",
			ciro,
			clientes.Buscar(ciro) != null? "Sim":"Nao"
		); // não foi encontrado (removido)
	} // fim da Main


} // fim da classe Principal
