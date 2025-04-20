﻿using SFC.Scheme.Application.Common.Mappings.Interfaces;
using SFC.Scheme.Domain.Entities.Team.General;

namespace SFC.Scheme.Application.Common.Dto.Team.General;
public class TeamAvailabilityDto : IMapFromReverse<TeamAvailability>
{
    public DayOfWeek Day { get; set; }

    public TimeSpan From { get; set; }

    public TimeSpan To { get; set; }
}