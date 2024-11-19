using System;
using System.Collections.Generic;

namespace CybageConnect_API.Models;

public partial class ArticlesOfUser
{
    public int ArticleId { get; set; }

    public int? UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Article { get; set; } = null!;

    public DateTime PublishedDate { get; set; }
}
