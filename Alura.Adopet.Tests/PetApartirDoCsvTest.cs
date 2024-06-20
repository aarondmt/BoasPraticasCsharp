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
}
