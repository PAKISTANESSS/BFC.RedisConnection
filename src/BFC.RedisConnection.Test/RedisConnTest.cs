using BFC.RedisConnection.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace BFC.RedisConnection.Test
{
    [TestClass]
    public class RedisConnTest
    {
        private readonly string _key = "KEY";
        [TestMethod]
        public async Task RedisConn_Set_ServerNameError_Test()
        {
            var redisConn = Mock.Of<IRedisConn>();

            string value = "Testing";

            RedisConnection.Server = "Wrong_server_name";

            bool success = await redisConn.SetString(_key, value);
            var result = await redisConn.GetString(_key);

            Assert.IsFalse(success);
            Assert.IsNull(result);
        }
    }
}
