using System.ComponentModel.DataAnnotations.Schema;

namespace mofdisplay.Models
{
    public class Contributor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ContributorID { get; set; }
        public string? Name { get; set; }

        ICollection<Kit> Kits { get; set; }

    }
}
