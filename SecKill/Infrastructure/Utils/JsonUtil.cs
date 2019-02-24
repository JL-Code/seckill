using Newtonsoft.Json;

namespace SecKill.Infrastructure.Utils
{
    public class JsonUtil
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static object Deserialize(string jsonstr)
        {
            return JsonConvert.DeserializeObject(jsonstr);
        }

        public static T Deserialize<T>(string jsonstr)
        {
            return JsonConvert.DeserializeObject<T>(jsonstr);
        }
    }

    public static class JsonUtilExtension
    {
        public static string Serialize(this ISerialize value)
        {
            return JsonUtil.Serialize(value);
        }

        public static T Deserialize<T>(this string value) where T : ISerialize
        {
            return JsonUtil.Deserialize<T>(value);
        }
    }

    public interface ISerialize { }
}
