using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using SharpTestsEx;

namespace ThrowHelper.Tests
{
    [TestFixture]
    public class ThrowNow
    {
        [SetUp]
        public void SetUp()
        {
            Throw.GlobalModifier = null;
        }

        [Test]
        public void Now_PassingNull_ThrowsArgumentNullException()
        {
            Executing.This(() => Throw.Now(null))
                .Should().Throw<ArgumentNullException>()
                .And.Exception.ParamName.Should().Be("exception");
        }

        [Test]
        public void Now_PassingAnException_ThrowsIt()
        {
            var exception = new InvalidOperationException();
            Executing.This(() => Throw.Now(exception))
                .Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void Now_PassingAnExceptionAndAModifier_ThrowsModifiedException()
        {
            var exception = new InvalidOperationException();
            Func<Exception, Exception> modifier = (e) =>
                        new Exception("Outer Exception", e);

            Executing.This(() => Throw.Now(exception, modifier))
                .Should().Throw<Exception>()
                .And.Exception.InnerException.Should().Be(exception);
        }

        [Test]
        public void Now_PassingAnExceptionWithGlobalModifier_ThrowsModifiedException()
        {
            var exception = new InvalidOperationException();
            Func<Exception, Exception> modifier = (e) =>
                        new Exception("Outer Exception", e);

            Throw.GlobalModifier = modifier;

            Executing.This(() => Throw.Now(exception))
                .Should().Throw<Exception>()
                .And.Exception.InnerException.Should().Be(exception);
        }
    }
}
