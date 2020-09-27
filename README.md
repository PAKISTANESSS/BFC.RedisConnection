# BFC.RedisConnection

BFC.RedisConnection is a simple Redis Connection Client using StackExchange nugget, to easyly manage redis.

## Installation

First you need to install the package using package manager console.

```bash
Install-package BFC.RedisConnection
```
Or with the Nuget Manager Interface search for the package.

## Configuration
Second, you need to add the setup configuration to connect to your server.
```c#
string server = "localhost";
int port = 3000;
services.SetupRedisConnection(server, port);
```

## Usage
Third, you need to inject IRedisConn into your service.
And then use it as show above.
```c#
//Set an object with a key
var value = new Person
{
   Name = "Bernardo"
};
string key = "Key_To_Use";
_redisConn.SetObject(key, value);

//Retrieves the object using a key
var person = _redisConn.GetObject<Person>(key);
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.