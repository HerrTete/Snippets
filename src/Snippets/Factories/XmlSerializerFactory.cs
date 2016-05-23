using System;
using System.Collections.Concurrent;
using System.Xml.Serialization;

namespace Snippets.Factories
{
    public class XmlSerializerFactory
    {
        private static readonly ConcurrentDictionary<Type, XmlSerializer> Serializers = new ConcurrentDictionary<Type, XmlSerializer>();

        /// <summary>
        /// Returns a XmlSerializer for the inserted type and caches it.
        /// </summary>
        /// <param name="type">type for the xmlSerialzier</param>
        /// <returns><see cref="XmlSerializer"/></returns>
        public static XmlSerializer GetSerializer(Type type)
        {
            if (!Serializers.ContainsKey(type))
            {
                var serializer = new XmlSerializer(type);
                if (!Serializers.TryAdd(type, serializer))
                {
                    lock (Serializers)
                    {
                        Serializers.TryAdd(type, serializer);
                    }
                }
            }
            return Serializers[type];
        }
    }
}