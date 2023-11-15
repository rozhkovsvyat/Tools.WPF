namespace System.Windows.Input;

/// <summary>
/// Provides the ability to store cursors and retrieve only the last cursor from the bag.
/// </summary>
public static class CursorBag
{
	/// <summary>
	/// A bag that stores cursors.
	/// </summary>
	private static readonly Dictionary<string, Dictionary<object, Cursor?>> Bag = new();

	/// <summary>
	/// Puts the cursor in the bag.
	/// </summary>
	/// <param name="cursor">Cursor to be placed.</param>
	/// <param name="cursorTag">Cursor tag.</param>
	/// <param name="bagTag">Bag tag.</param>
	public static void Put(Cursor cursor, object cursorTag, string bagTag = nameof(Cursor))
	{
		Bag.TryAdd(bagTag, new Dictionary<object, Cursor?>());
		var bag = Bag[bagTag];
		bag.TryAdd(cursorTag, cursor);
	}

	/// <summary>
	/// Attempts to retrieve the specified cursor from the bag as the last one.
	/// </summary>
	/// <param name="cursor">Cursor to retrieve the value.</param>
	/// <param name="cursorTag">Cursor tag.</param>
	/// <param name="bagTag">Bag tag.</param>
	public static bool TryRetrieve(out Cursor? cursor, object cursorTag, string bagTag = nameof(Cursor))
	{
		cursor = null;
		if (!Bag.TryGetValue(bagTag, out var bag)) return false;
		bag.TryGetValue(cursorTag, out cursor);
		bag.Remove(cursorTag);
		return bag.Keys.Count is 0;
	}
}
