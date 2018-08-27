using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCWebProject.ViewModels;
using MVCWebProject.ViewModels.Users;

namespace MVCWebProject.Services
{
    public interface IUsersServicePL
    {
        UsersListingDataViewModel GetListingViewData(string searchString, int page, int pageSize, string sortOption);

        UsersCreatViewModel GetCreateModel();

        UsersCreatViewModel GetCitiesToModel(UsersCreatViewModel model, string selectCountry);

        UsersEditViewModel GetCitiesToModel(UsersEditViewModel model, string selectCountry);

        void AddPerson(UsersCreatViewModel model);

        UsersEditViewModel GetEditModel(int id);

        void UpdatePerson(UsersEditViewModel model);

        UsersDeleteViewModel GetDeleteModel(int id);

        void DeletePerson(int id);

        UsersCommentsViewModel GetCommentsModel(int id);
    }
}
