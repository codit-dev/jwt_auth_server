namespace auth.api.migrations
{
    using contexts;
    using entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using static models.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<auth.api.contexts.AuthContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(auth.api.contexts.AuthContext context)
        {

            var manager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(new AuthContext()));
            

            var user = new IdentityUser()
            {
                UserName = "Bonga",
                Email = "bonga.dludla@gmail.com",
                EmailConfirmed = true,
            };

            manager.Create(user, "051991Dludl@");

            if (context.Audiences.Count() > 0)
            {
                return;
            }

            context.Audiences.AddRange(BuildClientsList());
            context.SaveChanges();

        }

        private static List<Audience> BuildClientsList()
        {

            List<Audience> ClientsList = new List<Audience>
            {
                new Audience
                {
                    ClientId = "angularApp",
                    Base64Secret= Helper.GetHash("abc@123"),
                    Name="Angular Application",
                    ApplicationType =  ApplicationTypes.JavaScript,
                    Active = true,
                    RefreshTokenLifeTime = 7200,
                    AllowedOrigin = "*"
                },
                new Audience
                {
                    ClientId = "consoleApp",
                    Base64Secret= Helper.GetHash("123@abc"),
                    Name="Console Application",
                    ApplicationType = ApplicationTypes.NativeConfidential,
                    Active = true,
                    RefreshTokenLifeTime = 14400,
                    AllowedOrigin = "*"
                }
            };

            return ClientsList;
        }
    }
}
