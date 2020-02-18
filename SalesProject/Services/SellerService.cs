using SalesProject.Data;
using SalesProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesProject.Services
{
    public class SellerService
    {
        private readonly SalesProjectContext _context;

        public SellerService(SalesProjectContext context)
        {
            _context = context;
        }

        public List<Department> DepartmentList()
        {
            return _context.Department.ToList();
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {         
            _context.Add(obj);
            _context.SaveChanges();
        }

    }
}
