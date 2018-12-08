using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace AutoLead
{
    public static class ExtensionMethods
    {
        // Token: 0x06000036 RID: 54 RVA: 0x0000506C File Offset: 0x0000326C
        public static T DeepClone<T>(this T a)
        {
            T result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, a);
                memoryStream.Position = 0L;
                result = (T)((object)binaryFormatter.Deserialize(memoryStream));
            }
            return result;
        }
    }
}
