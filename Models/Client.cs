using Microsoft.Data.SqlClient;

namespace Client.Models
{
    public class Clients
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNo { get; set; }
        public string Address { get; set; }
        public string CreatedAt { get; set; }


        public static List<Clients> GetAllClients()
        {
            List<Clients> lstCli = new List<Clients>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from Client";
                SqlDataReader dr = cmdInsert.ExecuteReader();
                while (dr.Read())
                    lstCli.Add(new Clients { Id = dr.GetInt32(0), Name = dr.GetString(1), Email = dr.GetString(2), PhoneNo = dr.GetInt32(3), Address = dr.GetString(4), CreatedAt = dr.GetString(5) });
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return lstCli;
        }

        public static Clients GetSingleClient(int Id)
        {
            Clients obj = new Clients();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "select * from Client where Id=@Id";
                cmdInsert.Parameters.AddWithValue("@Id", Id);
                SqlDataReader dr = cmdInsert.ExecuteReader();
                if (dr.Read())
                {

                    obj.Id = dr.GetInt32(0);
                    obj.Name = dr.GetString(1);
                    obj.Email = dr.GetString(2);
                    obj.PhoneNo = dr.GetInt32(3);
                    obj.Address = dr.GetString(4);
                    obj.CreatedAt = dr.GetString(5);

                }
                else
                {
                    obj = null;
                    //Console.WriteLine("Not present");
                    //record not persent
                }
                dr.Close();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }

        public static void InsertClient(Clients obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "insert into Client values(@Id,@Name,@Email,@PhoneNo,@Address,@CreatedAt )";


                cmdInsert.Parameters.AddWithValue("@Id", obj.Id);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Email", obj.Email);
                cmdInsert.Parameters.AddWithValue("@PhoneNo", obj.PhoneNo);
                cmdInsert.Parameters.AddWithValue("@Address", obj.Address);
                cmdInsert.Parameters.AddWithValue("@CreatedAt", obj.CreatedAt);
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }




        }

        public static void UpdateClient(Clients obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "update Client set  Name=@Name,Email=@Email,PhoneNo=@PhoneNo,Address=@Address,CreatedAt=@CreatedAt where Id =@Id";

                cmdInsert.Parameters.AddWithValue("@Id", obj.Id);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Email", obj.Email);
                cmdInsert.Parameters.AddWithValue("@PhoneNo", obj.PhoneNo);
                cmdInsert.Parameters.AddWithValue("@Address", obj.Address);
                cmdInsert.Parameters.AddWithValue("@CreatedAt", obj.CreatedAt);
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }




        }

        public static void DeleteClient(int Id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KtJune23;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "delete from Client where Id =@Id";




                cmdInsert.Parameters.AddWithValue("@Id", Id);
                cmdInsert.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }




        }

    }
}
