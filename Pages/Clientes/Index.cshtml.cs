using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using BancoApp.Services;
using BancoApp.Models;

namespace BancoApp.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ClienteService _clienteService;

        public IndexModel(ClienteService clienteService)
        {
         _clienteService = clienteService;
        }

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();

        [BindProperty(SupportsGet = true)]
        public string CriterioBusqueda { get; set; } = string.Empty;

        public void OnGet()
        {
            if (string.IsNullOrEmpty(CriterioBusqueda))
            {
                Clientes = _clienteService.ObtenerClientes();
            }
            else
            {
                Clientes = _clienteService.BuscarClientes(CriterioBusqueda);
            }
        }



        public IActionResult OnPostEliminar(int id)
        {
            bool resultado = _clienteService.EliminarCliente(id);

            if (resultado)
            {
                TempData["SuccessMessage"] = "Cliente eliminado correctamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar el cliente.";
            }

            return RedirectToPage();
        }
    }
}


