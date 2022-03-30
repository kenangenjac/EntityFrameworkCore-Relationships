using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace EFCoreRelationships.Models
{
    public class Weapon
    {
        /// <summary>
        /// Id of the Weapon
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Weapon
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Damage that can be dealt by the Weapon
        /// </summary>
        public int Damage { get; set; } = 10;

        /// <summary>
        /// Character reference
        /// A Character can have only one Weapon and only one Weapon can be held by a Character at the time
        /// </summary>
        [JsonIgnore]
        public Character Character { get; set; }

        /// <summary>
        /// Foreign Key in Weapons table
        /// A Weapon cannot exist without a Character, but a Character can exist without a Weapon
        /// </summary>
        public int CharacterId { get; set; }
    }
}
