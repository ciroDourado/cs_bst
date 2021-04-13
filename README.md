# cs_bst
Então galerinha, como a descrição e o próprio nome já dizem, esse é um código feito para tentar representar uma árvore binária pra armazenar e buscar itens.

Minha motivação aqui nesse trabalho é justamente aproveitar o melhor de C# para produzir um código limpo, fácil de entender, e que seja extensível a qualquer dado que você queira armazenar.

Como eu disse antes, eu disse que esses dados são genéricos. Porém eu disse isso entre aspas, justamente porque meu conceito de dado genérico não é necessariamente relacionado à TIPOS genéricos, e sim relacionado à uma classe abstrata chamada Tabela. 

Eu poderia ter usado apenas Generics? Sim. Eu poderia ter usado alguma outra coisa? Claro que poderia. Mas minha escolha por usar uma classe-pai foi justamente para forçar a implementação de funções para acessar dados específicos para cada caso de conjunto de dados. E não só por isso, minha árvore não deveria se preocupar em qual tipo específico ela armazenaria um dado: qualquer conjunto de dados que você queira armazenar será visto apenas como uma Table pelo nó/árvore.

Por mais que meu conhecimento em bancos de dados no momento em que escrevo isso (13/04/2021) seja limitado, eu pensei em fazer com que os dados que minhas árvores armazenam se assemelhem à tabelas de BD's, pois a gente nunca irá saber quantos campos cada tabela pode ter, quais serão seus tipos, e etc. Mas alguns detalhes são sempre importantes; citando um deles: qual dado será usado como chave para aquela tabela, a fim de que se possa realizar uma busca apenas comparando aquele campo.

Enfim, quaisquer dúvidas/sugestões sobre uso ou implementação, sintam-se livres para me contatar.
