
```cs
using ServiceStack.OrmLite;
using Kimtoo.ServicestackContext;
 

/**Create a connection**/

//This creates default connecton
 var err = Db.Init(@"Server=EXRESS\LOCALHOST;Database=DatabaseName;Trusted_Connection=True;", SqlServerDialect.Provider);

// if connection fails, It returns an exception
   if (err != null)  MessageBox.Show(err.Message);


//Get the default connetion
  var db = Db.Get();

  
/**Named Instances**/

//You can run multiple instances of databases  using names     
  var err = Db.Init(@"Server=EXPRESS\SERVER;Database=DatabaseName;Trusted_Connection=True;", SqlServerDialect.Provider,"database2");       
 
//Get the connetion
  var db2 = Db.Get("database2");

/**Remove a connection**/
//this will close and remove the default connection, returns exception if it fails
Db.Close();
//this will close and remove the named connection, returns exception if it fails
Db.Close("database2");

```