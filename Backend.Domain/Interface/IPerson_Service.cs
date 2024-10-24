using Backend.Domain.Entity;
using Backend.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Interface
{
    public interface IPerson_Service
    {
        IEnumerable<PersonRequests> GetAsync();
        string SaveAsync(PersonRequests entity);

    }
}
