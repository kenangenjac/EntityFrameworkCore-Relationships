namespace EFCoreRelationships.Models
{
    public class User
    {
        /// <summary>
        /// Id of the User
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Username of the User
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// List of Characters
        /// A single User can have multiple Characters
        /// A User can create various Charaters
        /// </summary>
        public List<Character> Characters { get; set; }
    }
}
