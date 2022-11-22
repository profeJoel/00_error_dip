using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ejemploColegio.Models
{
    public class Anotacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Descripcion { get; set; }
        public int EstudianteId { get; set; }
        [ForeignKey("EstudianteId")]

        public virtual Estudiante Estudiante { get; set; }


    }
}