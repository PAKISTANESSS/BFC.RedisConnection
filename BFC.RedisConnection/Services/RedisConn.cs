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

        public async Task<string> GetKey(string key)
        {
            var db = await GetDatabase();

            return await db.StringGetAsync(key);
        }

        public async Task<bool> SetKey(string key, string value)
        {
            var db = await GetDatabase();

            return await db.StringSetAsync(key, value);
        }

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
    }
}
