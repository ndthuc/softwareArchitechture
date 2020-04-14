using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TIN415DE01_HomeworkW03.DAL;
using TIN415DE01_HomeworkW03.DTO;

namespace TIN415DE01_HomeworkW03.BLL
{
    class ArtBUS
    {
        public List<Art_Materials_n_Tool> GetAll()
        {
            List<Art_Materials_n_Tool> artItems = new ArtDAO().SelectAll();
            return artItems;
        }

        public List<Art_Materials_n_Tool> Search(String keyword)
        {
            List<Art_Materials_n_Tool> artItems = new ArtDAO().SelectByName(keyword);
            return artItems;
        }

        public bool AddNewIntem(Art_Materials_n_Tool artItem)
        {
            bool result = new ArtDAO().Insert(artItem);
            return result;
        }

        public bool DeleteItem(int code)
        {
            bool result = new ArtDAO().Delete(code);
            return result;
        }

        public bool UpdateItem(Art_Materials_n_Tool artItem)
        {
            bool result = new ArtDAO().Update(artItem);
            return result;
        }
    }
}
