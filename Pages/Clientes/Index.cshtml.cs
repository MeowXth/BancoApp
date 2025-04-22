using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using BancoApp.Services;
using BancoApp.Models;

namespace BancoApp.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ClienteService _clienteService;
        public List<Cliente> Clientes { get; set; } = new();

        public IndexModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void OnGet()
        {
            Clientes = _clienteService.ObtenerClientes();
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


