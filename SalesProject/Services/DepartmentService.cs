using SalesProject.Data;
using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesProject.Services
{
    public class DepartmentService
    {
        private readonly SalesProjectContext _context;

        public DepartmentService(SalesProjectContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }
}
