﻿namespace DepartmentReminderSystem.Domain.Entities
{
    public class Reminder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
    }
}
