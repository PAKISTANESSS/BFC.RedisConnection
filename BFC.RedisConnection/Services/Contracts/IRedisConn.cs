using System.Threading.Tasks;

namespace BFC.RedisConnection.Services.Contracts
{
    /// <summary>
    /// Interface for redis get and set operations
    /// </summary>
    public interface IRedisConn
    {
        /// <summary>
        /// Set a key with a object
        /// </summary>
        /// <param name="key">Key to set/get the value</param>
        /// <param name="value">Value that is saved</param>
        /// <returns></returns>
        abstract Task<bool> SetObject(string key, object value);
        /// <summary>
        /// Set a key with a string
        /// </summary>
        /// <param name="key">Key to set/get the value</param>
        /// <param name="value">Value that is saved</param>
        /// <returns></returns>
        abstract Task<bool> SetKey(string key, string value);
        abstract Task<T> GetObject<T>(string key) where T : class;
        abstract Task<string> GetKey(string key);
    }
}
