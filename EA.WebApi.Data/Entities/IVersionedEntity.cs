// IVersionedEntity.cs
// Copyright Jamie Kurtz, Brian Wortman 2014.

namespace EA.WebApi.Data.Entities
{
    public interface IVersionedEntity
    {
        byte[] Version { get; set; }
    }
}