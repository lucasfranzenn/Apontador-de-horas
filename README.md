# Apontador de horas

Aplicativo de console em C# que lê um CSV com nomes e minutos trabalhados, soma os minutos de cada pessoa e apresenta os totais.

## Requisitos

- .NET 10 SDK

## Formato do arquivo

A primeira linha é o cabeçalho. As demais linhas contêm um nome e os minutos, separados por vírgula:

```csv
pessoa,minutos
Ana,40
Beto,30
Ana,50
Caio,abc
```

O programa ignora o cabeçalho, agrupa os registros pelo nome e soma os valores inteiros. Linhas com minutos que não podem ser convertidos em inteiro são ignoradas. No exemplo, Ana totaliza 90 minutos e Beto, 30; a linha de Caio é ignorada.

## Executar o aplicativo

Na raiz do repositório, rode:

```powershell
dotnet run --project ".\Apontador de horas\Apontador de horas.csproj" -- "C:\caminho\para\horas.csv"
```

Para compilar o aplicativo:

```powershell
dotnet build ".\Apontador de horas\Apontador de horas.csproj"
```

## Executar os testes

O projeto xUnit `TestApontadorDeHoras` está incluído na solução. Na raiz do repositório, execute:

```powershell
dotnet test ".\Apontador de horas\Apontador de horas.slnx"
```

Os testes cobrem leitura e conversão de minutos válidos, soma de registros com o mesmo nome, descarte de minutos inválidos e arquivo que contém somente o cabeçalho.

## Estrutura

- `Apontador de horas/Program.cs`: leitura do CSV e cálculo dos totais.
- `Apontador de horas/Apontador de horas.csproj`: aplicativo de console.
- `Apontador de horas/Apontador de horas.slnx`: solução com o aplicativo e o projeto de testes.
- `TestApontadorDeHoras/LeitorCsvTest.cs`: testes unitários xUnit.
- `TestApontadorDeHoras/TestApontadorDeHoras.csproj`: configuração do projeto de testes.

## Limitações atuais

Valores que não podem ser convertidos em inteiro são ignorados sem aviso. O aplicativo também aceita zero e números negativos; a validação para aceitar somente minutos positivos ainda não foi implementada.
