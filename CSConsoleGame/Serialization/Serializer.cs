using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using System.Xml.Serialization;

namespace Game.Serialization
{
    public static class GSerializer
    {
        public static string SerializeJSON<T>(T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);    
        }
        public static T DeserializeJSON<T>(string obj)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(obj);
        }
        public static string SerializeXML<T>(T obj,Type TypeOfLoadedAttributeClasses = null,Assembly SourceAssembly = null)
        {
            if (TypeOfLoadedAttributeClasses == null)
                TypeOfLoadedAttributeClasses = typeof(SerializableAttribute);
            if (SourceAssembly == null)
                SourceAssembly = obj.GetType().Assembly;
            Type[] types = (from k in SourceAssembly.GetTypes()
                            where !k.IsNestedPrivate && k.CustomAttributes.FirstOrDefault(new Func<CustomAttributeData, bool>((CustomAttributeData data) => { return data.AttributeType == TypeOfLoadedAttributeClasses; })) != null
                            select k).ToArray();
            XmlSerializer serializer = new XmlSerializer(typeof(T), types);
            MemoryStream s = new MemoryStream();
            serializer.Serialize(s, obj);
            s.Seek(0, SeekOrigin.Begin);
            return new StreamReader(s).ReadToEnd();
        }
        public static T DeserializeXML<T>(string obj, Type TypeOfLoadedAttributeClasses = null, Assembly SourceAssembly = null)
        {
            if (TypeOfLoadedAttributeClasses == null)
                TypeOfLoadedAttributeClasses = typeof(SerializableAttribute);
            if (SourceAssembly == null)
                SourceAssembly = obj.GetType().Assembly;
            Type[] types = (from k in SourceAssembly.GetTypes()
                            where !k.IsNestedPrivate && k.CustomAttributes.FirstOrDefault(new Func<CustomAttributeData, bool>((CustomAttributeData data) => { return data.AttributeType == TypeOfLoadedAttributeClasses; })) != null
                            select k).ToArray();
            XmlSerializer serializer = new XmlSerializer(typeof(T), types);
            MemoryStream s = new MemoryStream();
            new StreamWriter(s).Write(obj);
            return (T)serializer.Deserialize(s);
        }
    }
}
