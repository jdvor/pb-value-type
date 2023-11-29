using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Pvt.Types.Tests;

[DataContract]
public sealed record SampleDtoWithoutNullables(
    [property: DataMember(Order = 1)] SampleId Id,
    [property: DataMember(Order = 2)] ImmutableArray<SampleId> IdArray)
{
    private SampleDtoWithoutNullables() 
        : this(default, default)
    {
    }
}