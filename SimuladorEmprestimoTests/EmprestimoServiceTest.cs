using SimuladorEmprestimo.Services;

namespace SimuladorEmprestimoTests;

public class EmprestimoServiceTest
{
    private readonly EmprestimoService _service = new();

    [Fact]
    public void SimularEmprestimo_DeveRetornarResultado_QuandoNomeForValido()
    {
        const string nome = "Angelo Sobral";

        var sut = _service.SimularEmprestimo(nome);

        Assert.NotNull(sut);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void SimularEmprestimo_DeveLancarArgumentNullException_QuandoNomeForInvalido(string nome)
    {
        const string mensagemEsperada = "O nome deve ser informado.";

        var exception = Assert.Throws<ArgumentNullException>(() => _service.SimularEmprestimo(nome));

        Assert.Contains(mensagemEsperada, exception.Message);
        Assert.Equal("nome", exception.ParamName);
    }
}