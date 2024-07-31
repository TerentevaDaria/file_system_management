using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;

public interface IParser
{
    public void AddNext(IParser nextParser);

    public ICommand? TryParsing(IReadOnlyList<string> text);
}