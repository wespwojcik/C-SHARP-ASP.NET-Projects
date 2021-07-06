<h1>Eccommerce Site ASP.NET Core </h1>

<h2>Description</h2>

<p>Created a full eccommerce website with authentication and authorization abilities. I also added a cache feature which allowed the user to add things to the cart and save items
to the users cache using a GUID.</p>



Code Snapshots

<h3>Create GUID with Isession functionality</h3>
![Ecommerce](blob/main/GuidEccommerce.jpg)

<p> This code creates a GUID every time a user opens the website in the browser by creating a service. This is service is injected into my 
 shopping cart class. After i'm done registering my GUID, the GUID is then returned as a shopping cart object which is returned as a db context object</p>
