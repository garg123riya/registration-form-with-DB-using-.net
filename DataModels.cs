using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class UserRegistrationDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Edu { get; set; }
        public string gender { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }

    }

    public class ModelValidatatioResult
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
    }
}
