using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem.Services.Writer;
using Itmo.ObjectOrientedProgramming.Lab4.Parser.Services;
using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    [Fact]
    public void TryParsingConnect()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "connect D:\\test -m local";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<Connect>(command);
        if (command is Connect connect)
        {
            Assert.Equal(controller, connect.Controller);
            Assert.Equal(Mode.Local, connect.Mode);
            Assert.Equal("D:\\test", connect.Address.StringValue);
        }
    }

    [Fact]
    public void TryParsingDisconnect()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "disconnect";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<Disconnect>(command);
        if (command is Disconnect disconnect)
        {
            Assert.Equal(controller, disconnect.Controller);
        }
    }

    [Fact]
    public void TryParsingTreeGoTo()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "tree goto D:\\test";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<TreeGoTo>(command);
        if (command is TreeGoTo treeGoTo)
        {
            Assert.Equal(controller, treeGoTo.Controller);
            Assert.Equal("D:\\test", treeGoTo.Path.StringValue);
        }
    }

    [Fact]
    public void TryParsingTreeListWithDepth()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "tree list -d 5";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<TreeList>(command);
        if (command is TreeList treeList)
        {
            Assert.Equal(controller, treeList.Controller);
            Assert.Equal(5, treeList.Depth);
        }
    }

    [Fact]
    public void TryParsingTreeListWithDefaultDepth()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "tree list";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<TreeList>(command);
        if (command is TreeList treeList)
        {
            Assert.Equal(controller, treeList.Controller);
            Assert.Equal(1, treeList.Depth);
        }
    }

    [Fact]
    public void TryParsingFileShow()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "file show D:\\test\\t1\\1.txt -m console";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<FileShow>(command);
        if (command is FileShow fileShow)
        {
            Assert.Equal(controller, fileShow.Controller);
            Assert.Equal("D:\\test\\t1\\1.txt", fileShow.Path.StringValue);
            Assert.IsType<ConsoleWriter>(fileShow.Writer);
        }
    }

    [Fact]
    public void TryParsingFileMove()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "file move D:\\test\\t1\\1.txt t2";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<FileMove>(command);
        if (command is FileMove fileMove)
        {
            Assert.Equal(controller, fileMove.Controller);
            Assert.Equal("D:\\test\\t1\\1.txt", fileMove.SourcePath.StringValue);
            Assert.Equal("t2", fileMove.DestinationPath.StringValue);
        }
    }

    [Fact]
    public void TryParsingFileCopy()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "file copy D:\\test\\t1\\1.txt t2";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<FileCopy>(command);
        if (command is FileCopy fileCopy)
        {
            Assert.Equal(controller, fileCopy.Controller);
            Assert.Equal("D:\\test\\t1\\1.txt", fileCopy.SourcePath.StringValue);
            Assert.Equal("t2", fileCopy.DestinationPath.StringValue);
        }
    }

    [Fact]
    public void TryParsingFileRename()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "file rename D:\\test\\t1\\1.txt 2.txt";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<FileRename>(command);
        if (command is FileRename fileRename)
        {
            Assert.Equal(controller, fileRename.Controller);
            Assert.Equal("D:\\test\\t1\\1.txt", fileRename.Path.StringValue);
            Assert.Equal("2.txt", fileRename.Name);
        }
    }

    [Fact]
    public void TryParsingDelete()
    {
        // Arrange
        IFileSystemController controller = new FileSystemController();
        IParser parser = new Parser.Services.Parser(controller);
        string text = "file delete D:\\test\\1.txt";

        // Act
        ICommand? command = parser.TryParsing(text.Split());

        // Assert
        Assert.IsType<FileDelete>(command);
        if (command is FileDelete fileDelete)
        {
            Assert.Equal(controller, fileDelete.Controller);
            Assert.Equal("D:\\test\\1.txt", fileDelete.Path.StringValue);
        }
    }
}