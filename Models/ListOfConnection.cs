using System;
using System.Collections.Generic;

namespace CybageConnect_API.Models;

public partial class ListOfConnection
{
    public int Id { get; set; }

    public int? SenderId { get; set; }

    public string? SenderName { get; set; }

    public int? ReceiverId { get; set; }

    public string? ReceiverName { get; set; }
}
