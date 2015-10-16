using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentriosiPhotoContest.Models
{
    public class ContestStrategy
    {
        public int Id { get; set; }

        public int WinnersCount { get; set; }

        public bool isOpenForAllContesters { get; set; }

        public bool isOpenForAllVoters { get; set; }
    }
}
