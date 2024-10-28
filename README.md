Number to Words Converter
A .NET application that converts decimal numbers into words, specifically formatted in dollars and cents (e.g., 123.45 becomes "ONE HUNDRED AND TWENTY-THREE DOLLARS AND FORTY-FIVE CENTS").

Requirements
.NET 6 SDK or higher
xUnit (included in project dependencies)
Microsoft.NET.Test.Sdk (for running tests)
How to Run the Project
Clone the Repository:

bash
Copy code
git clone [<repository-url>](https://github.com/Mrkiller2001/NumberToWordsConverter.git)
cd NumberToWordsConverter
Restore Dependencies:

In the project’s root directory, run:
bash
Copy code
dotnet restore
Run the Application:

Start the application by running:
bash
Copy code
dotnet run --project NumberToWordsConverter
After starting, open a browser and go to https://localhost:5171 (or the specified port in the terminal) to access the app.
How to Run the Tests
Navigate to the Test Project:

Change directory to the test project:
bash
Copy code
cd NumberToWordsConverter.Tests
Run the Tests:

Execute all tests using:
bash
Copy code
dotnet test
This command compiles and runs all tests, showing results in the terminal.
Required Packages for Testing (Already Included)
These packages are included in the test project’s dependencies:

Microsoft.NET.Test.Sdk
xUnit
xUnit.runner.visualstudio
If these are missing, add the following to your test project’s .csproj file:

xml
Copy code
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
<PackageReference Include="xunit" Version="2.9.2" />
<PackageReference Include="xunit.runner.visualstudio" Version="3.0.0-pre.42" />
