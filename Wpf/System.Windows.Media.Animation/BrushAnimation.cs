using System.Windows.Controls;

namespace System.Windows.Media.Animation;

/// <summary>
/// Provides the ability to animate brushes.
/// </summary>
public class BrushAnimation : AnimationTimeline
{
	#region AnimationTimeline

	/// <summary>
	/// Creates an instance of itself as <see cref="Freezable"/>.
	/// </summary>
	/// <returns><see cref="BrushAnimation"/> instance as <see cref="Freezable"/>.</returns>
	protected override Freezable CreateInstanceCore() => new BrushAnimation();

	/// <summary>
	/// Target property type.
	/// </summary>
	public override Type TargetPropertyType => typeof(Brush);

	/// <summary>
	/// Returns the current value.
	/// </summary>
	/// <param name="defaultOriginValue">Default start value.</param>
	/// <param name="defaultDestinationValue">Default end value.</param>
	/// <param name="animationClock">Current animation clock.</param>
	/// <returns>Current value.</returns>
	public override object GetCurrentValue(object defaultOriginValue, 
		object defaultDestinationValue, AnimationClock animationClock) 
		=> !animationClock.CurrentProgress.HasValue ? Brushes.Transparent 
			: animationClock.CurrentProgress.Value switch 
			{
				1 => To,
				0 => From,
				_ => new VisualBrush(new Border
				{
					Child = new Border 
					{
						Opacity = animationClock.CurrentProgress.Value,
						Background = To
					},
					Background = From,
					Height = 1,
					Width = 1
				})
			};

	#endregion

	/// <summary>
	/// Start value.
	/// </summary>
	public static readonly DependencyProperty
		FromProperty = DependencyProperty.Register(nameof(From),
			typeof(Brush), typeof(BrushAnimation));
	/// <inheritdoc cref="FromProperty"/>
	public Brush From
	{
		get => (Brush)GetValue(FromProperty);
		set => SetValue(FromProperty, value);
	}
	/// <summary>
	/// End value.
	/// </summary>
	public static readonly DependencyProperty
		ToProperty = DependencyProperty.Register(nameof(To),
			typeof(Brush), typeof(BrushAnimation));
	/// <inheritdoc cref="ToProperty"/>
	public Brush To
	{
		get => (Brush)GetValue(ToProperty);
		set => SetValue(ToProperty, value);
	}
}
