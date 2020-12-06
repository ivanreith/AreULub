using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AreULub.Repositories;
using AreULub.Models;
namespace AreULub.Repositories
{
    public class FakeServicesRepository : IServices
    {
        List<ServiceModel> ServicesList = new List<ServiceModel>();
        public IQueryable<ServiceModel> service => ServicesList.AsQueryable();
       
        public void AddService(ServiceModel service)
        {
            service.ServiceID = ServicesList.Count();
            ServicesList.Add(service);
        }
        public void DeleteService(ServiceModel service)
        {
            ServicesList.Remove(service);
        }
        public ServiceModel GetServiceById(int Id)
        {
            foreach (ServiceModel service in ServicesList)
            {
                if (service.ServiceID == Id)
                {
                    return service;
                }

            }
            return null;
            // throw new NotImplementedException();
            //ServiceModel serviceRecovered = ServicesList.Find(Id) ;  // This one gave me an type missmatch error
             //         return serviceRecovered;
        }
        public void UpdateService(ServiceModel service)
        {
            ServicesList[service.ServiceID -1] = service; // it takes one out because the count starts at 0 with 1 element
        }
    }
}
