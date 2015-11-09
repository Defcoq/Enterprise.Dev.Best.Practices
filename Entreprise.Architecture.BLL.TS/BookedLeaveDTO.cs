using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entreprise.Architecture.BLL.TS
{
    public class BookedLeaveDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int DaysTaken { get; set; }
    }
}
