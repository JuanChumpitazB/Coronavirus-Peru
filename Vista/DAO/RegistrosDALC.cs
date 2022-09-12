using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Configuration;

namespace Presentacion.DAO
{
    public class RegistrosDALC
    {

        SqlConnection cn = new SqlConnection("workstation id=CORONAVIRUSPERU.mssql.somee.com;packet size=4096;user id=JUCCOMP_SQLLogin_1;pwd=dwekrc8idb;data source=CORONAVIRUSPERU.mssql.somee.com;persist security info=False;initial catalog=CORONAVIRUSPERU");
        private string FormatoFecha (string fecha)
        {
            string nuevaFecha = "";
            int desde = fecha.IndexOf("-");
            desde += 1;
            string mesNum= fecha.Substring(desde,2);
            string diaNum= fecha.Substring(0,2);

            switch (mesNum)
            {
                case "01": nuevaFecha = "Ene"; break;
                case "02": nuevaFecha = "Feb"; break;
                case "03": nuevaFecha = "Mar"; break;
                case "04": nuevaFecha = "Abr"; break;
                case "05": nuevaFecha = "May"; break;
                case "06": nuevaFecha = "Jun"; break;
                case "07": nuevaFecha = "Jul"; break;
                case "08": nuevaFecha = "Ago"; break;
                case "09": nuevaFecha = "Set"; break;
                case "10": nuevaFecha = "Oct"; break;
                case "11": nuevaFecha = "Nov"; break;
                case "12": nuevaFecha = "Dic"; break;
            }

            nuevaFecha = diaNum + "-"+ nuevaFecha;

            return nuevaFecha;
        }
        //public List<Registros_InfecFallAlta_BE> InfectadosFallecidosRecuperados()
        //{
        //    List<Registros_InfecFallAlta_BE> lst = new List<Registros_InfecFallAlta_BE>();
        //    try
        //    {
        //        string sql = "R_INFEC_FALLE_RECUPE";
        //        SqlCommand cmd = new SqlCommand(sql, cn);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            Registros_InfecFallAlta_BE registrosBE = new Registros_InfecFallAlta_BE();
        //            string nuevoFormatoFecha = FormatoFecha(dr["FECHA"].ToString());
        //            registrosBE.FECHA = nuevoFormatoFecha;
        //            registrosBE.INFECTADOS = dr["INFECTADOS"].ToString();
        //            registrosBE.FALLECIDOS = dr["FALLECIDOS"].ToString();
        //            registrosBE.RECUPERADOS = dr["RECUPERADOS"].ToString();

        //            lst.Add(registrosBE);
        //        }
        //        cn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
            
        //    return lst;
        //}

        public DataSet DT_InfectadosFallecidosRecuperado()
        {
            SqlDataAdapter da = new SqlDataAdapter("R_INFEC_FALLE_RECUPE",cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet DT_InfectadosXdia()
        {
            SqlDataAdapter da = new SqlDataAdapter("R_INFEC_X_DIA", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet DT_PruebasCasosActivos()
        {
            SqlDataAdapter da = new SqlDataAdapter("R_PRUEBAS_CASOSACTIVOS", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet DT_ActivosHospiUCI()
        {
            SqlDataAdapter da = new SqlDataAdapter("R_ACTIVOS_HOSPI_UCI", cn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public List<RegistrosBE> ListadoGeneral()
        {
            List<RegistrosBE> lst = new List<RegistrosBE>();
            try
            {
                string sql = "SP_LISTADOGENERAL";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RegistrosBE registrosBE = new RegistrosBE();
                    string nuevoFormatoFecha = FormatoFecha(dr["FECHA"].ToString());
                    registrosBE.ID_REGISTRO = Convert.ToInt32(dr["ID_REGISTRO"].ToString());
                    registrosBE.FECHA = nuevoFormatoFecha;
                    registrosBE.INFECTADOS = dr["INFECTADOS"].ToString();
                    registrosBE.FALLECIDOS = dr["FALLECIDOS"].ToString();
                    registrosBE.RECUPERADOS = dr["RECUPERADOS"].ToString();
                    registrosBE.INFEC_X_DIA = dr["INFEC_X_DIA"].ToString();
                    registrosBE.PRUEBAS = dr["PRUEBAS"].ToString();
                    registrosBE.CASOS_ACTIVOS = dr["CASOS_ACTIVOS"].ToString();
                    registrosBE.HOSPITALIZADOS = dr["HOSPITALIZADOS"].ToString();
                    registrosBE.UCI = dr["UCI"].ToString();
                    registrosBE.TOTAL_CAMAS = dr["TOTAL_CAMAS"].ToString();
                    registrosBE.CAMAS_DISPONIBLES = dr["CAMAS_DISPONIBLES"].ToString();

                    lst.Add(registrosBE);
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw;
            }

            return lst;
        }

        public decimal PorcentajeMortalidad()
        {
            decimal porcentaje = 0;
            try
            {
                string sql = "R_PORCENTAJE_MORTALIDAD";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    porcentaje = Convert.ToDecimal(dr["PORCENTAJE"].ToString());
                }
                return porcentaje;
            }
            catch (Exception)
            {
                return porcentaje = 0;
            }
            finally
            {
                cn.Close();
            }
        }
        public decimal PorcentajeInfectados()
        {
            decimal porcentaje = 0;
            try
            {
                string sql = "R_PORCENTAJE_INFECTADOS";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    porcentaje = Convert.ToDecimal(dr["PORCENTAJE"].ToString());
                }
                return porcentaje;
            }
            catch (Exception)
            {
                return porcentaje = 0;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
