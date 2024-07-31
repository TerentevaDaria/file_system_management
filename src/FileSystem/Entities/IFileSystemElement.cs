using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;

public interface IFileSystemElement
{
    public Path Path { get; }
    public string Name { get; }

    public void Accept(IVisitor visitor);
}