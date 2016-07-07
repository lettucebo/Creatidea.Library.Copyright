namespace Creatidea.Library.Copyright.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Creatidea.Library.Copyright.Library.Enums;

    public partial class SiteIp
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SiteId { get; set; }
        public string Address { get; set; }
        public IpType Type { get; set; }
        public ExecuteAction Action { get; set; }
        public Guid? Modifier { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string Url { get; set; }

        public virtual Site Site { get; set; }
    }
}
