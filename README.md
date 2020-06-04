# jaytwo.AsyncHelper

[![NuGet version (jaytwo.AsyncHelper)](https://img.shields.io/nuget/v/jaytwo.AsyncHelper.svg?style=flat-square)](https://www.nuget.org/packages/jaytwo.AsyncHelper/)

Sometimes you have to mix normal and `async` code.  It's dangerous, and trying to research the "right" way to do it is 
very frustrating.  There are gradations of rightness and wrongness, and what I've done here is probably more right than
it is wrong.  Plus it's (subjectively) cleaner.

The only thing this does library does is offer a `.AwaitSynchronously()` extension method on `Task` and `Task<T>` objects.
That's it.  Seriously, two lines of code.

## Installation

Add the NuGet package

```
PM> Install-Package jaytwo.AsyncHelper
```

## Usage

```csharp
TestMethodWithoutResult().AwaitSynchronously();

// ...

async Task TestMethodWithoutResult()
{
    await Task.Delay(1);
}
```

```csharp
var foo = TestMethodWithResult(5).AwaitSynchronously();

// ...

async Task TestMethodWithResult(int value)
{
    await Task.Delay(1);
    return value;
}
```

---

Made with &hearts; by Jake
