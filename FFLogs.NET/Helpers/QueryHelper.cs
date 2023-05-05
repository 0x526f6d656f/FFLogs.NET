using FFLogs.NET.Options;

namespace FFLogs.NET.Helpers
{
    internal static class QueryHelper {
        public static string GetZonesQuery() {
            return $$"""
                query {
                  worldData {
                    expansions {
                      name
                      zones {
                        name
                        expansion {
                          name
                        }
                        encounters {
                          name
                          id
                        }
                      }
                    }
                  }
                }
                """;
        }

        public static string GetJobDataQuery() {
            return $$"""
                query {
                  gameData {
                    classes {
                      id
                      name
                      slug
                      specs {
                        id
                        name
                        slug
                      }
                    }
                  }
                }
                """;
        }

        public static string GetEncounterFightRankingsQuery(int encounterId, FightRankingOptions rankingOptions) {
            return $$"""
                query {
                  worldData {
                    encounter (id: {{encounterId}}) {
                      fightRankings (
                        {{(rankingOptions.Bracket.HasValue ? $"bracket: {rankingOptions.Bracket}" : "")}}
                        difficulty: {{(int)rankingOptions.Difficulty}}
                        {{(rankingOptions.Filter != null ? $"filter: \"{rankingOptions.Filter}\"" : "")}}
                        page: {{rankingOptions.Page}}
                        {{(rankingOptions.Partition.HasValue ? $"partition: {rankingOptions.Partition}" : "")}}
                        {{(rankingOptions.ServerRegion != null ? $"serverRegion: \"{rankingOptions.ServerRegion}\"" : "")}}
                        {{(rankingOptions.ServerSlug != null ? $"serverSlug: \"{rankingOptions.ServerSlug}\"" : "")}}
                        {{(rankingOptions.Size.HasValue ? $"size: {rankingOptions.Size}" : "")}}
                        {{(rankingOptions.Leaderboard.HasValue ? $"leaderboard: {rankingOptions.Leaderboard}" : "")}}
                        {{(rankingOptions.Metric.HasValue ? $"metric: {rankingOptions.Metric}" : "")}}
                      )
                    }
                  }
                }
                """;
        }

        public static string GetEncountercharacterRankingsQuery(int encounterId, CharacterRankingOptions rankingOptions) {
            return $$"""
                query {
                  worldData {
                    encounter (id: {{encounterId}}) {
                      characterRankings (
                        {{(rankingOptions.Bracket.HasValue ? $"bracket: {rankingOptions.Bracket}" : "")}}
                        difficulty: {{(int)rankingOptions.Difficulty}}
                        {{(rankingOptions.Filter != null ? $"filter: \"{rankingOptions.Filter}\"" : "")}}
                        page: {{rankingOptions.Page}}
                        {{(rankingOptions.Partition.HasValue ? $"partition: {rankingOptions.Partition}" : "")}}
                        {{(rankingOptions.ServerRegion != null ? $"serverRegion: \"{rankingOptions.ServerRegion}\"" : "")}}
                        {{(rankingOptions.ServerSlug != null ? $"serverSlug: \"{rankingOptions.ServerSlug}\"" : "")}}
                        {{(rankingOptions.Size.HasValue ? $"size: {rankingOptions.Size}" : "")}}
                        {{(rankingOptions.Leaderboard.HasValue ? $"leaderboard: {rankingOptions.Leaderboard}" : "")}}
                        {{(rankingOptions.Metric.HasValue ? $"metric: {rankingOptions.Metric}" : "")}}
                        {{(rankingOptions.IncludeCombatantInfo.HasValue ? $"includeCombatantInfo: {rankingOptions.IncludeCombatantInfo}" : "")}}
                        {{(rankingOptions.ClassName != null ? $"className: \"{rankingOptions.ClassName}\"" : "")}}
                        {{(rankingOptions.JobName != null ? $"specName: \"{rankingOptions.JobName}\"" : "")}}
                      )
                    }
                  }
                }
                """;
        }
    }
}
