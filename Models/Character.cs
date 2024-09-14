namespace Arda_API.Models
{
    public class Character
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Race { get; set; }
        public required string Description { get; set; }
        // Autres propriétés spécifiques aux personnages
    }
}
