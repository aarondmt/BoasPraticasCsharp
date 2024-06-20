using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

internal class LeitorDeArquivo
{
    public List<Pet> RealizaLeitura(string caminhoDoArquivoASerLido)
    {
        List<Pet> listaDePet = new();
        using (StreamReader sr = new(caminhoDoArquivoASerLido))
        {
            System.Console.WriteLine("----- Serão importados os dados abaixo -----");
            while (!sr.EndOfStream)
            {
                Pet pet = sr.ReadLine()?.ConverteDoTexto();
                listaDePet.Add(pet);
            }
        }
        return listaDePet;
    }
}
