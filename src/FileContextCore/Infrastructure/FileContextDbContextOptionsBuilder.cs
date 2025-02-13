// Copyright (c) morrisjdev. All rights reserved.
// Original copyright (c) .NET Foundation. All rights reserved.
// Modified version by morrisjdev
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel;

using FileContextCore.Utilities;

using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore;

namespace FileContextCore.Infrastructure;

/// <summary>
///     <para>
///         Allows in-memory specific configuration to be performed on <see cref="DbContextOptions" />.
///     </para>
///     <para>
///         Instances of this class are returned from a call to
///         <see
///             cref="FileContextDbContextOptionsExtensions.UseFileContextDatabase(DbContextOptionsBuilder, string, System.Action{FileContextDbContextOptionsBuilder})" />
///         and it is not designed to be directly constructed in your application code.
///     </para>
/// </summary>
public class FileContextDbContextOptionsBuilder
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="FileContextDbContextOptionsBuilder" /> class.
    /// </summary>
    /// <param name="optionsBuilder"> The options builder. </param>
    public FileContextDbContextOptionsBuilder([NotNull] DbContextOptionsBuilder optionsBuilder)
    {
        Check.NotNull(optionsBuilder, nameof(optionsBuilder));

        OptionsBuilder = optionsBuilder;
    }

    /// <summary>
    ///     Clones the configuration in this builder.
    /// </summary>
    /// <returns> The cloned configuration. </returns>
    protected virtual DbContextOptionsBuilder OptionsBuilder { get; }

    #region Hidden System.Object members

    /// <summary>
    ///     Returns a string that represents the current object.
    /// </summary>
    /// <returns> A string that represents the current object. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => base.ToString();

    /// <summary>
    ///     Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj"> The object to compare with the current object. </param>
    /// <returns> true if the specified object is equal to the current object; otherwise, false. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj) => base.Equals(obj);

    /// <summary>
    ///     Serves as the default hash function.
    /// </summary>
    /// <returns> A hash code for the current object. </returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => base.GetHashCode();

    #endregion
}
