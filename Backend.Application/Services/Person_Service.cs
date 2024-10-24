using Backend.Domain.Entity;
using Backend.Domain.Interface;
using Backend.Domain.Model;
using Backend.Infastructure.Persistant.Context;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Services
{
    public class Person_Service : IPerson_Service
    {
        private readonly IDocumentSession _session;
        public Person_Service(IDocumentSession session)
        {
            _session = session;
        }
        public IEnumerable<PersonRequests> GetAsync()
        {
            try
            {
                var result = _session.Query<PersonRequests>().ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string SaveAsync(PersonRequests person)
        {
            try{
                _session.Store(person);
                _session.SaveChanges(); // Commit changes to the database
                return "Saved";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
