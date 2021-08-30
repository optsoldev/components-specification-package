# Specification Pattern
Na programação de computadores, o padrão de especificação é um padrão de design de software específico, por meio do qual as regras de negócios podem ser recombinadas encadeando as regras de negócios usando a lógica booleana. O padrão é freqüentemente usado no contexto de design orientado a domínio.

Um padrão de especificação descreve uma regra de negócios que pode ser combinada com outras regras de negócios. Nesse padrão, uma unidade de lógica de negócios herda sua funcionalidade da classe abstrata Composite Specification agregada. A classe Composite Specification tem uma função chamada IsSatisfiedBy que retorna um valor booleano. Após a instanciação, a especificação é "encadeada" com outras especificações, tornando as novas especificações de fácil manutenção, mas com lógica de negócios altamente personalizável. Além disso, na instanciação, a lógica de negócios pode, por meio da invocação de método ou inversão de controle, ter seu estado alterado para se tornar um delegado de outras classes, como um repositório de persistência.

Como consequência da composição do tempo de execução da lógica de negócios / domínio de alto nível, o padrão de especificação é uma ferramenta conveniente para converter critérios de pesquisa de usuário ad-hoc em lógica de baixo nível para serem processados ​​por repositórios.


![Specification_UML.png](/.asserts/Specification_UML.png)

# Referências

[Wikipedia](https://en.wikipedia.org/wiki/Specification_pattern)

[Martin Flower](https://martinfowler.com/apsupp/spec.pdf)