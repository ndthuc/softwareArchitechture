using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using TIN415DE01_Project.DTO;

namespace TIN415DE01_Project.DAL
{
    class ArtDAO
    {
        public List<ArtItem> SelectAll()
        {
            List<ArtItem> artItems = new List<ArtItem>();
            //connect db
            String strCon = "SERVER = den1.mssql7.gear.host; DATABASE = tin415de2171609;" +
                " USER = tin415de2171609; PASSWORD = Ni8luMJ-T~vI";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "select * from [Art_Materials_n_Tools]";
            SqlCommand sqlCommand = new SqlCommand(strCom, con);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ArtItem artItem = new ArtItem()
                {
                    Code = (int)sqlDataReader["Code"],
                    Name = (string)sqlDataReader["Name"],
                    Category = (string)sqlDataReader["Category"],
                    Price = (int)sqlDataReader["Price"],
                    Brand = (string)sqlDataReader["Brand"]
                };
                artItems.Add(artItem);
            }
            return artItems;
        }

        public bool Insert(ArtItem Item)
        {
            String strCon = "SERVER = den1.mssql7.gear.host; DATABASE = tin415de2171609;" +
                " USER = tin415de2171609; PASSWORD = Ni8luMJ-T~vI";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "insert into [Art_Materials_n_Tools] " +
                "values (@Name, @Category, @Price, @Brand)";
            SqlCommand sqlCommand = new SqlCommand(strCom, con);

            sqlCommand.Parameters.Add(new SqlParameter("@Name", Item.Name));
            sqlCommand.Parameters.Add(new SqlParameter("Category", Item.Category));
            sqlCommand.Parameters.Add(new SqlParameter("@Price", Item.Price));
            sqlCommand.Parameters.Add(new SqlParameter("@Brand", Item.Brand));

            
            try
            {
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0) return true;
                else return false;
            }
            catch { return false; }
        }

        public List<ArtItem> SelectByName(String keyword)
        {
            List<ArtItem> artItems = new List<ArtItem>();
            //connect db
            String strCon = "SERVER = den1.mssql7.gear.host; DATABASE = tin415de2171609;" +
                " USER = tin415de2171609; PASSWORD = Ni8luMJ-T~vI";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "select * from [Art_Materials_n_Tools]" +
                "where Name like '%" + keyword + "%'";
            SqlCommand sqlCommand = new SqlCommand(strCom, con);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                ArtItem artItem = new ArtItem()
                {
                    Code = (int)sqlDataReader["Code"],
                    Name = (string)sqlDataReader["Name"],
                    Category = (string)sqlDataReader["Category"],
                    Price = (int)sqlDataReader["Price"],
                    Brand = (string)sqlDataReader["Brand"]
                };
                artItems.Add(artItem);
            }
            return artItems;
        }

        public bool Update(ArtItem Item)
        {
            String strCon = "SERVER = den1.mssql7.gear.host; DATABASE = tin415de2171609;" +
                " USER = tin415de2171609; PASSWORD = Ni8luMJ-T~vI";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "update [Art_Materials_n_Tools] " +
                "set Name = @Name, Category = @Category, Price = @Price, Brand = @Brand " +
                "where Code = @Code";
            SqlCommand sqlCommand = new SqlCommand(strCom, con);

            sqlCommand.Parameters.Add(new SqlParameter("@Code", Item.Code));
            sqlCommand.Parameters.Add(new SqlParameter("@Name", Item.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@Category", Item.Category));
            sqlCommand.Parameters.Add(new SqlParameter("@Price", Item.Price));
            sqlCommand.Parameters.Add(new SqlParameter("@Brand", Item.Brand));


            try
            {
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0) return true;
                else return false;
            }
            catch { return false; }
        }

        public bool Delete(int code)
        {
            String strCon = "SERVER = den1.mssql7.gear.host; DATABASE = tin415de2171609;" +
                " USER = tin415de2171609; PASSWORD = Ni8luMJ-T~vI";
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "delete from [Art_Materials_n_Tools] where Code = "
                + code + "";
            SqlCommand sqlCommand = new SqlCommand(strCom, con);
            try
            {
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0) return true;
                else return false;
            }
            catch { return false; }
        }
    }
}
