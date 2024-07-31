using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Writer;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;

public class TreeListParser : BaseParser
{
    public TreeListParser(IFileSystemController controller)
        : base(controller)
    {
    }

    public override ICommand? TryParsing(IReadOnlyList<string> text)
    {
        text = text ?? throw new ArgumentNullException(nameof(text));
        if (text.Count == 0) return null;

        IEnumerator<string> textEnumerator = text.GetEnumerator();
        textEnumerator.MoveNext();

        const string commandNamePartOne = "tree";
        if (textEnumerator.Current != commandNamePartOne) return NextParser?.TryParsing(text);
        textEnumerator.MoveNext();
        const string commandNamePartTwo = "list";
        if (textEnumerator.Current != commandNamePartTwo) return NextParser?.TryParsing(text);

        int depth = 1;
        if (textEnumerator.MoveNext())
        {
            const string argumentName = "-d";
            if (textEnumerator.Current != argumentName) throw new UnknownArgumentException(textEnumerator.Current);
            if (!textEnumerator.MoveNext()) throw new MissingArgumentValueException(argumentName);
            if (!int.TryParse(textEnumerator.Current, out depth)) depth = 1;
        }

        if (textEnumerator.MoveNext()) throw new UnknownArgumentException(nameof(textEnumerator.Current));

        return new TreeList(Controller, depth, new ConsoleWriter(), new Configurator('-', '*', ' '));
    }
}