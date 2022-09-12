using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace PresentacionMVC.DALC
{
    public class conexion
    {
        public SqlConnection cn = new SqlConnection("Data source=. ;Initial Catalog=CORONAVIRUSPERU;User ID=sa;Password=123456789");
       
        public void Abrir()
        {
            try
            {
                cn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Conexion: " + ex);
                throw;
            }
        }
        public void Cerrar()
        {
            try
            {
                cn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Conexion: " + ex);
                throw;
            }
            
        }
    }
}