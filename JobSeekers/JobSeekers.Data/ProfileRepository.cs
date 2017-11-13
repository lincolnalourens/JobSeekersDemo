using JobSeekers.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace JobSeekers.Data
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly JobSeekersContext _dbContext;
        private readonly ILogger<ProfileRepository> _logger;

        public ProfileRepository(JobSeekersContext dbContext, ILogger<ProfileRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Gets Profile By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Profile> GetByIdAsync(long id)
        {
            _logger.LogInformation($"ProfileRepository.GetByIdAsync({id})", id);

            if(id <= 0)
            {
                throw new ArgumentException($"Invalid Profile Id {id}");
            }

            // be sure to include everything with the profile
            var profile = await _dbContext
                .Profile
                .Include(p => p.WorkHistory)
                .ThenInclude(wh => wh.Location)
                .SingleOrDefaultAsync(p => p.Id == id);

            return profile;
        }

        /// <summary>
        /// Create A Profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public async Task<long> CreateAsync(Profile profile)
        {
            _logger.LogInformation($"ProfileRepository.CreateAsync({JsonConvert.SerializeObject(profile)})");

            if(profile == null)
            {
                throw new ArgumentException("A profile is required.");
            }

            await _dbContext.Profile.AddAsync(profile);

            await _dbContext.SaveChangesAsync();

            return profile.Id;
        }

        /// <summary>
        /// Update A Profile
        /// </summary>
        /// <param name="profileId"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        // TODO verify that this returns true/false when you want it to
        public async Task<bool> UpdateAsync(long profileId, Profile profile)
        {
            _logger.LogInformation($"ProfileRepository.UpdateAsync({JsonConvert.SerializeObject(profile)})");

            if (profile == null)
            {
                throw new ArgumentException("A profile is required.");
            }

            _dbContext.Profile.Update(profile);

            var result = await _dbContext.SaveChangesAsync();

            // attempt to return true/false based on return value from .Update .es
            return result > 0;
        }
    }
}
