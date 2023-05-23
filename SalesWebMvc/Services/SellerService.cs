using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        // Construtor para que a injeção de dependência possa ocorrer
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAssync()
        {
            return await _context.Seller.ToListAsync();
        }

        // Inserir um novo vendedor (Seller) no banco de dados
        public async Task InsertAssync(Seller obj)
        {
            _context.Add(obj); // Chamando apenas o .Add(), ele não confirma a inserção no banco de dados
            await _context.SaveChangesAsync(); // Para confirmar a operação no banco é preciso chamar o .SaveChanges()
        }

        public async Task<Seller> FindByIdAssync(int id)
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAssync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj); // Removeu o obj do DbSet
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssync(Seller obj)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny) // Verifica, no banco, se existe um ID com o mesmo do objeto
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }


    }
}
