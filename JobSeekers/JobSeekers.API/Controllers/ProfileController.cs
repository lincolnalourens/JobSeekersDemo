using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobSeekers.Data;
using JobSeekers.API.Models;
using Newtonsoft.Json;

namespace JobSeekers.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;

        private readonly IMapper _objectMapper;

        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IProfileRepository profileRepository, IMapper objectMapper, ILogger<ProfileController> logger)
        {
            _profileRepository = profileRepository;
            _objectMapper = objectMapper;
            _logger = logger;
        }

        /// <summary>
        /// Get a profile resource.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProfile")]
        public async Task<IActionResult> Get(long id)
        {
            _logger.LogInformation($"ProfileController.Get({id})");

            // validate
            if (id <= 0)
            {
                return BadRequest("Invalid Profile ID.");
            }

            // query the repository for the profile
            var repositoryProfile = await _profileRepository.GetByIdAsync(id);

            // return not found if appropriate
            if (repositoryProfile == null) return NotFound();

            // map data to the outgoing format
            var profile = await _objectMapper.FromRepositoryModelAsync(repositoryProfile);

            return Ok(profile);
        }

        /// <summary>
        /// Creates a profile resource.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Profile profile)
        {
            _logger.LogInformation($"ProfileController.Post({JsonConvert.SerializeObject(profile)})");

            // validate
            if(ModelState.IsValid)
            {
                // mapping
                var repositoryProfile = await _objectMapper.ToRepositoryModelAsync(profile);

                // create via repository
                var repositoryProfileId = await _profileRepository.CreateAsync(repositoryProfile);

                // we use the following because it formats the response Location header value to be the new location of the created resource
                return CreatedAtRoute("GetProfile", new { id = repositoryProfileId }, null);
            }

            // todo format this cleaner
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Updates a profile resource.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Profile profile)
        {
            _logger.LogInformation($"ProfileController.Put({id}, {JsonConvert.SerializeObject(profile)})");

            // validate
            if(ModelState.IsValid)
            {
                // mapping
                var repositoryProfile = await _objectMapper.ToRepositoryModelAsync(profile);

                // update via repository
                var updated = await _profileRepository.UpdateAsync(id, repositoryProfile);

                // todo vary the returned message/result based on the result from UpdateAsync
                return Ok();
            }

            // todo format this cleaner
            return BadRequest(ModelState);
        }

    }
}