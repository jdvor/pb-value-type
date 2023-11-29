namespace Pvt.Types;

using ProtoBuf.Meta;

public static class Extensions
{
    public static RuntimeTypeModel AddSampleId(this RuntimeTypeModel model)
    {
        model.Add<SampleId>().SerializerType = typeof(SampleIdSerializer);
        model.Add<SampleId?>().SerializerType = typeof(SampleIdSerializer);
        return model;
    }
}