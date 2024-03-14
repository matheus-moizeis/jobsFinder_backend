namespace JobsFinder.Domain.Entities;
public class Cidade : EntityBase
{
    public string NomeCidade { get; set; }
    public int CodIbge { get; set; }
    public long EstadoId { get; set; }
    public Estado Estado { get; set; }
    public ICollection<Perfil> Perfis { get; set; }
}
