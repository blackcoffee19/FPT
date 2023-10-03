using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Domain
{
    public class Account : BaseEntity
    {
        [Column(TypeName ="nvarchar")]
        [MaxLength(100)]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? Password { get; set; }
        [MaxLength (100)]
        public string? Phone { get; set;}
    }
}
