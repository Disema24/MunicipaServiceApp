using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipaServiceApp
{
    public class EventManager
    {
        // 1. SORTED DICTIONARY - automatically sorts events by date
        public SortedDictionary<DateTime, List<Event>> EventsByDate { get; private set; }

        // 2. HASHSET - stores unique categories (no duplicates allowed)
        public HashSet<string> Categories { get; private set; }

        // 3. SORTED SET - stores unique dates in chronological order
        public SortedSet<DateTime> UniqueDates { get; private set; }

        // 4. STACK - tracks search history (LIFO - last search on top)
        public Stack<string> SearchHistory { get; private set; }

        // 5. QUEUE - manages upcoming events in order
        public Queue<Event> UpcomingEventsQueue { get; private set; }

        // 6. DICTIONARY - tracks how many times each category was searched
        public Dictionary<string, int> SearchFrequency { get; private set; }

        // 7. PRIORITY QUEUE (simulated with sorted list) - high priority events first
        public List<Event> PriorityEvents { get; private set; }

        private int nextId = 1;

        public EventManager()
        {
            EventsByDate = new SortedDictionary<DateTime, List<Event>>();
            Categories = new HashSet<string>();
            UniqueDates = new SortedSet<DateTime>();
            SearchHistory = new Stack<string>();
            UpcomingEventsQueue = new Queue<Event>();
            SearchFrequency = new Dictionary<string, int>();
            PriorityEvents = new List<Event>();

            LoadSampleEvents();
        }

        // Add a new event to all relevant structures
        public void AddEvent(Event evt)
        {
            // Add to SortedDictionary
            if (!EventsByDate.ContainsKey(evt.EventDate))
            {
                EventsByDate[evt.EventDate] = new List<Event>();
            }
            EventsByDate[evt.EventDate].Add(evt);

            // Add to HashSet (duplicates automatically ignored)
            Categories.Add(evt.Category);

            // Add to SortedSet
            UniqueDates.Add(evt.EventDate);

            // Add to Queue (only if event is in the future)
            if (evt.EventDate >= DateTime.Today)
            {
                UpcomingEventsQueue.Enqueue(evt);
            }

            // Add to Priority list (sorted by priority, then date)
            PriorityEvents.Add(evt);
            PriorityEvents = PriorityEvents
                .OrderBy(e => e.Priority)
                .ThenBy(e => e.EventDate)
                .ToList();
        }

        // Search events by category and/or date
        public List<Event> SearchEvents(string category, DateTime? date)
        {
            List<Event> results = new List<Event>();

            // Track search history in Stack
            string searchTerm = $"Category: {category ?? "Any"}, Date: {date?.ToString("yyyy-MM-dd") ?? "Any"}";
            SearchHistory.Push(searchTerm);

            // Track search frequency for recommendations
            if (!string.IsNullOrEmpty(category))
            {
                if (SearchFrequency.ContainsKey(category))
                    SearchFrequency[category]++;
                else
                    SearchFrequency[category] = 1;
            }

            // Filter using the SortedDictionary
            foreach (var kvp in EventsByDate)
            {
                // Date filter
                if (date.HasValue && kvp.Key.Date != date.Value.Date)
                    continue;

                foreach (var evt in kvp.Value)
                {
                    // Category filter
                    if (!string.IsNullOrEmpty(category) && !evt.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                        continue;

                    results.Add(evt);
                }
            }

            return results;
        }

        // RECOMMENDATION FEATURE - suggests events based on most searched category
        public List<Event> GetRecommendations()
        {
            List<Event> recommendations = new List<Event>();

            if (SearchFrequency.Count == 0)
            {
                // No searches yet - return top 3 upcoming high-priority events
                recommendations = UpcomingEventsQueue
                    .OrderBy(e => e.Priority)
                    .ThenBy(e => e.EventDate)
                    .Take(3)
                    .ToList();
            }
            else
            {
                // Find the most frequently searched category
                string topCategory = SearchFrequency
                    .OrderByDescending(kvp => kvp.Value)
                    .First().Key;

                // Recommend events from that category
                recommendations = EventsByDate
                    .SelectMany(kvp => kvp.Value)
                    .Where(e => e.Category == topCategory && e.EventDate >= DateTime.Today)
                    .OrderBy(e => e.EventDate)
                    .Take(3)
                    .ToList();

                // If not enough recommendations, fill with other upcoming events
                if (recommendations.Count < 3)
                {
                    var extraEvents = EventsByDate
                        .SelectMany(kvp => kvp.Value)
                        .Where(e => e.EventDate >= DateTime.Today && !recommendations.Contains(e))
                        .OrderBy(e => e.EventDate)
                        .Take(3 - recommendations.Count);

                    recommendations.AddRange(extraEvents);
                }
            }

            return recommendations;
        }

        // Get the last 5 searches (from Stack)
        public List<string> GetRecentSearches()
        {
            return SearchHistory.Take(5).ToList();
        }

        // Get all upcoming events in chronological order
        public List<Event> GetUpcomingEvents()
        {
            return UpcomingEventsQueue
                .Where(e => e.EventDate >= DateTime.Today)
                .OrderBy(e => e.EventDate)
                .ToList();
        }

        // Load sample data for demonstration
        private void LoadSampleEvents()
        {
            AddEvent(new Event(nextId++, "Community Clean-Up Day", "Community", DateTime.Today.AddDays(3), "Soweto Community Hall", "Join us for a neighbourhood clean-up. Bring gloves and bags.", 1));
            AddEvent(new Event(nextId++, "Water Outage Notice", "Utilities", DateTime.Today.AddDays(1), "Extension 5", "Scheduled water maintenance from 8am to 4pm. Please store water.", 1));
            AddEvent(new Event(nextId++, "Road Closure - Main Street", "Roads", DateTime.Today.AddDays(2), "Main Street", "Road repairs will close Main Street for 3 days. Use alternative routes.", 2));
            AddEvent(new Event(nextId++, "Mobile Clinic Visit", "Health", DateTime.Today.AddDays(5), "Community Centre", "Free health check-ups and vaccinations available.", 1));
            AddEvent(new Event(nextId++, "Recycling Workshop", "Environment", DateTime.Today.AddDays(7), "Library Hall", "Learn how to recycle effectively. Free entry.", 3));
            AddEvent(new Event(nextId++, "Town Hall Meeting", "Community", DateTime.Today.AddDays(10), "Municipal Chambers", "Discuss the new budget and service delivery plans.", 1));
            AddEvent(new Event(nextId++, "Electricity Maintenance", "Utilities", DateTime.Today.AddDays(4), "Ward 12", "Power will be off from 9am to 1pm for substation repairs.", 2));
            AddEvent(new Event(nextId++, "Pothole Repair Schedule", "Roads", DateTime.Today.AddDays(6), "Various Streets", "Pothole repairs will take place across the ward.", 3));
            AddEvent(new Event(nextId++, "Library Book Sale", "Community", DateTime.Today.AddDays(8), "Public Library", "Second-hand books on sale from R5.", 3));
            AddEvent(new Event(nextId++, "Fire Safety Awareness", "Safety", DateTime.Today.AddDays(9), "Fire Station", "Free fire safety training for residents.", 2));
        }
        public int GetNextEventId()
        {
            return nextId++;
        }
    }
}