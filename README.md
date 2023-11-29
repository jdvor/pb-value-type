# Are custom serializers supported for collections of nullable types in protobuf-net?

Attempt to serialize `ImmutableArray<SampleId?> SampleDto.NullableIdArray` leads to an exception:

```
System.NullReferenceException: An element of type System.Nullable`1[Pvt.Types.SampleId] was null; this might be as contents in a list/array

System.NullReferenceException
An element of type System.Nullable`1[Pvt.Types.SampleId] was null; this might be as contents in a list/array
at ProtoBuf.Internal.ThrowHelper.ThrowNullRepeatedContents[T]() in /_/src/protobuf-net.Core/Internal/ThrowHelper.cs:line 102
at ProtoBuf.Serializers.ImmutableArraySerializer`1.Write(State& state, Int32 fieldNumber, SerializerFeatures category, WireType wireType, ImmutableArray`1 values, ISerializer`1 serializer, SerializerFeatures features) in /_/src/protobuf-net.Core/Serializers/RepeatedSerializer.Immutable.cs:line 100
at ProtoBuf.Serializers.RepeatedSerializer`2.WriteRepeated(State& state, Int32 fieldNumber, SerializerFeatures features, TCollection values, ISerializer`1 serializer) in /_/src/protobuf-net.Core/Serializers/RepeatedSerializer.cs:line 157
at proto_1(State&, SampleDto)
at ProtoBuf.Internal.Serializers.SimpleCompiledSerializer`1.ProtoBuf.Serializers.ISerializer<T>.Write(State& state, T value)
at ProtoBuf.ProtoWriter.State.WriteAsRoot[T](T value, ISerializer`1 serializer)
at ProtoBuf.ProtoWriter.State.SerializeRoot[T](T value, ISerializer`1 serializer)
at ProtoBuf.Meta.TypeModel.SerializeImpl[T](State& state, T value)
at ProtoBuf.Serializer.Serialize[T](Stream destination, T instance, Object userState)
at ProtoBuf.Serializer.Serialize[T](Stream destination, T instance)
at Pvt.Types.Tests.SerializationTests.WithNullables()
at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
```