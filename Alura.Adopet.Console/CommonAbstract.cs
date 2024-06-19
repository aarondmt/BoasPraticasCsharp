namespace Alura.Adopet.Console;

internal abstract class CommonAbstract
{
    public HttpClient client;

    protected CommonAbstract(HttpClient client)
    {
        this.client = client;
    }
}
