Thank you much for your time and consideration!

I elected to use .NET Core 2.0 with a standard N-tier/Repository architeture. I chose the architecture as it was
requested, and the platform as I'm familiar with .NET and .NET Core 1.0 and I was looking forward to seeing what 
.NET Core 2 brings!

Even though a connection to a real database was not required, I find that building functionality off of a real database
is often very useful. It was just easier to build a database and pursue the "full experience". I have used the 
local sqlite database and will include it with source control to ensure you can run this.

Get and Post functions are working well against the database - update functionality was not quite completed, there is a
bug in the "update" code and work history is not updating, among other limitations.

A few unit tests were built out to demonstrate how I approach testing. Typically I aim for 90% or higher code coverage.
I left test files in place to show how I would move forward with tests.

To run: Open in Visual Studio 2017, run in the typical fashion.

Documentation: /swagger