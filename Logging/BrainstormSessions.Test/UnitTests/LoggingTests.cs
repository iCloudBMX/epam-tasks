using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainstormSessions.Api;
using BrainstormSessions.Controllers;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using FluentAssertions;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using Moq;
using Serilog;
using Serilog.Sinks.TestCorrelator;
using Xunit;
using Serilog.Events;

namespace BrainstormSessions.Test.UnitTests
{
    public class LoggingTests : IDisposable
    {
        private readonly MemoryAppender _appender;

        public LoggingTests()
        {
            _appender = new MemoryAppender();
            BasicConfigurator.Configure(_appender);
        }

        public void Dispose()
        {
            _appender.Clear();
        }

        [Fact]
        public async Task HomeController_Index_LogInfoMessages()
        {
            // Arrange
            var brainstormSessionMockRepository =
                new Mock<IBrainstormSessionRepository>();
            
            brainstormSessionMockRepository.Setup(repository =>
                repository.ListAsync())
                    .ReturnsAsync(GetTestSessions());
            
            var homeController = new HomeController(brainstormSessionMockRepository.Object);
            
            using (TestCorrelator.CreateContext())
            {
                using(var logger = new LoggerConfiguration()
                    .WriteTo.Sink(new TestCorrelatorSink())
                        .Enrich.FromLogContext()
                            .CreateLogger())
                {
                    Log.Logger = logger;

                    // Act
                    var result = await homeController.Index();

                    // Assert
                    var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

                    logEvents.Should()
                        .Satisfy(logEvent =>
                            logEvent.Level == LogEventLevel.Information);
                }                
            }
        }

        [Fact]
        public async Task HomeController_IndexPost_LogWarningMessage_WhenModelStateIsInvalid()
        {
            // Arrange
            var brainstormSessionMockRepository =
                new Mock<IBrainstormSessionRepository>();
            
            brainstormSessionMockRepository.Setup(repository =>
                repository.ListAsync())
                    .ReturnsAsync(GetTestSessions());
            
            var homeController = new HomeController(brainstormSessionMockRepository.Object);            
            homeController.ModelState.AddModelError("SessionName", "Required");
            
            var newSession = new HomeController.NewSessionModel();

            using (TestCorrelator.CreateContext())
            {
                using (var logger = new LoggerConfiguration()
                    .WriteTo.Sink(new TestCorrelatorSink())
                        .Enrich.FromLogContext()
                            .CreateLogger())
                {
                    Log.Logger = logger;

                    // Act
                    var result = await homeController.Index(newSession);

                    // Assert
                    var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

                    logEvents.Should()
                        .Satisfy(logEvent =>
                            logEvent.Level == LogEventLevel.Warning);
                }
            }
        }

        [Fact]
        public async Task IdeasController_CreateActionResult_LogErrorMessage_WhenModelStateIsInvalid()
        {
            // Arrange
            var brainstormSessionMockRepository =
                new Mock<IBrainstormSessionRepository>();
            
            var ideasController = new IdeasController(brainstormSessionMockRepository.Object);
            ideasController.ModelState.AddModelError("error", "some error");           

            using (TestCorrelator.CreateContext())
            {
                using (var logger = new LoggerConfiguration()
                    .WriteTo.Sink(new TestCorrelatorSink())
                        .Enrich.FromLogContext()
                            .CreateLogger())
                {
                    Log.Logger = logger;

                    // Act
                    var result = await ideasController.CreateActionResult(model: null);

                    // Assert
                    var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

                    logEvents.Should()
                        .Satisfy(logEvent =>
                            logEvent.Level == LogEventLevel.Error);
                }
            }
        }

        [Fact]
        public async Task SessionController_Index_LogDebugMessages()
        {
            // Arrange
            int testSessionId = 1;
            int actualCountOfDebegLevelEvents = 2;

            var brainstormSessionMockRepository =
                new Mock<IBrainstormSessionRepository>();
            
            brainstormSessionMockRepository.Setup(repository =>
                repository.GetByIdAsync(testSessionId))
                    .ReturnsAsync(GetTestSessions()
                        .FirstOrDefault(session => 
                            session.Id == testSessionId));

            var sessionController = new SessionController(brainstormSessionMockRepository.Object);

            using (TestCorrelator.CreateContext())
            {
                using (var logger = new LoggerConfiguration()
                    .WriteTo.Sink(new TestCorrelatorSink())
                        .Enrich.FromLogContext()
                            .CreateLogger())
                {
                    Log.Logger = logger;

                    // Act
                    var result = await sessionController.Index(testSessionId);

                    // Assert
                    var logEvents = TestCorrelator.GetLogEventsFromCurrentContext();

                    int expectedCountOfDebegLevelEvents =
                        logEvents.Count(logEvent =>
                            logEvent.Level == LogEventLevel.Debug);

                    expectedCountOfDebegLevelEvents.Should()
                        .Be(actualCountOfDebegLevelEvents);
                }
            }
        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession>();
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            });
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 1),
                Id = 2,
                Name = "Test Two"
            });
            return sessions;
        }

    }
}
