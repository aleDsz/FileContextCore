// Copyright (c) morrisjdev. All rights reserved.
// Original copyright (c) .NET Foundation. All rights reserved.
// Modified version by morrisjdev
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FileContextCore.Utilities
{
    internal static class DisposableExtensions
    {
        public static ValueTask DisposeAsyncIfAvailable([CanBeNull] this IDisposable disposable)
        {
            if (disposable != null)
            {
                if (disposable is IAsyncDisposable asyncDisposable)
                {
                    return asyncDisposable.DisposeAsync();
                }

                disposable.Dispose();
            }

            return default;
        }
    }
}
