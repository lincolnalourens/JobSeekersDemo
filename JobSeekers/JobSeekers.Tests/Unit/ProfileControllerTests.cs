using JobSeekers.API.Controllers;
using JobSeekers.API.Models;
using JobSeekers.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Tests.Unit
{
    [TestClass]
    public class ProfileControllerTests
    {
        [TestMethod]
        public async Task Get_Calls_Repository_GetById()
        {
            // Arrange
            var profileRepositoryMock = CommonMocks.GetMockProfileRepository();
            profileRepositoryMock.Setup(pr => pr.GetByIdAsync(It.IsAny<long>())).ReturnsAsync(It.IsAny<JobSeekers.Data.Models.Profile>());
            var mapperMock = CommonMocks.GetMockMapper();
            var loggerMock = CommonMocks.GetMockProfileControllerLogger();
            var profileController = new ProfileController(profileRepositoryMock.Object,mapperMock.Object, loggerMock.Object);

            // Act
            var profileResult = profileController.Get(1);

            // Assert
            profileRepositoryMock.Verify(pr => pr.GetByIdAsync(It.IsAny<long>()), Times.Once);
        }
    }
}
