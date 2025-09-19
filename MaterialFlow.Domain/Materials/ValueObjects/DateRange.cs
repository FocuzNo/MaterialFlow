using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialFlow.Domain.Materials.ValueObjects;

public sealed record DateRange(
    DateOnly StartDate,
    DateOnly EndDate)
{
    public bool Contains(DateOnly date) =>
        date >= StartDate && date <= EndDate;
}