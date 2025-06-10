using System.ComponentModel.DataAnnotations;
namespace Imanol_Acosta_Ap1_P1.Models;

    public class Aporte
    {
    [Key]

    public int AporteID { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public string? Nombres { get; set; } = string.Empty;

    public DateTime Fecha{ get; set; } = DateTime.Now.Date;
    public double Monto { get; set; }
}

