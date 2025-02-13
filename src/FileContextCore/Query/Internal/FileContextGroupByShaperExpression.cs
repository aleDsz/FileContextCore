﻿// Copyright (c) morrisjdev. All rights reserved.
// Original copyright (c) .NET Foundation. All rights reserved.
// Modified version by morrisjdev
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore.Query;

namespace FileContextCore.Query.Internal;

public class FileContextGroupByShaperExpression : GroupByShaperExpression
{
    public FileContextGroupByShaperExpression(
        Expression keySelector,
        Expression elementSelector,
        ParameterExpression groupingParameter,
        ParameterExpression valueBufferParameter)
        : base(keySelector, elementSelector)
    {
        GroupingParameter = groupingParameter;
        ValueBufferParameter = valueBufferParameter;
    }

    public virtual ParameterExpression GroupingParameter { get; }
    public virtual ParameterExpression ValueBufferParameter { get; }
}
