using System;
using System.Diagnostics;

namespace ThrowHelper
{
    public static class Throw
    {
        public static Func<Exception, Exception> GlobalModifier { get; set; }

        [DebuggerStepThrough]
        public static void Now(
            Exception exception,
            Func<Exception, Exception> modifier = null
            )
        {

            if (exception == null)
                throw new ArgumentNullException("exception");

            Exception e = exception;

            if (modifier != null)
                e = modifier(exception) ?? exception;

            if (GlobalModifier != null)
                e = GlobalModifier(e) ?? exception;

            throw e;
        }

        [DebuggerStepThrough]
        public static void IfArgumentNull(
            object argument,
            string argumentName = null,
            Func<Exception, Exception> modifier = null
            )
        {
            if (argument != null) return;

            Now(
                new ArgumentNullException(argumentName),
                modifier
                );
        }

        [DebuggerStepThrough]
        public static void IfArgumentNullOrEmpty(
            string argument,
            string argumentName = null,
            Func<Exception, Exception> modifier = null
            )
        {
            IfArgumentNull(argument, argumentName, modifier);

            if (!String.IsNullOrEmpty(argument)) return;

            Now(new ArgumentException("Argument could not be empty", argumentName),
                modifier);
        }

    }
}
