using System.ComponentModel.DataAnnotations.Schema;

namespace mofdisplay.Models
{
    public class Display
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DisplayID {get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public int CuratorID { get; set; }

        public Contributor Curator { get; set; }

        public ICollection<Kit> Kits { get; set; }

    }
}
