﻿using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Department>> FindAllAssync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

    }
}
