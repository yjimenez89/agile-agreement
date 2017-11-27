using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amsystem.Data.Entities
{
    public class Agreement
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Observation { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<User> Responsibles { get; set; }
    }
}
