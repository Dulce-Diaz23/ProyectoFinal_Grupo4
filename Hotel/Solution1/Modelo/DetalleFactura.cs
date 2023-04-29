namespace Modelos
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int IdFactura { get; set; }
        public int CodigoHabitacion { get; set; }
		public string Habitacion { get; set; }
		public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
