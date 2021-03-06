﻿using MVCWebProject.Utilities;

namespace MVCWebProject.ViewModels.Users
{
    public class UsersListingDataViewModel
    {
        public UsersListingDataViewModel(string search, int page, string sortOption, bool descending, IPagingList<UsersListingViewModel> pagingList)
        {
            this.Search = search;
            this.Page = page;
            this.SortOption = sortOption;
            this.Descending = descending;
            this.PagingList = pagingList;
        }

        public string Search { get; }

        public int Page { get; }

        public string SortOption { get; }

        public bool Descending { get; }

        public IPagingList<UsersListingViewModel> PagingList { get; }
    }
}