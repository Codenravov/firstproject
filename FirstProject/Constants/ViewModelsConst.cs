using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCWebProject.Constants
{
    public class ViewModelsConst
    {
        private static readonly List<SelectListItem> Titles = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Miss", Value = "Miss" },
            new SelectListItem() { Text = "Ms", Value = "Ms" },
            new SelectListItem() { Text = "Mr", Value = "Mr" },
            new SelectListItem() { Text = "Sir", Value = "Sir" },
            new SelectListItem() { Text = "Mrs", Value = "Mrs" },
            new SelectListItem() { Text = "Dr", Value = "Dr" },
            new SelectListItem() { Text = "Lady", Value = "Lady" },
            new SelectListItem() { Text = "Lord", Value = "Lord" }
        };

        public static SelectList GetTitles
        {
            get
            {
                return new SelectList(Titles, "Text", "Value");
            }
        }
    }
}