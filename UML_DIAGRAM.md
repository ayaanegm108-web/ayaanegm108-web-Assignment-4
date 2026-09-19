# UML Diagram - Academy Schedule Analyzer

Open this file in Visual Studio Code and use Markdown Preview (`Ctrl+Shift+V`) to view the diagrams.

## Class Diagram

```mermaid
classDiagram
    namespace Ass04 {
        class Program {
            - string[] sessionNames
            - DateTime[] sessionDates
            - int[] sessionDurations
            + Main(string[] args) void
            + Menu() void
            + displayArray~T~(T[] arr) void
            + displaySessions() void
            + displayOneSession(int index) void
            + validateInputstring() string
            + searchSession() int
            + searchStringIgnoreCase(string name) int
            + sortSessionNames() void
            + ReverseSessionNames() void
            + FindSessionIndex() void
            + CheckIfASessionExists() void
            + FindASessionUsingACondition(Func~string,bool~ condition) string
            + FindASessionIndexUsingACondition(Func~string,bool~ condition) void
            + durationAnalysis() void
            + sortDuration() void
            + squareValue(ref int value) void
            + sessionDetailsReturn(out int index, out int sessionDuration) void
            + squareRoot(double value) void
            + CalculateTotalDuration(params int[] durations) int
            + displaySessionDate() void
            + findTimeDiff() void
            + sessionsStatues() void
            + findNextSession() void
            + displaySessionDateByAllFormat() void
            + validateADate() void
            + ValidateMenuInput() int
            + GetSessionByIndex() void
            + validateDuration() void
            + mulInverse(double num) void
            + createAScheduleUsingString() string
            + createAScheduleUsingStringBuilder() string
        }
    }

    namespace Ass04.Benchmarks {
        class StringBenchmark {
            + int Iterations
            + StringConcatenation() string
            + StringBuilderConcatenation() string
        }
    }

    Program ..> StringBenchmark : optional benchmark run
    StringBenchmark ..> BenchmarkDotNet : uses attributes
```

## Application Flow Diagram

```mermaid
flowchart TD
    A[Main] --> B[Menu]
    B --> C[ValidateMenuInput]
    C --> D{Selected option}

    D -->|1| E[Display all sessions]
    D -->|2| F[Search session]
    D -->|3| G[Sort session names]
    D -->|4| H[Reverse session names]
    D -->|5| I[Find session index]
    D -->|6| J[Check session exists]
    D -->|7| K[Duration analysis]
    D -->|8| L[Session date details]
    D -->|9| M[Past and upcoming sessions]
    D -->|10| N[Find next session]
    D -->|11| O[Compare two dates]
    D -->|12| P[Validate custom date]
    D -->|13| Q[Get session by index]
    D -->|14| R[Validate duration]
    D -->|15| S[Generate report using string]
    D -->|16| T[Generate report using StringBuilder]
    D -->|0| U[Exit]

    E --> B
    F --> B
    G --> B
    H --> B
    I --> B
    J --> B
    K --> B
    L --> B
    M --> B
    N --> B
    O --> B
    P --> B
    Q --> B
    R --> B
    S --> B
    T --> B
```

## Component Diagram

```mermaid
flowchart LR
    User[Console User] --> Menu[Program.Menu]
    Menu --> Input[Input Validation]
    Menu --> Sessions[Session Data Arrays]
    Menu --> Search[Search and Lookup Methods]
    Menu --> Dates[Date and Time Methods]
    Menu --> Duration[Duration Analysis Methods]
    Menu --> Reports[Report Generation Methods]

    Benchmark[StringBenchmark] --> BenchmarkDotNet[BenchmarkDotNet]
    Benchmark --> Reports
```
