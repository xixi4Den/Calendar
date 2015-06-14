using System;
using System.Linq;
using System.Linq.Expressions;
using Calendar.Business;
using Calendar.DataAccess;
using Calendar.Entities;
using Calendar.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Calendar.Tests
{
    [TestClass]
    public class EventServiceTests
    {
        private Mock<IRepository<Event>> eventRepositoryMock;
        private EventService subject;
        private string userId;
        private DateTime date;

        [TestInitialize]
        public void Initialize()
        {
            date = DateTime.Now;
            userId = Guid.NewGuid().ToString();
            eventRepositoryMock = new Mock<IRepository<Event>>();
            subject = new EventService(eventRepositoryMock.Object);
            AutoMapperConfiguration.RegisterMappings();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Incorrect date")]
        public void GetEventsOnDate_IncorrectDate_ArgumentException()
        {
            subject.GetEventsOnDate(new DateTime(), userId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "userId should not be null or empty")]
        public void GetEventsOnDate_EmptyUserId_ArgumentException()
        {
            subject.GetEventsOnDate(date, "");
        }

        [TestMethod]
        public void GetEventsOnDate_CorrectArguments_ResultWithCorrectDate()
        {
            var result = subject.GetEventsOnDate(date, userId);

            Assert.AreEqual(date, result.Day, "result EventListViewModel contains incorrect date");
        }

        [TestMethod]
        public void GetEventsOnDate_CorrectArguments_ResultWithCorrectUserId()
        {
            var result = subject.GetEventsOnDate(date, userId);

            Assert.AreEqual(userId, result.UserId, "result EventListViewModel contains incorrect userId");
        }

        [TestMethod]
        public void GetEventsOnDate_CorrectArguments_ResultWithCorrectEvents()
        {
            var event1 = new Event { Id = Guid.NewGuid(), ApplicationUserId = userId, StartDate = date, EndDate = date };
            SetupEventRepositoryMock(event1);

            var result = subject.GetEventsOnDate(date, userId);

            Assert.AreEqual(1, result.Events.Count(), "result EventListViewModel contains incorrect count of events");
        }

        [TestMethod]
        public void GetEventsOnDate_CorrectArguments_InvokesRepositoryOnce()
        {
            subject.GetEventsOnDate(date, userId);

            eventRepositoryMock.Verify(x => x.Get(It.IsAny<Expression<Func<Event, bool>>>(), It.IsAny<Func<IQueryable<Event>, IOrderedQueryable<Event>>>()), Times.Once);
        }

        private void SetupEventRepositoryMock(params Event[] events)
        {
            eventRepositoryMock.Setup(
                x => x.Get(It.IsAny<Expression<Func<Event, bool>>>(), It.IsAny<Func<IQueryable<Event>, IOrderedQueryable<Event>>>()))
                .Returns(events.AsQueryable());
        }
    }
}
