using Blazored.LocalStorage;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence;

public abstract class ActivatableItemRepository<T>
{
	private readonly ILocalStorageService _localStorage;

	protected ActivatableItemRepository(ILocalStorageService localStorage)
	{
		_localStorage = localStorage;
	}

	private static string StorageKey => typeof(T).Name;

	public async Task<T[]> GetActive()
	{
		var items = await _localStorage.GetItemAsync<T[]>(StorageKey);
		if (items is null)
		{
			items = GetAll();
			await _localStorage.SetItemAsync(StorageKey, items);
		}

		return items;
	}

	public abstract T[] GetAll();

	public async Task ToggleIsActive(T item)
	{
		var activeItems = new HashSet<T>(await GetActive());
		if (!activeItems.Remove(item))
		{
			activeItems.Add(item);
		}
		await _localStorage.SetItemAsync(StorageKey, activeItems.ToArray());
	}
}
