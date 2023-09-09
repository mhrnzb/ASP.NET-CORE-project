using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Abstractions;

namespace Catalog.API.Models
{
    public class Customer : Entiity<Guid>
    {
        //public Guid Id { get; set; }

        public string FullName { get; set; }

        //? other Properties 
    }
}