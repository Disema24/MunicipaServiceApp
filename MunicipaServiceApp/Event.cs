using System;

namespace MunicipaServiceApp
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; } // 1 = High, 2 = Medium, 3 = Low

        public Event(int id, string title, string category, DateTime eventDate, string location, string description, int priority)
        {
            Id = id;
            Title = title;
            Category = category;
            EventDate = eventDate;
            Location = location;
            Description = description;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{EventDate:yyyy-MM-dd} | [{Category}] {Title} - {Location}";
        }
    }
}