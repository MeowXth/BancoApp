using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BancoApp.Services;
using BancoApp.Models;

namespace BancoApp.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly ClienteService _clienteService;

        [BindProperty]
        public Cliente Cliente { get; set; } = new();

        public EditModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult OnGet(int id)
        {
            Cliente = _clienteService.ObtenerClientePorId(id);
            if (Cliente == null) return RedirectToPage("Index");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Por favor, corrige los errores antes de continuar.";
                return Page();
            }

            bool resultado = _clienteService.ActualizarCliente(Cliente);

            if (resultado)
            {
                TempData["SuccessMessage"] = "Cliente actualizado correctamente.";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Error al actualizar el cliente.";
                return Page();
            }
        }

    }
}
