using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialFlow.Domain.ForecastPlans.Events;

public sealed record ForecastPlanItemDeletedDomainEvent(Guid ItemId, Guid ForecastPlanId) : IDomainEvent;