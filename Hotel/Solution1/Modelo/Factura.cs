namespace Modelos
{
    public class Factura
    {
        public int Id { get; set; }
        public string IdentidadCliente { get; set; }
        public DateTime Fecha { get; set; }
        public string CodigoUsuario { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
