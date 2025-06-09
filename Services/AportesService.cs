using Imanol_Acosta_Ap1_P1.DAL;
using Imanol_Acosta_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Imanol_Acosta_Ap1_P1.Services;

public class AportesService(IDbContextFactory<Contexto> DbFactory)
{

    public async Task<bool> Guardar(Aporte aportes)
    {
        if (!await Existe(aportes.AporteID))
        {
            return await Insertar(aportes);
        }
        else
        {
            return await Modificar(aportes);
        }
    }


    public async Task<bool> Existe(int AporteID)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Aportes.AsNoTracking().AnyAsync(a => a.AporteID == AporteID);
    }

    private async Task<bool> Insertar(Aporte aportes)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Aportes.Add(aportes);
        return await Contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(Aporte aportes)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        Contexto.Aportes.Update(aportes);
        return await Contexto.SaveChangesAsync() > 0;
    }

    public async Task<Aporte?> Buscar(int AporteID)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return await Contexto.Aportes.AsNoTracking().FirstOrDefaultAsync(a => a.AporteID == AporteID);
    }
    public async Task<List<Aporte>> Listar(Expression<Func<Aporte, bool>> criterio)
    {
        await using var Contexto = await DbFactory.CreateDbContextAsync();
        return Contexto.Aportes.AsNoTracking().Where(criterio).ToList();
    }


}

