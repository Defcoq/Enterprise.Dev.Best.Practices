﻿// RootObjectNotFoundException.cs
// Copyright Jamie Kurtz, Brian Wortman 2014.

using System;

namespace EA.WebApi.Data.Exceptions
{
    /// <summary>
    ///     Exception thrown when the primary, or "aggregate root", object is not found.
    /// </summary>
    [Serializable]
    public class RootObjectNotFoundException : Exception
    {
        public RootObjectNotFoundException(string message) : base(message)
        {
        }
    }
}