namespace EventVersioning;

using System;
using System.Collections.Generic;

/// <summary>
/// Represents a CloudEvent as defined by the Cloud Native Computing Foundation (CNCF).
/// This class encapsulates all the standard attributes of a CloudEvent.
/// This is Mocked up for CNCF CloudEvent SpecVersion 1.0
/// </summary>
public class CloudEvent
{
    /// <summary>
    /// Gets or sets the unique identifier of the event.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the URI that identifies the context in which the event happened.
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// Gets or sets the type of event related to the originating occurrence.
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets the version of the CloudEvents specification being used.
    /// </summary>
    public string SpecVersion { get; set; }

    /// <summary>
    /// Gets or sets the content type of the data attribute.
    /// </summary>
    public string DataContentType { get; set; }

    /// <summary>
    /// Gets or sets the URI that identifies the schema that data adheres to.
    /// </summary>
    public string DataSchema { get; set; }

    /// <summary>
    /// Gets or sets the subject of the event.
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of when the event happened.
    /// </summary>
    public DateTime? Time { get; set; }

    /// <summary>
    /// Gets or sets the event payload. This can be any kind of data.
    /// </summary>
    public object Data { get; set; }

    /// <summary>
    /// Gets the dictionary for any additional metadata not covered by the standard attributes.
    /// </summary>
    public IDictionary<string, object> Extensions { get; set; }

    /// <summary>
    /// Initializes a new instance of the CloudEvent class, setting the SpecVersion to 1.0.
    /// </summary>
    public CloudEvent()
    {
        SpecVersion = "1.0";  // Defaulting to CloudEvents spec version 1.0
        Extensions = new Dictionary<string, object>();
    }
}
