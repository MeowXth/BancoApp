using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using BancoApp.Models;

namespace BancoApp.Data
{
    public class ClienteRepository
    {
        private readonly DatabaseHelper _databaseHelper;

        public ClienteRepository(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public List<Cliente> ObtenerClientes()
        {
            var clientes = new List<Cliente>();

            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, Nombre, Correo, Saldo FROM Clientes", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add(new Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Correo = reader.GetString(2),
                                Saldo = reader.GetDecimal(3)
                            });
                        }
                    }
                }
            }

            return clientes;
        }

        public void AgregarCliente(Cliente cliente)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Clientes (Nombre, Correo, Saldo) VALUES (@Nombre, @Correo, @Saldo)", connection))
                {
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Correo", cliente.Correo);
                    command.Parameters.AddWithValue("@Saldo", cliente.Saldo);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Cliente? ObtenerClientePorId(int id)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Id, Nombre, Correo, Saldo FROM Clientes WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cliente
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                Correo = reader.GetString(2),
                                Saldo = reader.GetDecimal(3)
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void ActualizarCliente(Cliente cliente)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Clientes SET Nombre = @Nombre, Correo = @Correo, Saldo = @Saldo WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", cliente.Id);
                    command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    command.Parameters.AddWithValue("@Correo", cliente.Correo);
                    command.Parameters.AddWithValue("@Saldo", cliente.Saldo);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCliente(int id)
        {
            using (var connection = _databaseHelper.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Clientes WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
