// Status.cs
// Copyright Jamie Kurtz, Brian Wortman 2014.

namespace  EA.WebApi.Model
{
    public class Status
    {
        public long StatusId { get; set; }
        public string Name { get; set; }
        public int Ordinal { get; set; }
    }
}