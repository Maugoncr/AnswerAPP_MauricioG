using System;
using System.Collections.Generic;
using System.Text;
using AnswerAPP_MauricioG.Models;
using System.Threading.Tasks;

namespace AnswerAPP_MauricioG.ViewModels
{
    public class UserViewModel : BaseViewModel
    {

        public User MyUser { get; set; }

        public UserViewModel()
        {
            MyUser = new User();

            //TODO: Implementar los command posteriormente
        }

        // Agregamos una funcion para AGREGAR el usuario

        public async Task<bool> AddUser(string pUserName,
                                        string pFirstName, 
                                        string pLastName, 
                                        string pPhoneNumber,
                                        string pUserPassword,
                                        string pBackUpEmail,
                                        string pJobDescription,
                                        int pUserStatusId = 1,
                                        int pCountryId = 1,
                                        int pUserRoleId = 1)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {

                //TODO hay que encriptar el password
                MyUser.UserName = pUserName;
                MyUser.FirstName = pFirstName;
                MyUser.LastName = pLastName;
                MyUser.PhoneNumber = pPhoneNumber;
                MyUser.UserPassword = pUserPassword;
                MyUser.BackUpEmail = pBackUpEmail;
                MyUser.JobDescription = pJobDescription;
                MyUser.UserStatusId = pUserStatusId;
                MyUser.CountryId = pCountryId;
                MyUser.UserRoleId = pUserRoleId;

                bool R = await MyUser.AddNewUser();

                return R;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally 
            { 
            
                IsBusy = false;
            
            }
                
        
        
        
        
        
        }




    }
}
