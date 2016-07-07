namespace Creatidea.Library.Copyright.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Creatidea.Library.Copyright.Library.Enums;

    public partial class Machine
    {
        [Key]
        public Guid Id { get; set; }
        public Guid SiteId { get; set; }
        public string Name { get; set; }
        public ExecuteAction Action { get; set; }
        public DateTime? ModifyTime { get; set; }
        public Guid? Modifier { get; set; }
        public DateTime CreateTime { get; set; }
        public Guid MachineKey { get; set; }

        public virtual Site Site { get; set; }
    }
}
