using Imanol_Acosta_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Imanol_Acosta_Ap1_P1.DAL;
public class Contexto : DbContext 
{
    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    public DbSet<Aporte> Aportes { get; set; }
}



