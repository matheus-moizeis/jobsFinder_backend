using JobsFinder.Domain.Enum;

namespace JobsFinder.Domain.Entities;
public class Perfil : EntityBase
{
    public string Titulo { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Descricao { get; set; }
    public string Email { get; set; }
    public int Telefone { get; set; }
    public string Foto { get; set; }
    public DateTime DtNascimento { get; set; }
    public string Naturalidade { get; set; }
    public Genero Genero { get; set; }
    public string Nascionalidade { get; set; }
    public EstadoCivil EstadoCivil { get; set; }
    public string Linkedin { get; set; }
    public string Site { get; set; }
    public int Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string CarteiraMotorista { get; set; }
    public CategoriaCarteiraMotorista CategoriaCarteiraMotorista { get; set; }

    public long IdCidade { get; set; }
    public Cidade Cidade { get; set; }

}
