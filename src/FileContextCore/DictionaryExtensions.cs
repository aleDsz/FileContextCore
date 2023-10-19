// Copyright (c) morrisjdev. All rights reserved.
// Original copyright (c) .NET Foundation. All rights reserved.
// Modified version by morrisjdev
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace FileContextCore.Utilities
{
    [DebuggerStepThrough]
    internal static class DictionaryExtensions
    {
        public static TValue GetOrAddNew<TKey, TValue>(
            [NotNull] this IDictionary<TKey, TValue> source,
            [NotNull] TKey key)
            where TValue : new()
        {
            if (!source.TryGetValue(key, out var value))
            {
                value = new TValue();
                source.Add(key, value);
            }

            return value;
        }

        public static TValue Find<TKey, TValue>(
            [NotNull] this IReadOnlyDictionary<TKey, TValue> source,
            [NotNull] TKey key)
            => !source.TryGetValue(key, out var value) ? default : value;
    }
}
