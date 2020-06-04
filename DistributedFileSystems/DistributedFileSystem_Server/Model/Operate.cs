using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileCenter.Model
{
    [Table("Operates")]
    public class Operate
    {
        [Key]
        public int Id { get; set; }

        public EnumOperateType OperateType { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public EnumOperateResult OperateResult { get; set; }
    }
}