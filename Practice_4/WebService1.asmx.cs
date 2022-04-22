using Practice_4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Practice_4
{
    /// <summary>
    /// Сводное описание для WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    //[System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

		[WebMethod]
		public List<Customer> GetAllClients()
		{
			List<Customer> clients = new List<Customer>();

			//string str = System.Configuration.ConfigurationManager.ConnectionStrings["Orders_and_customers"].ConnectionString;//"Server=localhost;uid=sa;pwd=;database=Orders_and_customers"
			using (SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Orders_and_customers"].ConnectionString))
			{
				SqlCommand com = new SqlCommand("Select * from Clients", con);
				con.Open();
				SqlDataReader sdr = com.ExecuteReader();
				while (sdr.Read())
				{
					Customer c = new Customer();
					c.Id = (int)sdr["Id"];
					c.Name = sdr["Name"].ToString();
					c.Surname = sdr["Surname"].ToString();
					c.Address = sdr["Address"].ToString();
					clients.Add(c);
				}
			}

			return clients;
		}
	}
}
