using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Writer;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;

public class FileShowParser : BaseParser
{
    public FileShowParser(IFileSystemController controller)
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
        const string commandNamePartTwo = "show";
        if (textEnumerator.Current != commandNamePartTwo) return NextParser?.TryParsing(text);

        const string firstArgumentName = "Path";
        if (!textEnumerator.MoveNext()) throw new MissingArgumentException(firstArgumentName);
        string path = textEnumerator.Current;

        const string argumentName = "-m";
        if (!textEnumerator.MoveNext()) throw new MissingArgumentException(argumentName);
        if (textEnumerator.Current != argumentName) throw new UnknownArgumentException(textEnumerator.Current);
        if (!textEnumerator.MoveNext()) throw new MissingArgumentValueException(argumentName);

        var expectedValues = new Dictionary<string, IWriter>() { { "console", new ConsoleWriter() }, };
        IWriter mode;
        if (!expectedValues.ContainsKey(textEnumerator.Current)) throw new InvalidValueException(text[3]);
        else mode = expectedValues[textEnumerator.Current];

        if (textEnumerator.MoveNext()) throw new UnknownArgumentException(nameof(textEnumerator.Current));

        return new FileShow(Controller, new Path(path), mode);
    }
}