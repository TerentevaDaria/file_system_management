using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;

public class Parser : BaseParser
{
    private IParser _chain;

    public Parser(IFileSystemController controller)
        : base(controller)
    {
        _chain = new ConnectParser(Controller);
        _chain.AddNext(new DisconnectParser(Controller));
        _chain.AddNext(new FileCopyParser(Controller));
        _chain.AddNext(new FileDeleteParser(Controller));
        _chain.AddNext(new FileMoveParser(Controller));
        _chain.AddNext(new FileRenameParser(Controller));
        _chain.AddNext(new FileShowParser(Controller));
        _chain.AddNext(new TreeGoToParser(Controller));
        _chain.AddNext(new TreeListParser(Controller));
    }

    public override ICommand? TryParsing(IReadOnlyList<string> text)
    {
        text = text ?? throw new ArgumentNullException(nameof(text));

        ICommand? result = _chain.TryParsing(text);

        return result ?? NextParser?.TryParsing(text);
    }
}