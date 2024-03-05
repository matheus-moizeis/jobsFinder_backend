namespace JobsFinder.Communication.Response;
public class ResErrorJson
{
    public List<string> Mensagens { get; set; }

    public ResErrorJson(string mensagem)
    {
        Mensagens = new List<string>
        {
            mensagem
        };
    }

    public ResErrorJson(List<string> mensagens)
    {
        Mensagens = mensagens;
    }
}
