using ContentCreator.Business.Service.VideoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentCreator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoSerivce _service;

        public VideoController(IVideoSerivce service)
        {
            _service = service;
        }

        [HttpGet("get-list-video-by-contentcreatorId")]
        public async Task<IActionResult> GetListVideoContentCreatorId(Guid contentCreatorId)
        {
            Data.Models.ResultModel.ResultModel result = await _service.GetListVideoByContentId(contentCreatorId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-all-videos")]
        public async Task<IActionResult> GetAllVideos()
        {
            Data.Models.ResultModel.ResultModel result = await _service.GetAllVideos();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
