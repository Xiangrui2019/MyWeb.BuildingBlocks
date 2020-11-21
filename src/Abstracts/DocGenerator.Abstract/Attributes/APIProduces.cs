using System;

namespace DocGenerator.Abstract.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class APIProduces : Attribute
    {
        public readonly Type PossibleType;

        public APIProduces(Type type)
        {
            PossibleType = type;
        }
    }
}