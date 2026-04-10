using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentTask.Models;

public partial class TblStudent
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int? Age { get; set; }
    public string Course { get; set; }
    public DateOnly? CreatedDate { get; set; }
}
