using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComandoAttribute(instrucao: "import-clientes",
        documentacao: "adopet import-clientes <ARQUIVO> comando que realiza a importação do arquivo de clientes.")]
public class ImportClientes : IComando
{
    private IApiService<Cliente> apiService;
    private ILeitorDeArquivos<Cliente> leitorDeArquivos;

    public ImportClientes(IApiService<Cliente> apiService, ILeitorDeArquivos<Cliente> leitorDeArquivos)
    {
        this.apiService = apiService;
        this.leitorDeArquivos = leitorDeArquivos;
    }

    public async Task<Result> ExecutarAsync()
    {
        try
        {
            var lista = leitorDeArquivos.RealizaLeitura();
            foreach (var cliente in lista)
            {
                await apiService.CreateAsync(cliente);
            }
            return Result.Ok().WithSuccess(new SuccessWithClientes(lista, "Importação realizada com sucesso!"));
        }
        catch (Exception ex)
        {
            return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
        }
    }
}
