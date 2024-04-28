using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace LocalizationExampleDotNetCore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly IStringLocalizer<LanguageController> _localizer;

        public LanguageController(IStringLocalizer<LanguageController> localizer)
        {
            _localizer = localizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var guid = Guid.NewGuid();
            return Ok(_localizer["RandomGUID", guid.ToString()].Value);
        }

        [HttpGet]
        [Route("/greeting")]
        public IActionResult Greeting()
        {
            var localizedStr = _localizer["Welcome"];
            return Ok(localizedStr.Value);
        }
    }
}
