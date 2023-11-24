using BackEnd.Datos.interfaz;
using BackEnd.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Datos.Implementacion
{
    public class TicketDAO : ITicketDAO
    {
        public bool CrearTiket(Ticket oTicket)
        {
            bool res = true;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();
                cmd.Connection = conexion;
                cmd.Transaction = t;
                cmd.CommandText = "SP_Insert_Ticket";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pagado", oTicket.Pagado);
                cmd.Parameters.AddWithValue("@id_forma_pago", oTicket.FormaPago.IdFormaPago);
                SqlParameter parametro = new SqlParameter();
                parametro.ParameterName = "@ticket_nro";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parametro);
                cmd.ExecuteNonQuery();
                oTicket.TicketNro = (int)parametro.Value;
                // int detalleNro = 1;
                SqlCommand cmdDetalle;
                foreach (Butaca butaca in oTicket.listBuataca)
                {
                    cmdDetalle = new SqlCommand("Sp_Insert_Butaca", conexion, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@descuento_porcentaje", butaca.Descuento);
                    cmdDetalle.Parameters.AddWithValue("@precio_butaca", butaca.Precio);
                    cmdDetalle.Parameters.AddWithValue("@numero", butaca.Numero);
                    cmdDetalle.Parameters.AddWithValue("@estado", butaca.Estado);
                    cmdDetalle.Parameters.AddWithValue("@id_ticket", oTicket.TicketNro);
                    cmdDetalle.Parameters.AddWithValue("@id_tipo_cliente", butaca.Cliente.TipoNro);
                    cmdDetalle.Parameters.AddWithValue("@id_estado_reserva", 1); //Todas los tickets son vendidos y pagados en caja.
                    cmdDetalle.Parameters.AddWithValue("@id_funcion", butaca.Funcion.FuncionNro);
                    cmdDetalle.Parameters.AddWithValue("@id_sala", butaca.Sala.SalaNro);
                    cmdDetalle.ExecuteNonQuery();

                }
                t.Commit();
            }
            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                res = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                    conexion.Close();
            }

            return res;
        }
    }
}

