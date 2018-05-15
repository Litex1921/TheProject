using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheProject.DB.Entities
{
    class IBaseEntity <T,K>
    {
        T Id { get; set; }

        K CreatedTime { get; set; }

        K UpdatedTime { get; set; }
    }
}
