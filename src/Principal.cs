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

		Console.WriteLine(
			"Clientes cadastrados: {0} ",
			clientes.Contar()
		);
		var nome = "Memphis";
		Console.WriteLine(
			"{0} esta cadastrado/cadastrada? {1}", nome,
			clientes.Buscar(nome) != null? "Sim":"Nao"
		);
	} // fim da Main


} // fim da classe Principal
