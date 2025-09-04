using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Datos;
using System.Security.Claims;

namespace FavoritosNegocio
{
    public class Favorito
    {
        public List<Favoritos>  ObtenerFavoritos(int usuarioId)
        {

            List<Favoritos> favoritos = new List<Favoritos>();
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.SqlProcedimiento("StoreFavoritos");
                datos.AgregarParametro("@Codigo", usuarioId);
                var reader = datos.EjecutarLectura();
                while(reader.Read())
                {

                    Favoritos Fav = new Favoritos();
                    Fav.Id = (int)reader["Id"];
                    Fav.IdUsuario = (int)reader["IdUser"];
                    Fav.IdArticulo = (int)reader["IdArticulo"];
                    Fav.Codigo = (string)reader["Codigo"];
                    Fav.Nombre = (string)reader["Nombre"];
                    Fav.ImagenUrl = reader.IsDBNull(reader.GetOrdinal("ImagenUrl"))? null : reader["ImagenUrl"].ToString();
                    Fav.Descripcion = reader.IsDBNull(reader.GetOrdinal("Descripcion")) ? null : reader["Descripcion"].ToString();
                    favoritos.Add(Fav);


                }
                 return favoritos;

            }
            catch (Exception ex)
            {
               throw new Exception($"Error al filtrar los favoritos del usuario ({usuarioId}): {ex.Message}");
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int AgregarFavorito(int user, int articulo, int resultado)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.SqlProcedimiento("StoreAgregarFav");
                datos.AgregarParametro("@CodigoUser", user);
                datos.AgregarParametro("@CodigoArticulo", articulo);
                datos.AgregarParametro("@Resultado", resultado);
                var retorno = datos.AgregarParametroReturn();
                datos.EjecutarComando();
                resultado = (int)retorno.Value;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar el favorito: {ex.Message}");
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public int EliminarFavorito(int user, int articulo, int resultado)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.SqlProcedimiento("StoreEliminarFav");
                datos.AgregarParametro("@CodigoUser", user);
                datos.AgregarParametro("@CodigoArticulo", articulo);
                datos.AgregarParametro("@Resultado", resultado);
                var retorno = datos.AgregarParametroReturn();
                datos.EjecutarComando();
                int final = (int)retorno.Value;
                return final;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el favorito: {ex.Message}");
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
