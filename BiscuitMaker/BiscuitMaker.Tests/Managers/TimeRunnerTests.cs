using BiscuitMaker.Managers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitMaker.Tests.Managers
{
    [TestFixture]
    class TimeRunnerTests : ManagerTestsBase
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
