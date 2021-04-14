# cs_bst (Binary Search Trees em C#)
Então galerinha, como a descrição e o próprio nome já dizem, esse é um código feito para tentar representar uma árvore binária pra armazenar e buscar itens.

Minha motivação aqui nesse trabalho é justamente aproveitar o melhor de C# para produzir um código limpo, fácil de entender, e que seja extensível a qualquer dado que você queira armazenar.

## Seções

1. [Introdução](https://github.com/ciroDourado/cs_bst#1-introdução)
2. [Aplicando em seu código](https://github.com/ciroDourado/cs_bst#2-aplicando-em-seu-código)
3. [Como usar as árvores](https://github.com/ciroDourado/cs_bst#3-como-usar-as-árvores)
4. [Como criar suas próprias tabelas](https://github.com/ciroDourado/cs_bst#4-como-criar-suas-próprias-tabelas)
5. [Contribuição e agradecimentos](https://github.com/ciroDourado/cs_bst#5-contribuição-e-agradecimentos)

## 1. Introdução

Como eu disse antes, eu disse que esses dados são genéricos. Porém eu disse isso entre aspas, justamente porque meu conceito de dado genérico não é necessariamente relacionado à TIPOS genéricos, e sim relacionado à uma classe abstrata chamada Tabela. 

Eu poderia ter usado apenas Generics? Sim. Eu poderia ter usado alguma outra coisa? Claro que poderia. Mas minha escolha por usar uma classe-pai foi justamente para forçar a implementação de funções para acessar dados específicos para cada caso de conjunto de dados. E não só por isso, minha árvore não deveria se preocupar em qual tipo específico ela armazenaria um dado: qualquer conjunto de dados que você queira armazenar será visto apenas como uma Table pelo nó/árvore.

![]()

Por mais que meu conhecimento em bancos de dados no momento em que escrevo isso (13/04/2021) seja limitado, eu pensei em fazer com que os dados que minhas árvores armazenam se assemelhem à tabelas de BD's, pois a gente nunca irá saber quantos campos cada tabela pode ter, quais serão seus tipos, e etc. Mas alguns detalhes são sempre importantes; citando um deles: qual dado será usado como chave para aquela tabela, a fim de que se possa realizar uma busca apenas comparando aquele campo.

Vale lembrar que todo e qualquer método de busca/percorrer a árvore foi feito usando iteração. Evitei o uso de recursão nas implementações.

**[Voltar para seções](https://github.com/ciroDourado/cs_bst#seções)** 

## 2. Aplicando em seu código

Usar este "módulo" requer nada mais do que incluir estes arquivos no mesmo diretório de seu projeto.
Por exemplo: você está colocando seus códigos-fonte em uma pasta específica, inclua os códigos-fonte de ArvoreBinaria, NoArvore e Tabela da minha pasta src/ também.

De resto, apenas o óbvio. Para compilar todos os arquivos deste diretório, pelo terminal faça:

```
csc /out:[nome_de_seu_executavel] *.cs
```

Caso você utilize o mono, para executar o código seria simplesmente:

```
mono [nome_de_seu_executavel]
```

**[Voltar para seções](https://github.com/ciroDourado/cs_bst#seções)** 

## 3. Como usar as árvores

Um breve resumo:

| Método    | Parâmetro           | Retorno                                              |
|-----------|---------------------|------------------------------------------------------| 
| Inserir   | Instância de Nó*    | Nenhum                                               |
| Inserir   | Instância de Tabela | Nenhum                                               |
| EstaVazia | Nenhum              | Verdadeiro ou falso                                  |
| Contar    | Nenhum              | Número de nós existentes na árvore                   |
| Buscar    | ID do elemento      | Em caso de sucesso: instância do nó; senão: null     |
| Remover   | ID do elemento      | Em caso de sucesso: instância da tabela; senão: null |

###### * Certifique-se de que sua instância de nó contenha uma instância de Tabela.

Você pode tomar como referência o arquivo Principal.cs dentro de src/. Eu estive usando ele para testar meu código no período de desenvolvimento.
Expondo apenas obviedades aqui, toda variável/instância do tipo ArvoreBinaria deve ser inicializada com a sentença new ArvoreBinaria(), ex.:

```
var minhaArvore = new ArvoreBinaria();
```

Com isso você terá em mãos uma árvore vazia. Para inserir elementos, estão disponíveis duas funções Inserir: uma recebe como parâmetro uma instância de Tabela, e outra recebe uma instância de NoArvore. Internamente, o código de árvore insere na verdade instância de nós, as quais encapsulam instâncias de Tabela. Porém, para facilitar a vida do programador (tornando o código bem menos verboso), também é possível passar apenas a instância de Tabela, a qual será colocada dentro de um novo nó alocado.

```
var primeiroNo = new NoArvore(new Tabela(...));
minhaArvore.Inserir(primeiroNo);

// aqui seria um segundo nó
minhaArvore.Inserir(new Tabela(...));
```
Funções de contagem (usando iteração), busca e remoção seguem a mesma lógica; apenas verifique a assinatura dentro dos códigos-fonte.

**[Voltar para seções](https://github.com/ciroDourado/cs_bst#seções)** 

## 4. Como criar suas próprias tabelas

Pois bem, chegamos à parte importante deste módulo: a possibilidade de usar quaisquer conjunto de dados dentro da árvore. Não entrarei em muitos detalhes novamente sobre o porquê eu preferi usar uma classe abstrata chamada Tabela, ao invés de Generics (caso queira ler sobre, volte à seção 1), apenas um entendimento básico é necessário: você pode criar tabelas com quantos campos quiser, de quais tipos quiser; mas *obrigatoriamente* você deve fornecer uma implementação para a função que retorna a chave que servirá de busca.

Independente do campo escolhido para a chave, ou seu tipo, ele deve ser retornado como uma String. Então, caso você escolha um inteiro, ou um número de ponto flutuante, estes deverão ser convertidos para texto.

Seu conjunto de dados, ou tabela específica, deve ser uma nova classe derivada da abstrata Tabela, que fornece uma assinatura sem implementação da função que retorna uma chave. Dentro de sua classe, insira normalmente como atributos todos os campos que compõem sua representação de um objeto do mundo real, como por exemplo:

```
class Xicara: Tabela {
    private string cor;
    private string marca;
    private double altura;
}
```

E digamos que, dentre esses atributos, você quer organizar sua árvore de xícaras com base na marca delas. É aí que entra a necessidade de se implementar o método IdParaBusca(). Dentro de sua classe xícara, declare um método público com a mesma assinatura que está presente em Tabela.cs, e faça:

```
class Xicara: Tabela {
    [...]
    
    public string IdParaBusca() {
        return this.marca;
    }
}
```
Feito isso, agora você tem sua própria tabela de dados para ser usada na árvore. Com esta string retornada, a função de inserção será responsável por organizar seus nós por ordem alfabética.

**[Voltar para seções](https://github.com/ciroDourado/cs_bst#seções)** 

## 5. Contribuição e agradecimentos

Caso você queira fazer algum comentário, sugerir alguma mudança, elogiar ou até mesmo falar mal diretamente kkkkkk mande um e-mail para mim. Ele está como público neste meu perfil. Mas de qualquer forma, meu endereço é: `ciro dot brz at gmail dot com`; lembre-se de trocar os dots e at kkkk

Este é um código feito durante meu tempo livre - mais precisamente nas minhas férias. Como no próximo semestre da faculdade (de novo, estou escrevendo isso no dia 13 de abril de 2021) teremos uma matéria sobre estruturas de dados usando C#, estou aproveitando para aprender a linguagem antes mesmo de começarem as aulas. 

Então, já me perdoem por qualquer erro ou falha besta encontrada. C:

**[Voltar para seções](https://github.com/ciroDourado/cs_bst#seções)** 
