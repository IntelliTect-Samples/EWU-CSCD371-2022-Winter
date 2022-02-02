﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "test method names do not use PascalCase")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Underscores allowed in test method names")]
[assembly: SuppressMessage("Globalization", "CA1304:Specify CultureInfo", Justification = "Don't need to consider globalization")]
[assembly: SuppressMessage("Globalization", "CA1307:Specify StringComparison", Justification = "Don't need to consider globalization")]

