using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

public class UnknownArgumentException : ParserException
{
    public UnknownArgumentException()
    {
    }

    public UnknownArgumentException(string argument)
        : base("unknown argument " + argument)
    {
    }

    public UnknownArgumentException(string message, Exception inner)
        : base(message, inner)
    {
    }
}