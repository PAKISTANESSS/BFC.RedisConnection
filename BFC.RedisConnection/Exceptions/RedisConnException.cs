﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BFC.RedisConnection.Exceptions
{
    public class RedisConnException : Exception
    {
        public RedisConnException(string message) : base(message)
        {
        }

        public RedisConnException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
