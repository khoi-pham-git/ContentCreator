using ContentCreator.Business.Service.ContentCreatorService;
using ContentCreator.Data.Models.ContentCreator;
using ContentCreator.Data.Repositories.ContentCreatorRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentCreatorController : Controller
    {
        private readonly IContentCreator _service;

        public ContentCreatorController(IContentCreator service)
        {
            _service = service;
        }

        [HttpPost("create-contentcreator")]
        public async Task<IActionResult> createProduct([FromForm] ContentCreatorCreateModel model)
        {
            Data.Models.ResultModel.ResultModel result = await _service.CreateContentCreator(model);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-all-contentcreators")]
        public async Task<IActionResult> getAllContentCreator()
        {
            Data.Models.ResultModel.ResultModel result = await _service.GetAllContentCreator();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost("update-contentcreator")]
        public async Task<IActionResult> updateProduct([FromForm] ContentCreatorUpdateModel model)
        {
            Data.Models.ResultModel.ResultModel result = await _service.UpdateContentCreator(model);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
