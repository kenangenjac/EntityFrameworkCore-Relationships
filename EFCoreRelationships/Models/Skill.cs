using System.Text.Json.Serialization;

namespace EFCoreRelationships.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }

        /// <summary>
        /// Characters reference
        /// A Character can have multiple Skills and Skills can be possessed by multiple Characters 
        /// </summary>
        [JsonIgnore]
        public List<Character> Characters { get; set; }
    }
}
