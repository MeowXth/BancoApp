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

        public bool AgregarCliente(Cliente cliente)
        {
            try
            {
                using (var connection = _databaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Clientes (Nombre, Correo, Saldo) VALUES (@Nombre, @Correo, @Saldo)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        command.Parameters.AddWithValue("@Correo", cliente.Correo);
                        command.Parameters.AddWithValue("@Saldo", cliente.Saldo);
                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas > 0; 
                    }
                }
            }
            catch (Exception)
            {
                return false; 
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

        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                using (var connection = _databaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "UPDATE Clientes SET Nombre = @Nombre, Correo = @Correo, Saldo = @Saldo WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                        command.Parameters.AddWithValue("@Correo", cliente.Correo);
                        command.Parameters.AddWithValue("@Saldo", cliente.Saldo);
                        command.Parameters.AddWithValue("@Id", cliente.Id);
                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarCliente(int id)
        {
            try
            {
                using (var connection = _databaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "DELETE FROM Clientes WHERE Id = @Id";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        int filasAfectadas = command.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Cliente> BuscarClientes(string criterio) {
            List<Cliente> clientes = new List<Cliente>();
            try
            {
                using(var connection = _databaseHelper.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT * FROM Clientes WHERE Nombre LIKE @Criterio OR Correo LIKE @Criterio";
                    using(var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Criterio", $"%{criterio}%");
                        using(var reader = command.ExecuteReader())
                        {
                            while(reader.Read())
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
            }
            catch(Exception)
            {
                //En caso de error, retornamos una lista vacía
            }
            return clientes;
        }
    }
}
