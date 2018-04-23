using CryptoQuery.Domain.Articles;
using CryptoQuery.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace CryptoQuery.SqlServer
{
    public class CryptoDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        public CryptoDbContext()
        {

        }

        public CryptoDbContext(DbContextOptions<CryptoDbContext> context) : base(context)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if environment is development, use local host
            var connectionString = GetConnectionStringFromAppConfigFile("LocalHost");

            // otherwise use Azure
            
            optionsBuilder.UseSqlServer(connectionString);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        private string GetConnectionStringFromAppConfigFile(string connectionStringName)
        {
            XDocument xmlDocument = XDocument.Load("app.config");

            var addXmlElement = xmlDocument.Descendants().Where(element => element.Name == "add" && element.Attribute("name").Value == connectionStringName).FirstOrDefault();

            if (addXmlElement == null)
            {
                return string.Empty;
            }

            return addXmlElement.Attribute("connectionString").Value;
        }
    }
}