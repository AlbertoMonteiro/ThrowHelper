using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

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
    }
}
