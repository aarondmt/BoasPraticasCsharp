using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Tests;

public class PetApartirDoCsvTest
{
    [Fact]
    public void QuandoStringForValidaDeveRetornarUmPet()
    {
        //Arrange
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

        //Act
        Pet pet = linha.ConverteDoTexto();

        //Assert
        Assert.NotNull(pet);
    }

    [Fact]
    public void QuandoStringForNulaDeveLancarArgumentNullException()
    {
        //Arrange
        string? linha = null;

        //Act + Assert
        Assert.Throws<ArgumentNullException>(linha.ConverteDoTexto);
    }

    [Fact]
    public void QuandoStringForVaziaDeveLancarArgumentException()
    {
        //Arrange
        string? linha = "";

        //Act + Assert
        Assert.Throws<ArgumentException>(linha.ConverteDoTexto);
    }

    [Fact]
    public void QuandoCamposInsulficienteDeveLancarArgumentException()
    {
        //Arrange
        string? linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";

        //Act + Assert
        Assert.Throws<ArgumentException>(linha.ConverteDoTexto);
    }

    [Fact]
    public void QuandoGuidInvalidaDeveLancarArgumentException()
    {
        //Arrange
        string? linha = "456b24f4-19e2-4423-845d;Lima Limão;1";

        //Act + Assert
        Assert.Throws<ArgumentException>(linha.ConverteDoTexto);
    }

    [Fact]
    public void QuandoTipoDePetInvalidoDeveLancarArgumentException()
    {
        //Arrange
        string? linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;5";

        //Act + Assert
        Assert.Throws<ArgumentException>(linha.ConverteDoTexto);
    }
}
