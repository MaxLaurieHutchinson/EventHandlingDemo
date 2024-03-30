using EventVersioning;
using System;
using System.Collections.Generic;

/// <summary>
/// Represents a CloudEvent with additional data versioning capabilities.
/// Inherits from the base CloudEvent class and adds functionality
/// to manage the version of the event's data payload.
/// </summary>
public class CloudEventDataVersioning : CloudEvent
{
    private const string DataVersionKey = "dataVersion";

    /// <summary>
    /// Initializes a new instance of the CloudEventDataVersioning class
    /// with a default data version of 1.
    /// </summary>
    public CloudEventDataVersioning()
        : base()
    {
        Extensions[DataVersionKey] = 1; // Initialize with default version
    }

    /// <summary>
    /// Overrides the Extensions dictionary of CloudEvent to ensure
    /// it contains a data version key.
    /// </summary>
    public new IDictionary<string, object> Extensions
    {
        get => base.Extensions;
        set
        {
            if (value == null)
                throw new ArgumentNullException(nameof(Extensions), "Extensions cannot be null.");

            if (!value.ContainsKey(DataVersionKey))
                value[DataVersionKey] = 1;

            base.Extensions = value;
        }
    }

    /// <summary>
    /// Gets or sets the data version of the event.
    /// Throws an exception if the value is less than or equal to 0.
    /// </summary>
    public int DataVersion
    {
        get => (int)Extensions[DataVersionKey];
        set
        {
            if (value <= 0)
                throw new ArgumentException("Data version must be a positive integer.");

            Extensions[DataVersionKey] = value;
        }
    }
}
