using GospelWorld.Models;
using GospelWorld.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GospelWorld.Entities;

namespace GospelWorld.Controllers.Api
{
   // [RoutePrefix("api/rainofheaven")]
    public class SermonApiController : ApiController
    {
        private ApplicationDbContext _context;
        private readonly ISermonServices _sermonServices;
        public SermonApiController(ISermonServices sermonServices)
        {
            _sermonServices = sermonServices;
            _context = new ApplicationDbContext();
        }

        public HttpResponseMessage GetSermons()
        {
            try
            {
                var sermon = _context.Sermons;
                return this.Request.CreateResponse<IEnumerable<Sermon>>(HttpStatusCode.Created, sermon);
            }
            catch(Exception message)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, message.Message);
            }
        }

        public HttpResponseMessage AddSermon([FromBody]SermonModel s )
        {
            IEnumerable<SermonModel> sermon = _sermonServices.GetSermons();
            var checksermon = sermon.FirstOrDefault(se => se.SermonTitle == s.SermonTitle);
            if (checksermon != null) return this.Request.CreateResponse(HttpStatusCode.Conflict, "Sermon with the title exist ");
            var model = s.Create(s);
            _context.Sermons.Add(model);
            _context.SaveChanges();
            return this.Request.CreateResponse(HttpStatusCode.Created, "Successful");
        }
    }
}
