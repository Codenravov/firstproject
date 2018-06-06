using MVCWebProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebProject.ViewModels.Users
{
    public class UsersListingDataViewModel
    {
        public string search { get; }
        public int page { get; }
        public string sortOption { get; }
        public IPagingList<UsersListingViewModel> pagingList { get; }
        public UsersListingDataViewModel(string search, int page, string sortOption, IPagingList<UsersListingViewModel> pagingList)
        {
            this.search = search;
            this.page = page;
            this.sortOption = sortOption;
            this.pagingList = pagingList;
        }
    }
}