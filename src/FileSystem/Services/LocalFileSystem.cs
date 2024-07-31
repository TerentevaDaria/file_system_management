using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;

public class LocalFileSystem : IFileSystem
{
    public LocalFileSystem(Path workingDirectory)
    {
        workingDirectory = workingDirectory ?? throw new ArgumentNullException(nameof(workingDirectory));

        WorkingDirectory = workingDirectory;
    }

    public Path WorkingDirectory { get; private set; }

    public void ChangeDirectory(Path path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));

        string newPath = System.IO.Path.IsPathRooted(path.StringValue)
            ? path.StringValue
            : System.IO.Path.GetFullPath(path.StringValue, WorkingDirectory.StringValue);

        if (!System.IO.Path.Exists(newPath)) throw new System.IO.DirectoryNotFoundException(newPath);

        WorkingDirectory = new Path(newPath);
    }

    public File GetFile(Path path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        string filePath = System.IO.Path.IsPathRooted(path.StringValue)
            ? path.StringValue
            : System.IO.Path.GetFullPath(path.StringValue, WorkingDirectory.StringValue);

        return new File(System.IO.Path.GetFileName(filePath), path, System.IO.File.ReadAllText(filePath));
    }

    public void MoveFile(Path sourcePath, Path destinationPath)
    {
        sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));

        string absoluteSourcePath = System.IO.Path.IsPathRooted(sourcePath.StringValue)
            ? sourcePath.StringValue
            : System.IO.Path.GetFullPath(sourcePath.StringValue, WorkingDirectory.StringValue);
        string absoluteDestinationPath = System.IO.Path.IsPathRooted(destinationPath.StringValue)
            ? destinationPath.StringValue
            : System.IO.Path.GetFullPath(destinationPath.StringValue, WorkingDirectory.StringValue);
        absoluteDestinationPath = System.IO.Path.GetFullPath(System.IO.Path.GetFileName(sourcePath.StringValue), absoluteDestinationPath);

        if (System.IO.Path.Exists(absoluteDestinationPath)) throw new FileAlreadyExistsException(destinationPath.StringValue);

        System.IO.File.Move(absoluteSourcePath, absoluteDestinationPath);
    }

    public void CopyFile(Path sourcePath, Path destinationPath)
    {
        sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));

        string absoluteSourcePath = System.IO.Path.IsPathRooted(sourcePath.StringValue)
            ? sourcePath.StringValue
            : System.IO.Path.GetFullPath(sourcePath.StringValue, WorkingDirectory.StringValue);
        string absoluteDestinationPath = System.IO.Path.IsPathRooted(destinationPath.StringValue)
            ? destinationPath.StringValue
            : System.IO.Path.GetFullPath(destinationPath.StringValue, WorkingDirectory.StringValue);
        absoluteDestinationPath = System.IO.Path.GetFullPath(System.IO.Path.GetFileName(sourcePath.StringValue), absoluteDestinationPath);

        if (System.IO.Path.Exists(absoluteDestinationPath)) throw new FileAlreadyExistsException(destinationPath.StringValue);

        System.IO.File.Copy(absoluteSourcePath, absoluteDestinationPath);
    }

    public void DeleteFile(Path path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        string filePath = System.IO.Path.IsPathRooted(path.StringValue)
            ? path.StringValue
            : System.IO.Path.GetFullPath(path.StringValue, WorkingDirectory.StringValue);

        System.IO.File.Delete(filePath);
    }

    public void RenameFile(Path path, string name)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        string sourcePath = System.IO.Path.IsPathRooted(path.StringValue)
            ? path.StringValue
            : System.IO.Path.GetFullPath(path.StringValue, WorkingDirectory.StringValue);
        string destinationPath = System.IO.Path.IsPathRooted(path.StringValue)
            ? path.StringValue
            : System.IO.Path.GetFullPath(path.StringValue, WorkingDirectory.StringValue);
        string? directory = System.IO.Path.GetDirectoryName(destinationPath);
        if (directory is null) throw new InvalidPathException(path.StringValue);
        destinationPath = System.IO.Path.GetFullPath(name, directory);

        System.IO.File.Move(sourcePath, destinationPath);
    }

    public Directory GetTree(int depth)
    {
        if (depth < 0) throw new NotPositiveValueException(nameof(depth));

        return GetTree(WorkingDirectory.StringValue, depth);
    }

    private Directory GetTree(string directoryPath, int depth)
    {
        if (depth < 0) throw new NotPositiveValueException(nameof(depth));

        var data = new List<IFileSystemElement>();

        foreach (string path in System.IO.Directory.EnumerateDirectories(directoryPath))
        {
            if (depth > 1) data.Add(GetTree(path, depth - 1));
            else data.Add(new Directory(System.IO.Path.GetFileName(path), new Path(path)));
        }

        foreach (string path in System.IO.Directory.EnumerateFiles(directoryPath))
        {
            data.Add(new File(System.IO.Path.GetFileName(path), new Path(path)));
        }

        return new Directory(System.IO.Path.GetFileName(directoryPath), new Path(directoryPath), data);
    }
}