namespace System.Windows.Input;

/// <summary>
/// Contains <see cref="Cmd"/> extension methods.
/// </summary>
public static class CmdExtensions
{
	/// <summary>
	/// Attempts to execute a <see cref="Cmd"/>.
	/// </summary>
	/// <param name="tryExecute">Argument that is possibly a <see cref="Cmd"/>.</param>
	/// <param name="parameter"><see cref="Cmd"/> execution parameter.</param>
	/// <returns><see langword="null"/> if <see cref="Cmd"/> is executed, <see cref="object"/>? if argument is not a <see cref="Cmd"/></returns>
	public static object? TryExecute(this object? tryExecute, object? parameter = null)
	{
		if (tryExecute is not Cmd cmd) return tryExecute;
		cmd.Execute(parameter);
		return null;
	}

	/// <summary>
	/// <inheritdoc cref="TryExecute"/>
	/// </summary>
	/// <remarks>Replaces an argument.</remarks>
	/// <param name="tryExecute">Argument that is possibly a <see cref="Cmd"/>.</param>
	/// <param name="toReplace">Replacement argument.</param>
	/// <param name="parameter"><see cref="Cmd"/> execution parameter.</param>
	/// <returns>Replaced argument.</returns>
	public static object? TryExecuteAndReplace(this object? tryExecute,
		object? toReplace, object? parameter = null)
	{
		if (tryExecute is Cmd cmd) cmd.Execute(parameter);
		return toReplace;
	}
}
