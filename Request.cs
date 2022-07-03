namespace Librarian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class Request
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        [StringLength(50)]
        public string BookAuthor { get; set; }

        [StringLength(1200)]
        public string BookDescription { get; set; }

        public virtual User User { get; set; }
    }
}
