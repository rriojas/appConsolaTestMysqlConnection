using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
namespace appConsolaTestMysqlConnection
{
  class Program
  {
    static void Main(string[] args)
    {
      string cadena= "Server = localhost;Database = testdb1;Uid = root;Pwd = ;sslmode=none;";
      MySqlConnection conexion = new MySqlConnection(cadena);
      conexion.Open();
      string consulta;
      consulta = "insert into table1 values(8,'asdfasdfasdfasdf','1');";
      MySqlCommand cmd = new MySqlCommand(consulta, conexion);
      cmd.ExecuteNonQuery();
      consulta = "select * from table1;";
      DataSet ds = new DataSet();
      MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
      da.Fill(ds, "table1");
      for (int i = 0; i < ds.Tables[0].Rows.Count ; i++)
      {
        Console.WriteLine(ds.Tables["table1"].Rows[i].ItemArray[0]+ " " + ds.Tables["table1"].Rows[i].ItemArray[1]);
      }

      Console.ReadKey();
    }
  }
}
