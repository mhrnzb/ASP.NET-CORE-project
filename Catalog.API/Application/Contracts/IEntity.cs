using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Application.Contracts
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}