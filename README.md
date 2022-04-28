# BouwmarktAPI - W.I.P.

I rewrote the Bouwmarkt code to match the original assignment of building a ASP.NET (C#) Web Application management system for a hardware store to keep track of shopping Sundays. Using Entity Framework on a Code-first / Database-first base, MS SQL database with CRUD operations based on the REST principle. No front end implementation this time and a (direct) possibility to test the API with Swagger.

Instructions for testing are pretty straight forward;

<b>GET:</b>
/api/Vestiging

<b>GET (by id):</b>
/api/Vestiging/{id}

<b>POST:</b>
/api/Vestiging

<b>PUT:</b>
/api/Vestiging

<b>DELETE:</b>
/api/Vestiging/{id}

<I>Code here is runnable but not finished yet! Just added Koopzondagen. I am testing. After that I will implement some validation (prevent duplicate dates etc.). Separate I wrote a function to determine possible shopping Sundays a validation which I hope to implement later</I>.

#Showing myself and future employers I am capable of doing these kind of ASP.NET projects!
