using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jaytwo.AsyncHelper
{
    public static class TaskExtensions
    {
        public static T AwaitSynchronously<T>(this Task<T> task) => Task.Run(() => task).ConfigureAwait(false).GetAwaiter().GetResult();

        public static void AwaitSynchronously(this Task task) => Task.Run(() => task).ConfigureAwait(false).GetAwaiter().GetResult();
    }
}
