using System;

namespace FerreteriaDominio.Entidades;

public class Categoria
{
    public int IdCategoria { get; set; }
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
}
