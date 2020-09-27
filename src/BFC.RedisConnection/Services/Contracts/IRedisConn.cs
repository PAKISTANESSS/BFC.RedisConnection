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
        abstract Task<bool> SetString(string key, string value);
        /// <summary>
        /// Set a key with a integer
        /// </summary>
        /// <param name="key">Key to set/get the value</param>
        /// <param name="value">Value that is saved</param>
        /// <returns></returns>
        abstract Task<bool> SetInt(string key, int value);
        /// <summary>
        /// Set a key with a bool
        /// </summary>
        /// <param name="key">Key to set/get the value</param>
        /// <param name="value">Value that is saved</param>
        /// <returns></returns>
        abstract Task<bool> SetBool(string key, bool value);

        /// <summary>
        /// Get an object corresponding to the given key
        /// </summary>
        /// <typeparam name="T">Type of class</typeparam>
        /// <param name="key">Key to set/get the value</param>
        /// <returns></returns>
        abstract Task<T> GetObject<T>(string key) where T : class;
        /// <summary>
        /// Get a string corresponding to the given key
        /// </summary>
        /// <param name="key">Key to set/get the value</param>
        /// <returns></returns>
        abstract Task<string> GetString(string key);
        /// <summary>
        /// Get a integer corresponding to the given key
        /// </summary>
        /// <param name="key">Key to set/get the value</param>
        /// <returns></returns>
        abstract Task<int> GetInt(string key);
        /// <summary>
        /// Get a bool corresponding to the given key
        /// </summary>
        /// <param name="key">Key to set/get the value</param>
        /// <returns></returns>
        abstract Task<bool> GetBool(string key);
    }
}
