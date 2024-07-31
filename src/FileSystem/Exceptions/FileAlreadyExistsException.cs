using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

public class FileAlreadyExistsException : InvalidOperationException
{
    public FileAlreadyExistsException()
    {
    }

    public FileAlreadyExistsException(string path)
        : base("file " + path + " already exists")
    {
    }

    public FileAlreadyExistsException(string message, Exception inner)
        : base(message, inner)
    {
    }
}