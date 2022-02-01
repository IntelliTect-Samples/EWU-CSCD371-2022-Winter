// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Globalization", "CA1303:Do not pass literals as localized parameters", Justification = "No need for data table", Scope = "module")]
[assembly: SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Test methods may contain underscores", Scope = "module")]
[assembly: SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "Test methods may contain underscores", Scope = "module")]
