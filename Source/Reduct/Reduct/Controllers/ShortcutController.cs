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
		public async Task<IActionResult> GetShorted([FromBody] UrlContract contract)
		{
			if (!_validator.Validate(contract.Url))
				return Ok(ResponseFactory.Create(false, "Wrong url format"));

			var hashedValue = _hashProvider.GetHashed(contract.Url);
			await _linkRepository.AddEntry(hashedValue, contract.Url);

			return Ok(ResponseFactory.Create(true, $"{Request.Scheme}://{Request.Host}/{hashedValue}"));
		}

		private readonly UrlHashProvider       _hashProvider;
		private readonly UrlValidationProvider _validator;
		private readonly ILinkRepository       _linkRepository;
	}
}