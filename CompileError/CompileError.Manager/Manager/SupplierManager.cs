﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileError.Model.Model;
using CompileError.Repository.Repository;

namespace CompileError.Manager.Manager
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }

        public bool Delete(int id)
        {
            return _supplierRepository.Delete(id);
        }
        public bool Update(Supplier supplier)
        {
            return _supplierRepository.Update(supplier);
        }
        public Supplier Search(int id)
        {
            return _supplierRepository.Search(id);
        }

        public List<Supplier>GetAll()
        {
            return _supplierRepository.GetAll();
        }


    }
}
