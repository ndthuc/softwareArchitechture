using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;

namespace ArtSOAPServiceHW09
{
    
    public class ArtDAO
    {
        private static String strCon = ConfigurationManager.ConnectionStrings["tin415de2171609ConnectionString"].ConnectionString;
        MyArtDBDataContext db = new MyArtDBDataContext(strCon);
        public List<Art_Materials_n_Tool> SelectAll()
        {
            List<Art_Materials_n_Tool> artItems = db.Art_Materials_n_Tools.ToList();
            return artItems;
        }

        public List<Art_Materials_n_Tool> SelectByName(String keyword)
        {

            List<Art_Materials_n_Tool> artItems = db.Art_Materials_n_Tools.Where(artItem => artItem.Name.Contains(keyword)).ToList();
            return artItems;
        }
        public bool Insert(Art_Materials_n_Tool newArtItem)
        {
            try
            {
                db.Art_Materials_n_Tools.InsertOnSubmit(newArtItem);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int code)
        {
            Art_Materials_n_Tool artItem = db.Art_Materials_n_Tools.SingleOrDefault(Item => Item.Code == code);
            if (artItem != null)
            {
                try
                {
                    db.Art_Materials_n_Tools.DeleteOnSubmit(artItem);
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }



        }
        public bool Update(Art_Materials_n_Tool updatedArtItem)
        {
            Art_Materials_n_Tool artItem = db.Art_Materials_n_Tools.SingleOrDefault(item => item.Code == updatedArtItem.Code);
            if (artItem != null)
            {
                try
                {
                    artItem.Name = updatedArtItem.Name;
                    artItem.Category = updatedArtItem.Category;
                    artItem.Price = updatedArtItem.Price;
                    artItem.Brand = updatedArtItem.Brand;
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}