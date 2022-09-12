using System;
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

namespace PresentacionMVC
{
    public class RegistrosDALC
    {

        //SqlConnection cn = new SqlConnection("workstation id=CORONAVIRUSPERU.mssql.somee.com;packet size=4096;user id=JUCCOMP_SQLLogin_1;pwd=dwekrc8idb;data source=CORONAVIRUSPERU.mssql.somee.com;persist security info=False;initial catalog=CORONAVIRUSPERU");

        conexion conexion = new conexion();
        
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

        public List<object> UltimaInformacion()
        {
            List<object> lstUltimaInformacion = new List<object>();
            NumberFormatInfo nfi = new NumberFormatInfo(); // Pendiente !!!!!!!!!!!!!!!
            nfi.NumberGroupSeparator = " ";
            try
            {

                SqlCommand cmd = new SqlCommand("R_ULTIMA_INFORMACION", conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object[] meses = { dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7] };
                    lstUltimaInformacion.Add(meses);
                }
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }

            return lstUltimaInformacion;
        }
        public List<object> Meses(int numAnio)
        {
            List<object> lstMeses = new List<object>();
            try
            {
                
                SqlCommand cmd = new SqlCommand("R_LISTA_MESES", conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NUM_ANIO", numAnio);
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object[] meses = { dr[0],dr[1]};
                    lstMeses.Add(meses);
                }
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }

            return lstMeses;
        }
        public List<object> Anios()
        {
            List<object> lstAnios = new List<object>();
            try
            {

                SqlCommand cmd = new SqlCommand("R_LISTA_ANIOS", conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    object[] anios = { Convert.ToInt32(dr["NUM_ANIO"]) };
                    lstAnios.Add(anios);
                }
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }

            return lstAnios;
        }
        public int UltimoAnioRegistrado()
        {
            int ultimoAnio = 0;
            try
            {
                string sql = "R_ULTIMO_ANIO_REGISTRADO";
                SqlCommand cmd = new SqlCommand(sql, conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    ultimoAnio = Convert.ToInt32(dr["NUM_ANIO"].ToString());
                }
                conexion.Cerrar();
                return ultimoAnio;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public DataTable DT_InfectadosFallecidosRecuperado(int numAnio, int numMes)
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.Abrir();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("R_INFEC_FALLE_RECUPE", conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NUM_ANIO", numAnio);
                cmd.Parameters.AddWithValue("@NUM_MES",numMes);
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                
                da.Fill(dt);
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }
            
            return dt;
        }
        public DataTable DT_InfectadosXdia(int numAnio,int numMes)
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.Abrir();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("R_INFEC_X_DIA", conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numAnio", numAnio);
                cmd.Parameters.AddWithValue("@numMes", numMes);
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                
                da.Fill(dt);
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }

            return dt;
        }
        public DataTable DT_Chart_Principal()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.Abrir();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("R_CHART_PRINCIPAL", conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();

                da.Fill(dt);
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }

            return dt;
        }


        public DataTable DT_PruebasCasosActivos()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("R_PRUEBAS_CASOSACTIVOS", conexion.cn);
                DataSet ds = new DataSet();
                
                da.Fill(dt);
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }

            return dt;
        }
        public DataTable DT_ActivosHospiUCI()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.Abrir();
                SqlDataAdapter da = new SqlDataAdapter("R_ACTIVOS_HOSPI_UCI", conexion.cn);
                DataSet ds = new DataSet();
                
                da.Fill(dt);
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }

            return dt;
        }
        public List<RegistrosBE> ListadoGeneral()
        {
            List<RegistrosBE> lst = new List<RegistrosBE>();
            try
            {
                string sql = "SP_LISTADOGENERAL";
                SqlCommand cmd = new SqlCommand(sql, conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Abrir() ;
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
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }

            return lst;
        }

        #region Semanal
        public DataTable DT_InfectadosFallecidosRecuperado_Semanal(int numAnio)
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.Abrir();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand("R_INFEC_FALLE_RECUPE_SEMANAL", conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NUM_ANIO", numAnio);
                da.SelectCommand = cmd;
                da.Fill(dt);
                conexion.Cerrar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally { conexion.Cerrar(); }

            return dt;
        }

        #endregion

        #region Porcentajes

        public decimal PorcentajeMortalidad()
        {
            decimal porcentaje = 0;
            try
            {
                string sql = "R_PORCENTAJE_MORTALIDAD";
                SqlCommand cmd = new SqlCommand(sql, conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    porcentaje = Convert.ToDecimal(dr["PORCENTAJE"].ToString());
                }
                conexion.Cerrar();
                return porcentaje;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        public decimal PorcentajeInfectados()
        {
            decimal porcentaje = 0;
            try
            {
                string sql = "R_PORCENTAJE_INFECTADOS";
                SqlCommand cmd = new SqlCommand(sql, conexion.cn);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Abrir();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    porcentaje = Convert.ToDecimal(dr["PORCENTAJE"].ToString());
                }
                conexion.Cerrar();
                return porcentaje;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
                throw;
            }
            finally
            {
                conexion.Cerrar();
            }
        }
        #endregion
    }
}
