using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    [Table("OperationResult")]
    public class OperationResult
    {
        [Key]
        public int Id { get; set; }

        

        public int ArgumentCount { get; set; }

        [MaxLength(50)]
        public string Arguments { get; set; }

        [MaxLength(50)]
        public string Result { get; set; }

        public long ExecTimeMs { get; set; }

        public int OperationId { get; set; }

        public Operation Operation { get; set; }


    }
}