using Systema_de_ventas.Models;
using System.Data.SqlClient;
using System.Data;

namespace Systema_de_ventas.Datos
{
    public class CRUD_cliente
    {
        // Método para listar todos los clientes
        public List<Modelo_cliente> Listar()
        {
            var Lista_cliente = new List<Modelo_cliente>();
            var conectar = new Conexion();
            using (var conexion = new SqlConnection(conectar.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarClientes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Lista_cliente.Add(new Modelo_cliente()
                        {
                            ClienteId = Convert.ToInt32(dr["cliente_id"]),
                            Nombre = dr["nombre"].ToString(),
                            Email = dr["email"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            Direccion = dr["direccion"].ToString(),
                            Ciudad = dr["ciudad"].ToString(),
                            Pais = dr["pais"].ToString(),
                            DNI = dr["dni"].ToString(),
                            RUC = dr["ruc"].ToString(),
                            Distrito = dr["distrito"].ToString()
                        });
                    }
                }
            }
            return Lista_cliente;
        }

        // Método para registrar un nuevo cliente
        public bool Registrar(Modelo_cliente cliente)
        {
            bool respuesta;
            var conectar = new Conexion();
            using (var conexion = new SqlConnection(conectar.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros del procedimiento almacenado
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@ciudad", cliente.Ciudad);
                cmd.Parameters.AddWithValue("@pais", cliente.Pais);
                cmd.Parameters.AddWithValue("@dni", cliente.DNI);
                cmd.Parameters.AddWithValue("@ruc", cliente.RUC);
                cmd.Parameters.AddWithValue("@distrito", cliente.Distrito);

                // Ejecutar el procedimiento
                respuesta = cmd.ExecuteNonQuery() > 0;
            }
            return respuesta;
        }

        // Método para editar un cliente existente
        public bool Editar(Modelo_cliente cliente)
        {
            bool respuesta;
            var conectar = new Conexion();
            using (var conexion = new SqlConnection(conectar.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_EditarCliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar los parámetros del procedimiento almacenado
                cmd.Parameters.AddWithValue("@cliente_id", cliente.ClienteId);
                cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@email", cliente.Email);
                cmd.Parameters.AddWithValue("@telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@ciudad", cliente.Ciudad);
                cmd.Parameters.AddWithValue("@pais", cliente.Pais);
                cmd.Parameters.AddWithValue("@dni", cliente.DNI);
                cmd.Parameters.AddWithValue("@ruc", cliente.RUC);
                cmd.Parameters.AddWithValue("@distrito", cliente.Distrito);

                // Ejecutar el procedimiento
                respuesta = cmd.ExecuteNonQuery() > 0;
            }
            return respuesta;
        }

        // Método para eliminar un cliente
        public bool Borrar(int cliente_id)
        {
            bool respuesta;
            var conectar = new Conexion();
            using (var conexion = new SqlConnection(conectar.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_BorrarCliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro del procedimiento almacenado
                cmd.Parameters.AddWithValue("@cliente_id", cliente_id);

                // Ejecutar el procedimiento
                respuesta = cmd.ExecuteNonQuery() > 0;
            }
            return respuesta;
        }

        // Método para obtener el detalle de un cliente específico
        public Modelo_cliente Detalle(int cliente_id)
        {
            Modelo_cliente cliente = null;
            var conectar = new Conexion();
            using (var conexion = new SqlConnection(conectar.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_DetalleCliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregar el parámetro del procedimiento almacenado
                cmd.Parameters.AddWithValue("@cliente_id", cliente_id);

                // Leer el resultado
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        cliente = new Modelo_cliente()
                        {
                            ClienteId = Convert.ToInt32(dr["cliente_id"]),
                            Nombre = dr["nombre"].ToString(),
                            Email = dr["email"].ToString(),
                            Telefono = dr["telefono"].ToString(),
                            Direccion = dr["direccion"].ToString(),
                            Ciudad = dr["ciudad"].ToString(),
                            Pais = dr["pais"].ToString(),
                            DNI = dr["dni"].ToString(),
                            RUC = dr["ruc"].ToString(),
                            Distrito = dr["distrito"].ToString()
                        };
                    }
                }
            }
            return cliente;
        }
    }
}
