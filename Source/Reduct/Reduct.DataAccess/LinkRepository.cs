using System.Threading.Tasks;

using StackExchange.Redis;

namespace Reduct.DataAccess
{
	public class LinkRepository : ILinkRepository
	{
		public LinkRepository(RedisConfiguration configuration)
		{
			var connectionConfig = new ConfigurationOptions
			{
				EndPoints =
				{
					{ configuration.Host, configuration.Port }
				},
				Password = configuration.Password
			};
			
			_connection = ConnectionMultiplexer.Connect(connectionConfig);
			_database = _connection.GetDatabase();
		}

		public async Task AddEntry(string shortUrl, string fullUrl)
			=> await _database.StringSetAsync(shortUrl, fullUrl);

		public async Task<string> GetFullUrl(string shortUrl)
		{
			if (!(await this.Exists(shortUrl)))
				return string.Empty;
			
			return await _database.StringGetAsync(shortUrl);
		}

		public async Task<bool> Exists(string key)
			=> await _database.KeyExistsAsync(key);

		private readonly ConnectionMultiplexer _connection;
		private readonly IDatabase _database;
	}
}