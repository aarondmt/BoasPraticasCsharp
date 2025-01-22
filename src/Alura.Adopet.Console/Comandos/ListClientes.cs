using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Alura.Adopet.Console.Comandos;

[DocComando(instrucao: "list-clientes", documentacao: "adopet list-clientes comando que exibe no terminal o conteúdo de clientes na base de dados AdoPet.")]
public class ListClientes : IComando
{
	private readonly IApiService<Cliente> service;

    public ListClientes(IApiService<Cliente> service)
    {
        this.service = service;
    }

    public async Task<Result> ExecutarAsync()
    {
		try
		{
			IEnumerable<Cliente>? clientes = await service.ListAsync();
			return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Listagem dos Clientes!"));
		}
		catch (Exception ex)
		{
			return Result.Fail(new Error("Listagem falhou!").CausedBy(ex));
		}
    }
}
