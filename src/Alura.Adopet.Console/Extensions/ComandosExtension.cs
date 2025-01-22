using Alura.Adopet.Console.Atributos;
using Alura.Adopet.Console.Comandos;
using System.Reflection;

namespace Alura.Adopet.Console.Extensions;
public static class ComandosExtension
{
    public static Type? GetTipoComando(this Assembly assembly, string instrucao)
    {
        return assembly
            .GetTypes() // lista de tipos
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando))) // filtra apenas os tipos concretos
            .FirstOrDefault(t => t.GetCustomAttributes<DocComandoAttribute>().Any(d => d.Instrucao.Equals(instrucao))); // recupera apenas aquele que atende à instrucao
    }

    public static IEnumerable<IComandoFactory?> GetFabricas(this Assembly assembly)
    {
        return assembly
            .GetTypes()
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComandoFactory))) // filtra os tipos concretos que implementam IComandoFactory
            .Select(f => Activator.CreateInstance(f) as IComandoFactory); // criar instância de cada fábrica (não é o ideal)
    }
}
