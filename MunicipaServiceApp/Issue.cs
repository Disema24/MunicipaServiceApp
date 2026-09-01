using System;

namespace MunicipalServiceApp
{
    public class Issue
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachmentPath { get; set; }
        public DateTime SubmittedAt { get; set; }

        public Issue(int id, string location, string category, string description, string attachmentPath)
        {
            Id = id;
            Location = location;
            Category = category;
            Description = description;
            AttachmentPath = attachmentPath;
            SubmittedAt = DateTime.Now;
        }

        public override string ToString()
        {
            return $"#{Id} - {Category} at {Location} ({SubmittedAt:yyyy-MM-dd HH:mm})";
        }
    }
}