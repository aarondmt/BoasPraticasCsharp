namespace Alura.Adopet.Console;

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
                // separa linha usando ponto e vírgula
                string[] propriedades = sr.ReadLine().Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new Pet(Guid.Parse(propriedades[0]),
                propriedades[1],
                TipoPet.Cachorro
                );
                listaDePet.Add(pet);
            }
        }
        return listaDePet;
    }
}
