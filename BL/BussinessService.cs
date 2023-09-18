using DataModels;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BL
{
    public class BussinessService
    {
        private DataService dataService;

        public BussinessService()
        {
            dataService = new DataService();
        }

        private ModelValidatatioResult ValidateUserRegistrationDetails(UserRegistrationDetails userRegistrationDetails)
        {
            ModelValidatatioResult res = new ModelValidatatioResult()
            {
                Status = false,
                Msg = "enter valid details",
            };


            if (string.IsNullOrEmpty(userRegistrationDetails.Name))
            {
                res = new ModelValidatatioResult()
                {
                    Status = false,
                    Msg = "Enter User Name",
                };
                return res;
            }


            if (!IsValidEmail(userRegistrationDetails.Email))
            {
                res = new ModelValidatatioResult()
                {
                    Status = false,
                    Msg = "Enter Valid Email",
                };

                return res;
            }
           
            res.Status = true;

            return res;
        }

        public ModelValidatatioResult RegisterUser(UserRegistrationDetails userRegistrationDetails)
        {
            ModelValidatatioResult res = ValidateUserRegistrationDetails(userRegistrationDetails);
            if (res.Status)
            {
                dataService.SaveUser(userRegistrationDetails);
            }
            return res;
        }

        static bool IsValidEmail(string email)
        {

            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";


            Regex regex = new Regex(pattern);


            return regex.IsMatch(email);
        }
    }


}
