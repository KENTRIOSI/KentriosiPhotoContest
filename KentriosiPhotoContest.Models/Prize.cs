using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentriosiPhotoContest.Models
{
    public class Prize
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int WinnerPlace { get; set; }

        public int WinnerId { get; set; }

        public virtual ApplicationUser Winner { get; set; }
    }
}
