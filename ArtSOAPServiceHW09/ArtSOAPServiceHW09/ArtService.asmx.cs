using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ArtSOAPServiceHW09
{
    /// <summary>
    /// Summary description for ArtService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ArtService : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}
        [WebMethod]
        public List<Art_Materials_n_Tool> GetAll()
        {
            List<Art_Materials_n_Tool> artItems = new ArtDAO().SelectAll();
            return artItems;
        }
        [WebMethod]
        public List<Art_Materials_n_Tool> Search(String keyword)
        {
            List<Art_Materials_n_Tool> artItems = new ArtDAO().SelectByName(keyword);
            return artItems;
        }
        [WebMethod]
        public bool AddNewIntem(Art_Materials_n_Tool artItem)
        {
            bool result = new ArtDAO().Insert(artItem);
            return result;
        }
        [WebMethod]
        public bool DeleteItem(int code)
        {
            bool result = new ArtDAO().Delete(code);
            return result;
        }
        [WebMethod]
        public bool UpdateItem(Art_Materials_n_Tool artItem)
        {
            bool result = new ArtDAO().Update(artItem);
            return result;
        }
    }
}
