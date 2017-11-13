using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobSeekers.Data.Models
{
    public static class Seeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JobSeekersContext(
                serviceProvider.GetRequiredService<DbContextOptions<JobSeekersContext>>()))
            {
                // Look for any movies.
                if (context.Profile.Any())
                {
                    return;   // DB has been seeded
                }

                var skills = new List<string>
                    { "C#", "JavaScript", "CSS", "HTML", "T-SQL", "ASP.NET MVC", "ASP.NET Web API", "Entity Framework", "Bootstrap","Microsoft SQL Server", "Visual Studio", "SQL Server Management Studio", "TFS", "Git" };

                var workLocations = new List<Location>
                {
                    new Location
                {
                    Name = "Chipotle HQ #1",
                    Address = "1401 Wynkoop St.",
                    City = "Denver",
                    State = "CO",
                    Zip = "80224",
                    Description = "Chipotle Headquarters Building 1"
                },
                new Location
                {
                    Name = "EffectiveUI HQ",
                    Address = "2162 Market St.",
                    City = "Denver",
                    State = "CO",
                    Zip = "80205",
                    Description = "EffectiveUI HQ"
                },
                new Location
                {
                    Name = "Robert Half Technology Denver",
                    Address = "1125 17th St. Suite 870",
                    City = "Denver",
                    State = "CO",
                    Zip = "80202",
                    Description = "Robert Half Technology Denver"
                },
                new Location
                {
                    Name = "Shane Co. Corporate Headquarters",
                    Address = "(unlisted for security)",
                    City = "Denver",
                    State = "CO",
                    Zip = "",
                    Description = "Shane Co. Corporate Offices"
                },
                new Location
                {
                    Name = "University of Denver Parking & Mobility Services",
                    Address = "2130 S. High St.",
                    City = "Denver",
                    State = "CO",
                    Zip = "80208",
                    Description = "University of Denver Parking & Mobility Services"
                },
                new Location
                {
                    Name = "University of Iowa Center for Public Health Statistics",
                    Address = "2220 Westlawn",
                    City = "Iowa City",
                    State = "IA",
                    Zip = "52242",
                    Description = "University of Iowa Center for Public Health Statistics"
                }               };

                var workHistory = new List<Position>
                {
                    new Position
                    {
                        Title = "Senior .NET Developer",
                        Description = "Performed maintenance and contributed improvements to a variety of applications, all of which served some role in an enterprise architecture at a 2000+ store international restaurant company.",
                        StartDate = new DateTime(2016, 11, 28).ToShortDateString(),
                        EndDate = null,
                        EmployerName = "Chipotle Mexican Grill",
                            Location = workLocations[0]
                    },
                    new Position
                    {
                        Title = "Lead Software Architect",
                        Description = "Performed maintenance and contributed improvements to a SpringMVC/AngularJS web application used for travel and expenses by every employee in a large agency network. Automated significant portions of a Cucumber acceptance test suite written in Gherkin and Ruby. Contributed to the successful development of a Rails telecommunications app based on Twilio. Developed a Dockerized Node/Express SSO template to be used across varied projects. Introduced and implemented OpenAPI for documentation and mock API server purposes. Participated in fast - paced one - week sprints in a “Lab” format to solve problems quickly.",
                        StartDate = new DateTime(2016, 3, 1).ToShortDateString(),
                        EndDate = new DateTime(2016, 11, 25).ToShortDateString(),
                        EmployerName = "EffectiveUI",
                            Location = workLocations[1]
                    },
                    new Position
                    {
                        Title = "Software Developer",
                        Description = "Performed maintenance and contributed improvements to legacy Windows Forms applications for Windows Mobile in an Agile development process. Performed maintenance and contributed improvements to an Azure-based 311 system utilizing Service Bus and Blob Storage. Rewrote an aging WCF api into a modern Web API implementation. Contributed to a custom integration solution utilizing Azure Service Bus to enable cross-selling of functionality in two distinct products with entirely separate code bases and database schemas. Rewrote a municipal sales tax filing and payment portal, integrating legacy and modern systems throughout the architecture. Developed a custom OAuth2 bearer token authentication server based upon Microsoft ASP.NET Identity. Performed maintenance and contributed improvements to legacy code bases where feasible.",
                        StartDate = new DateTime(2015, 3, 1).ToShortDateString(),
                        EndDate = new DateTime(2016, 3, 1).ToShortDateString(),
                        EmployerName = "Robert Half Salaried Professional",
                            Location = workLocations[2]
                    },
                    new Position
                    {
                        Title = "Web Developer",
                        Description = "Merged new functionality and a front-end redesign into a legacy e-store codebase written in ASP.NET Web Forms. Performed maintenance and contributed improvements to legacy code bases where feasible. Participated in the development of an in-house developed point of sale system for a national jewelry retailer. Participated in a two - person team effort to introduce AngularJS, Bootstrap and modern development practices for a significant portion of the in-house POS system to assist jewelers and enforce workflow and processes.",
                        StartDate = new DateTime(2014, 7, 1).ToShortDateString(),
                        EndDate = new DateTime(2015, 3, 1).ToShortDateString(),
                        EmployerName = "Shane Co.",
                            Location = workLocations[3]
                    },
                    new Position
                    {
                        Title = "Junior Application Developer",
                        Description = "Was responsible for maintaining and updating a legacy codebase written in ASP.NET Web Forms. Developed new functionality according to the needs of domain experts and end-users. Refactored existing code to improve modularity, testability and separation of concerns. Researched new techniques and platforms for source control management with Perforce and Team Foundation Server.",
                        StartDate = new DateTime(2013, 12, 1).ToShortDateString(),
                        EndDate = new DateTime(2014, 7, 1).ToShortDateString(),
                        EmployerName = "University of Denver Parking & Mobility Services",
                            Location = workLocations[4]
                    },
                    new Position
                    {
                        Title = "Web Developer",
                        Description = "Participated in every aspect of the software development/project management life cycle. Requirements gathering and analysis - personally interacted with domain experts and end-users to determine specifications and needs from both perspectives. Participated in the design and implementation of new SQL Server databases and transitioned from a legacy SQL Server database. Used T-SQL and SAS to manage SQL Server databases. Migrated from a paper-based public health data collection system to a web-based data entry system built using C# with ASP.NET MVC and Entity Framework. Designed and implemented JavaScript-based front end interfaces with focus on user experience and performance. Implemented a complex validation system with an expressive and modifiable code base in C# using FluentValidation and a custom architecture. Designed an implementation of a unit test suite and a browser-based acceptance test suite for regression testing using NUnit and Selenium.",
                        StartDate = new DateTime(2011, 7, 1).ToShortDateString(),
                        EndDate = new DateTime(2014, 8, 1).ToShortDateString(),
                        EmployerName = "University of Iowa Center for Public Health Statistics",
                            Location = workLocations[5]
                    }
                };

                var profiles = new List<Profile>
                {
                    new Profile
                    {
                        FirstName = "Lincoln",
                        MiddleName = "Alan",
                        LastName = "Lourens",
                        WorkHistory = workHistory,
                        Skills = string.Join(',',skills)
                    }
                };

                var user = new User
                {
                    Email = "lincolnlourens@gmail.comm",
                    Profile = profiles[0]
                };

                context.Users.Add(user);
                context.Profile.AddRange(profiles);
                context.Positions.AddRange(workHistory);
                context.Location.AddRange(workLocations);
                context.SaveChanges();
            }
        }
    }
}

