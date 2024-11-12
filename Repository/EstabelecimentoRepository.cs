using Microsoft.EntityFrameworkCore;
using Solar_Tracker.Data;
using Solar_Tracker.Models;
using Solar_Tracker.Repository.Interface;
using System;

namespace Solar_Tracker.Repository
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly dbContext dbContext;

        public EstabelecimentoRepository(dbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<Estabelecimento>> GetEstabelecimento()
        {
            return await dbContext.Estabelecimentos.ToListAsync();
        }

        public async Task<Estabelecimento> AddEstabelecimento(Estabelecimento estabelecimento)
        {
            var result = await dbContext.Estabelecimentos.AddAsync(estabelecimento);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Estabelecimento> DeleteEstabelecimento(int id)
        {
            var result = await dbContext.Estabelecimentos.FirstOrDefaultAsync(x => x.IdEstabelecimento == id);
            if (result != null)
            {
                dbContext.Estabelecimentos.Remove(result);
                await dbContext.SaveChangesAsync();
            }

            return result;
        }


        public async Task<Estabelecimento> UpdateEstabelecimento(Estabelecimento estabelecimento)
        {
            var result = await dbContext.Estabelecimentos.FirstOrDefaultAsync(x => x.IdEstabelecimento == estabelecimento.IdEstabelecimento);

            if (result != null)
            {
                result.IdEstabelecimento = estabelecimento.IdEstabelecimento; 
                result.Nome = estabelecimento.Nome;
                result.Localizacao = estabelecimento.Localizacao;
            
                await dbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Estabelecimento> GetEstabelecimento(int estabid)
        {
            return await dbContext.Estabelecimentos.FirstOrDefaultAsync(x => x.IdEstabelecimento == estabid);
        }
    }
}
