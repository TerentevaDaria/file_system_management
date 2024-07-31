using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

public class MissingArgumentValueException : ParserException
{
    public MissingArgumentValueException()
    {
    }

    public MissingArgumentValueException(string argument)
        : base("missing value for " + argument)
    {
    }

    public MissingArgumentValueException(string message, Exception inner)
        : base(message, inner)
    {
    }
}