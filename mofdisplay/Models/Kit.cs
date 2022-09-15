using System.ComponentModel.DataAnnotations.Schema;

namespace mofdisplay.Models
{
    public class Kit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KitID { get; set; }
        public string Name { get; set; }

        public Display Display { get; set; }
        public Contributor Contributor { get; set; }
    }
}
