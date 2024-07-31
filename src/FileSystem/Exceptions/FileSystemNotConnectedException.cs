using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;

public class FileSystemNotConnectedException : InvalidOperationException
{
    public FileSystemNotConnectedException()
        : base("filesystem is not connected")
    {
    }

    public FileSystemNotConnectedException(string message)
        : base(message)
    {
    }

    public FileSystemNotConnectedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}