using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Departamentos_Seguimiento_2018
{
    public class Conexion
    {
        string connectionString = "data source=EHI008\\SQLEXPRESS; initial catalog=DepartamentosSeguimiento2018_2; integrated security=true";
        internal DataSet dataSet = new DataSet();

        internal string qAcumuladoAño = "" +
            "SELECT sum(a.real) FROM asiento AS a "+
"INNER JOIN Elemento AS e ON E.Id=a.IdElemento "+
"WHERE e.IdConcepto = @idconcepto  AND Year(a.fecha) LIKE @año";
        internal string qAcumuladoAñoArea = "" +
        "SELECT sum(a.real) FROM asiento AS a " +
"INNER JOIN Elemento AS e ON e.Id=a.IdElemento " +
"WHERE e.IdConcepto = @idconcepto  AND Year(a.fecha) LIKE @año AND e.IdArea=@idarea";
        internal string qTotalesConceptoMesAño = "" +
            "SELECT sum(a.estimado),sum(a.descuento),sum(a.real) FROM asiento AS a "+
"INNER JOIN ELEMENTO AS E ON E.Id=A.IDELEMENTO "+
"WHERE E.IdConcepto =  @idconcepto AND MONTH(a.fecha) like @mes AND Year(a.fecha) LIKE @año";

         internal string qTotalesConceptoMesAñoArea = "" +
           "SELECT sum(a.estimado),sum(a.descuento),sum(a.real) FROM asiento AS a " +
"INNER JOIN ELEMENTO AS E ON E.Id=A.IDELEMENTO " +
"INNER JOIN AREA AS AR ON AR.Id=e.IDAREA " +
"WHERE E.IdConcepto =  @idconcepto AND MONTH(a.fecha) like @mes AND Year(a.fecha) LIKE @año AND e.IdArea=@idarea";

        internal string qAreasConceptoMesAño = "" +
           "SELECT aR.id, ar.area, sum(a.estimado),sum(a.descuento),sum(a.real) FROM asiento AS a " +
"INNER JOIN ELEMENTO AS E ON E.Id=A.IDELEMENTO " +
"INNER JOIN AREA AS AR ON AR.Id=e.IDAREA " +
"WHERE E.IdConcepto =  @idconcepto AND MONTH(a.fecha) like @mes AND Year(a.fecha) LIKE @año GROUP BY AR.ID,aR.AREA ";

        internal string qElementosConceptoMesesAñoArea = "" +
            "SELECT e.id, e.elemento, ce.estimado ,ce.descuento,ce.real, Month(ce.fecha), Day(ce.fecha) ,ce.id FROM asiento as ce " +
"INNER JOIN Elemento AS e ON e.Id=ce.IdElemento "+
"INNER JOIN Concepto AS c ON c.Id=e.IdConcepto "+
"WHERE e.IdConcepto = 1  AND Year(ce.fecha) LIKE '2018' AND e.idarea= 1  order by e.id, Month(ce.fecha)";
           /*"SELECT e.id, e.elemento, ce.estimado,ce.descuento,ce.real, ce.fecha ,ce.id FROM asiento as ce "+
"INNER JOIN Elemento AS e ON e.Id=ce.IdElemento "+
"INNER JOIN Concepto AS c ON c.Id=e.IdConcepto "+
"WHERE e.IdConcepto = @idconcepto AND Month(ce.fecha) LIKE @mes  AND Year(ce.fecha) LIKE @año AND e.idarea= @idarea";*/

        internal string qElementosIdConcepto = "" +
            "SELECT * FROM ELEMENTO WHERE IdConcepto=@idconcepto AND IdArea=@idarea";
        
        
        // Tablas//////////////////////


        internal void actualizaTablaAreaConceptoMes(int idconcepto, string mes, string año)
        {
           /* using (SqlConnection connection = new SqlConnection(connectionString))
            {               
                connection.Open();
                SqlDataAdapter sda =  new SqlDataAdapter();
                sda.SelectCommand =     new SqlCommand(qAreaConceptoMes, connection);
                sda.SelectCommand.Parameters.AddWithValue("@idconcepto", "%" + idconcepto + "%");
                sda.SelectCommand.Parameters.AddWithValue("@mes", "%" + mes + "%");
                sda.SelectCommand.Parameters.AddWithValue("@año", "%" + año + "%");
                
                SqlCommandBuilder builder =   new SqlCommandBuilder(sda);
           
                sda.UpdateCommand = builder.GetUpdateCommand();
                sda.Update(dataSet.Tables["dtAreaConcepto"]);
                connection.Close();
            }*/
        }

       

        internal int insertarElemento(string idconcepto, string idarea, string elemento)
        {
              using (SqlConnection connection = new SqlConnection(connectionString))
              {
                  connection.Open();
                  string sql = "INSERT INTO elemento VALUES(@idconcepto, @idarea, @elemento)";
                  SqlCommand cmd = new SqlCommand(sql, connection);
                  cmd.Parameters.Add("@idconcepto", SqlDbType.Int).Value = Int32.Parse(idconcepto);
                  cmd.Parameters.Add("@idarea", SqlDbType.Int).Value = Int32.Parse(idarea);
                  cmd.Parameters.Add("@elemento", SqlDbType.VarChar).Value = elemento;
      
                  cmd.CommandType = CommandType.Text;

                  try
                  {
                    int r = cmd.ExecuteNonQuery();
                    MessageBox.Show("Elemento grabado");
                    return r;

                  }
                  catch (SqlException ex)
                  {
                      MessageBox.Show("El elemento ya existe.");
                      return 0;
                  }
              }
           
        }

        internal int insertarArea(string area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO area VALUES(@area)";
                SqlCommand cmd = new SqlCommand(sql, connection);               
                cmd.Parameters.Add("@area", SqlDbType.VarChar).Value = area;

                cmd.CommandType = CommandType.Text;
               
                try
                {
                    int r = cmd.ExecuteNonQuery();
                    MessageBox.Show("Area grabada");
                    return r;
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("El area ya existe.");
                    return 0;
                }
            }
         }

        internal int eliminarArea(string idarea)
        {
            int r = eliminarAsientoIdArea(idarea);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE area WHERE id=@idarea";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idarea", SqlDbType.Int).Value = Int32.Parse(idarea);

                cmd.CommandType = CommandType.Text;
                try
                {
                    r = cmd.ExecuteNonQuery();
                    return r;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Se ha producido un error");
                    return 0;
                }
            }
        }

        

        internal int insertarAsiento(string idelemento,DateTime fecha,string estimado, string descuento, string real)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO asiento VALUES(@idelemento, @fecha,@estimado,@descuento,@real)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idelemento", SqlDbType.Int).Value = Int32.Parse(idelemento);       
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                cmd.Parameters.Add("@estimado", SqlDbType.Money).Value = estimado;
                cmd.Parameters.Add("@descuento", SqlDbType.Money).Value = descuento;
                cmd.Parameters.Add("@real", SqlDbType.Money).Value = real;

                cmd.CommandType = CommandType.Text;

                try
                {
                    int r = cmd.ExecuteNonQuery();
                    MessageBox.Show("Asiento grabado");
                    return r;

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Asiento ya existe.");
                    return 0;
                }
            }
        }

        internal int eliminarAsiento(string idasiento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE asiento WHERE id=@idasiento";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idasiento", SqlDbType.Int).Value = Int32.Parse(idasiento);
               

                cmd.CommandType = CommandType.Text;

                try
                {
                    int r = cmd.ExecuteNonQuery();                  
                    return r;

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Se ha producido un error");
                    return 0;
                }
            }
        }

        private int eliminarAsientoIdArea(string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE asiento WHERE idArea=@idarea";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idarea", SqlDbType.Int).Value = Int32.Parse(idarea);

                cmd.CommandType = CommandType.Text;

                try
                {
                    int r = cmd.ExecuteNonQuery();
                    return r;

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Se ha producido un error");
                    return 0;
                }
            }
        }

        internal int actualizarAsiento(string idasiento,DateTime fecha, string estimado, string descuento, string real)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE asiento SET fecha=@fecha, estimado=@estimado, descuento=@descuento, real=@real WHERE id=@idasiento";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idasiento", SqlDbType.Int).Value = Int32.Parse(idasiento);
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;
                cmd.Parameters.Add("@estimado", SqlDbType.Money).Value = Double.Parse(estimado);
                cmd.Parameters.Add("@descuento", SqlDbType.Money).Value = Double.Parse(descuento);
                cmd.Parameters.Add("@real", SqlDbType.Money).Value = Double.Parse(real);

                cmd.CommandType = CommandType.Text;

                try
                {
                    int r = cmd.ExecuteNonQuery();
                    return r;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Se ha producido un error");
                    return 0;
                }
            }
        }

        internal DataTable tablaAcumuladoAño(string idconcepto, string año)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qAcumuladoAño, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int);
                command.Parameters["@idconcepto"].Value = idconcepto;
                command.Parameters.AddWithValue("@año", "%" + año + "%");
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return dt;
            }
        }

        internal DataTable tablaAcumuladoAñoArea(string idconcepto, string año, string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qAcumuladoAñoArea, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int);
                command.Parameters["@idconcepto"].Value = idconcepto;
                command.Parameters.Add("@idarea", SqlDbType.Int);
                command.Parameters["@idarea"].Value = idarea;
                command.Parameters.AddWithValue("@año", "%" + año + "%");
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return dt;
            }
        }

        internal DataTable tablaTotalesConceptoMesAño(string idconcepto, string mes, string año)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {               
                SqlCommand command = new SqlCommand(qTotalesConceptoMesAño, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int);
                command.Parameters["@idconcepto"].Value = idconcepto;              
                command.Parameters.AddWithValue("@mes", "%" + mes + "%");
                command.Parameters.AddWithValue("@año", "%" + año + "%");
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();                   
                    dt.Load(reader);
                    connection.Close();
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return dt;
            }
        }

        internal DataTable tablaTotalesConceptoMesAñoArea(string idconcepto, string mes, string año, string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qTotalesConceptoMesAñoArea, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int);
                command.Parameters["@idconcepto"].Value = idconcepto;
                command.Parameters.Add("@idarea", SqlDbType.Int);
                command.Parameters["@idarea"].Value = idarea;
                command.Parameters.AddWithValue("@mes", "%" + mes + "%");
                command.Parameters.AddWithValue("@año", "%" + año + "%");
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return dt;
            }
        }

        internal void tablaTotalesConceptoMesArea(string idconcepto, string mes, string area)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (dataSet.Tables["dtTotales" + idconcepto + mes + area] != null)
                    dataSet.Tables["dtTotales" + idconcepto + mes + area].Clear();

                SqlDataAdapter sda = new SqlDataAdapter(qTotalesConceptoMesAñoArea, connection);
                sda.SelectCommand.Parameters.AddWithValue("@idconcepto", "%" + idconcepto + "%");
                sda.SelectCommand.Parameters.AddWithValue("@mes", "%" + mes + "%");
                sda.SelectCommand.Parameters.AddWithValue("@area", "%" + area + "%");
                connection.Open();
                sda.Fill(dataSet, "dtTotales" + idconcepto + mes + area);
                connection.Close();


            }
        }

        internal DataTable tablaElementosConceptoMesesAñoArea(string idconcepto, string año, string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
             /*   if (dataSet.Tables["dtElementos" + idconcepto + idarea] != null)
                    dataSet.Tables["dtElementos" + idconcepto + idarea].Clear();

                SqlDataAdapter sda = new SqlDataAdapter(qElementosConceptoMesesAñoArea, connection);
                sda.SelectCommand.Parameters.AddWithValue("@idconcepto", "%" + idconcepto + "%");
                sda.SelectCommand.Parameters.AddWithValue("@idarea", "%" + idarea + "%");
                sda.SelectCommand.Parameters.AddWithValue("@año", "%" + año + "%");
                
                connection.Open();
                sda.Fill(dataSet, "dtElementos" + idconcepto + idarea);
                connection.Close();
*/
                SqlCommand command = new SqlCommand(qElementosConceptoMesesAñoArea, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int);
                command.Parameters["@idconcepto"].Value = idconcepto;
                command.Parameters.Add("@idarea", SqlDbType.Int);
                command.Parameters["@idarea"].Value = idarea;
                command.Parameters.AddWithValue("@año", "%" + año + "%");
                DataTable dt = new DataTable();
                try
                {                  
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();                  
                    dt.Load(reader);
                    connection.Close();                  
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message+"ERROR tablaElementosconcetpmedesañosarea");
                }

                return dt;
               
            }
        }

        internal DataTable tablaAreasConceptoMesAño(string idconcepto, string mes, string año)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qAreasConceptoMesAño, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int);
                command.Parameters["@idconcepto"].Value = idconcepto;
                command.Parameters.AddWithValue("@mes", "%" + mes + "%");
                command.Parameters.AddWithValue("@año", "%" + año + "%");

               
                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message+"ERROR no se pudieron cargar las AREAs");
                }

                return dt;
              

            }
        }

        //Para añadir tablas al dataSet
        public void tablaDataSet(string query, string tabla)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (dataSet.Tables[tabla] != null)
                    dataSet.Tables[tabla].Clear();

                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);              
                sda.Fill(dataSet, tabla);
                connection.Close();


            }
        }



        internal DataTable tabla(String query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                connection.Close();

                return dt;
            }
        }

        internal DataTable tablaId(string query, string idconcepto, string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int).Value = idconcepto;
                command.Parameters.Add("@idarea", SqlDbType.Int).Value = idarea;

                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "ERROR consulta elemento ID");
                }

                return dt;

            }
        }

    }
}
