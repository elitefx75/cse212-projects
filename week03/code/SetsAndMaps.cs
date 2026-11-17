
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Find all symmetric pairs of two-character words using sets in O(n) time.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var processed = new HashSet<string>();
        var pairs = new List<string>();

        foreach (var word in words)
        {
            string reversed = new string(word.Reverse().ToArray());

            if (word != reversed &&
                wordSet.Contains(reversed) &&
                !processed.Contains(word))
            {
                pairs.Add($"{word} & {reversed}");

                processed.Add(word);
                processed.Add(reversed);
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees earned.
    /// The degree is stored in the fourth column.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length < 4)
                continue;

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine whether two words are anagrams.
    /// Ignore spaces and letter case.
    /// Use a dictionary to count letters.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLowerInvariant();
        word2 = word2.Replace(" ", "").ToLowerInvariant();

        if (word1.Length != word2.Length)
            return false;

        var letterCounts = new Dictionary<char, int>();

        foreach (char letter in word1)
        {
            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
            else
            {
                letterCounts[letter] = 1;
            }
        }

        foreach (char letter in word2)
        {
            if (!letterCounts.ContainsKey(letter))
                return false;

            letterCounts[letter]--;

            if (letterCounts[letter] == 0)
            {
                letterCounts.Remove(letter);
            }
        }

        return letterCounts.Count == 0;
    }

    /// <summary>
    /// Retrieve today's earthquake information from the USGS website.
    /// Return earthquake locations and magnitudes as formatted strings.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var response = client.GetAsync(uri).GetAwaiter().GetResult();

        response.EnsureSuccessStatusCode();

        using var jsonStream = response.Content.ReadAsStream();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(jsonStream, options);

        var results = new List<string>();

        if (featureCollection?.Features == null)
            return results.ToArray();

        foreach (var feature in featureCollection.Features)
        {
            if (feature.Properties != null &&
                feature.Properties.Mag.HasValue &&
                !string.IsNullOrEmpty(feature.Properties.Place))
            {
                string magnitude = feature.Properties.Mag.Value.ToString(
                    System.Globalization.CultureInfo.InvariantCulture);

                results.Add(
                    $"{feature.Properties.Place} - Mag {magnitude}");
            }
        }

        return results.ToArray();
    }
}
