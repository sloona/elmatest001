using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Calc;

namespace Web.Models
{
    public class OperationModel
    {
        [DisplayName("Операция")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Arg 1")]
        public int X { get; set; }

        [DisplayName("Arg 2")]
        public int Y { get; set; }


        public string[] OperationNames = { "sum", "multiply" };

        public object[] GetParametrs() {
            return new object[] { X, Y};
        }
    }
}