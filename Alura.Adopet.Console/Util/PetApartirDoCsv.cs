using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public static class PetApartirDoCsv
{
    public static Pet ConverteDoTexto(this string? linha)
    {
        if (linha is null) throw new ArgumentNullException("Texto não pode ser nulo.");

        if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Texto não pode ser vázio.");

        string[]? propriedades = linha?.Split(';');
        
        if (propriedades!.Length != 3) throw new ArgumentException("Texto inválido.");
        
        if (!Guid.TryParse(propriedades[0], out Guid petId)) throw new ArgumentException("Guid inválido.");

        if (!int.TryParse(propriedades[2], out int tipoPet)) throw new ArgumentException("Tipo de Pet inálido!");

        if (!Enum.IsDefined(typeof(TipoPet), tipoPet)) throw new ArgumentException("Tipo de Pet inválido.");

        Enum.TryParse(propriedades[2], out TipoPet tipoPetEnum);

        return new(petId, propriedades[1], tipoPetEnum);
    }
}
