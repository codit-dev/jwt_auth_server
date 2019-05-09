using auth.api.contexts;
using auth.api.entities;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace auth.api.repositories
{
    
    public static class AudienceRepository
    {
        private static AuthContext db = new AuthContext();

        public static Audience AddAudience(string name)
        {
            var clientId = Guid.NewGuid().ToString("N");

            var key = new byte[32];
            RNGCryptoServiceProvider.Create().GetBytes(key);
            var base64Secret = TextEncodings.Base64Url.Encode(key);

            Audience newAudience = new Audience { ClientId = clientId, Base64Secret = base64Secret, Name = name };// TODO: add other properties (see Audience entity). These properties could also be assigned as parameters in AddAudience method  
            db.Audiences.Add(newAudience);
            db.SaveChanges();

            return newAudience;
        }

        public static Audience FindAudience(string clientId)
        {
            var audience = db.Audiences.Find(clientId);

            if (audience != null)
            {
                return audience;
            }

            return null;
        }
    }
}