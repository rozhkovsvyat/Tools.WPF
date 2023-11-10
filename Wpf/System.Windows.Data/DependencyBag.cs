namespace System.Windows.Data;

/// <summary>
/// Provides a set of dependency properties.
/// </summary>
public class DependencyBag : DependencyObject
{
	/// <summary>
	/// Title.
	/// </summary>
	public static readonly DependencyProperty TitleProperty =
		DependencyProperty.Register(nameof(Title), typeof(string),
			typeof(DependencyBag), new FrameworkPropertyMetadata(string.Empty,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null,
				null, false, UpdateSourceTrigger.PropertyChanged));
	/// <inheritdoc cref="TitleProperty"/>
	public string Title
	{
		get => (string)GetValue(TitleProperty);
		set => SetValue(TitleProperty, value);
	}

	/// <summary>
	/// Enable flag.
	/// </summary>
	public static readonly DependencyProperty IsEnabledProperty =
		DependencyProperty.Register(nameof(IsEnabled), typeof(bool),
			typeof(DependencyBag), new FrameworkPropertyMetadata(true,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null,
				null, false, UpdateSourceTrigger.PropertyChanged));
	/// <inheritdoc cref="IsEnabledProperty"/>
	public bool IsEnabled
	{
		get => (bool)GetValue(IsEnabledProperty);
		set => SetValue(IsEnabledProperty, value);
	}

	/// <summary>
	/// Comparison object.
	/// </summary>
	public static readonly DependencyProperty CompareWithProperty =
		DependencyProperty.Register(nameof(CompareWith), typeof(object),
			typeof(DependencyBag), new FrameworkPropertyMetadata(null,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null,
				null, false, UpdateSourceTrigger.PropertyChanged));
	/// <inheritdoc cref="CompareWithProperty"/>
	public object? CompareWith
	{
		get => GetValue(CompareWithProperty);
		set => SetValue(CompareWithProperty, value);
	}
}
