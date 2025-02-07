using System;

public enum TipoEstablecimiento
{
    Banco,
    Dealer
}

public class Establecimiento
{
    public int Id { get; set; }
    public string NombreFiscal { get; set; }
    public string Direccion { get; set; }
    public TipoEstablecimiento Tipo { get; set; }
    public int UsuarioCreadorId { get; set; }
    public string Telefono { get; set; }
    public string CorreoElectronico { get; set; }
    public DateTime FechaRegistro { get; set; }
    public bool EstaActivo { get; set; }
    public string ProductosServicios { get; set; }
    public string NotasAdicionales { get; set; }
}
