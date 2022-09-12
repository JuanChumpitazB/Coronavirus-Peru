using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;
using PresentacionMVC.DALC;
using System.Globalization;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;

namespace PresentacionMVC.DALC
{
    public class VisitantesDALC
    {
        conexion cn = new conexion();

        public bool AgregarVisitante(VisitantesBE visitanteBE)
        {
            bool resp = false;
            try
            {
                SqlCommand cmd = new SqlCommand("VISITANTES_INSERT", cn.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IP", visitanteBE.IP);
                cmd.Parameters.AddWithValue("@HOSTNAME", visitanteBE.AHOSTNAME);
                cmd.Parameters.AddWithValue("@IP_DETRAS_PROXY", visitanteBE.IP_DETRAS_PROXY);
                cmd.Parameters.AddWithValue("@FECHA", visitanteBE.FECHA);
                cmd.Parameters.AddWithValue("@HORA", visitanteBE.HORA);
                cn.Abrir();
                int i = (int) cmd.ExecuteNonQuery();
                cn.Cerrar();
                if (i == 1) return true;
                else return false;
                
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex);
                return false;
                throw;
            }
            finally { cn.Cerrar(); }
        }
    }
}