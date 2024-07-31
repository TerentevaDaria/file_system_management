using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

public class NotPositiveValueException : ArgumentOutOfRangeException
{
    public NotPositiveValueException()
    {
    }

    public NotPositiveValueException(string message)
        : base(message + " should be positive")
    {
    }

    public NotPositiveValueException(string message, Exception inner)
        : base(message, inner)
    {
    }
}