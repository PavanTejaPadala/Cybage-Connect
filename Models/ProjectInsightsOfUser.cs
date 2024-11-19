using System;
using System.Collections.Generic;

namespace CybageConnect_API.Models;

public partial class ProjectInsightsOfUser
{
    public int ProjectInsightId { get; set; }

    public int? UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string ProjectInsight { get; set; } = null!;

    public DateTime PublishedDateOfProjectInsight { get; set; }
}
