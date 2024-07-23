Requitos para executar a aplicação:
-
  - Angular 17 ou superior: https://v17.angular.io/docs
  - Node.js: https://nodejs.org/en
  - .NET 7: https://dotnet.microsoft.com/pt-br/download/dotnet/7.0

Como executar o projeto:
  -
  - Inicie a aplicação .NET B3.Api em modo debug e modo http
  - Inicie o projeto angular 'ng serve -o'

Stacks utilizadas:
-
  - API:
      - .NET 7
      - FluentValidation: Validação dos inputs do sistema
      - NUnity: Testes unitários

  - Site:
      - Angular 17

Funcionamento:
- 
  - Todas as regras de cálculo de rendimentos foram inseridas nas classes de domínio 'CDBCalculator.cs'
  - Foram aplicadas validações de entrada para não permitir as seguintes regras:
    - O valor do investimento deve ser maior que 0
    - A quantidade de meses deve ser maior que 1
  - O valor do imposto foi armazenado em um array dentro do repositório simulando um tabela no banco de dados por serem valores que podem sofrer alterações ao longo do tempo e não devem ser fixos no código
  - Para realizar um cálculo siga os passos abaixo:
    - Na tela principal preenche os campos 'Valor do investimento' e 'Meses'
    - Pressione o botão 'Calcular'
    - Os resultado bruto e líquido dos rendimentos serão exibidos ao lado
        
  
