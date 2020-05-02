using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppShare;

namespace AppServer
{
    class ArtDAO
    {
        private static String strCon = "SERVER = den1.mssql7.gear.host; DATABASE = tin415de2171609;" +
            " USER = tin415de2171609; PASSWORD = Ni8luMJ-T~vI";
        private MyArtDBDataContext db = new MyArtDBDataContext(strCon);

        public List<Art_Materials_n_Tool> SelectAll()
        {
            db.ObjectTrackingEnabled = false;

            List<Art_Materials_n_Tool> artItems = db.Art_Materials_n_Tools.ToList();
            return artItems;
        }
        public List<Art_Materials_n_Tool> SelectByName(String keyword)
        {
            db.ObjectTrackingEnabled = false;

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
