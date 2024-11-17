using System;
using System.Collections.Generic;

namespace SovcomHackAPI.Models;

public partial class ViewProductUserOnCard
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronomic { get; set; } = null!;

    public string Number { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;
}
