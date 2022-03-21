﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Reliability", "CA2000:Dispose objects before losing scope", Justification = "written by intellitect people, assume that it is semantics that the analyzer prefers to not use default", Scope = "member", Target = "~M:Assignment.PingProcess.Run(System.String)~Assignment.PingResult")]
[assembly: SuppressMessage("Reliability", "CA2007:Consider calling ConfigureAwait on the awaited task", Justification = "do we need to configureAwait?")]
