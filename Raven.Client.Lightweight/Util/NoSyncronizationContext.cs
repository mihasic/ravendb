﻿// -----------------------------------------------------------------------
//  <copyright file="SafeSyncronizationContext.cs" company="Hibernating Rhinos LTD">
//      Copyright (c) Hibernating Rhinos LTD. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------
using System;
using System.Threading;
using Raven.Abstractions.Extensions;

namespace Raven.Client.Util
{
	public static class NoSyncronizationContext
	{
		 public static IDisposable Scope()
		 {
#if !SILVERLIGHT
			 var old = SynchronizationContext.Current;
			 SynchronizationContext.SetSynchronizationContext(null);
			 return new DisposableAction(() => SynchronizationContext.SetSynchronizationContext(old));
#else
			 return null;
#endif
		 }
	}
}