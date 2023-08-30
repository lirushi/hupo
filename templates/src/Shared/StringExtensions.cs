using System.Diagnostics.CodeAnalysis;

namespace System;

public static class StringExtensions
{
    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? s)
    {
        return string.IsNullOrEmpty(s);
    }

    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? s)
    {
        return string.IsNullOrWhiteSpace(s);
    }
}
