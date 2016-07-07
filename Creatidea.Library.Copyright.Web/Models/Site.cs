namespace Creatidea.Library.Copyright.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Creatidea.Library.Copyright.Library.Enums;

    public partial class Site
    {
        public Site()
        {
            this.Machines = new HashSet<Machine>();
            this.SiteIps = new HashSet<SiteIp>();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ExecuteAction DefaultAction { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public Guid? Modifier { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<Machine> Machines { get; set; }
        public virtual ICollection<SiteIp> SiteIps { get; set; }
    }
}
