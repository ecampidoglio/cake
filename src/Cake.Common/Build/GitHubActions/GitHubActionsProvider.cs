// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Cake.Common.Build.GitHubActions.Data;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Common.Build.GitHubActions
{
    /// <summary>
    /// Responsible for communicating with GitHub Actions.
    /// </summary>
    public class GitHubActionsProvider : IGitHubActionsProvider
    {
        private readonly ICakeEnvironment _environment;
        private readonly IBuildSystemServiceMessageWriter _writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubActionsProvider"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public GitHubActionsProvider(ICakeEnvironment environment, IBuildSystemServiceMessageWriter writer)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));

            Environment = new GitHubActionsEnvironmentInfo(environment);
        }

        /// <summary>
        /// Gets a value indicating whether the current build is running on GitHub Actions.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current build is running on GitHub Actions; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunningOnGitHubActions => _environment.GetEnvironmentVariable("GITHUB_ACTIONS")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;

        /// <summary>
        /// Gets the GitHub Actions environment.
        /// </summary>
        /// <value>
        /// The GitHub Actions environment.
        /// </value>
        public GitHubActionsEnvironmentInfo Environment { get; }

        public void AddPath(DirectoryPath path)
        {
            _writer.Write($"::add-path::{path.FullPath}");
        }
    }
}
