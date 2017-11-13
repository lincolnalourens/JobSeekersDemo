using JobSeekers.API.Controllers;
using JobSeekers.API.Models;
using JobSeekers.Data;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeekers.Tests
{
    public static class CommonMocks
    {
        public static Mock<ILogger<ProfileRepository>> GetMockProfileRepositoryLogger()
        {
            return new Mock<ILogger<ProfileRepository>>();
        }

        public static Mock<IProfileRepository> GetMockProfileRepository()
        {
            return new Mock<IProfileRepository>();
        }

        public static Mock<ILogger<ProfileController>> GetMockProfileControllerLogger()
        {
            return new Mock<ILogger<ProfileController>>();
        }

        public static Mock<IMapper> GetMockMapper()
        {
            return new Mock<IMapper>();
        }

    }
}
