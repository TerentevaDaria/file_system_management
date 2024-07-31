using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

public class InvalidValueException : ParserException
{
    public InvalidValueException()
    {
    }

    public InvalidValueException(string value)
        : base("invalid value " + value)
    {
    }

    public InvalidValueException(string message, Exception inner)
        : base(message, inner)
    {
    }
}