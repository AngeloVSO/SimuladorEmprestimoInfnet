namespace SimuladorEmprestimo.Services;

public class EmprestimoService : IEmprestimoService
{
    public object SimularEmprestimo(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentNullException(nameof(nome), "O nome deve ser informado.");
        }

        var random = new Random();
        bool possuiRestricao = random.Next(2) == 0;
        var niveisEmprestimo = new Dictionary<string, decimal>
        {
            { "Bronze", 200000 },
            { "Prata", 400000 },
            { "Ouro", 600000 },
            { "Diamante", 1000000 }
        };
        var nivel = niveisEmprestimo.Keys.ElementAt(random.Next(niveisEmprestimo.Count));
        var valor = niveisEmprestimo[nivel];

        var resposta = new
        {
            Nome = nome,
            EmprestimoAprovado = !possuiRestricao,
            Nivel = nivel,
            Valor = !possuiRestricao ? valor : 0
        };

        return resposta;
    }
}
