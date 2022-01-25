## Guidelines - Essential C# 8.0 ##

All references:
Michaelis, Mark. Essential C# 8.0 (Addison-Wesley Microsoft Technology Series). Pearson Education. Kindle Edition.

See here for the current [IntelliTect Coding Guidelines](https://intellitect.github.io/CodingGuidelines)

### Chapters 1 - 9 ###

**DO** favor clarity over brevity when naming identifiers.

**DO NOT** use abbreviations or contractions within identifier names.

**DO NOT** use any acronyms unless they are widely accepted, and even then, only when necessary.
(p14)

**DO** capitalize both characters in two-character acronyms, except for the first word of a camelCased identifier.

**DO** capitalize only the first character in acronyms with three or more characters, except for the first word of a camelCased identifier.

**DO NOT** capitalize any of the characters in acronyms at the beginning of a camelCased identifier.

**DO NOT** use Hungarian notation (that is, do not encode the type of a variable in its name).
(p14)

**DO** name classes with nouns or noun phrases.

**DO** use PascalCasing for all class names.
(p15)

**DO** use camelCasing for local variable names.
(p22)

**DO NOT** use comments unless they describe something that is not obvious to someone other than the developer
who wrote the code.

**DO** favor writing clearer code over entering comments to clarify a complicated algorithm.
(p31)

**DO** use the C# keyword rather than the BCL name when specifying a data type (e.g., string rather than String).

**DO** favor consistency rather than variety within your code.
(p45)

**DO** use uppercase literal suffixes (e.g., 1.618033988749895M).
(p50)


**DO** rely on System.WriteLine() and System.Environment.NewLine rather than \n to accommodate Windows-
specific operating system idiosyncrasies with the same code that runs on Linux and iOS.
(p64)

**AVOID** using implicitly typed local variables unless the data type of the assigned value is obvious.
(p82)

**DO** use camelCasing for variable declarations using tuple syntax.

**CONSIDER** using PascalCasing for all tuple item names.
(p87)

**DO** use parentheses to make code more readable, particularly if the operator precedence is not clear to the casual
reader.
(p113)

**DO** favor composite formatting over use of the addition operator for concatenating strings when localization is a possibility.
(p115)

**AVOID** binary floating-point types when exact decimal arithmetic is required; use the decimal floating-point type instead.
(p117)

**AVOID** using equality conditionals with binary floating-point types. Either subtract the two values and see if their difference is less than a tolerance, or use the decimal type.
(p118)

**AVOID** confusing usage of the increment and decrement operators.

**DO** be cautious when porting code between C, C++, and C# that uses increment and decrement operators; C and C++ implementations need not follow the same rules as C#.
(p124)

**DO NOT** use a constant for any value that can possibly change over time. The value of pi and the number of protons in an atom of gold are constants; the price of gold, the name of your company, and the version number of your program can change.
(p125)

**AVOID** omitting braces, except for the simplest of single-line if statements.
(p135)

**CONSIDER** using an if/else statement instead of an overly complicated conditional expression.
(p143)

**CONSIDER** refactoring the method to make the control flow easier to understand if you find yourself writing for loops with complex conditionals and multiple loop variables.
(p158)

**DO** use the for loop when the number of loop iterations is known in advance and the “counter” that gives the number of iterations executed is needed in the loop.

**DO** use the while loop when the number of loop iterations is not known in advance and a counter is not needed.
(p159)

**DO NOT** use continue as the jump statement that exits a switch section. This is legal when the switch is inside a loop, but it is easy to become confused about the meaning of break in a later switch section.
(p163)

**AVOID** using goto.
(p171)

**DO** give methods names that are verbs or verb phrases.
(p183)

**DO** use PascalCasing for namespace names.

**CONSIDER** organizing the directory hierarchy for source code files to match the namespace hierarchy.
(p186)

**DO** use camelCasing for parameter names.
(p191)

**DO** use parameter arrays when a method can handle any number—including zero—of additional arguments.
(p214)

**DO** provide good defaults for all parameters where possible.

**DO** provide simple method overloads that have a small number of required parameters.

**CONSIDER** organizing overloads from the simplest to the most complex.
(p222)

**DO** treat parameter names as part of the API, and avoid changing the names if version compatibility between APIs is important.
(p223)

**AVOID** explicitly throwing exceptions from finally blocks. (Implicitly thrown exceptions resulting from method calls are acceptable.)

**DO** favor try/finally and avoid using try/catch for cleanup code.

**DO** throw exceptions that describe which exceptional circumstance occurred, and if possible, how to prevent it.
(p232)

**AVOID** general catch blocks and replace them with a catch of System.Exception.

**AVOID** catching exceptions for which the appropriate action is unknown. It is better to let an exception go unhandled than to handle it incorrectly.

**AVOID** catching and logging an exception before rethrowing it. Instead, allow the exception to escape until it can be handled appropriately.
(p235)

**DO** prefer using an empty throw when catching and rethrowing an exception so as to preserve the call stack.

**DO** report execution failures by throwing exceptions rather than returning error codes.

**DO NOT** have public members that return exceptions as return values or an out parameter. Throw exceptions to indicate errors; do not use them as return values to indicate errors.
(p237)

**DO NOT** use exceptions for handling normal, expected conditions; use them for exceptional, unexpected conditions.
(p238)

**DO NOT** place more than one class in a single source file.

**DO** name the source file with the name of the public type it contains.
(p246)

**DO** use properties for simple access to simple data with simple computations.

**AVOID** throwing exceptions from property getters.

**DO** preserve the original property value if the property throws an exception.

**DO** favor automatically implemented properties over properties with simple backing fields when no additional logic is required.
(p267)

**CONSIDER** using the same casing on a property’s backing field as that used in the property, distinguishing the backing field with an “_” prefix. Do not, however, use two underscores; identifiers beginning with two underscores are reserved for the use of the C# compiler itself.

**DO** name properties using a noun, noun phrase, or adjective.

**CONSIDER** giving a property the same name as its type.

**AVOID** naming fields with camelCase.

**DO** favor prefixing Boolean properties with “Is,” “Can,” or “Has,” when that practice adds value.

**DO NOT** declare instance fields that are public or protected. (Instead, expose them via a property.)

**DO** name properties with PascalCase.

**DO** favor automatically implemented properties over fields.

**DO** favor automatically implemented properties over using fully expanded ones if there is no additional implementation logic.
(p268)

**AVOID** accessing the backing field of a property outside the property, even from within the containing class.

**DO** use "value" for the paramName argument when creating ArgumentException() or ArgumentNullException() type exceptions ("value" is the implicit name of the parameter on property setters).
(p270)

**DO** create read-only properties if the property value should not be changed.

**DO** create read-only automatically implemented properties in C# 6.0 (or later) rather than read-only properties with a backing field if the property value should not be changed.
(p272)

**DO** apply appropriate accessibility modifiers on implementations of getters and setters on all properties.

**DO NOT** provide set-only properties or properties with the setter having broader accessibility than the getter.
(p276)

**DO** provide sensible defaults for all properties, ensuring that defaults do not result in a security hole or significantly inefficient code. For automatically implemented properties, set the default via the constructor.


**DO** allow properties to be set in any order, even if this results in a temporarily invalid object state.
(p282)

**DO** use the same name for constructor parameters (camelCase) and properties (PascalCase) if the constructor parameters are used to simply set the property.

**DO** provide constructor optional parameters and/or convenience constructor overloads that initialize properties with good defaults.

**DO** allow properties to be set in any order, even if this results in a temporarily invalid object state.
(p285)

**CONSIDER** initializing static fields inline rather than explicitly using static constructors or declaration assigned values.
(p296)

**AVOID** frivolously defining extension methods, especially on types you don’t own.
(p300)

**DO** use constant fields for values that will never change.

**DO NOT** use constant fields for values that will change over time.
(p301)

**DO** favor read-only automatically implemented properties in C# 6.0 (or later) over read-only fields.

**DO** use public static readonly modified fields for predefined object instances prior to C# 6.0.

**AVOID** changing a public readonly modified field in pre-C# 6.0 to a read-only automatically implemented property in C# 6.0 (or later) if version API compatibility is required.
(p304)

**AVOID** publicly exposed nested types. The only exception is if the declaration of such a type is unlikely or pertains to an advanced customization scenario.
(p306)

**DO** use PascalCasing and an “I” prefix for interface names.
(p355)

**AVOID** implementing interface members explicitly without a good reason. However, if you’re unsure, favor explicit implementation.
(p365)

**CONSIDER** defining interfaces to achieve a similar effect to that of multiple inheritance.
(p372)

**DO NOT** add members to an interface that has already shipped.
(p374)

**DO** generally favor classes over interfaces. Use abstract classes to decouple contracts (what the type does) from implementation details (how the type does it.)

**CONSIDER** defining an interface if you need to support its functionality on types that already inherit from some other type.
(p376)

**AVOID** using “marker” interfaces with no members; use attributes instead.
(p377)

**DO NOT** create value types that consume more than 16 bytes of memory.
(p381)

**DO** create value types that are immutable.
(p385)

**DO** ensure that the default value of a struct is valid; it is always possible to obtain the default “all zero” value of a struct.
(p387)

**DO** overload the equality operators (Equals(), ==, and !=) on value types if equality is meaningful. (Also consider implementing the IEquatable<T> interface.)
(p390)

**AVOID** mutable value types.
(p396)

**CONSIDER** using the default 32-bit integer type as the underlying type of an enum. Use a smaller type only if you must do so for interoperability or performance reasons; use a larger type only if you are creating a flags enum (see the discussion later in this chapter) with more than 32 flags.
(p401)

**CONSIDER** adding new members to existing enums, but keep in mind the compatibility risk.

**AVOID** creating enums that represent an “incomplete” set of values, such as product version numbers.

**AVOID** creating “reserved for future use” values in an enum.

**AVOID** enums that contain a single value. 

**DO** provide a value of 0 (none) for simple enums, knowing that 0 will be the default value when no explicit initialization is provided.
(p402)

**AVOID** direct enum/string conversions where the string must be localized into the user’s language.
(p404)

**DO** use the FlagsAttribute to mark enums that contain flags.

**DO** provide a None value equal to 0 for all flag enums.

**AVOID** creating flag enums where the zero value has a meaning other than “no flags are set.”

**CONSIDER** providing special values for commonly used combinations of flags.

**DO NOT** include “sentinel” values (such as a value called Maximum); such values can be confusing to the user.

**DO** use powers of 2 to ensure that all flag combinations are represented uniquely.
(p407)

**DO NOT** define a struct unless it logically represents a single value, consumes 16 bytes or less of storage, is immutable, and is infrequently boxed.
(p410)


All references:
Michaelis, Mark. Essential C# 8.0 (Addison-Wesley Microsoft Technology Series). Pearson Education. Kindle Edition.
