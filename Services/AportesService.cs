using Imanol_Acosta_Ap1_P1.DAL;
using Imanol_Acosta_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace Imanol_Acosta_Ap1_P1.Services;

public class AportesService(IDbContextFactory<Contexto> DbFactory)
{
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


}

