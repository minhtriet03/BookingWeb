using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingWeb.Server.Models
{
    public class XeVitri
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Xe")]  
        public int IdXe { get; set; }

        [ForeignKey("Vitri")]  
        public int IdVitri { get; set; }

        public virtual Xe Xe { get; set; }
        public virtual Vitri Vitri { get; set; }

    }
}
    