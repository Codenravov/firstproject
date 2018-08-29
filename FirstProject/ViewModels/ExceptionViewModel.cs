using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebProject.ViewModels
{
    public class ExceptionViewModel
    {
        private string action;

        private string exception;

        private string message;

        public string Action
        {
            get
            {
                return this.action;
            }

            set
            {
                this.action = $"Action : {value}";
            }
        }

        public string Exception
        {
            get
            {
                return this.exception;
            }

            set
            {
                this.exception = $"Exception : {value}";
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = $"Message : {value}";
            }
        }
    }
}