namespace System.Windows.Input;

/// <summary>
/// Provides a command.
/// </summary>
public class Cmd : ICommand
{
	#region ICommand

	/// <inheritdoc/>
	public bool CanExecute(object? parameter) 
		=> _canExecute == null || _canExecute(parameter);

	/// <inheritdoc/>
	public void Execute(object? parameter) 
		=> _execute(parameter);

	/// <inheritdoc/>
    public event EventHandler? CanExecuteChanged
    {
	    add => CommandManager.RequerySuggested += value;
	    remove => CommandManager.RequerySuggested -= value;
    }

	#endregion

	/// <summary>
	/// Method that determines whether the command can execute in its current state.
	/// </summary>
	private readonly Func<object?, bool>? _canExecute;
	/// <summary>
	/// Method to be called when the command is invoked.
	/// </summary>
	private readonly Action<object?> _execute;

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="execute">Method to be called when the command is invoked.</param>
	/// <param name="canExecute">Method that determines whether the command can execute in its current state.</param>
	public Cmd(Action<object?> execute, Func<object?, bool>? canExecute = null)
	{
		_execute = execute; 
		_canExecute = canExecute;
	}
}
