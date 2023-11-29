namespace Pvt.Types;

using ProtoBuf;
using ProtoBuf.Serializers;

public sealed class SampleIdSerializer : ISerializer<SampleId>, ISerializer<SampleId?>
{
    public SampleId Read(ref ProtoReader.State state, SampleId value)
    {
        var underlyingValue = state.ReadInt64();
        return new SampleId(underlyingValue);
    }
    
    public SampleId? Read(ref ProtoReader.State state, SampleId? value)
    {
        var underlyingValue = state.ReadInt64();
        if (underlyingValue < 1)
        {
            return null;
        }

        return new SampleId(underlyingValue);
    }

    public void Write(ref ProtoWriter.State state, SampleId value)
    {
        state.WriteInt64(value.UnderlyingValue);
    }

    public void Write(ref ProtoWriter.State state, SampleId? value)
    {
        if (value is null)
        {
            state.WriteInt64(0);
            return;
        }
        
        state.WriteInt64(value.Value.UnderlyingValue);
    }

    public SerializerFeatures Features => SerializerFeatures.CategoryScalar | SerializerFeatures.WireTypeVarint;
}