using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Transfermarkt.Models.Requests;
using Transfermarkt.WebAPI.Database;

namespace Transfermarkt.WebAPI.Services
{
    public interface IReportGenerator
    {
        IEnumerable<Transfers> GetTransfersReport();
    }

    public class ReportGenerator : IReportGenerator
    {
        private readonly FootballAssociationDbContext _context;

        public ReportGenerator(FootballAssociationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Transfers> GetTransfersReport()
        {
            return _context.Contracts.Include(x => x.Club).Include(x => x.Player)
                .Where(y => y.PlayerId == y.Player.Id)
                .Select(x => new Transfers
                {
                    ClubName = x.Club.Name,
                    PlayerFullName = $"{x.Player.FirstName } {x.Player.LastName}",
                    ContractExpirationDate = x.ExpirationDate,
                    RedemptionClause = $"{x.RedemptionClause} €"
                }).ToList();
        }
    }
}
