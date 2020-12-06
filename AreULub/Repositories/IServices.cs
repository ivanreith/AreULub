using AreULub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AreULub.Repositories
{
    public interface IServices
    {
        IQueryable<ServiceModel> service { get; } // read   or get    
        void AddService(ServiceModel service);  // create
        ServiceModel GetServiceById(int ServiceID); //Retrieve a service by topic
        void UpdateService(ServiceModel service);
        void DeleteService(ServiceModel service);
    }
}
