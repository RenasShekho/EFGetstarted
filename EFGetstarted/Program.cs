using EFGetstarted;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection.Metadata;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();

static void Main()
{
    using var db = new BloggingContext();
    using (var context = new BloggingContext())
    {
        var tasks = db.Tasks.Include(t => t.Todos).ToList();

        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.Name}");
            foreach (var todo in task.Todos)
            {
                Console.WriteLine($"  Todo: {todo.Name} (Complete:{todo.IsComplete})");
            }
        }
    }

}

static void seedTasks(BloggingContext db)
{
    var produceSoftwareTask = new EFGetstarted.Task
    {
        Name = "Produce software",
        Todos = new List<ToDo>
        {
                new ToDo { Name = "Write code", IsComplete = false },
                new ToDo { Name = "Compile source", IsComplete = false },
                new ToDo { Name = "Test program", IsComplete = false }
            }
    };

    var brewCoffeeTask = new EFGetstarted.Task
    {
        Name = "Brew coffee",
        Todos = new List<ToDo>
        {
                new ToDo { Name = "Pour water", IsComplete = false },
                new ToDo { Name = "Pour coffee", IsComplete = false },
                new ToDo { Name = "Turn on", IsComplete = false }
            }
    };

}
   

