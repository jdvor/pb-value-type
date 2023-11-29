namespace Pvt.Types;

public record struct SampleId(long UnderlyingValue)
{
    public static implicit operator long(SampleId id)
        => id.UnderlyingValue;
    
    public static explicit operator SampleId(long value)
        => new(value);
}