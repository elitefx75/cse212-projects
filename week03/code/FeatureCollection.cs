
using System.Collections.Generic;

/// <summary>
/// Represents the complete earthquake JSON data received from USGS.
/// </summary>
public class FeatureCollection
{
    public string Type { get; set; } = "";

    public List<Feature> Features { get; set; } = new List<Feature>();
}

/// <summary>
/// Represents an individual earthquake record.
/// </summary>
public class Feature
{
    public FeatureProperties Properties { get; set; } = new FeatureProperties();
}

/// <summary>
/// Contains the earthquake location and magnitude.
/// </summary>
public class FeatureProperties
{
    public double? Mag { get; set; }

    public string Place { get; set; } = "";
}
