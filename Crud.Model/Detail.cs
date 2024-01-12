
using Crud.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.Models
{
    public class Detail
    {
        [Key]
        public int DetailId { get; set; }   
        public string faculty { get; set; } 
        public int floor { get; set; }

        public int InfoId { get; set; }
        [ForeignKey("InfoId")]
        public virtual Info Info { get; set; }
    }
}

