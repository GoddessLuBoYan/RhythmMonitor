using System;
using System.Runtime.Serialization;

[Serializable]
public class LevelLoaderException : Exception 
{
    public LevelLoaderException() : base() { }
    public LevelLoaderException(string message) : base(message){}
    public LevelLoaderException(string message, Exception innerException) : base(message, innerException){}
    protected LevelLoaderException(SerializationInfo info, StreamingContext context) : base(info, context){}
}
