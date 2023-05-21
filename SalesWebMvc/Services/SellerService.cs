using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        // Inserir um novo vendedor (Seller) no banco de dados
        public void Insert(Seller obj)
        {
            _context.Add(obj); // Chamando apenas o .Add(), ele não confirma a inserção no banco de dados
            _context.SaveChanges(); // Para confirmar a operação no banco é preciso chamar o .SaveChanges()
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj); // Removeu o obj do DbSet
            _context.SaveChanges();
        }

    }
}
