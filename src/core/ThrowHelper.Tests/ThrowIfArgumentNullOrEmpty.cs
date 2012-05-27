using System;

using NUnit.Framework;
using SharpTestsEx;

namespace ThrowHelper.Tests
{
    [TestFixture]
    public class ThrowIfArgumentNullOrEmpty
    {
        [Test]
        public void IfArgumentNullOrEmpty_PassingNotNullNorEmpty_NotThrow()
        {
            Executing.This(() => Throw.IfArgumentNullOrEmpty("value"))
                .Should().NotThrow();
        }

        [Test]
        public void IfArgumentNullOrEmpty_PassingNullAndParamName_ThrowsArgumentNullException()
        {
            Executing.This(() => Throw.IfArgumentNullOrEmpty(null, "a"))
                .Should().Throw<ArgumentNullException>()
                .And.Exception.ParamName.Should().Be("a");
        }

        [Test]
        public void IfArgumentNullOrEmpty_PassingEmptyAndParamName_ThrowsArgumentException()
        {
            Executing.This(() => Throw.IfArgumentNullOrEmpty(string.Empty, "a"))
                .Should().Throw<ArgumentException>()
                .And.Exception.ParamName.Should().Be("a");
        }
    }
}
