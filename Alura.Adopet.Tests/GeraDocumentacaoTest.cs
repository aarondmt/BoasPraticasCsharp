﻿using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Util;
using System.Reflection;

namespace Alura.Adopet.Tests;

public class GeraDocumentacaoTest
{
    [Fact]
    public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
    {
        //Arrange
        Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!;

        //Act
        Dictionary<string, DocComando> dicionario = DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);

        //Assert
        Assert.NotNull(dicionario);
        Assert.NotEmpty(dicionario);
        Assert.Equal(4, dicionario.Count);
    }
}
