using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings;
public static class Configurations
{
    private static IConfiguration BuildConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets("d19606d3-e481-4de2-aae1-6087c7877b34")
            .Build();
    }

    public static ApiSettings ApiSettigs
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(ApiSettings.Section)
                .Get<ApiSettings>() ?? throw new ArgumentException("Seção para configuração da API não encontrada!");
        }
    }

    public static MailSettings EmailSettings
    {
        get
        {
            var _config = BuildConfiguration();
            return _config
                .GetSection(MailSettings.Section)
                .Get<MailSettings>() ?? throw new ArgumentException("Seção para configuração do Serviço de Email não encontrado!");
        }
    }
}
