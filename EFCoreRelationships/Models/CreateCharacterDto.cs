namespace EFCoreRelationships.Models
{
    /// <summary>
    /// Data Transfer Object used to solve object cycle of User object inside Character Class when creating a new Character
    /// </summary>
    public class CreateCharacterDto
    {
        public string Name { get; set; } = "Character";
        public string RpgClass { get; set; } = "Knight";
        public int UserId { get; set; } = 1;
    }
}
