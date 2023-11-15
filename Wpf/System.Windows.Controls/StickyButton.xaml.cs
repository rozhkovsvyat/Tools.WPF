using System.Windows.Media;
using System.Windows.Data;

namespace System.Windows.Controls;

/// <summary>
/// Provides a button with sticky behavior properties.
/// </summary>
public partial class StickyButton
{
	#region IsSticked

	/// <summary>
	/// A property indicating if this button is sticked or not.
	/// </summary>
	public static readonly DependencyProperty IsStickedProperty =
		DependencyProperty.Register(nameof(IsSticked), typeof(bool),
			typeof(StickyButton), new FrameworkPropertyMetadata(false,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null,
				null, false, UpdateSourceTrigger.PropertyChanged));
	/// <inheritdoc cref="IsStickedProperty"/>
	public bool IsSticked
	{
		get => (bool)GetValue(IsStickedProperty);
		set => SetValue(IsStickedProperty, value);
	}

	#endregion

	#region IsTextCollapsed

	/// <summary>
	/// A property indicating if this button text collapsed or not.
	/// </summary>
	public static readonly DependencyProperty IsTextCollapsedProperty =
		DependencyProperty.Register(nameof(IsTextCollapsed), typeof(bool),
			typeof(StickyButton), new FrameworkPropertyMetadata(true));
	/// <inheritdoc cref="IsTextCollapsedProperty"/>
	public bool IsTextCollapsed
	{
		get => (bool)GetValue(IsTextCollapsedProperty);
		set => SetValue(IsTextCollapsedProperty, value);
	}

	#endregion

	#region StickyBrushes

	/// <summary>
	/// A property representing the sticky background brush of this button.
	/// </summary>
	public static readonly DependencyProperty StickyBackgroundProperty =
		DependencyProperty.Register(nameof(StickyBackground), typeof(Brush),
			typeof(StickyButton), new FrameworkPropertyMetadata(Brushes.White,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null,
				null, false, UpdateSourceTrigger.PropertyChanged));
	/// <inheritdoc cref="StickyBackgroundProperty"/>
	public Brush StickyBackground
	{
		get => (Brush)GetValue(StickyBackgroundProperty);
		set => SetValue(StickyBackgroundProperty, value);
	}

	/// <summary>
	/// A property representing the sticky foreground brush of this button.
	/// </summary>
	public static readonly DependencyProperty StickyForegroundProperty =
		DependencyProperty.Register(nameof(StickyForeground), typeof(Brush),
			typeof(StickyButton), new FrameworkPropertyMetadata(Brushes.Black,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null,
				null, false, UpdateSourceTrigger.PropertyChanged));
	/// <inheritdoc cref="StickyForegroundProperty"/>
	public Brush StickyForeground
	{
		get => (Brush)GetValue(StickyForegroundProperty);
		set => SetValue(StickyForegroundProperty, value);
	}

	#endregion

	/// <summary>
	/// Пустой конструктор
	/// </summary>
	public StickyButton() => InitializeComponent();
}
