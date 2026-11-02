using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Apontador_de_horas
{
    public class ApontadorHoras
    {
        const string BACKSLASH = "-------";
        public static string[] dadosTeste = { "nome,minutos", "lucas,10", "lucas,20", "bianca,40", "jeferson,abc", "lucca,0", "bianca, 67" };
        static void Main(string[] args)
        {
            Console.WriteLine($"{BACKSLASH} Contador de horas {BACKSLASH}");

            foreach ( var item in args)
            { 
                if (Path.Exists(Path.GetFullPath(item)))
                {
                    var pessoas = LerPessoas(File.ReadAllLines(item));
                    foreach(var p in AgruparMinutagemPessoas(pessoas))
                    {
                        Console.WriteLine(p);
                    }
                }
                else
                {
                    var pessoas = LerPessoas(dadosTeste);
                    foreach (var p in AgruparMinutagemPessoas(pessoas))
                    {
                        Console.WriteLine(p);
                    }
                }
            }

            if (args.Length == 0) { var pessoas = LerPessoas(dadosTeste); }
        }
        public static List<(string nome, int minutos)> LerPessoas(string[] linhas)
        {
            var pessoas = new List<(string nome, int minutos)>();

            foreach (string linha in linhas.Skip(1))
            {
                string[] colunas = linha.Split(',');

                if (colunas.Length == 2 && int.TryParse(colunas[1], out var minutos))
                {
                    pessoas.Add((colunas[0], minutos));
                }

            }

            return pessoas;
        }
        public static List<(string nome, int tempoTotal)> AgruparMinutagemPessoas(List<(string nome, int minutos)> pessoas)
        {
            return pessoas
                        .GroupBy(p => p.nome)
                        .Select(grupo => (nome: grupo.Key, tempoTotal: grupo.Sum(p => p.minutos))).ToList();
        }
    }

}
