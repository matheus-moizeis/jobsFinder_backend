﻿namespace JobsFinder.Domain.Entities;
public class Estado : EntityBase
{
    public string NomeEstado { get; set; }
    public string Uf { get; set; }
    public ICollection<Cidade> Cidades { get; set; }
}
