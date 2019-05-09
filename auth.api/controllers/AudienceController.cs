using auth.api.entities;
using auth.api.models;
using auth.api.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace auth.api.controllers
{
    [RoutePrefix("api/audience")]
    public class AudienceController : ApiController
    {
        [Route("")]
        public IHttpActionResult Post(AudienceModel audienceModel) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Audience newAudience = AudienceRepository.AddAudience(audienceModel.Name);

            return Ok<Audience>(newAudience);

        }
    }
}