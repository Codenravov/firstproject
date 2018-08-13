using MVCWebProjectDAL.Entities;

namespace MVCWebProjectDAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Person> Peoples { get; }

        IRepository<Country> Countries { get; }

        IRepository<City> Cities { get; }

    }
}
