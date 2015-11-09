using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EA.SOA.EventTiket.Model
{
   public interface IEventRepository
    {
        Event FindBy(Guid id);
        void Save(Event eventEntity);
    }
}
