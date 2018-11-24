using ContentService.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ContentService.Repository
{
    public class ContentItemRepository: IContentItemRepository
    {
        private IConfiguration _configuration;

        public ContentItemRepository(IConfiguration configuration)
        {
           var test = configuration.GetConnectionString("ContentService");
            _configuration = configuration;
        }
              

        public List<ContentItem> GetAllConentItemsAsync()
        {
            using (IDbConnection db = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Database=Content;Persist Security Info=true;"))
            {
                return db.Query<ContentItem>
                (GetAllContentItems).ToList();
            }
        }

        private static string GetAllContentItems = "Select \"ContentKey\",\"Name\", \"Value\" from \"ContentItems\"";

    }
}
