using Xunit;
using LibraryLogic;
using System;
using FakeItEasy;

namespace LibraryLogic.UnitTests.Services
{
    public class OverdueCheckerTests
    {
        private readonly OverdueChecker _sut;

        public OverdueCheckerTests() {
            _sut = new OverdueChecker();
        }

        [Fact]
        public void Should_CheckSuccessfullyForTrue()
        {
            var dueDate = DateTime.Now.AddDays(-50);

            bool result = _sut.IsOverdue(dueDate);

            Assert.True(result);
        }

        [Fact]
        public void Should_CheckSuccessfullyForFalse()
        {
            var dueDate = DateTime.Now.AddDays(50);

            bool result = _sut.IsOverdue(dueDate);

            Assert.False(result);
        }
    }
}