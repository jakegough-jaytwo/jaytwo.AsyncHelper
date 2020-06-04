using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace jaytwo.AsyncHelper.Tests
{
    public class TaskExtensionsTests
    {
        [Fact]
        public void AwaitSynchronously_void()
        {
            // arrange
            //   (nothing to arrange)

            // act
            TestMethodWithoutResult().AwaitSynchronously();

            // assert
            //   (nothing to assert)
        }

        [Fact]
        public void AwaitSynchronously_with_result()
        {
            // arrange

            // act
            var result = TestMethodWithResult(1).AwaitSynchronously();

            // assert
            Assert.Equal(1, result);
        }

        private async Task TestMethodWithoutResult()
        {
            await Task.Delay(1);
        }

        private async Task<int> TestMethodWithResult(int value)
        {
            await Task.Delay(1);
            return value;
        }
    }
}
