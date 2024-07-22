using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimMarketing.Models;

[Table("InquiryInformation")]
public partial class InquiryInformation
{
    [Key]
    public int InquiryInformationId { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Firstname { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Lastname { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Middlename { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MobilePhone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    public bool? LogicalDelete { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateModified { get; set; }

    [Column("InquiryInformation")]
    [Unicode(false)]
    public string? InquiryInformation1 { get; set; }

    [Unicode(false)]
    public string? Department { get; set; }

    [Unicode(false)]
    public string? Position { get; set; }
}
