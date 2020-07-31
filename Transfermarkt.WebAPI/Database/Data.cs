using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transfermarkt.WebAPI.Database
{
    public class Data
    {
        public static void Seed(FootballAssociationDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
