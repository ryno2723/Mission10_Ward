
using Microsoft.EntityFrameworkCore;

namespace APIBowling.Data
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private BowlingLeagueContext _context;

        public EFBowlingRepository(BowlingLeagueContext temp) { 
            _context = temp;
        }

        public IEnumerable<Bowler> Bowlers => _context.Bowlers;

        public IEnumerable<Team> Teams => _context.Teams;
       
        public IEnumerable<Bowler> GetAllBowlers()
        {
            var joinedData = from bowler in _context.Bowlers
                                join team in _context.Teams
                                on bowler.TeamId equals team.TeamId
                                select new
                                {
                                    BowlerID = bowler.BowlerId,
                                    BowlerFirstName = bowler.BowlerFirstName,
                                    BowlerLastName = bowler.BowlerLastName,
                                    BowlerMiddleInit = bowler.BowlerMiddleInit,
                                    BowlerAddress = bowler.BowlerAddress,
                                    BowlerCity = bowler.BowlerCity,
                                    BowlerState = bowler.BowlerState,
                                    BowlerZip = bowler.BowlerZip,
                                    BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                                    TeamID = bowler.TeamId,
                                    TeamID2 = team.TeamId,
                                    TeamName = team.TeamName,
                                    CaptainID = team.CaptainId
                                };

            var bowlersWithTeams = joinedData
                .Select(b => new Bowler
                {
                    BowlerId = b.BowlerID,
                    BowlerFirstName = b.BowlerFirstName,
                    BowlerLastName = b.BowlerLastName,
                    BowlerMiddleInit = b.BowlerMiddleInit,
                    BowlerAddress = b.BowlerAddress,
                    BowlerCity = b.BowlerCity,
                    BowlerState = b.BowlerState,
                    BowlerZip = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber,
                    TeamId = b.TeamID,
                    Team = new Team { TeamName = b.TeamName, TeamId = b.TeamID2, CaptainId = b.CaptainID }
                })
                .ToList();

            return bowlersWithTeams;
            }
        }
    }

    

