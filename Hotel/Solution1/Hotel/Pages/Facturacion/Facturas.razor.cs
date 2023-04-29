using Hotel.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Hotel.Pages.Facturacion
{
	public partial class Facturas
	{
		[Inject] private IFacturaServicio facturaServicio { get; set; }

		private IEnumerable<Factura> lista { get; set; }

		protected override async Task OnInitializedAsync()
		{
			lista = await facturaServicio.GetLista();
		}
	}
}
