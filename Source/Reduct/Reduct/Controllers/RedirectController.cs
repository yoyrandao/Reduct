using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Reduct.DataAccess;

namespace Reduct.Controllers
{
	[ApiController]
	[Route("/")]
	public class RedirectController : Controller
	{
		public RedirectController(ILinkRepository linkRepository)
		{
			_linkRepository = linkRepository;
		}

		[HttpGet("{shortcut}")]
		public async Task<IActionResult> RedirectFromShortcut(string shortcut)
		{
			var fullUrl = new Uri(await _linkRepository.GetFullUrl(shortcut));

			return Redirect(fullUrl.ToString());
		}

		private readonly ILinkRepository _linkRepository;
	}
}