using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace WebApplication2.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ClientInfo> listClient= new List<ClientInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=DESKTOPHOME;Initial Catalog=mystore_webapp1;Integrated Security=True";

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String sql = "Select * FROM clients";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        { 
                            while(reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = "" + reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                                clientInfo.createdAt= reader.GetDateTime(5).ToString();
                                listClient.Add(clientInfo);

                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return;
            }
        }
    }

    public class ClientInfo {
    public string id { get; set; }
    public string name { get; set; }
    public string email{ get; set; }
    public string phone { get; set; }
    public string address { get; set; }

    public string createdAt {  get; set; }
    }
}
