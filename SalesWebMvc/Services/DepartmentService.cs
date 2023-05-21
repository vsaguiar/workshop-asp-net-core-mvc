using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {

        private readonly SalesWebMvcContext _context;

        // Construtor para que a injeção de dependência possa ocorrer
        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // Método para retornar todos os departamentos
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
