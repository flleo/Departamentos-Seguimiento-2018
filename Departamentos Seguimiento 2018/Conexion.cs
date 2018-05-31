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
        string connectionString = "data source=EHI008\\SQLEXPRESS; initial catalog=DepartamentosSeguimiento2018; integrated security=true";
        internal DataSet dataSet = new DataSet();

        // Consultas 
        internal string qAcumuladoAño = "" +
            "SELECT sum(a.real) FROM asiento AS a "+
"INNER JOIN Elemento AS e ON E.Id=a.IdElemento "+
"WHERE e.IdConcepto = @idconcepto  AND Year(a.fecha) LIKE @año";
        internal string qAcumuladoAñoArea = "" +
        "SELECT sum(a.real) FROM asiento AS a " +
"INNER JOIN Elemento AS e ON e.Id=a.IdElemento " +
"WHERE e.IdConcepto = @idconcepto  AND Year(a.fecha) = @año AND a.IdArea=@idarea";
        private string qTotalesRealesConceptoAñoArea="" +
            "SELECT sum(a.real) FROM asiento AS a "+
"INNER JOIN ELEMENTO AS E ON E.Id=A.IDELEMENTO "+
"WHERE E.IdConcepto =  @idconcepto  AND Year(a.fecha) = @año AND idarea=@idarea";
        internal string qTotalesConceptoMesAño = "" +
            "SELECT sum(a.estimado),sum(a.descuento),sum(a.real) FROM asiento AS a "+
"INNER JOIN ELEMENTO AS E ON E.Id=A.IDELEMENTO "+
"WHERE E.IdConcepto =  @idconcepto AND MONTH(a.fecha) = @mes AND Year(a.fecha) = @año";

         internal string qTotalesConceptoMesAñoArea = "" +
           "SELECT sum(a.estimado),sum(a.descuento),sum(a.real) FROM asiento AS a " +
"INNER JOIN ELEMENTO AS E ON E.Id=A.IDELEMENTO " +
"WHERE E.IdConcepto =  @idconcepto AND MONTH(a.fecha) = @mes AND Year(a.fecha) = @año AND a.IdArea=@idarea";

        internal string qAreasConceptoMesAño = "" +
           "SELECT aR.id, ar.area, sum(a.estimado),sum(a.descuento),sum(a.real) FROM asiento AS a " +
"INNER JOIN ELEMENTO AS E ON E.Id=A.IDELEMENTO " +
"INNER JOIN AREA AS AR ON AR.Id=a.IDAREA " +
"WHERE E.IdConcepto =  @idconcepto AND MONTH(a.fecha) = @mes AND Year(a.fecha) = @año GROUP BY AR.ID,aR.AREA ";

        internal string qElementosConceptoMesAñoArea = "" +
            "SELECT e.id, e.elemento, ce.estimado,ce.descuento,ce.real, ce.id FROM asiento as ce "+
"INNER JOIN Elemento AS e ON e.Id=ce.IdElemento "+
"WHERE e.IdConcepto = @idconcepto AND Month(ce.fecha) = @mes  AND Year(ce.fecha) like @año AND ce.idarea = @idarea";

       

        internal string qConceptoIdElemento = "" +
            "SELECT c.concepto from elemento e " +
            "INNER JOIN CONCEPTO AS C ON c.id = e.idConcepto " +
            "WHERE e.id=@id";
        
        private string qElementosIdConcepto = "" +
            "SELECT e.id,e.elemento from elemento as e WHERE e.idConcepto=@id ";
        




        // Tablas//////////////////////


        internal object tablaBeneficioAcumuladoAño_(int año)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qAcumuladoAño, connection);
                command.Parameters.Add("@año", SqlDbType.Int).Value = año;
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

        internal DataTable tablaAcumuladoAño_(string idconcepto, int año)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qAcumuladoAño, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int).Value = idconcepto;
                command.Parameters.Add("@año", SqlDbType.Int).Value = año;
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
                command.Parameters.Add("@idconcepto", SqlDbType.Int).Value = idconcepto;
                command.Parameters.Add("@idarea", SqlDbType.Int).Value = idarea;
                command.Parameters.Add("@año", SqlDbType.Int).Value = año;

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

        internal int insertarElemento(string idconcepto, string elemento)
        {
              using (SqlConnection connection = new SqlConnection(connectionString))
              {
                  connection.Open();
                  string sql = "INSERT INTO elemento VALUES(@idconcepto,@elemento)";
                  SqlCommand cmd = new SqlCommand(sql, connection);
                  cmd.Parameters.Add("@idconcepto", SqlDbType.Int).Value = Int32.Parse(idconcepto);                
                  cmd.Parameters.Add("@elemento", SqlDbType.VarChar).Value = elemento;
      
                  cmd.CommandType = CommandType.Text;

                  try
                  {
                    int r = cmd.ExecuteNonQuery();
                    MessageBox.Show("Elemento GRABADO");
                    return r;

                  }
                  catch (SqlException)
                  {                      
                      return 0;
                  }
              }
           
        }

        internal object tablaElementosIdConcepto(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qElementosIdConcepto, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;

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
                    Console.WriteLine(ex.Message + "ERROR no se pudieron cargar los elementosIdConcepto");
                }
                return dt;
            }
        }

        internal int eliminarElemento(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE elemento WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(id);

                cmd.CommandType = CommandType.Text;

                try
                {
                    int r = cmd.ExecuteNonQuery();
                    Console.Write("Elemento Eliminado");
                    return r;

                }
                catch (SqlException ex)
                {
                    Console.Write("El elemento no pudo ser eliminado");
                    return 0;
                }
            }
        }

        internal void eliminarElementoAreaIdEle(string idEle)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE elemento_area WHERE idElemento=@idelemento";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idelemento", SqlDbType.Int).Value = Int32.Parse(idEle);
               

                cmd.CommandType = CommandType.Text;
                try
                {
                    int r = cmd.ExecuteNonQuery();
                   
                }
                catch (SqlException ex)
                {
                    Console.Write("ERROR eliminarElementoArea");
                  
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
                    MessageBox.Show("Area GRABADA");
                    return r;
                    
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("El area YA EXISTE.");
                    return 0;
                }
            }
         }

        internal int eliminarAreaIdArea(string idarea)
        {
            int r = eliminarAsientoIdArea(idarea);
            r = eliminarElementoAreaIdArea(idarea);

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
                catch (SqlException)
                {
                    Console.Write("ERROR eliminarArea");
                    return 0;
                }
            }
        }

        

        private int eliminarElementoAreaIdArea(string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE elemento_area WHERE idarea=@idarea";
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
                    Console.Write("ERROR eliminarElementoArea");
                    return 0;
                }
            }
        }

        internal int eliminarElementoArea(string idelemento, string idarea)
        {
   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE elemento_area WHERE idElemento=@idelemento AND idarea=@idarea";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idelemento", SqlDbType.Int).Value = Int32.Parse(idelemento);
                cmd.Parameters.Add("@idarea", SqlDbType.Int).Value = Int32.Parse(idarea);

                cmd.CommandType = CommandType.Text;
                try
                {
                    int r = cmd.ExecuteNonQuery();
                    return r;
                }
                catch (SqlException ex)
                {
                    Console.Write("ERROR eliminarElementoArea");
                    return 0;
                }
            }
        }

        internal int insertarElementoArea(string idelemento, string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                string sql = "INSERT INTO elemento_area VALUES(@idelemento,@idarea)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idelemento", SqlDbType.Int).Value = Int32.Parse(idelemento);
                cmd.Parameters.Add("@idarea", SqlDbType.Int).Value = Int32.Parse(idarea);

                cmd.CommandType = CommandType.Text;

                try
                {
                    int r = cmd.ExecuteNonQuery();

                    Console.Write("Asiento Elemento_Area GRABADO");
                    return r;

                }
                catch (SqlException ex)
                {
                    Console.Write("Asiento Elemento_Area YA EXISTE");
                    return 0;
                }
            }
        }

        internal int insertarAsiento(string idelemento,string idarea, DateTime fecha,string estimado, string descuento, string real)
        {
           
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    string sql = "INSERT INTO asiento VALUES(@idelemento,@idarea, @fecha,@estimado,@descuento,@real)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add("@idelemento", SqlDbType.Int).Value = Int32.Parse(idelemento);
                    cmd.Parameters.Add("@idarea", SqlDbType.Int).Value = Int32.Parse(idarea);
                    cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                    cmd.Parameters.Add("@estimado", SqlDbType.Money).Value = estimado;
                    cmd.Parameters.Add("@descuento", SqlDbType.Money).Value = descuento;
                    cmd.Parameters.Add("@real", SqlDbType.Money).Value = real;

                    cmd.CommandType = CommandType.Text;

                    try
                    {
                        int r = cmd.ExecuteNonQuery();
                        Console.Write("Asiento GRABADO");
                        return r;

                    }
                    catch (SqlException ex)
                    {
                        Console.Write("Asiento YA EXISTE");
                        return 0;
                    }
                }
             
        }

        internal int eliminarAsientoIdElementoIdArea(string idelemento, string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE asiento WHERE idElemento=@idelemento AND idArea=@idarea";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idelemento", SqlDbType.Int).Value = Int32.Parse(idelemento);
                cmd.Parameters.Add("@idarea", SqlDbType.Int).Value = Int32.Parse(idarea);

                cmd.CommandType = CommandType.Text;

                try
                {
                    int r = cmd.ExecuteNonQuery();
                    return r;

                }
                catch (SqlException ex)
                {

                    return 0;
                }
            }
        }

        internal int eliminarAsientoIdElemento(string idelemento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "DELETE asiento WHERE idElemento=@idelemento";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idelemento", SqlDbType.Int).Value = Int32.Parse(idelemento);
            
                cmd.CommandType = CommandType.Text;

                try
                {
                    int r = cmd.ExecuteNonQuery();
                    return r;

                }
                catch (SqlException ex)
                {
                   
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
                    Console.Write("ERROR eliminarAsientoIdArea");
                    return 0;
                }
            }
        }

        internal int actualizarAsiento(string idasiento, string estimado, string descuento, string real)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "UPDATE asiento SET  estimado=@estimado, descuento=@descuento, real=@real WHERE id=@idasiento";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@idasiento", SqlDbType.Int).Value = Int32.Parse(idasiento);
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
                    Console.Write("ERROR actualizarAsiento");
                    return 0;
                }
            }
        }

        internal int actualizarElemento(string id,  string elemento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                string sql = "UPDATE elemento SET elemento = @elemento WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = Int32.Parse(id);
                cmd.Parameters.Add("@elemento", SqlDbType.Text).Value = elemento;
               
                cmd.CommandType = CommandType.Text;

                try
                {
                    int r = cmd.ExecuteNonQuery();
                    Console.Write("Elemento actualizado con EXITO");
                    return r;
                }
                catch (SqlException ex)
                {
                    Console.Write("ERROR actualizarELEMENTO");
                    return 0;
                }
            }
        }

        internal DataTable tablaTotalesRealesConceptoAñoArea(string idconcepto, string año, string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qTotalesRealesConceptoAñoArea, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int).Value = idconcepto;
                command.Parameters.Add("@idarea", SqlDbType.Int).Value = idarea;
                command.Parameters.Add("@año", SqlDbType.Int).Value = año;

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

        internal DataTable tablaTotalesConceptoMesAño_(string idconcepto, int mes, int año)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qTotalesConceptoMesAño, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int).Value = idconcepto;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                command.Parameters.Add("@año", SqlDbType.Int).Value = año;

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
                command.Parameters.Add("@idconcepto", SqlDbType.Int).Value = idconcepto;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                command.Parameters.Add("@año", SqlDbType.Int).Value = año;
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
                    Console.WriteLine(ex.Message);
                }

                return dt;
            }
        }


        internal DataTable tablaElementosConceptoMesAñoArea_(string idconcepto, string mes, string año, string idarea)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qElementosConceptoMesAñoArea, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int).Value = idconcepto;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                command.Parameters.Add("@año", SqlDbType.Int).Value = año;
                command.Parameters.Add("@idarea", SqlDbType.Int).Value = idarea;

                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    dt.Load(reader);
                   // MessageBox.Show(dt.Rows.Count.ToString());
                    connection.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "ERROR no se pudieron cargar los elementos del mes ");
                }

                return dt;

            }
        }


        internal DataTable tablaAreasConceptoMesAño_(string idconcepto, int mes, int año)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qAreasConceptoMesAño, connection);
                command.Parameters.Add("@idconcepto", SqlDbType.Int).Value = idconcepto;
                command.Parameters.Add("@mes", SqlDbType.Int).Value = mes;
                command.Parameters.Add("@año", SqlDbType.Int).Value = año;


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

        internal DataTable tablaConceptoIdElemento(string id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(qConceptoIdElemento, connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                

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
                    Console.WriteLine(ex.Message + "ERROR tablaConceptoIdElemento");
                }

                return dt;

            }
        }

    }
}
