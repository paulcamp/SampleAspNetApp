# What is it?
An ASP.NET MVC Sample that stores a user email and password to a repo without using an ORM, instead demonstrating standard ADO.NET. 

# Setup
Create a blank SQL Server database and run the following script against it: 
````
SQLServer-Setup.sql
````

# Configuration

Configure your SQL Server database connection string in web.config: 

````csharp
<connectionStrings>
    <add name="DB"
         providerName="System.Data.SqlClient"
         connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=YOURDATABASENAME;Integrated Security=True"/>
  </connectionStrings>
````


# Areas for improvement

* Email confirmation step could be added before storing an anonymous user - SendGrid or similar could be used to do this.
* Registration page could be throttled to avoid spamming
* AJAX could be used to check if the email address already exists before submitting the form but I have purposely avoided any hand-crafted JavaScript in this example.
* Strings used in the UI should probably live in a resource to allow for easier internationalisation
* Analytics could be used to capture number of new registrations, failures, etc.
* PasswordHasher could be swapped for a non-copyrighted alternative - it was used in the interests of time constraints and not having to re-invent the wheel.
* The SQL database table may benefit from an index that includes the Email column when the data grows to a substantial size.

