// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Cake.Common.Tests.Fixtures.Build;
using NSubstitute;
using Xunit;

namespace Cake.Common.Tests.Unit.Build.GitHubActions.Data
{
    public sealed class GitHubActionsRunnerInfoTests
    {
        // ReSharper disable once InconsistentNaming
        public sealed class TheOSProperty
        {
            [Fact]
            public void Should_Return_Correct_Value()
            {
                // Given
                var info = new GitHubActionsInfoFixture().CreateRunnerInfo();

                // When
                var result = info.OS;

                // Then
                Assert.Equal("Linux", result);
            }
        }

        public sealed class TheTempProperty
        {
            [Fact]
            public void Should_Return_Correct_Value()
            {
                // Given
                var info = new GitHubActionsInfoFixture().CreateRunnerInfo();

                // When
                var result = info.Temp;

                // Then
                Assert.Equal("/home/runner/work/_temp", result);
            }
        }

        public sealed class TheToolCacheProperty
        {
            [Fact]
            public void Should_Return_Correct_Value()
            {
                // Given
                var info = new GitHubActionsInfoFixture().CreateRunnerInfo();

                // When
                var result = info.ToolCache;

                // Then
                Assert.Equal("/opt/hostedtoolcache", result);
            }
        }

        public sealed class TheWorkspaceProperty
        {
            [Fact]
            public void Should_Return_Correct_Value()
            {
                // Given
                var info = new GitHubActionsInfoFixture().CreateRunnerInfo();

                // When
                var result = info.Workspace;

                // Then
                Assert.Equal("/home/runner/work/cake", result);
            }
        }

        public sealed class TheIsDebugProperty
        {
            [Theory]
            [InlineData("true")]
            [InlineData("1")]
            public void Should_Return_True_If_The_Runner_Debug_Environment_Variable_Is_Set(string value)
            {
                // Given
                var fixture = new GitHubActionsInfoFixture();
                fixture.Environment.GetEnvironmentVariable("RUNNER_DEBUG").Returns(value);
                var info = fixture.CreateRunnerInfo();

                // When
                var result = info.IsDebug;

                // Then
                Assert.True(result);
            }

            [Theory]
            [InlineData("false")]
            [InlineData("0")]
            public void Should_Return_False_If_The_Runner_Debug_Environment_Variable_Is_Unset(string value)
            {
                // Given
                var fixture = new GitHubActionsInfoFixture();
                fixture.Environment.GetEnvironmentVariable("RUNNER_DEBUG").Returns(value);
                var info = fixture.CreateRunnerInfo();

                // When
                var result = info.IsDebug;

                // Then
                Assert.False(result);
            }

            [Theory]
            [InlineData(null)]
            [InlineData("")]
            public void Should_Return_False_If_The_Runner_Debug_Environment_Variable_Is_Missing(string value)
            {
                // Given
                var fixture = new GitHubActionsInfoFixture();
                fixture.Environment.GetEnvironmentVariable("RUNNER_DEBUG").Returns(value);
                var info = fixture.CreateRunnerInfo();

                // When
                var result = info.IsDebug;

                // Then
                Assert.False(result);
            }
        }
    }
}
