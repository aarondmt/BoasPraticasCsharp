using Alura.Adopet.Console.Modelos;
using FluentResults;

namespace Alura.Adopet.Console.Results;
public class SuccessWithClientes : Success
{
    public SuccessWithClientes(IEnumerable<Cliente> data, string message) : base(message)
    {
        Data = data;
    }

    public IEnumerable<Cliente> Data { get; }
}
