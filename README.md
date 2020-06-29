# jaytwo.AsyncHelper

<p align="center">
  <a href="https://jenkins.jaytwo.com/job/jaytwo.AsyncHelper/job/master/" alt="Build Status (master)">
    <img src="https://jenkins.jaytwo.com/buildStatus/icon?job=jaytwo.AsyncHelper%2Fmaster&subject=build%20(master)" /></a>
  <a href="https://jenkins.jaytwo.com/job/jaytwo.AsyncHelper/job/develop/" alt="Build Status (develop)">
    <img src="https://jenkins.jaytwo.com/buildStatus/icon?job=jaytwo.AsyncHelper%2Fdevelop&subject=build%20(develop)" /></a>
</p>

<p align="center">
  <a href="https://www.nuget.org/packages/jaytwo.AsyncHelper/" alt="NuGet Package jaytwo.AsyncHelper">
    <img src="https://img.shields.io/nuget/v/jaytwo.AsyncHelper.svg?logo=nuget&label=jaytwo.AsyncHelper" /></a>
  <a href="https://www.nuget.org/packages/jaytwo.AsyncHelper/" alt="NuGet Package jaytwo.AsyncHelper (beta)">
    <img src="https://img.shields.io/nuget/vpre/jaytwo.AsyncHelper.svg?logo=nuget&label=jaytwo.AsyncHelper" /></a>
</p>

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
