using MVCWebProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebProject.ViewModels.Users
{
    public class UsersListingDataViewModel
    {
        public string searchString { get; }
        public int page { get; }
        public string sortOption { get; }
        public IPagingList<UsersListingViewModel> pagingList { get; }
        public UsersListingDataViewModel(string searcString, int page, string sortOption, IPagingList<UsersListingViewModel> pagingList)
        {
            this.searchString = searchString;
            this.page = page;
            this.sortOption = sortOption;
            this.pagingList = pagingList;
        }
    }
}