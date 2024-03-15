namespace APIBowling.Data
{
    public interface IBowlingRepository
    {
        IEnumerable<Bowler> Bowlers { get; }
        IEnumerable<Team> Teams { get; }
        IEnumerable<Bowler> GetAllBowlers();
    }
}
