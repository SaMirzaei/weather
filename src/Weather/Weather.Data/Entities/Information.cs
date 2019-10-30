namespace Weather.Data.Entities
{
    using System;

    public class Information
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Json { get; set; }
    }
}
