﻿using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Submarine.Core.Test
{
	[ExcludeFromCodeCoverage]
	public class XunitLogger<T> : ILogger<T>, IDisposable
	{
		private readonly ITestOutputHelper _output;

		public XunitLogger(ITestOutputHelper output)
		{
			_output = output;
		}
		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			_output.WriteLine(state.ToString());
		}
		
		public bool IsEnabled(LogLevel logLevel)
		{
			return true;
		}

		public IDisposable BeginScope<TState>(TState state)
		{
			return this;
		}

		public void Dispose()
		{
		}
	}
}
