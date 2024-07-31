using System;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Visitors;

public class StringExportVisitor : IVisitor
{
    private readonly char _fileIcon;
    private readonly char _directoryIcon;
    private readonly char _indentIcon;
    private int _depth;

    public StringExportVisitor(Configurator configurator)
    {
        configurator = configurator ?? throw new ArgumentNullException(nameof(configurator));

        _fileIcon = configurator.FileIcon;
        _directoryIcon = configurator.DirectoryIcon;
        _indentIcon = configurator.IndentIcon;
        Result = string.Empty;
    }

    public string Result { get; private set; }

    public void VisitFile(File file)
    {
        file = file ?? throw new ArgumentNullException(nameof(file));

        Result += new string(_indentIcon, _depth) + _fileIcon + file.Name + '\n';
    }

    public void VisitDirectory(Directory directory)
    {
        directory = directory ?? throw new ArgumentNullException(nameof(directory));

        Result += new string(_indentIcon, _depth) + _directoryIcon + directory.Name + '\n';
        _depth += 1;

        foreach (IFileSystemElement fileSystemElement in directory.Data)
        {
            fileSystemElement.Accept(this);
        }

        _depth -= 1;
    }

    public void Reset()
    {
        _depth = 0;
        Result = string.Empty;
    }
}