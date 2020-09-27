using BFC.RedisConnection.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BFC.RedisConnection.Test
{
    [TestClass]
    public class RedisConnectionTest
    {
        /// <summary>
        /// Assert that if passing the server and port values, the RedisConnection stores it
        /// </summary>
        [TestMethod]
        public void RedisConnection_Test()
        {
            var serviceCollection = Mock.Of<IServiceCollection>();

            string server = "localhost";
            int port = 123;

            RedisConnection.SetupRedisConnection(serviceCollection, server, port);

            Assert.AreEqual(server, RedisConnection.Server);
            Assert.AreEqual(port, RedisConnection.Port);
        }

        /// <summary>
        /// Assert that if passing the server but not the port, the RedisConnection stores it and sets the port to 0
        /// </summary>
        [TestMethod]
        public void RedisConnection_WithoutPort_Test()
        {
            var serviceCollection = Mock.Of<IServiceCollection>();

            string server = "localhost";

            RedisConnection.SetupRedisConnection(serviceCollection, server);

            Assert.AreEqual(server, RedisConnection.Server);
            Assert.AreEqual(0, RedisConnection.Port);
        }

        /// <summary>
        /// Assert that if the server string is empty or null, it will throw an exception
        /// </summary>
        [TestMethod]
        public void RedisConnection_WithoutServerAndPort_Test()
        {
            var serviceCollection = Mock.Of<IServiceCollection>();

            Assert.ThrowsException<RedisConnException>(() => RedisConnection.SetupRedisConnection(serviceCollection, null));
        }
    }
}
