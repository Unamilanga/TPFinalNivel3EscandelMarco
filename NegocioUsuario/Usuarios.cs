using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Dominio;
using Microsoft.SqlServer.Server;

namespace NegocioUsuario
{
    public class Usuarios
    {
        public bool ExisteMail(string mail)
        {
                
                ConexionDB conexion = new ConexionDB();
            try 
            {
                
                conexion.SqlProcedimiento("storeExisteUser");
                conexion.AgregarParametro("@email", mail);
                int contador= (int)conexion.EjecutarEscalar();

                return contador>0;

                }

            catch(Exception ex) {

                throw new Exception("Error al verificar el código", ex);

            }
            finally
            {
                conexion.CerrarConexion();

            }
        }

        public bool CoincideUser(string mail, string contraseña)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlProcedimiento("storeUserEncontrado");
                conexion.AgregarParametro("@email", mail);
                conexion.AgregarParametro("@contraseña", contraseña);
                int contador = (int)conexion.EjecutarEscalar();
                return contador > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la contraseña o el mail: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public Usuario ObtenerUsuario(string mail, string contraseña)
        {
            ConexionDB conexion = new ConexionDB();
            Usuario user = new Usuario();
            try
            {
                //aux.Codigo = reader.IsDBNull(reader.GetOrdinal("Codigo")) ? "VACIO" : reader["Codigo"].ToString();
                conexion.SqlProcedimiento("storeBuscarUser");
                conexion.AgregarParametro("@email", mail);
                conexion.AgregarParametro("@contraseña", contraseña);
                var reader = conexion.EjecutarLectura();
                if (reader.Read())
                {
                    user.Id = (int)reader["Id"];
                    user.Email = reader["Email"].ToString();
                    user.Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre"))?null: reader["Nombre"].ToString();
                    user.Apellido = reader.IsDBNull(reader.GetOrdinal("Apellido")) ? null : reader["Apellido"].ToString();
                    user.urlImagenPerfil = reader.IsDBNull(reader.GetOrdinal("urlImagenPerfil")) ? null : reader["urlImagenPerfil"].ToString();
                    user.Admin = (bool)reader["Admin"];
                    user.Pass = reader["Pass"].ToString();
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el usuario: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public int NuevoUser(string mail, string contraseña)
        {
            ConexionDB conexion = new ConexionDB();
            int nuevoId;
            try
            {
                conexion.SqlProcedimiento("storeNuevoUser");
                conexion.AgregarParametro("@email", mail);
                conexion.AgregarParametro("@contraseña", contraseña);
                object resultado = conexion.EjecutarEscalar();
                nuevoId = Convert.ToInt32(resultado);

                return nuevoId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el usuario: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public void EditarUsuario(Usuario usuario)
        {
            ConexionDB conexion = new ConexionDB();

            try
            {
                conexion.SqlProcedimiento("StoreEditarUser");
                conexion.AgregarParametro("@Nombre",usuario.Nombre);
                conexion.AgregarParametro("@Apellido",usuario.Apellido);
                conexion.AgregarParametro("@urlimagen", string.IsNullOrEmpty(usuario.urlImagenPerfil)? (object)DBNull.Value: usuario.urlImagenPerfil);
                conexion.AgregarParametro("@Id", usuario.Id);
                conexion.EjecutarComando();

            } catch (Exception ex)
            {
                throw new Exception("Error al modificar el usuario: " + ex.Message);

            } finally { conexion.CerrarConexion(); }

            return;
        }

        public void CambiarContraseña(Usuario usuario, string nuevaContraseña)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlProcedimiento("StoreCambiarContraseña");
                conexion.AgregarParametro("@Id", usuario.Id);
                conexion.AgregarParametro("@NuevaContraseña", nuevaContraseña);
                conexion.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cambiar la contraseña: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }

        public string RecuperarContraseña(string mail)
        {
            ConexionDB conexion = new ConexionDB();
            try
            {
                conexion.SqlProcedimiento("storeRecuperar");
                conexion.AgregarParametro("@email", mail);
                var reader = conexion.EjecutarLectura();
                if (reader.Read())
                {
                    return reader["Pass"].ToString();
                }
                else
                {
                    throw new Exception("No se encontró el usuario con ese correo.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al recuperar la contraseña: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexion();
            }
        }
    }

}
