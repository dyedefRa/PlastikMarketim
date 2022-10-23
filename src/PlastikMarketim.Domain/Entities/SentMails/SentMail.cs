using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace PlastikMarketim.Entities.SentMails
{
    [Table(PlastikMarketimConsts.DbTablePrefix + "SentMails")]
    public class SentMail : Entity<int>
    {
        [Required]
        [MaxLength(500)]
        public string ToAddress { get; set; }
        [MaxLength(500)]
        public string CcAddress { get; set; }
        [MaxLength(500)]
        public string BccAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
