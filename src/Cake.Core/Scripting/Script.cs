﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using System.Linq;

namespace Cake.Core.Scripting
{
    /// <summary>
    /// Represents a script.
    /// </summary>
    public sealed class Script
    {
        private readonly List<string> _namespaces;
        private readonly List<string> _lines;
        private readonly List<ScriptAlias> _aliases;
        private readonly List<string> _usingAliasDirectives;
        private readonly List<string> _usingStaticDirectives;
        private readonly List<string> _defines;

        /// <summary>
        /// Gets the namespaces imported via the <c>using</c> statement.
        /// </summary>
        /// <value>The namespaces.</value>
        public IReadOnlyList<string> Namespaces => _namespaces;

        /// <summary>
        /// Gets the script lines.
        /// </summary>
        /// <value>
        /// The lines.
        /// </value>
        public IReadOnlyList<string> Lines => _lines;

        /// <summary>
        /// Gets the aliases.
        /// </summary>
        /// <value>The aliases.</value>
        public IReadOnlyList<ScriptAlias> Aliases => _aliases;

        /// <summary>
        /// Gets the using alias directives.
        /// </summary>
        /// <value>The using alias directives.</value>
        public IReadOnlyList<string> UsingAliasDirectives => _usingAliasDirectives;

        /// <summary>
        /// Gets the using static directives.
        /// </summary>
        /// <value>The using static directives.</value>
        public IReadOnlyList<string> UsingStaticDirectives => _usingStaticDirectives;

        /// <summary>
        /// Gets the defines.
        /// </summary>
        /// <value>The defines.</value>
        public IReadOnlyList<string> Defines => _defines;

        /// <summary>
        /// Initializes a new instance of the <see cref="Script" /> class.
        /// </summary>
        /// <param name="namespaces">The namespaces.</param>
        /// <param name="lines">The scrip lines.</param>
        /// <param name="aliases">The script aliases.</param>
        /// <param name="usingAliasDirectives">The using alias directives.</param>
        /// <param name="usingStaticDirectives">The using static directives.</param>
        /// <param name="defines">The defines.</param>
        public Script(
            IEnumerable<string> namespaces,
            IEnumerable<string> lines,
            IEnumerable<ScriptAlias> aliases,
            IEnumerable<string> usingAliasDirectives,
            IEnumerable<string> usingStaticDirectives,
            IEnumerable<string> defines)
        {
            _namespaces = new List<string>(namespaces ?? Enumerable.Empty<string>());
            _lines = new List<string>(lines ?? Enumerable.Empty<string>());
            _aliases = new List<ScriptAlias>(aliases ?? Enumerable.Empty<ScriptAlias>());
            _usingAliasDirectives = new List<string>(usingAliasDirectives ?? Enumerable.Empty<string>());
            _usingStaticDirectives = new List<string>(usingStaticDirectives ?? Enumerable.Empty<string>());
            _defines = new List<string>(defines ?? Enumerable.Empty<string>());
        }
    }
}