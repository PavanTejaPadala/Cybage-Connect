using System;
using System.Collections.Generic;

namespace CybageConnect_API.Models;

public partial class Connection
{
    public int ConnectId { get; set; }

    public int? UserId { get; set; }

    public int? RqstCount { get; set; }

    public virtual UserRegistration? User { get; set; }
}
