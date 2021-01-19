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
        IEnumerable<ClubContracts> GetClubContractsReport();
    }

    public class ReportGenerator : IReportGenerator
    {
        private readonly FootballAssociationDbContext _context;

        public ReportGenerator(FootballAssociationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ClubContracts> GetClubContractsReport()
        {
            return _context.Clubs.Include(x => x.Contracts).ThenInclude(x => x.Player)
                .Select(x => new ClubContracts
                {
                    ClubName = x.Name,
                    Sum = _context.Contracts.Where(p => p.ClubId == x.Id).Sum(s => s.RedemptionClause)
                }).ToList();
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
