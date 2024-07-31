using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

public class MissingArgumentException : ParserException
{
    public MissingArgumentException()
    {
    }

    public MissingArgumentException(string argument)
        : base("missing " + argument)
    {
    }

    public MissingArgumentException(string message, Exception inner)
        : base(message, inner)
    {
    }
}