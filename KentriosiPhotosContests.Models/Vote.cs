using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KentriosiPhotoContest.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public int VoterId { get; set; }

        public virtual User Voter { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public DateTime Date { get; set; }
    }
}
