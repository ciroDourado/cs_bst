using System;

class Principal {


	static void Main() {
		var contatos = new ArvoreBinaria();

		Console.WriteLine( contatos.EstaVazia()?
			"Sua agenda está vazia":
			"Você possui pessoas cadastradas"
		);
		contatos.Inserir(new Pessoa("Ciro"  , "123.456.789-01"));
		contatos.Inserir(new Pessoa("Lara"  , "456.789.012-34"));
		contatos.Inserir(new Pessoa("Ester" , "345.678.901-23"));
		contatos.Inserir(new Pessoa("Daniel", "789.012.345-67"));
		contatos.Inserir(new Pessoa("Nathan", "012.345.678-90"));


		// testando método Contar
		Console.WriteLine( "Contatos cadastrados: {0} ",
			contatos.Contar()
		); // 5 clientes


		// testando método Buscar
		var bia = "Bia";
		Console.WriteLine( "{0} esta cadastrada? {1}",
			bia,
			contatos.Buscar(bia) != null? "Sim":"Nao"
		); // não foi encontrada


		// testando método Remover
		var ciro = "Ciro";
		contatos.Remover(ciro); // encontrado e removido

		Console.WriteLine( "Clientes cadastrados: {0} ",
			contatos.Contar()
		); // 4 clientes
		Console.WriteLine( "{0} esta cadastrado? {1}",
			ciro,
			contatos.Buscar(ciro) != null? "Sim":"Nao"
		); // não foi encontrado (removido)


		// testando método Remover novamente
		var lara = "Lara";
		contatos.Remover(lara); // encontrado e removido

		Console.WriteLine( "Clientes cadastrados: {0} ",
			contatos.Contar()
		); // 3 clientes
		Console.WriteLine( "{0} esta cadastrada? {1}",
			lara,
			contatos.Buscar(lara) != null? "Sim":"Nao"
		); // não foi encontrado (removido)

		
	} // fim da Main


} // fim da classe Principal
