using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MvvmEasyLecture.Models
{
    public partial class UserName : ObservableObject
    {   //lower case is private
        //Upper case is public
        [ObservableProperty]
        string firstName;

        [ObservableProperty]
        string lastName;

        [ObservableProperty]
        string loginName;

        public string Password => "Secure Password Here";

        [RelayCommand]
        public void buildUserName()
        {
            LoginName = FirstName.Substring(0, 1) + LastName;

        }
        
    }
}
