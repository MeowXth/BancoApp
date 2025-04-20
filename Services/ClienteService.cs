using System.Collections.Generic;
using BancoApp.Data;
using BancoApp.Models;

namespace BancoApp.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> ObtenerClientes()
        {
            return _clienteRepository.ObtenerClientes();
        }
        public void AgregarCliente(Cliente cliente)
        {
            _clienteRepository.AgregarCliente(cliente);
        }
        public Cliente? ObtenerClientePorId(int id)
        {
            return _clienteRepository.ObtenerClientePorId(id);
        }
        public void ActualizarCliente(Cliente cliente)
        {
            _clienteRepository.ActualizarCliente(cliente);
        }
        public void EliminarCliente(int id)
        {
            _clienteRepository.EliminarCliente(id);
        }
    }
}
