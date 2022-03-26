using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace SmartGADs.Models
{
    public class ProductDB
    {
       
            private SqlConnection con;
            private void connection()
            {
                string constring = System.Configuration.ConfigurationManager.ConnectionStrings["Productconn"].ToString();
                con = new SqlConnection(constring);
            }
        // ADD NEW PRODUCT 
        public bool AddProduct(Product pmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", pmodel.Name);
            cmd.Parameters.AddWithValue("@Quantity", pmodel.Quantity);
            

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //  VIEW PRODUCT DETAILS 
        public List<Product> GetProduct()
        {
            connection();
            List<Product> ProductList = new List<Product>();

            SqlCommand cmd = new SqlCommand("GetProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                ProductList.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                       Quantity=Convert.ToInt32(dr["Quantity"])
                    });
            }
            return ProductList;
        }
        //  UPDATE PRODUCT DETAILS 
        public bool UpdateDetails(Product pmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateProductDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", pmodel.Id);
            cmd.Parameters.AddWithValue("@Name", pmodel.Name);
            cmd.Parameters.AddWithValue("@Quantity", pmodel.Quantity);
            

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        //  DELETE STUDENT DETAILS 
        public bool DeleteProduct(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeleteProduct", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
