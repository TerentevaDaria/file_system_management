using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Writer;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;

public class FileSystemController : IFileSystemController
{
    private IFileSystem? _fileSystem;

    public void Connect(Path address, Mode mode)
    {
        try
        {
            if (mode == Mode.Local)
            {
                _fileSystem = new LocalFileSystem(address);
            }
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message, e);
        }
    }

    public void Disconnect()
    {
        if (_fileSystem is null) throw new FileSystemNotConnectedException();

        _fileSystem = null;
    }

    public void TreeGoTo(Path path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        if (_fileSystem is null) throw new FileSystemNotConnectedException();

        try
        {
            _fileSystem.ChangeDirectory(path);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message, e);
        }
    }

    public void TreeList(int depth, IWriter writer, Configurator configurator)
    {
        writer = writer ?? throw new ArgumentNullException(nameof(writer));
        configurator = configurator ?? throw new ArgumentNullException(nameof(configurator));
        if (depth < 0) throw new NotPositiveValueException(nameof(depth));
        if (_fileSystem is null) throw new FileSystemNotConnectedException();

        try
        {
            Directory res = _fileSystem.GetTree(depth);
            var visitor = new StringExportVisitor(configurator);
            visitor.VisitDirectory(res);
            writer.Write(visitor.Result);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message, e);
        }
    }

    public void FileShow(Path path, IWriter writer)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        writer = writer ?? throw new ArgumentNullException(nameof(writer));
        if (_fileSystem is null) throw new FileSystemNotConnectedException();

        try
        {
            writer.Write(_fileSystem.GetFile(path).Data);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message, e);
        }
    }

    public void FileMove(Path sourcePath, Path destinationPath)
    {
        sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
        if (_fileSystem is null) throw new FileSystemNotConnectedException();

        try
        {
            _fileSystem.MoveFile(sourcePath, destinationPath);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message, e);
        }
    }

    public void FileCopy(Path sourcePath, Path destinationPath)
    {
        sourcePath = sourcePath ?? throw new ArgumentNullException(nameof(sourcePath));
        destinationPath = destinationPath ?? throw new ArgumentNullException(nameof(destinationPath));
        if (_fileSystem is null) throw new FileSystemNotConnectedException();

        try
        {
            _fileSystem.CopyFile(sourcePath, destinationPath);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message, e);
        }
    }

    public void FileDelete(Path path)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        if (_fileSystem is null) throw new FileSystemNotConnectedException();

        try
        {
            _fileSystem.DeleteFile(path);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message, e);
        }
    }

    public void FileRename(Path path, string name)
    {
        path = path ?? throw new ArgumentNullException(nameof(path));
        if (_fileSystem is null) throw new FileSystemNotConnectedException();

        try
        {
            _fileSystem.RenameFile(path, name);
        }
        catch (Exception e)
        {
            throw new FileSystemException(e.Message, e);
        }
    }
}