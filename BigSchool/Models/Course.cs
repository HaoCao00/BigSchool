namespace BigSchool.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("Course")]
    public partial class Course
    {
        public int Id { get; set; }

        [StringLength(128)]
        public string LecturerId { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage ="The Place is required")]
        public string Place { get; set; }
        //[DataType(DataType.DateTime, ErrorMessage ="Not correct format")]
        public DateTime? DateTime { get; set; }
        [Required(ErrorMessage ="Category is required")]
        public int? CategoryId { get; set; }
        public string Name;

        public virtual Category Category { get; set; }
        public List<Category> ListCategory = new List<Category>();
    }
}
