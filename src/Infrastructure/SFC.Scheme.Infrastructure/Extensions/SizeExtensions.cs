﻿namespace SFC.Scheme.Infrastructure.Extensions;
public static class SizeExtensions
{
    public static int ToByteSize(this int megabytes) => megabytes * 1024 * 1024;
}