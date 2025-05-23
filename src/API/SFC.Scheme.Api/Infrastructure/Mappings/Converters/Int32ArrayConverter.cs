using AutoMapper;

using SFC.Scheme.Contracts.Models.Common;

namespace SFC.Scheme.Api.Infrastructure.Mappings.Converters;

public class Int32ArrayConverter : ITypeConverter<IEnumerable<int>, Int32Array>
{
    public Int32Array Convert(IEnumerable<int> source, Int32Array destination, ResolutionContext context)
    {
        Int32Array result = new();
        result.Value.Add(source);

        return result;
    }
}