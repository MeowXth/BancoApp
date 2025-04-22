
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BancoApp.Services;
using BancoApp.Models;

namespace BancoApp.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly ClienteService _clienteService;

        [BindProperty]
        public Cliente Cliente { get; set; } = new();

        public CreateModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Por favor, corrige los errores antes de continuar.";
                return Page();
            }

            bool resultado = _clienteService.AgregarCliente(Cliente);

            if (resultado)
            {
                TempData["SuccessMessage"] = "Cliente agregado exitosamente.";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "Error al agregar el cliente. Inténtalo nuevamente.";
                return Page();
            }
        }

    }
}
