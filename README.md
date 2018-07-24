# What is it?
An ASP.NET MVC Sample that stores a user email and password to a repo without using an ORM

# Setup
Create a blank SQL Server database and run the following script against it: SQLServer-Setup.sql

# Configuration

Configure your SQL Database connection string in web.config

````csharp
<connectionStrings>
    <add name="DB"
         providerName="System.Data.SqlClient"
         connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=YOURDATABASENAME;Integrated Security=True"/>
  </connectionStrings>
````


# Areas for improvement

* PasswordHasher could be swapped for a non-copyrighted alternative - it was used in the interests of time constraints and not having to re-invent the wheel.
* Email confirmation step could be added before storing an anonymous user - SendGrid or similar could be used to do this.
* Registration page could be throttled to avoid spamming
* Success / Fail could have a nicer UX - it depends on where the user wants to go next within the application (Also should use Post-Redirect-Get pattern here to avoid form resubmission)
* Strings used in the UI should probably live in a resource to allow for easier internationalisation
* Analytics could be used to capture number of new registrations, failures, etc.

