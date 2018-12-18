using System;
using System.Windows.Input;
using Cp.Services;
using Cp.Helpers;
using Xamarin.Forms;

namespace Cp.Model
{
    public class RegisterViewModel
    {
        private readonly ApiServices _apiServices = new ApiServices();

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
        //public ICommand RegisterCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            var isRegistered = await _apiServices.SignupAsync
        //                (Username, Password, ConfirmPassword);

        //            Settings.id = Username;
        //            Settings.pass = Password;

        //            if (isRegistered)
        //            {
        //                Message = "Success :)";
        //            }
        //            else
        //            {
        //                Message = "Please try again :(";
        //            }
        //        });
        //    }
        //}
    }
}


