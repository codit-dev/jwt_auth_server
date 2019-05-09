using auth.api.entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace auth.api.contexts
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
           : base("AuthContext", throwIfV1Schema: false)
        {

        }

        public DbSet<Audience> Audiences { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public static AuthContext Create()
        {
            return new AuthContext();
        }
    }
}