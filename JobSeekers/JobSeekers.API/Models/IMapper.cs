using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSeekers.API.Models
{
    public interface IMapper
    {
        Task<JobSeekers.Data.Models.Profile> ToRepositoryModelAsync(Profile inModel);
        Task<Profile> FromRepositoryModelAsync(JobSeekers.Data.Models.Profile inModel);
    }
}
