using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

public class InvalidPathException : InvalidOperationException
{
    public InvalidPathException()
    {
    }

    public InvalidPathException(string path)
        : base("invalid path " + path)
    {
    }

    public InvalidPathException(string message, Exception inner)
        : base(message, inner)
    {
    }
}