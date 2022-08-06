// Modified after: https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Index.cs
// MIT licensed.

#if !NETCOREAPP3_0_OR_GREATER && !NETSTANDARD2_1_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

/// <summary>Represent a type can be used to index a collection either from the start or the end.</summary>
/// <remarks>
/// Index is used by the C# compiler to support the new index syntax.
/// <code>
/// int[] someArray = new int[5] { 1, 2, 3, 4, 5 } ;
/// int lastElement = someArray[^1]; // lastElement = 5
/// </code>
/// </remarks>
public readonly struct Index : IEquatable<Index>
{
    private readonly int _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="Index"/> struct.
    /// Construct an Index using a value and indicating if the index is from the start or from the end.
    /// </summary>
    /// <param name="value">The index value. it has to be zero or positive number.</param>
    /// <param name="fromEnd">Indicating if the index is from the start or from the end.</param>
    /// <remarks>
    /// If the Index constructed from the end, index value 1 means pointing at the last element and index value 0 means pointing at beyond last element.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Index(int value, bool fromEnd = false)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        if (fromEnd)
        {
            _value = ~value;
        }

        _value = value;
    }

    // The following private constructors mainly created for perf reason to avoid the checks
    private Index(int value)
    {
        _value = value;
    }

    /// <summary>
    /// Gets a new <see cref="Index"/> pointing at first element.
    /// </summary>
    public static Index Start => new Index(0);

    /// <summary>
    /// Gets a new <see cref="Index"/> pointing at beyond last element.
    /// </summary>
    public static Index End => new Index(~0);

    /// <summary>
    /// Gets the index value.
    /// </summary>
    public int Value
    {
        get
        {
            if (_value < 0)
            {
                return ~_value;
            }

            return _value;
        }
    }

    /// <summary>
    /// Gets a value indicating whether the index is from the start or the end.
    /// </summary>
    public bool IsFromEnd => _value < 0;

    /// <summary>
    /// Converts integer number to an Index.
    /// </summary>
    /// <param name="value">The index.</param>
    public static implicit operator Index(int value) => FromStart(value);

    /// <summary>
    /// Checks if two <see cref="Index"/> instances are equal.
    /// </summary>
    /// <param name="left">The first index.</param>
    /// <param name="right">The second index.</param>
    /// <returns><c>true</c> if the two <see cref="Index"/> instances are equal. <c>false</c> otherwise.</returns>
    public static bool operator ==(Index left, Index right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// Checks if two <see cref="Index"/> instances are unequal.
    /// </summary>
    /// <param name="left">The first index.</param>
    /// <param name="right">The second index.</param>
    /// <returns><c>true</c> if the two <see cref="Index"/> instances are unequal. <c>false</c> otherwise.</returns>
    public static bool operator !=(Index left, Index right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Create an <see cref="Index"/> from the start at the position indicated by the value.
    /// </summary>
    /// <param name="value">The index value from the start.</param>
    /// <returns>The resulting <see cref="Index"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index FromStart(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        return new Index(value);
    }

    /// <summary>
    /// Create an <see cref="Index"/> from the end at the position indicated by the value.
    /// </summary>
    /// <param name="value">The index value from the end.</param>
    /// <returns>The resulting <see cref="Index"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Index FromEnd(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value));
        }

        return new Index(~value);
    }

    /// <summary>Calculate the offset from the start using the giving collection length.</summary>
    /// <param name="length">The length of the collection that the Index will be used with. length has to be a positive value.</param>
    /// <remarks>
    /// For performance reason, we don't validate the input length parameter and the returned offset value against negative values.
    /// we don't validate either the returned offset is greater than the input length.
    /// It is expected Index will be used with collections which always have non negative length/count. If the returned offset is negative and
    /// then used to index a collection will get out of range exception which will be same affect as the validation.
    /// </remarks>
    /// <returns>The offset.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int GetOffset(int length)
    {
        int offset = _value;
        if (IsFromEnd)
        {
            offset += length + 1;
        }

        return offset;
    }

    /// <inheritdoc/>
    public override bool Equals([NotNullWhen(true)] object? value) => value is Index && _value == ((Index)value)._value;

    /// <inheritdoc/>
    public bool Equals(Index other) => _value == other._value;

    /// <inheritdoc/>
    public override int GetHashCode() => _value;

    /// <inheritdoc/>
    public override string ToString()
    {
        if (IsFromEnd)
        {
            return ToStringFromEnd();
        }

        return ((uint)Value).ToString();
    }

    private string ToStringFromEnd()
    {
        return '^' + Value.ToString();
    }
}
#endif
