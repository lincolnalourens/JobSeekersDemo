using JobSeekers.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Data
{
    public interface IProfileRepository
    {
        Task<Profile> GetByIdAsync(long id);
        Task<long> CreateAsync(Profile profile);
        Task<bool> UpdateAsync(long profileId, Profile profile);
    }
}
