namespace TestApontadorDeHoras;
using Apontador_de_horas;

public class LeitorCsvTest
{
    [Fact]
    public void LeTextoEConverteMinutos()
    {
        string[] linhas = { "nome,minutos","Ana,30", "Lucas,50", "Ana,30" };

        var pessoas = ApontadorHoras.LerPessoas(linhas);

        Assert.Equal(("Ana", 30), pessoas[0]);
    }

    [Fact]
    public void SomaMinutosDePessoasComMesmoNome()
    {
        var pessoas = new List<(string nome, int minutos)>
        {
            ("Ana", 10),
            ("Ana", 20),
            ("Bia", 5)
        };

        var resultado = ApontadorHoras.AgruparMinutagemPessoas(pessoas);

        Assert.Equal(new[] { ("Ana", 30), ("Bia", 5) }, resultado);
    }

    [Fact]
    public void IgnoraMinutosInvalidos()
    {
        string[] linhas = { "Nome,Minutos", "Ana,abc" };

        var resultado = ApontadorHoras.LerPessoas(linhas);

        Assert.Empty(resultado);
    }

    [Fact]
    public void RetornaListaVaziaQuandoHaApenasCabecalho()
    {
        string[] linhas = { "Nome,Minutos" };

        var resultado = ApontadorHoras.LerPessoas(linhas);

        Assert.Empty(resultado);
    }
}