using EFGetstarted;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection.Metadata;

public class Program
{
    static void Main(string[] args)
    {
        //Instance of BloggingContext class
        using var db = new BloggingContext();
        // call this method with argument
        seedTasks(db);
        seedWorkers(db);

        using (var context = new BloggingContext())
        {
            var tasks = db.Tasks.Include(t => t.Todos).ToList();
            printIncompleteTasksAndTodos(context);

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
    static void seedWorkers(BloggingContext db)
    {
        using (var ctx = new BloggingContext())
        {
            //Frontend
            Worker Steen = new() { Name = "Steen Secher" };
            Worker Ejvind = new() { Name = "Ejvind Møller" };
            Worker Konrad = new() { Name = "Konrad Sommer" };
            Team Frontend = new() { Name = "Frontend" };

            //Backend
            Worker Sofus = new() { Name = "Sofus Lotus" };
            Worker Remo = new() { Name = "Remo Lademann" };
            Team Backend = new() { Name = "Backend" };
            //Testere
            Worker Ella = new() { Name = "Ella Fanth" };
            Worker Anne = new() { Name = "Anne Dam" };
            Team Testere = new() { Name = "Testere" };

            ctx.TeamsWorkers.Add(new TeamWorker { Team = Frontend, Worker = Steen });
            ctx.TeamsWorkers.Add(new TeamWorker { Team = Frontend, Worker = Ejvind });
            ctx.TeamsWorkers.Add(new TeamWorker { Team = Frontend, Worker = Konrad });

            ctx.TeamsWorkers.Add(new TeamWorker { Team = Backend, Worker = Steen });
            ctx.TeamsWorkers.Add(new TeamWorker { Team = Backend, Worker = Sofus });
            ctx.TeamsWorkers.Add(new TeamWorker { Team = Backend, Worker = Remo });

            ctx.TeamsWorkers.Add(new TeamWorker { Team = Testere, Worker = Ella });
            ctx.TeamsWorkers.Add(new TeamWorker { Team = Testere, Worker = Anne });
            ctx.TeamsWorkers.Add(new TeamWorker { Team = Testere, Worker = Sofus });

        }
        db.SaveChanges();
    }
    static void seedTasks(BloggingContext db)
    {
        //add two new task with names 1-produceSoftwareTas 2-brewCoffeeTask 
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

        db.Tasks.AddRange(produceSoftwareTask, brewCoffeeTask);
        db.SaveChanges();


    }
    static void printIncompleteTasksAndTodos(BloggingContext context)
    {
        var tasks = context.Tasks
            .Include(task => task.Todos)
            .Where(task => task.Todos.Any(todo => !todo.IsComplete))
            .ToList();

        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.Name}");
            foreach (var todo in task.Todos)
            {
                Console.WriteLine($"  Todo: {todo.Name} (Completed: {todo.IsComplete})");
            }
        }
    }




}