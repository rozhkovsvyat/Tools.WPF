namespace System.Windows;

/// <summary>
/// Provides the data binding proxy.	
/// </summary>
public class BindingProxy : Freezable
{
	#region Freezable

	/// <summary>
	/// Creates an instance of itself as <see cref="Freezable"/>.
	/// </summary>
	/// <returns><see cref="BindingProxy"/> instance as <see cref="Freezable"/>.</returns>
	protected override Freezable CreateInstanceCore() => new BindingProxy();

	#endregion

	/// <summary>
	/// Data.
	/// </summary>
	public static readonly DependencyProperty DataProperty =
		DependencyProperty.Register(nameof(Data), typeof(object), 
			typeof(BindingProxy), new PropertyMetadata(null));
	/// <inheritdoc cref="DataProperty"/>
	public object Data
	{
		get => GetValue(DataProperty);
		set => SetValue(DataProperty, value);
	}
}
