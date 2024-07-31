using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;

public interface IFileSystemController
{
    public void Connect(Path address, Mode mode);
    public void Disconnect();

    public void TreeGoTo(Path path);

    public void TreeList(int depth, IWriter writer, Configurator configurator);

    public void FileShow(Path path, IWriter writer);
    public void FileMove(Path sourcePath, Path destinationPath);
    public void FileCopy(Path sourcePath, Path destinationPath);
    public void FileDelete(Path path);
    public void FileRename(Path path, string name);
}