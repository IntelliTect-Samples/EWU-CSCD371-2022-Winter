# EWU-CSCD371-2022-Winter

## See [Docs](Docs)

# Assignment 3

## Overview
For this assignment we are going to create a joke generator. For fun we will back it with a real web service that provides jokes. However, Chuck Norris jokes are over-used so we are going to filter those out. The code to retrieve the jokes from the web service is provided for you. 

** Please note ** This is someone else's web service, please be respectful and avoid spamming it. 

## Reading
- Chapter 10 - Well Formed Types
- Chapter 11 - Exception Handling
- Read Solid Principles at https://deviq.com/principles/solid.

## Assignment

For this assignment do the following:

- Create *two* interfaces. One to represent the `JokeService` and one interface to represent outputting the joke to the screen (`Console.WriteLine`). ✔
- The `JokeService` will need to have the interface applied to it. ✔
- Create an implementation of the output interface that writes out the joke to the console. ✔
- Implement the `Jester` class. It should take in both interfaces as dependencies. These dependencies should be null checked. ✔
- The `Jester` class `TellJoke()` method should retrieve a joke from the `JokeService`. If the joke contains "Chuck Norris", skip it and get another. The joke should be written to the output dependency. ✔
- Unit test the Jester class. Code coverage should be above 90% for this class. Moq will make this significantly easier. ✔
- Enable nullability in the .csproj files and ensure no errors or warnings: ✔

## Fundamentals
- Ensure you enable:
  - nullable reference types is enabled  ✔
  - net6 targetted  ✔
  - C# 10.0  ✔
  - and enabled .NET analyzers for both projects ✔
- For this assignment, always use `Assert.AreEqual<T>()` (the generic version)  ✔
- All of the above should be unit tested ✔
- Choose simplicity over complexity ✔
  
## Extra Credit
- Unit test your implementation that writes the joke out to the screen. How hard could it be to unit test a single line method ;)?
- The Geek jokes API that is being used can also return jokes in a JSON format. Update the `JokeService` to retrieve jokes using JSON. `GetJoke` should still return a string.

## Additional links
- [Moq](https://github.com/moq/moq4) for test doubles
- [coverlet](https://github.com/coverlet-coverage/coverlet#Quick-Start) code coverage tool
- [Geek jokes API](https://github.com/sameerkumar18/geek-joke-api)

