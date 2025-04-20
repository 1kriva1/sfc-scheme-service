﻿using SFC.Scheme.Messages.Models;
using SFC.Scheme.Messages.Models.Data;

namespace SFC.Scheme.Messages.Commands.Data;
public record InitializeData
{
    public IEnumerable<DataValue> FootballPositions { get; init; } = [];

    public IEnumerable<DataValue> GameStyles { get; init; } = [];

    public IEnumerable<DataValue> StatCategories { get; init; } = [];

    public IEnumerable<DataValue> StatSkills { get; init; } = [];

    public IEnumerable<StatTypeDataValue> StatTypes { get; init; } = [];

    public IEnumerable<DataValue> WorkingFoots { get; init; } = [];

    public IEnumerable<DataValue> Shirts { get; init; } = [];
}