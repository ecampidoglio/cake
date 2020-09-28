// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Cake.Common.Build;
using Cake.Common.Build.GitHubActions;
using Cake.Common.Tests.Fakes;
using Cake.Core;
using NSubstitute;

namespace Cake.Common.Tests.Fixtures.Build
{
    internal sealed class GitHubActionsFixture
    {
        public ICakeEnvironment Environment { get; set; }

        public FakeBuildSystemServiceMessageWriter Writer { get; set; }

        public GitHubActionsFixture()
        {
            Environment = Substitute.For<ICakeEnvironment>();
            Environment.GetEnvironmentVariable("GITHUB_ACTIONS").Returns((string)null);
            Writer = new FakeBuildSystemServiceMessageWriter();
        }

        public void IsRunningOnGitHubActions()
        {
            Environment.GetEnvironmentVariable("GITHUB_ACTIONS").Returns("true");
        }

        public GitHubActionsProvider CreateGitHubActionsService()
        {
            return new GitHubActionsProvider(Environment, Writer);
        }
    }
}
