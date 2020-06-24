using System.Threading.Tasks;

namespace Reduct.DataAccess
{
	public interface ILinkRepository
	{
		Task AddEntry(string shortUrl, string fullUrl);

		Task<string> GetFullUrl(string shortUrl);

		Task<bool> Exists(string key);
	}
}