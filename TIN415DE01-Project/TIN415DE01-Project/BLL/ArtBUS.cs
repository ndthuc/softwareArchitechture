using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TIN415DE01_Project.DTO;
using TIN415DE01_Project.DAL;

namespace TIN415DE01_Project.BLL
{
    class ArtBUS
    {
        public List<ArtItem> GetAll()
        {
            List<ArtItem> artItems = new ArtDAO().SelectAll();
            return artItems;
        }

        public List<ArtItem> Search(String keyword)
        {
            List<ArtItem> artItems = new ArtDAO().SelectByName(keyword);
            return artItems;
        }

        public bool AddNewIntem(ArtItem artItem)
        {
            bool result = new ArtDAO().Insert(artItem);
            return result;
        }
        
        public bool DeleteItem(int code)
        {
            bool result = new ArtDAO().Delete(code);
            return result;
        }

        public bool UpdateItem(ArtItem artItem)
        {
            bool result = new ArtDAO().Update(artItem);
            return result;
        }
    }
}
