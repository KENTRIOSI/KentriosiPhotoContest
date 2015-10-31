using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentriosiPhotoContest.MVC.Models.ViewModels.Profile
{
    public class ProfileInfoViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
