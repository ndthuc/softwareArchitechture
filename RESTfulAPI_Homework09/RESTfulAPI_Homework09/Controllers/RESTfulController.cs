using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RESTfulAPI_Homework09.Models;
using RESTfulAPI_Homework09.DAL;

namespace RESTfulAPI_Homework09.Controllers
{
    public class RESTfulController : ApiController
    {
        [HttpGet]
        [Route("api/arts")]
        public List<Art_Materials_n_Tool> GetAll()
        {
            List<Art_Materials_n_Tool> artItems = new ArtDAO().SelectAll();
            return artItems;
        }
        [HttpGet]
        [Route("api/arts/search/{keyword}")]
        public List<Art_Materials_n_Tool> Search(String keyword)
        {
            List<Art_Materials_n_Tool> artItems = new ArtDAO().SelectByName(keyword);
            return artItems;
        }
        [HttpPost]
        [Route("api/arts")]
        public Art_Materials_n_Tool AddNewIntem(Art_Materials_n_Tool artItem)
        {
            Art_Materials_n_Tool item = new ArtDAO().Insert(artItem);
            return item;
        }
        [HttpDelete]
        [Route("api/arts/{code}")]
        public Art_Materials_n_Tool DeleteItem(int code)
        {
            Art_Materials_n_Tool item = new ArtDAO().Delete(code);
            return item;
        }
        [HttpPut]
        [Route("api/arts/{code}")]
        public Art_Materials_n_Tool UpdateItem(int code, Art_Materials_n_Tool artItem)
        {
            Art_Materials_n_Tool item = new ArtDAO().Update(code, artItem);
            return item;
        }
        [HttpGet]
        [Route("api/arts/{code}")]
        public Art_Materials_n_Tool GetDetail(int code)
        {
            Art_Materials_n_Tool item = new ArtDAO().SelectByCode(code);
            return item;
        }
        [HttpPost]
        [Route("api/users")]
        public User Register(RegisterUser user)
        {
            User newUser = new UserDAO().Insert(user);
            return newUser;
        }

        [HttpPost]
        [Route("api/users")]
        public LoginUser Login(LoginUser user)
        {
            LoginUser loginUser = new UserDAO().GetUser(user);
            return loginUser;
        }

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}