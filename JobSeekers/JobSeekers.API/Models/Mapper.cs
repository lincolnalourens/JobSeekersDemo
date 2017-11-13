using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSeekers.API.Models
{
    public class Mapper : IMapper
    {
        private readonly ILogger<Mapper> _logger;

        public Mapper(ILogger<Mapper> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Converts an API-level model to a Repository-level model
        /// </summary>
        /// <param name="inModel"></param>
        /// <returns></returns>
        public async Task<JobSeekers.Data.Models.Profile> ToRepositoryModelAsync(Profile inModel)
        {
            _logger.LogInformation($"Mapper.ToRepositoryModelAsync({JsonConvert.SerializeObject(inModel)})");

            JobSeekers.Data.Models.Profile outModel = new Data.Models.Profile();

            outModel.FirstName = inModel.FirstName;
            outModel.MiddleName = inModel.MiddleName;
            outModel.LastName = inModel.LastName;
            outModel.Skills = inModel.Skills == null ? "" : string.Join(',', inModel.Skills);

            foreach (var inWorkHistory in inModel.WorkHistory)
            {
                outModel.WorkHistory.Add(new JobSeekers.Data.Models.Position
                {
                    Title = inWorkHistory.Title,
                    StartDate = inWorkHistory.StartDate,
                    EndDate = inWorkHistory.EndDate,
                    EmployerName = inWorkHistory.EmployerName,
                    Description = inWorkHistory.Description,
                    Location = new JobSeekers.Data.Models.Location
                    {
                        Name = inWorkHistory.Location.Name,
                        Address = inWorkHistory.Location.Address,
                        City = inWorkHistory.Location.City,
                        State = inWorkHistory.Location.State,
                        Zip = inWorkHistory.Location.Zip,
                        Description = inWorkHistory.Location.Description,
                    }
                });
            }

            return outModel;
        }

        /// <summary>
        /// Converts a Repository-level model to an API-level model
        /// </summary>
        /// <param name="inModel"></param>
        /// <returns></returns>
        public async Task<Profile> FromRepositoryModelAsync(JobSeekers.Data.Models.Profile inModel)
        {
            _logger.LogInformation($"Mapper.FromRepositoryModelAsync({JsonConvert.SerializeObject(inModel)})");

            Profile outModel = new Profile();

            outModel.FirstName = inModel.FirstName;
            outModel.MiddleName = inModel.MiddleName;
            outModel.LastName = inModel.LastName;
            outModel.Skills = inModel.Skills == null ? new List<string>() : inModel.Skills.Split(',').ToList();

            foreach(var inWorkHistory in inModel.WorkHistory)
            {
                outModel.WorkHistory.Add(new Position
                {
                    Title = inWorkHistory.Title,
                    StartDate = inWorkHistory.StartDate,
                    EndDate = inWorkHistory.EndDate,
                    EmployerName = inWorkHistory.EmployerName,
                    Description = inWorkHistory.Description,
                    Location = new Location
                    {
                        Name = inWorkHistory.Location.Name,
                        Address = inWorkHistory.Location.Address,
                        City = inWorkHistory.Location.City,
                        State = inWorkHistory.Location.State,
                        Zip = inWorkHistory.Location.Zip,
                        Description = inWorkHistory.Location.Description,
                    }
                });
            }

            return outModel;
        }

    }
}
