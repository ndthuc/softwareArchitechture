using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppShare
{
    public interface IArtBUS
    {
        List<Art_Materials_n_Tool> GetAll();

        List<Art_Materials_n_Tool> Search(String keyword);

        bool AddNewIntem(Art_Materials_n_Tool artItem);

        bool DeleteItem(int code);

        bool UpdateItem(Art_Materials_n_Tool artItem);
    }
}
