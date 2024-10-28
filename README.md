

---

# Number to Words Converter

A .NET application that converts decimal numbers into words, specifically formatted in dollars and cents (e.g., `123.45` becomes "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS").

## Requirements

- **.NET 6 SDK** or higher
- **xUnit** (included in project dependencies)
- **Microsoft.NET.Test.Sdk** (for running tests)

## How to Run the Project

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/Mrkiller2001/NumberToWordsConverter.git
   cd NumberToWordsConverter
   ```

2. **Restore Dependencies**:
   - In the project’s root directory, run:
     ```bash
     dotnet restore
     ```

3. **Run the Application**:
   - Start the application by running:
     ```bash
     dotnet run --project NumberToWordsConverter
     ```
   - After starting, open a browser and go to `https://localhost:5171` (or the specified port in the terminal) to access the app.

## How to Run the Tests

1. **Navigate to the Test Project**:
   - Change directory to the test project:
     ```bash
     cd NumberToWordsConverter.Tests
     ```

2. **Run the Tests**:
   - Execute all tests using:
     ```bash
     dotnet test
     ```
   - This command compiles and runs all tests, displaying the results in the terminal.

## Required Packages for Testing (Already Included)

These packages are included in the test project’s dependencies:

- **Microsoft.NET.Test.Sdk**
- **xUnit**
- **xUnit.runner.visualstudio**

If these packages are missing, add the following to your test project’s `.csproj` file:

```xml
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
<PackageReference Include="xunit" Version="2.9.2" />
<PackageReference Include="xunit.runner.visualstudio" Version="3.0.0-pre.42" />
```

---
