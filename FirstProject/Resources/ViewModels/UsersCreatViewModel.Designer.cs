﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCWebProject.Resources.ViewModels {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class UsersCreatViewModel {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UsersCreatViewModel() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MVCWebProject.Resources.ViewModels.UsersCreatViewModel", typeof(UsersCreatViewModel).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select your city.
        /// </summary>
        public static string City {
            get {
                return ResourceManager.GetString("City", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your comments (optional).
        /// </summary>
        public static string Comments {
            get {
                return ResourceManager.GetString("Comments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select your country.
        /// </summary>
        public static string Country {
            get {
                return ResourceManager.GetString("Country", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your e-mail.
        /// </summary>
        public static string Email {
            get {
                return ResourceManager.GetString("Email", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Comments length longer than maximum allow 255.
        /// </summary>
        public static string LengthErrComments {
            get {
                return ResourceManager.GetString("LengthErrComments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your phone number (optional).
        /// </summary>
        public static string Phone {
            get {
                return ResourceManager.GetString("Phone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E-mail is not valid.
        /// </summary>
        public static string RegularErrEmail {
            get {
                return ResourceManager.GetString("RegularErrEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not a valid phone number.
        /// </summary>
        public static string RegularErrPhone {
            get {
                return ResourceManager.GetString("RegularErrPhone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must select a сity.
        /// </summary>
        public static string RequiredErrCity {
            get {
                return ResourceManager.GetString("RequiredErrCity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must select a сountry.
        /// </summary>
        public static string RequiredErrCountry {
            get {
                return ResourceManager.GetString("RequiredErrCountry", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must provide a e-mail.
        /// </summary>
        public static string RequiredErrEmail {
            get {
                return ResourceManager.GetString("RequiredErrEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must select a title.
        /// </summary>
        public static string RequiredErrTitle {
            get {
                return ResourceManager.GetString("RequiredErrTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to City is not valid.
        /// </summary>
        public static string ServerErrCity {
            get {
                return ResourceManager.GetString("ServerErrCity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Country is not valid.
        /// </summary>
        public static string ServerErrCountry {
            get {
                return ResourceManager.GetString("ServerErrCountry", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Title is not valid.
        /// </summary>
        public static string ServerErrTitle {
            get {
                return ResourceManager.GetString("ServerErrTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select your title.
        /// </summary>
        public static string Title {
            get {
                return ResourceManager.GetString("Title", resourceCulture);
            }
        }
    }
}
