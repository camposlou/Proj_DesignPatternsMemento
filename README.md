# Proj_DesignPatternsMemento<h2>

Memento é um Design Patterns de Padrão Comportamental, usado quando você deseja salvar um instântaneo(snapshot) dos valores de propriedades
para permitir que o usuário altere esses valores e desfaça suas alterações.

Existem 3 componentes principais no Memento:

♦ Originator - que é uma classe onde vamos acompanhar suas mudanças;

♦ Memento - uma classe que tem o snapshot dos valores do Originator em diferentes estados no tempo, sem violar a integridade dos valores originais (cria histórico);

♦ Caretaker - que gerencia o salvamento e a restauração de Mementos.


Nas funções do Caretaker(Zelador) encontramos: 

• Função Salvar Estado Atual: o que ela faz é adicionar um novo objeto Memento ("LembrancaCliente"), passando o objeto atual para a variável memento ("lembrancascliente")
Este novo objeto Memento("LembrancaCliente") instanciará um desses objetos da Classe Memento ("LembrancaCliente") e salva as propriedades do metodo construtor Memento: ("LembrancaCliente"), 
e assim que tivermos esse objeto vamos adicioná-los na variável memento ("lembrancascliente") pra que possamos fazer nossas reversões, se necessário.
Como chamamos a função "Salvar Estado Atual" no método construtor Memento ("Classe Cliente"), a variável memento ("lembrancascliente") deve sempre ter o estado original com o qual foi
instaciado na lista (List<LembrancaCliente>lembrancascliente = new();)
Por ser uma função pública, isso é algo que pode ser chamado pelo resto do programa. Portanto, esse programa permite que o usuário edite um objeto da classe Memento ("Cliente"), 
e podemos acionar o método Salvar varias vezes enquanto os usuários estão fazendo alterações.

• Função Reverter Valor Original: o que ela faz é obter a primeira lembrança (sempre deve haver uma) do memento ("lembrancascliente"). Define através da função ("DefinirValoresLembranca") os valores da propriedade 
do memento ("lembrancascliente") passando para a variável "firstLembranca". Remove todas as lembranças exceto a primeira, pois estamos revertendo o estado atual para a primeira lembrança e
voltamos para primeira alteração, por isso não precisamos de alterações extras.

• Função Voltar Ao Valor Anterior: Bem similar a função descrita anteriormente, nesta função retornamos ao instantâneo valor anterior da propriedade do objeto da última lembrança, ou seja, retorna uma alteração anterior feita.
Remove a última lembrança, a menos que ela seja a primeira.

• Função VerifContaminado: como tiramos o valor do objeto quando ele é instanciado, criado pela primeira vez e salvamos na lista, na variável memento ("lembrancascliente"), podemos ver se o estado Atual do "Cliente" é 
diferente do estado Original. Caso contrário, vamos considerar esse objeto Cliente como contaminado. Isso pode ser algo que podemos usar para indicar que o objeto tem alterações e precisa ser salvo no Banco de Dados
Esta função acaba não sendo obrigatório no Memento, mas podendo ser acrescentado.


Conclusão Final: Neste programa, coloquei duas classes num arquivo.cs para que minha Classe Privada Memento("LembrancaCliente") fique oculta do resto do programa. Dessa forma estou garantindo o Encapsulamento da minha classe Memento("LembrancaCliente"). 
O resto do programa não sabe como está acontecendo, eles apenas sabem que podem chamar essas funções e o objeto faz o que deve fazer.

  

"PÓS E CONTRAS DESTE PADRÃO COMPORTAMENTAL MEMENTO"

[PÓS]
  
• Você pode produzir instantâneos do estado do objeto sem violar seu encapsulamento.
  
• Você pode simplificar o código do originador deixando o zelador manter o histórico do estado do originador.

[CONTRA] 
  
• O aplicativo pode consumir muita RAM se os clientes criarem lembranças com muita frequência.
  
• Os zeladores devem acompanhar o ciclo de vida do originador para poder destruir lembranças obsoletas.
  
• A maioria das linguagens de programação dinâmicas, como PHP, Python e JavaScript, não podem garantir que o estado dentro do memento permaneça intocado.



