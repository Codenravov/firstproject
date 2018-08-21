using MVCWebProjectDAL.Entities;

namespace MVCWebProjectDAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICityRepository Cities { get; }

        ICountryRepository Countries { get; }

        IPersonRepository People { get; }
    }
}
