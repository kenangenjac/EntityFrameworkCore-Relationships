using System.Text.Json.Serialization;

namespace EFCoreRelationships.Models
{
    public class Character
    {
        /// <summary>
        /// Character Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Character Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Character Class or Type
        /// </summary>
        public string RpgClass { get; set; } = "Knight";

        /// <summary>
        /// User reference
        /// A Character can have only one User
        /// A Character might be created by one User, while a User can create multiple Characters (Shown in Users table)
        /// </summary>
        [JsonIgnore]
        public User User { get; set; }

        /// <summary>
        /// Foreign Key in Characters Table
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Weapon reference
        /// A Character can have only one Weapon and only one Weapon can be held by a Character at the time
        /// </summary>
        public Weapon Weapon { get; set; }

        /// <summary>
        /// Skills reference
        /// A Character can have multiple Skills and Skills can be possessed by multiple Characters
        /// </summary>
        public List<Skill> Skills { get; set; }
    }
}
