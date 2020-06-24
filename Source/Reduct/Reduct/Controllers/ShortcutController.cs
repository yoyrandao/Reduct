using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Reduct.DataAccess;
using Reduct.Providers;

namespace Reduct.Controllers
{
	[ApiController]
	[Route("/register")]
	public class ShortcutController : Controller
	{
		public ShortcutController(
			UrlHashProvider       hashProvider,
			UrlValidationProvider validator,
			ILinkRepository       linkRepository)
		{
			_hashProvider   = hashProvider;
			_validator      = validator;
			_linkRepository = linkRepository;
		}

		[HttpPost]
		public async Task<IActionResult> GetShorted([FromBody] string fullUrl)
		{
			if (!_validator.Validate(fullUrl))
				return Ok(ResponseFactory.Create(false, "Wrong url format"));

			var hashedValue = _hashProvider.GetHashed(fullUrl);

			if (await _linkRepository.Exists(hashedValue))
				return Ok(ResponseFactory.Create(false, "Link already exists"));

			await _linkRepository.AddEntry(hashedValue, fullUrl);

			return Ok(ResponseFactory.Create(true, $"{Request.Scheme}://{Request.Host}/{hashedValue}"));
		}

		private readonly UrlHashProvider       _hashProvider;
		private readonly UrlValidationProvider _validator;
		private readonly ILinkRepository       _linkRepository;
	}
}