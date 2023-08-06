using System;
using System.Collections.Generic;

namespace Products.Models;

public partial class Itemstabletest
{
    public int Id { get; set; }

    public string? Site { get; set; }

    public string? Producer { get; set; }

    public string? Model { get; set; }

    public string? Title { get; set; }

    public string? Price { get; set; }

    public string? Url { get; set; }

    public string? Availability { get; set; }

    public static implicit operator List<object>(Itemstabletest? v)
    {
        throw new NotImplementedException();
    }
}
