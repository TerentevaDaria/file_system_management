using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Visitors;

public interface IVisitor
{
    public void VisitDirectory(Directory directory);
    public void VisitFile(File file);
}