namespace Creatidea.Library.Copyright.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("網站列表")]
        public Guid Id { get; set; }

        [DisplayName("名稱")]
        public string Name { get; set; }

        [DisplayName("預設行為")]
        public ExecuteAction DefaultAction { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public Guid? Modifier { get; set; }

        public bool IsDelete { get; set; }

        public virtual ICollection<Machine> Machines { get; set; }
        public virtual ICollection<SiteIp> SiteIps { get; set; }
    }
}
