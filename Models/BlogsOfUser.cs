using System;
using System.Collections.Generic;

namespace CybageConnect_API.Models;

public partial class BlogsOfUser
{
    public int BlogId { get; set; }

    public int? UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Blog { get; set; } = null!;

    public DateTime PublishedDateOfBlog { get; set; }
}
