namespace BiscuitMaker.Tests.Managers
{
    using BiscuitMaker.Managers;
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    class TimeRunnerTests : TestsBase
    {
        [Test]
        public void TickTest()
        {
            var hasTicked = false;
            var runner = new TimeRunner();

            runner.RaiseClockTick += (s, e) => hasTicked = true;

            Action act = () => runner.Tick(this.Maker);
            act.Should().NotThrow();
            hasTicked.Should().BeTrue();
        }
    }
}
