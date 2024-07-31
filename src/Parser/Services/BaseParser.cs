using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;

public abstract class BaseParser : IParser
{
    protected BaseParser(IFileSystemController controller)
    {
        Controller = controller ?? throw new ArgumentNullException(nameof(controller));
    }

    protected IParser? NextParser { get; private set; }
    protected IFileSystemController Controller { get; }

    public void AddNext(IParser nextParser)
    {
        nextParser = nextParser ?? throw new ArgumentNullException(nameof(nextParser));

        if (NextParser is null) NextParser = nextParser;
        else NextParser.AddNext(nextParser);
    }

    public abstract ICommand? TryParsing(IReadOnlyList<string> text);
}