using System;

using NUnit.Framework;
using SharpTestsEx;

namespace ThrowHelper.Tests
{
    [TestFixture]
    public class ThrowIfArgumentNull
    {
        [Test]
        public void IfArgumentNull_PassingNotNull_NotThrow()
        {
            Executing.This(() => Throw.IfArgumentNull("value"))
                .Should().NotThrow();
        }

        [Test]
        public void IfArgumentNull_PassingNullAndParamName_ThrowsArgumentNullException()
        {
            Executing.This(() => Throw.IfArgumentNull(null, "a"))
                .Should().Throw<ArgumentNullException>()
                .And.Exception.ParamName.Should().Be("a");
        }
    }
}
