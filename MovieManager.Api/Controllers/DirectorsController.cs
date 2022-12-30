namespace MovieManager.Api.Controllers
{
    [Route("api/directors")]
    [Authorize]
    public class DirectorsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<DirectorsViewModel>> GetDirectors()
        {
            var directorsViewModel = await Mediator.Send(new GetDirectorsQuery());
            return directorsViewModel;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDetailViewModel>> GetDirectorDetail(Guid id)
        {
            var directorViewModel = await Mediator.Send(new GetDirectorDetailQuery() { DirectorId = id });
            return directorViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector(CreateDirectorCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDirector(Guid id)
        {
            await Mediator.Send(new DeleteDirectorCommand() { DirectorId = id });
            return NoContent();
        }
    }
}
