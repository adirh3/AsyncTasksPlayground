# AsyncTasksPlayground
Project samples for async/tasks practices in C#

## Awating Tasks
You can run/debug this project to see what happens when `await`ing a Task, and what is the difference between real/not-real async methods.

## Async Void
You should use `async void` only for events since you can't track their progress.

## Task.Result
Using `Task.Result` is like calling `Task.Wait()` and then getting the `Result`, it is a non-async and blocking operation.
Debug the code to see exactly how `Task.Result` differs from normally `await`ing.

## Return Task
Calling an `async method creates a statemachine (which allocates memory), if possible always return the `Task` object and don't `await` if not necessary.

## Configure Await
Tasks will try to return to the default context after completing, the default context is defined by the `SynchronizationContext` object, [read more](https://devblogs.microsoft.com/dotnet/configureawait-faq/).
Using `ConfigureAwait(false)` makes sure that after the task completion the rest of the code won't run on the default context.

## Gui with async
The `SynchronizationContext` for GUI programs is the thread that renders the UI.
When `await`ing a `Task` invoked by the UI (like clicking a button), the processing of the task will usually occur on different thread, and the rest of the code will run GUI thread thanks to the `SynchronizationContext`.

## Value Tasks
`ValueTask` is a stripped version of `Task` that allocates less memory and should be used in a code that doesn't necessarily calls an `async` method.

## Async Enumerable
Just like normal `IEnumerable<T>` which it's enumerator has `MoveNext()` method, but for `IAsyncEnumerable<T>` the `MoveNext` method is `async`, therefore not blocking.

## Cancellation Tokens
Using cancellation tokens you can cancel long running tasks.
