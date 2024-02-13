namespace WebApp.Models.Entities
{
    public class Etudiant
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }        
        public string Phone { get; set; }
        public string Adresse { get; set; }
    }
}
