using FluentAssertions;

namespace TopLevel.Tests;

public class IntegrationTests
{
    [Test]
    public async Task InvokesNonTopLevelMain()
    {
        var result = await Main.Program.Main(Array.Empty<string>());
        result.Should().Be(0);
    }

    [Test]
    public void EntryPointIsNotAsync()
    {
        var entryPoint = typeof(Main.Program).Assembly.EntryPoint!;
        entryPoint.ReturnType.Should().Be(typeof(int));
    }

    [Test]
    public void InvokesNonTopLevelEntryPoint()
    {
        var entryPoint = typeof(Main.Program).Assembly.EntryPoint!;
        var result = entryPoint.Invoke(null, [Array.Empty<string>()]);
        result.Should().Be(0);
    }

    [Test]
    public void InvokesTopLevelSyncVoidEntryPoint()
    {
        var entryPoint = typeof(SyncVoid.AnyClass).Assembly.EntryPoint!;
        var result = entryPoint.Invoke(null, [Array.Empty<string>()]);
        result.Should().BeNull();
    }

    [Test]
    public void InvokesTopLevelSyncIntEntryPoint()
    {
        var entryPoint = typeof(SyncInt.AnyClass).Assembly.EntryPoint!;
        var result = entryPoint.Invoke(null, [Array.Empty<string>()]);
        result.Should().Be(0);
    }

    [Test]
    public void InvokesTopLevelAsyncVoidEntryPoint()
    {
        var entryPoint = typeof(AsyncVoid.AnyClass).Assembly.EntryPoint!;
        var result = entryPoint.Invoke(null, [Array.Empty<string>()]);
        result.Should().BeNull();
    }

    [Test]
    public void InvokesTopLevelAsyncIntEntryPoint()
    {
        var entryPoint = typeof(SyncInt.AnyClass).Assembly.EntryPoint!;
        var result = entryPoint.Invoke(null, [Array.Empty<string>()]);
        result.Should().Be(0);
    }

    [Test]
    public void InvokesTopLevelProgramOnlyEntryPoint()
    {
        var entryPoint = typeof(Program).Assembly.EntryPoint!;
        var result = entryPoint.Invoke(null, [Array.Empty<string>()]);
        result.Should().Be(0);
    }
}
