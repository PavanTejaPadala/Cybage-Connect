using System;
using System.Collections.Generic;

namespace CybageConnect_API.Models;

public partial class FriendRequest
{
    public int ReqId { get; set; }

    public int? SenderId { get; set; }

    public int? ReceiverId { get; set; }

    public string? RqstMessage { get; set; }

    public virtual UserRegistration? Receiver { get; set; }

    public virtual UserRegistration? Sender { get; set; }
}
