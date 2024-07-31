using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;

public interface IFileSystem
{
    public void ChangeDirectory(Path path);
    public File GetFile(Path path);
    public void MoveFile(Path sourcePath, Path destinationPath);
    public void CopyFile(Path sourcePath, Path destinationPath);
    public void DeleteFile(Path path);
    public void RenameFile(Path path, string name);
    public Directory GetTree(int depth);
}