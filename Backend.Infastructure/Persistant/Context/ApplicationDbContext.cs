using Raven.Client.Documents.Session;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Raven.Client.Constants;
using Microsoft.Extensions.Configuration;

namespace Backend.Infastructure.Persistant.Context
{

    public class ApplicationDbContext: IDisposable
    {
        private readonly IDocumentStore _store;
        public IDocumentStore GetDocumentStore() => _store;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _store = new DocumentStore
            {
                Urls = new[] { "https://a.salehimran.ravendb.community/" },
                Database = ""
            };
            _store.Initialize();
        }

        public IDocumentSession OpenSession()
        {
            return _store.OpenSession();
        }

        public void Dispose()
        {
            // Properly dispose of the DocumentStore
            _store.Dispose();
        }
    }
}
