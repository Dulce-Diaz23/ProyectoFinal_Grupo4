using CurrieTechnologies.Razor.SweetAlert2;
using Hotel.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Modelos;

namespace Hotel.Pages.Facturacion
{
    public partial class NuevaFactura
    {
        [Inject] private IFacturaServicio facturaServicio { get; set; }
        [Inject] private IDetalleFacturaServicio detalleFacturaServicio { get; set; }
        [Inject] private IHabitacionServicio habitacionServicio { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] private IHttpContextAccessor httpContextAccessor { get; set; }

        private Factura factura = new Factura();
        private List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        private Habitacion habitacion = new Habitacion();
        private int cantidad { get; set; }
        private string codigoHabitacion { get; set; }

        protected override async Task OnInitializedAsync()
        {
            factura.Fecha = DateTime.Now;
        }
        private async void BuscarHabitacion()
        {
            habitacion = await habitacionServicio.GetPorCodigo(Convert.ToInt32(codigoHabitacion));
        }
        protected async Task AgregarHabitacion(MouseEventArgs args)
        {
            if (args.Detail != 0)
            {
                if (habitacion != null)
                {
                    DetalleFactura detalle = new DetalleFactura();
                    detalle.Habitacion = habitacion.Nombre;
                    detalle.CodigoHabitacion = habitacion.Codigo;
                    detalle.Cantidad = Convert.ToInt32(cantidad);
                    detalle.Precio = habitacion.Precio;
                    detalle.Total = habitacion.Precio * Convert.ToInt32(cantidad);
                    listaDetalleFactura.Add(detalle);

                    habitacion.Codigo = 0;
                    habitacion.Nombre = string.Empty;
                    habitacion.Precio = 0;
                    habitacion.Existencia = 0;
                    cantidad = 0;
                    codigoHabitacion = "0";

                    factura.SubTotal = factura.SubTotal + detalle.Total;
                    factura.ISV = factura.SubTotal * 0.15M;
                    factura.Total = factura.SubTotal + factura.ISV - factura.Descuento;
                }

            }
        }

        protected async Task Guardar()
        {
            factura.CodigoUsuario = httpContextAccessor.HttpContext.User.Identity.Name;
            int idFactura = await facturaServicio.Nueva(factura);
            if (idFactura != 0)
            {
                foreach (var item in listaDetalleFactura)
                {
                    item.IdFactura = idFactura;
                    await detalleFacturaServicio.Nuevo(item);
                }
                await Swal.FireAsync("Felicidades", "Factura guardada con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar la factura", SweetAlertIcon.Error);
            }
        }

    }
}
