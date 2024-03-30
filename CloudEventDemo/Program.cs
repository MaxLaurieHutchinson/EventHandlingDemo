using EventVersioning;
using System;
using System.Text.Json;

namespace CloudEventDemo
{
     class Program
    {
        static void Main(string[] args)
        {
            // Instantiate and set up your CloudEvent and CloudEventDataVersioning objects

            // Create and set up a CloudEvent instance
            CloudEvent cloudEvent = new CloudEvent
            {
                Id = "event-123",
                Source = "/myapplication/events",
                Type = "com.example.someevent",
                DataContentType = "application/json",
                Data = "{\"name\":\"Test Event\"}"
            };

            // Create and set up a CloudEventDataVersioning instance
            CloudEventDataVersioning versionedEvent = new CloudEventDataVersioning
            {
                Id = "versioned-event-456",
                Source = "/myapplication/versionedevents",
                Type = "com.example.versionedevent",
                DataContentType = "application/json",
                Data = "{\"name\":\"Versioned Test Event\"}",
                DataVersion = 2
            };


            // Serialize CloudEvents to JSON
            string cloudEventJson = JsonSerializer.Serialize(cloudEvent, new JsonSerializerOptions { WriteIndented = true });
            string versionedEventJson = JsonSerializer.Serialize(versionedEvent, new JsonSerializerOptions { WriteIndented = true });

            // Calculate the path to the EventData directory
            //string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName;

            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string eventDirectory = Path.Combine(projectDirectory, "EventDemoData");

            // Ensure the EventData directory exists
            Directory.CreateDirectory(eventDirectory);

            // Create timestamped file names
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string cloudEventFileName = Path.Combine(eventDirectory, $"CloudEvent_{timestamp}.json");
            string versionedEventFileName = Path.Combine(eventDirectory, $"CloudEventDataVersioning_{timestamp}.json");

            // Write the JSON to files
            File.WriteAllText(cloudEventFileName, cloudEventJson);
            File.WriteAllText(versionedEventFileName, versionedEventJson);

            Console.WriteLine($"CloudEvent written to: {cloudEventFileName}");
            Console.WriteLine($"CloudEventDataVersioning written to: {versionedEventFileName}");

            // Keep the console window open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
