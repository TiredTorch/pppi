using pppi;

ClientAssociate client = new ClientAssociate();

Console.WriteLine("Post 1:\n");
AssociateModel result = await client.Get();

result.PrintResult();

Console.WriteLine("\n\nPost 2:\n");

AssociateModel result2 = await client.Post("2");

result2.PrintResult();