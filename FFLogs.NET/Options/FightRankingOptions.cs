using FFLogs.NET.Enums;

namespace FFLogs.NET.Options {

    public class FightRankingOptions {
        public int? Bracket { get; set; }
        public Difficulty Difficulty { get; set; } = Difficulty.Default;
        public string? Filter { get; set; }
        public int Page { get; set; } = 1;
        public int? Partition { get; set; }
        public string? ServerRegion { get; set; }
        public string? ServerSlug { get; set; }
        public int? Size { get; set; }
        public LeaderboardRank? Leaderboard { get; set; }
        public FightRankingMetricType? Metric { get; set; }

        public static FightRankingOptions DefaultOptions => new();
    }
}
