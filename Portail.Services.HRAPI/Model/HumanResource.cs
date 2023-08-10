using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portal.Services.HRAPI.Model
{
    public class HumanResource
    {

        [Key]
        [Column("HR_ID")]
        public int Id { get; set; }
        [Column("HR_FirstName")]
        public required string FirstName { get; set; }
        [Column("HR_LastName")]
        public required string LastName { get; set; }

    }
}
