// Copyright (c) morrisjdev. All rights reserved.
// Original copyright (c) .NET Foundation. All rights reserved.
// Modified version by morrisjdev
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using FileContextCore.Utilities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Utilities;
using Microsoft.Extensions.DependencyInjection;

namespace FileContextCore.Storage.Internal
{
    /// <summary>
    ///     <para>
    ///         This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///         the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///         any release. You should only use it directly in your code with extreme caution and knowing that
    ///         doing so can result in application failures when updating to a new Entity Framework Core release.
    ///     </para>
    ///     <para>
    ///         The service lifetime is <see cref="ServiceLifetime.Scoped"/>. This means that each
    ///         <see cref="DbContext"/> instance will use its own instance of this service.
    ///         The implementation may depend on other services registered with any lifetime.
    ///         The implementation does not need to be thread-safe.
    ///     </para>
    /// </summary>
    public class FileContextDatabaseCreator : IDatabaseCreator
    {
        private readonly IDatabase _database;

    
        public FileContextDatabaseCreator([NotNull] IDatabase database)
        {
            Check.NotNull(database, nameof(database));

            _database = database;
        }

    
        protected virtual IFileContextDatabase Database => (IFileContextDatabase)_database;

    
        public virtual bool EnsureDeleted()
            => Database.Store.Clear();

    
        public virtual Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(EnsureDeleted());

    
        public virtual bool EnsureCreated() => Database.EnsureDatabaseCreated();

    
        public virtual Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(Database.EnsureDatabaseCreated());

    
        public virtual bool CanConnect()
            => true;

    
        public virtual Task<bool> CanConnectAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(true);
    }
}
