using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spyIMS.Model
{
    [Table("spies")]
    public partial class Spies
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("first_name")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("surname")]
        [StringLength(50)]
        public string Surname { get; set; }
        [Column("dob", TypeName = "date")]
        public DateTime? Dob { get; set; }
        [Column("favourite_weapon")]
        [StringLength(50)]
        public string FavouriteWeapon { get; set; }
    }
}
