using FFLogs.NET.Enums;

namespace FFLogs.NET.Options {
    public class CharacterRankingOptions {
        public int? Bracket { get; set; }
        public Difficulty Difficulty { get; set; } = Difficulty.Default;
        public string? Filter { get; set; }
        public int Page { get; set; } = 1;
        public int? Partition { get; set; }
        public string? ServerRegion { get; set; }
        public string? ServerSlug { get; set; }
        public int? Size { get; set; }
        public LeaderboardRank? Leaderboard { get; set; }
        public CharacterRankingMetricType? Metric { get; set; }
        public bool? IncludeCombatantInfo { get; set; }
        public string? ClassName { get; set; }
        public string? JobName { get; set; }

        public static CharacterRankingOptions DefaultOptions => new();
    }
}
