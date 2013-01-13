namespace StudioDonder.PrisonersDilemma.Domain.Tests.Helpers
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Attribute to specify that we expect an exception to be thrown, 
    /// but we do not care which exception.
    /// </summary>
    public class ExpectException : ExpectedExceptionBaseAttribute
    {
        /// <summary>
        /// Verify the exception.
        /// </summary>
        /// <param name="exception">The exception thrown by the unit test.</param>
        protected override void Verify(Exception exception)
        {
        }
    }
}