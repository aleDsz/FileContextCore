﻿// Copyright (c) morrisjdev. All rights reserved.
// Original copyright (c) .NET Foundation. All rights reserved.
// Modified version by morrisjdev
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FileContextCore.Metadata.Conventions
{
    /// <summary>
    ///     <para>
    ///         A builder for building conventions for th in-memory provider.
    ///     </para>
    ///     <para>
    ///         The service lifetime is <see cref="ServiceLifetime.Scoped"/> and multiple registrations
    ///         are allowed. This means that each <see cref="DbContext"/> instance will use its own
    ///         set of instances of this service.
    ///         The implementations may depend on other services registered with any lifetime.
    ///         The implementations do not need to be thread-safe.
    ///     </para>
    /// </summary>
    public class FileContextConventionSetBuilder : ProviderConventionSetBuilder
    {
        /// <summary>
        ///     Creates a new <see cref="FileContextConventionSetBuilder"/> instance.
        /// </summary>
        /// <param name="dependencies"> The core dependencies for this service. </param>
        public FileContextConventionSetBuilder(
            [NotNull] ProviderConventionSetBuilderDependencies dependencies)
            : base(dependencies)
        {
        }

        /// <summary>
        ///     <para>
        ///         Call this method to build a <see cref="ConventionSet"/> for the in-memory provider when using
        ///         the <see cref="ModelBuilder"/> outside of <see cref="DbContext.OnModelCreating"/>.
        ///     </para>
        ///     <para>
        ///         Note that it is unusual to use this method.
        ///         Consider using <see cref="DbContext"/> in the normal way instead.
        ///     </para>
        /// </summary>
        /// <returns> The convention set. </returns>
        public static ConventionSet Build()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkFileContextDatabase()
                .AddDbContext<DbContext>((p, o) =>
                    o.UseFileContextDatabase(databaseName: Guid.NewGuid().ToString())
                        .UseInternalServiceProvider(p))
                .BuildServiceProvider();

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DbContext>())
                {
                    return ConventionSet.CreateConventionSet(context);
                }
            }
        }
    }
}
