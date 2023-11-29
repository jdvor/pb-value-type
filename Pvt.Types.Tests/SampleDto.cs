using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Pvt.Types.Tests;

[DataContract]
public sealed record SampleDto(
    [property: DataMember(Order = 1)] SampleId Id,
    [property: DataMember(Order = 2)] SampleId? NullableId,
    [property: DataMember(Order = 3)] ImmutableArray<SampleId> IdArray,
    [property: DataMember(Order = 4)] ImmutableArray<SampleId?> NullableIdArray
    )
{
    private SampleDto() 
        : this(default, default, default, default)
    {
    }
}