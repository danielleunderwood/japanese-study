using Blazored.LocalStorage;
using Core;
using System.Text.Json;

namespace Persistence;

public class VerbRepository : ActivatableItemRepository<Verb>
{
	public VerbRepository(ILocalStorageService localStorage) : base(localStorage)
	{
	}

	public override Verb[] GetAll()
	{
		return JsonSerializer.Deserialize<Verb[]>(Conjugation.Verbs, new JsonSerializerOptions(JsonSerializerDefaults.Web));
	}
}
