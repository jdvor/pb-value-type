namespace Pvt.Types.Tests;

using System.Collections.Immutable;
using KellermanSoftware.CompareNetObjects;
using ProtoBuf;
using ProtoBuf.Meta;
using Xunit;

public class SerializationTests
{
    private readonly CompareLogic comparer = new();
    
    static SerializationTests()
    {
        RuntimeTypeModel.Default.AddSampleId();
    }
    
    [Fact]
    public void WithNullables()
    {
        var expected = CreateSampleDto();
        
        using var ms = new MemoryStream();
        Serializer.Serialize(ms, expected);
        
        ms.Position = 0;
        var actual = Serializer.Deserialize<SampleDto>(ms);

        var result = comparer.Compare(expected, actual);
        Assert.True(result.AreEqual, result.DifferencesString);
    }
    
    [Fact]
    public void WithoutNullables()
    {
        var expected = CreateSampleDtoWithoutNullables();
        
        using var ms = new MemoryStream();
        Serializer.Serialize(ms, expected);
        
        ms.Position = 0;
        var actual = Serializer.Deserialize<SampleDtoWithoutNullables>(ms);
        
        var result = comparer.Compare(expected, actual);
        Assert.True(result.AreEqual, result.DifferencesString);
    }

    private static SampleDto CreateSampleDto()
    {
        return new SampleDto(
            new SampleId(1), 
            null, 
            new SampleId[] { new(3), new(4), new(5) }.ToImmutableArray(), 
            new SampleId?[] { new(6), null, new(8) }.ToImmutableArray());
    }
    
    private static SampleDtoWithoutNullables CreateSampleDtoWithoutNullables()
    {
        return new SampleDtoWithoutNullables(
            new SampleId(1),
            new SampleId[] { new(2), new(3), new(4) }.ToImmutableArray());
    }
}