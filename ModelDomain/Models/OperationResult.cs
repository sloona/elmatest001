using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Models
{
    //[Table("OperationResult")]
    public class OperationResult
    {
        [Key]
        public virtual int Id { get; set; }

        

        public virtual int ArgumentCount { get; set; }

        [MaxLength(50)]
        public virtual string Arguments { get; set; }

        [MaxLength(50)]
        public virtual string Result { get; set; }

        public virtual long ExecTimeMs { get; set; }

        public virtual int OperationId { get; set; }

        public virtual int UserId { get; set; }

        public virtual Operation Operation { get; set; }

        public virtual User User { get; set; }


    }
}