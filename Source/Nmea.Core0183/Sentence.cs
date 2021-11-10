using System;
using System.Collections.Generic;

namespace Nmea.Core0183;

/// <summary>
///     Class Sentence
/// </summary>
/// <remarks>
///     max sentence length is 82 characters
///     start with '$'
///     terminator is '\r''\n'
///     all fields separated by ','
///     checksum delimiter is '*'
///     checksum in hex
/// </remarks>
public class Sentence
{

    private readonly string[] _parts;

    public Sentence(string[] parts) {
        if (parts == null) {
            throw new ArgumentNullException("parts");
        }
        _parts = parts;
    }

    public string Id {
        get { return _parts[0]; }
    }

    public string[] Parts {
        get { return _parts; }
    }

    public override string ToString() {
        return ToString(true);
    }

    public string ToString(bool includeChecksum) {
        return string.Format("{0}{1}{2}{3}",
                             string.Join(",", _parts),
                             includeChecksum ? "*" : null,
                             includeChecksum ? CalculateChecksum(_parts).ToString("X2") : null,
                             Terminator);
    }

    public const string Terminator = "\r\n";

    /// <summary>
    ///     Parses the specified raw line into a sentence and verifies the checksum.
    /// </summary>
    /// <param name="raw">The raw.</param>
    /// <returns>Sentence.</returns>
    public static Sentence Parse(string raw) {
        if (raw == null) {
            throw new ArgumentNullException(nameof(raw));
        }
        if (raw.Length == 0 || raw[0] != '$') {
            return null;
        }
        raw = raw.TrimEnd('\r', '\n');
        // peel and validate checksum
        int checksumStart = raw.IndexOf('*');
        if (checksumStart > 0) {
            string checksumString = raw.Substring(checksumStart + 1);
            raw = raw.Substring(0, checksumStart);
            byte checksum = CalculateChecksum(raw);
            if (checksum.ToString("X2") != checksumString) {
                return null;
            }
        }
        string[] parts = raw.Split(',');
        return new Sentence(parts);
    }

    /// <summary>
    ///     Parses the specified raw lines into sentences and verifies the checksums.
    /// </summary>
    /// <param name="raw">The raw.</param>
    /// <returns>IEnumerable{Sentence}.</returns>
    public static IEnumerable<Sentence> ParseAll(string raw) {
        string[] lines = raw.Split(new[] { Terminator }, StringSplitOptions.RemoveEmptyEntries);
        var result = new List<Sentence>();
        foreach (string line in lines) {
            Sentence sentence = Parse(line);
            if (sentence != null) {
                result.Add(sentence);
            }
        }
        return result;
    }

    internal static byte CalculateChecksum(string sentence) {
        byte result = 0;
        for (int i = 1; i < sentence.Length; i++) {
            result ^= (byte)sentence[i];
        }
        return result;
    }

    internal static byte CalculateChecksum(string[] parts) {
        string sentence = string.Join(",", parts);
        return CalculateChecksum(sentence);
    }

}