using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;

public class FileRenameParser : BaseParser
{
    public FileRenameParser(IFileSystemController controller)
        : base(controller)
    {
    }

    public override ICommand? TryParsing(IReadOnlyList<string> text)
    {
        text = text ?? throw new ArgumentNullException(nameof(text));
        if (text.Count == 0) return null;

        IEnumerator<string> textEnumerator = text.GetEnumerator();
        textEnumerator.MoveNext();

        const string commandNamePartOne = "file";
        if (textEnumerator.Current != commandNamePartOne) return NextParser?.TryParsing(text);
        textEnumerator.MoveNext();
        const string commandNamePartTwo = "rename";
        if (textEnumerator.Current != commandNamePartTwo) return NextParser?.TryParsing(text);

        const string firstArgumentName = "SourcePath";
        if (!textEnumerator.MoveNext()) throw new MissingArgumentException(firstArgumentName);
        string sourcePath = textEnumerator.Current;

        const string secondArgumentName = "Name";
        if (!textEnumerator.MoveNext()) throw new MissingArgumentException(secondArgumentName);
        string name = textEnumerator.Current;

        if (textEnumerator.MoveNext()) throw new UnknownArgumentException(nameof(textEnumerator.Current));

        return new FileRename(Controller, new Path(sourcePath), name);
    }
}