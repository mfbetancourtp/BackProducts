namespace ProductApi.Models
{
    public class Doc
    {
        public string IdDocumento { get; set; } = null!;
        public string NombreDocumento { get; set; } = null!;
        public string? RutaExpediente { get; set; }
        public string? ObjectStore { get; set; }
        public string? TipoTraslado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
