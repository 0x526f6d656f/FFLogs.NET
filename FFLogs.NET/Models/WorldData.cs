using System.Text.Json.Serialization;

//todo: a lot

namespace FFLogs.NET.Models {
    public class Data {
        [JsonPropertyName("worldData")]
        public WorldData WorldData { get; set; }

        [JsonPropertyName("gameData")]
        public GameData GameData { get; set; }
    }

    public class Encounter {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("fightRankings")]
        public FightRankings FightRankings { get; set; }

        [JsonPropertyName("characterRankings")]
        public CharacterRankings CharacterRankings { get; set; }
    }

    public class Expansion {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("zones")]
        public List<Zone> Zones { get; set; }
    }

    public class Query {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class WorldData {
        [JsonPropertyName("expansions")]
        public List<Expansion> Expansions { get; set; }

        [JsonPropertyName("encounter")]
        public Encounter Encounter { get; set; }
    }

    public class Zone {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("expansion")]
        public Expansion Expansion { get; set; }

        [JsonPropertyName("encounters")]
        public List<Encounter> Encounters { get; set; }
    }

    public class Class {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("specs")]
        public List<Job> Jobs { get; set; }
    }

    public class GameData {
        [JsonPropertyName("classes")]
        public List<Class> Classes { get; set; }
    }

    public class Job {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }
    }

    public class FightRankings {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("hasMorePages")]
        public bool HasMorePages { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("rankings")]
        public List<FightRanking> Rankings { get; set; }
    }

    public class Guild {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("faction")]
        public int Faction { get; set; }
    }

    public class FightRanking {
        [JsonPropertyName("server")]
        public Server Server { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("startTime")]
        public long StartTime { get; set; }

        [JsonPropertyName("report")]
        public Report Report { get; set; }

        [JsonPropertyName("damageTaken")]
        public int DamageTaken { get; set; }

        [JsonPropertyName("deaths")]
        public int Deaths { get; set; }

        [JsonPropertyName("tanks")]
        public int Tanks { get; set; }

        [JsonPropertyName("healers")]
        public int Healers { get; set; }

        [JsonPropertyName("melee")]
        public int Melee { get; set; }

        [JsonPropertyName("ranged")]
        public int Ranged { get; set; }

        [JsonPropertyName("casters")]
        public int Casters { get; set; }

        [JsonPropertyName("guild")]
        public Guild Guild { get; set; }

        [JsonPropertyName("bracketData")]
        public double BracketData { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }
    }

    public class Report {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("fightID")]
        public int FightID { get; set; }

        [JsonPropertyName("startTime")]
        public long StartTime { get; set; }
    }

    public class Server {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }
    }

    public class CharacterRankings {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("hasMorePages")]
        public bool HasMorePages { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("rankings")]
        public List<CharacterRanking> Rankings { get; set; }
    }

    public class CharacterRanking {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("class")]
        public string Class { get; set; }

        [JsonPropertyName("spec")]
        public string Spec { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("startTime")]
        public long StartTime { get; set; }

        [JsonPropertyName("report")]
        public Report Report { get; set; }

        [JsonPropertyName("guild")]
        public Guild Guild { get; set; }

        [JsonPropertyName("server")]
        public Server Server { get; set; }

        [JsonPropertyName("bracketData")]
        public double BracketData { get; set; }

        [JsonPropertyName("aDPS")]
        public double ADPS { get; set; }

        [JsonPropertyName("rDPS")]
        public double RDPS { get; set; }

        [JsonPropertyName("nDPS")]
        public double NDPS { get; set; }

        [JsonPropertyName("pDPS")]
        public double PDPS { get; set; }
    }
}
