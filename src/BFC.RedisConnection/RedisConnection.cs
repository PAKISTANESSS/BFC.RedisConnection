using BFC.RedisConnection.Exceptions;
using BFC.RedisConnection.Services;
using BFC.RedisConnection.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;

namespace BFC.RedisConnection
{
    public static class RedisConnection

    {
        public static string Server;
        public static int Port;
        public static IServiceCollection SetupRedisConnection(this IServiceCollection serviceCollection, string server, int? port = null)
        {
            if (string.IsNullOrEmpty(server))
            {
                throw new RedisConnException("Server cannot be null or empty");
            }

            Server = server;
            Port = port ?? 0;

            serviceCollection.AddScoped<IRedisConn, RedisConn>();

            return serviceCollection;
        }

    }
}
