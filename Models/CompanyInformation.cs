using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SimMarketing.Models;

[Table("CompanyInformation")]
public partial class CompanyInformation
{
    [Key]
    public int CompanyId { get; set; }

    public int? InquiryInformationId { get; set; }

    [Unicode(false)]
    public string? CompanyAddress { get; set; }

    public bool? LogicalDelete { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DateModified { get; set; }
}
