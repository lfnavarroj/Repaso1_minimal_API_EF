using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace repaso1.models;

public class Tarea
{
    // [Key]
    public Guid TareaId { get; set; }
    // [ForeignKey("CategoriaId")]
    public Guid CategoriaId { get; set; }
    // [Required]
    // [MaxLength(150)]
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public Prioridad Prioridad { get; set; }
    public virtual Categoria Categoria { get; set; }
    [NotMapped]
    public string Resumen { get; set; }

}

public enum Prioridad
{
    Baja,
    Media,
    Alta
    
}