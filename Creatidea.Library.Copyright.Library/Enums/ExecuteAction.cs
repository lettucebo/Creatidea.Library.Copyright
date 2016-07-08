using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Creatidea.Library.Copyright.Library.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ExecuteAction
    {
        [Display(Name = "允許")]
        Allow = 1,
        [Display(Name = "不允許")]
        Deny = 2
    }
}
