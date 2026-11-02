# Apontador de horas

Aplicativo de console em C# que lê um arquivo CSV com nomes e minutos trabalhados, soma os minutos de cada pessoa e mostra o resultado.

## Requisitos

- .NET 10 SDK

## Formato do arquivo

O arquivo deve ter um cabeçalho na primeira linha. Cada linha seguinte deve conter um nome e um valor inteiro de minutos, separados por vírgula:

```csv
pessoa,minutos
Ana,40
Beto,30
Ana,50
Caio,abc
```

O programa ignora o cabeçalho, agrupa as linhas pelo nome e soma os valores inteiros. Linhas em que o segundo campo não pode ser convertido em inteiro são ignoradas. Com o exemplo acima, os totais válidos são Ana: 90 e Beto: 30; a linha de Caio é ignorada.

## Executar o aplicativo

Abra um terminal nesta pasta e execute:

```powershell
dotnet run --project ".\Apontador de horas.csproj" -- "C:\caminho\para\horas.csv"
```

O caminho do CSV é passado como argumento. Para publicar uma versão compilada, use:

```powershell
dotnet build ".\Apontador de horas.csproj"
```

## Executar os testes

O projeto de testes xUnit fica na pasta irmã `TestApontadorDeHoras` e está incluído na solução `Apontador de horas.slnx`. A partir desta pasta, rode:

```powershell
dotnet test ".\Apontador de horas.slnx"
```

Os testes cobrem:

- leitura e conversão de minutos válidos;
- soma dos minutos quando o nome se repete;
- descarte de uma linha cujo valor de minutos não é inteiro;
- retorno de uma lista vazia quando o arquivo contém somente o cabeçalho.

## Estrutura

- `Apontador de horas.csproj`: aplicativo de console.
- `Program.cs`: leitura das linhas, validação/conversão dos minutos e agrupamento dos totais.
- `../TestApontadorDeHoras/TestApontadorDeHoras.csproj`: projeto de testes xUnit.
- `../TestApontadorDeHoras/LeitorCsvTest.cs`: casos de teste.
- `Apontador de horas.slnx`: solução que reúne o aplicativo e os testes.

## Comportamento atual

Valores que não podem ser convertidos em inteiro são ignorados sem aviso na saída. O código também aceita zero e inteiros negativos. A validação de minutos estritamente positivos e a exibição de um aviso para cada linha inválida ainda não estão implementadas.
