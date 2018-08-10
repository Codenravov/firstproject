using MVCWebProjectDAL.Interfaces;
using MVCWebProjectDAL.Entities;

namespace MVCWebProjectBLL.Services
{
    public interface IUnitOfWork
    {
        IRepository<Person> Peoples { get; }

        IRepository<Country> Countries { get; }

        IRepository<City> Cities { get; }
    }
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Person> Peoples { get; }

        public IRepository<Country> Countries { get; }

        public IRepository<City> Cities { get; }
    }
}
