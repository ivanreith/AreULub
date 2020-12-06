using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AreULub.Models;
namespace AreULub.Repositories
{
    public class ServicesRepository : IServices
    {
        ServiceContext context;
        public ServicesRepository(ServiceContext c)
        {
            context = c;

        }
        public IQueryable<ServiceModel> service
        {
            get
            {
                return context.Services.Include(service => service.User);
            }
        }
        public void AddService(ServiceModel service)
        {
            context.Services.Add(service);
            context.SaveChanges();
        }
        public void DeleteService(ServiceModel service)
        {
            context.Services.Remove(service);
            context.SaveChanges();
        }
        public ServiceModel GetServiceById(int ServiceId)
        {
            //throw new NotImplementedException();
            var service = context.Services.Find(ServiceId);
            return service;
        }
        public void UpdateService(ServiceModel service)
        {
            context.Services.Update(service);
            context.SaveChanges();
        }



    }
}
