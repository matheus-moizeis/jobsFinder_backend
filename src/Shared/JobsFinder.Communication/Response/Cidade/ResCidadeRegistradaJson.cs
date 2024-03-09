using JobsFinder.Communication.Response.Estado;

namespace JobsFinder.Communication.Response.Cidade;
public class ResCidadeRegistradaJson
{
    public long Id { get; set; }
    public string NomeCidade { get; set; }
    public int CodIbge { get; set; }
    public ResponseEstado Estado { get; set; }
}
