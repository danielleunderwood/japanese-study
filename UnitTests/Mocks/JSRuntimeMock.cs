using Microsoft.JSInterop;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Mocks;

public class JSRuntimeMock : IJSRuntime
{
	public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object[] args)
	{
		throw new NotImplementedException();
	}

	public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object[] args)
	{
		throw new NotImplementedException();
	}
}
