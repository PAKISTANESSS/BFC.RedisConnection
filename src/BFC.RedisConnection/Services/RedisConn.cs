using BFC.RedisConnection.Exceptions;
using BFC.RedisConnection.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BFC.RedisConnection.Services
{
    internal class RedisConn : IRedisConn
    {
        private async Task<IDatabaseAsync> GetDatabase()
        {
            try
            {
                ConnectionMultiplexer redis = await ConnectionMultiplexer.ConnectAsync(RedisConnection.Server);

                return redis.GetDatabase();
            }
            catch (Exception ex)
            {
                throw new RedisConnException("Unable to connect to redis instance", ex);
            }
        }

        #region String
        public async Task<string> GetString(string key)
        {
            var db = await GetDatabase();

            return await db.StringGetAsync(key);
        }

        public async Task<bool> SetString(string key, string value)
        {
            var db = await GetDatabase();

            return await db.StringSetAsync(key, value);
        }
        #endregion

        #region Object
        public async Task<T> GetObject<T>(string key) where T : class
        {
            var db = await GetDatabase();

            var value = await db.StringGetAsync(key);

            var result = JsonConvert.DeserializeObject<T>(value);

            return result;
        }

        public async Task<bool> SetObject(string key, object value)
        {
            var db = await GetDatabase();

            var result = JsonConvert.SerializeObject(value);

            return await db.StringSetAsync(key, result);
        }
        #endregion

        #region Int
        public async Task<int> GetInt(string key)
        {
            var db = await GetDatabase();

            var value = await db.StringGetAsync(key);

            return int.Parse(value);
        }

        public async Task<bool> SetInt(string key, int value)
        {
            var db = await GetDatabase();

            return await db.StringSetAsync(key, value.ToString());
        }
        #endregion

        #region Bool
        public async Task<bool> GetBool(string key)
        {
            var db = await GetDatabase();

            var value = await db.StringGetAsync(key);

            return bool.Parse(value);
        }

        public async Task<bool> SetBool(string key, bool value)
        {
            var db = await GetDatabase();

            return await db.StringSetAsync(key, value.ToString());
        }
        #endregion
    }
}
