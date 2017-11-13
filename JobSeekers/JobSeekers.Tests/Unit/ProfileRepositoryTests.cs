using JobSeekers.Data;
using JobSeekers.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSeekers.Tests.Unit
{
    [TestClass]
    public class ProfileRepositoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task ProfileRepository_GetByIdAsync_WithInvalidId_Exception()
        {

            var builder = new DbContextOptionsBuilder<JobSeekersContext>().Options;

            var loggerMock = CommonMocks.GetMockProfileRepositoryLogger();

            loggerMock.Setup(lm => lm.Log(LogLevel.Error, 0, It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>()));

            var pr = new ProfileRepository(new Data.Models.JobSeekersContext(builder), loggerMock.Object);

            await pr.GetByIdAsync(0);

        }

        //[TestMethod]
        //public async Task ProfileRepository_GetByIdAsync_Calls_EntityFramework()
        //{
            // Arrange
            // Mock up Entity Framework/EF Wrapper/DB Context, mock up logger, instantiate ProfileRepository

            // Act
            // Call GetByIdAsync

            // Assert
            // Verify that appropriate methods were called on context
        //}
    }
}
