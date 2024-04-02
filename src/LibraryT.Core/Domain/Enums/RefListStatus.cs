using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Domain.Enums
{
    public enum RefListStatus: int
    {
        [Description("Ready to be collected")]
        Ready = 1,

        [Description("Collected")]
        Collected = 2,

        [Description("Returned")]
        Returned = 3,

        [Description("Overdue")]
        Overdue = 4,


    }
}
