using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

public class FileSystemException : Exception
{
    public FileSystemException()
    {
    }

    public FileSystemException(string message)
        : base(message)
    {
    }

    public FileSystemException(string message, Exception inner)
        : base(message, inner)
    {
    }
}