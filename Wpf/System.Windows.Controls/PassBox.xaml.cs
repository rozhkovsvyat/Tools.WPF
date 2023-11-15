using System.Windows.Input;
using System.Windows.Data;

namespace System.Windows.Controls;

/// <summary>
/// Provides a password control with a bindable password property.
/// </summary>
public partial class PassBox
{
	#region Password

	/// <summary>
	/// Flag to block field update from property.
	/// </summary>
	private bool _lockBack;

	/// <summary>
	/// Contents of the <see cref="PassBox"/>.
	/// </summary>
	public static readonly DependencyProperty PasswordProperty
		= DependencyProperty.Register(nameof(Password), typeof(string),
			typeof(PassBox), new FrameworkPropertyMetadata(string.Empty,
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
				PasswordPropertyChanged, null, false, 
				UpdateSourceTrigger.PropertyChanged));
	/// <inheritdoc cref="PasswordProperty"/>
	public string Password
	{
		get => (string)GetValue(PasswordProperty);
		set => SetValue(PasswordProperty, value);
	}

	/// <summary>
	/// Applies a change of <see cref="PasswordProperty"/> value to <see cref="PasswordBox.Password"/>.
	/// </summary>
	private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is not PassBox { _lockBack: false } p) return;
		p.PasswordBox.Password = p.Password;
	}

	/// <summary>
	/// Responds to the <see cref="PassBox"/> input field change event.
	/// </summary>
	protected void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
	{
		_lockBack = true;
		Password = PasswordBox.Password;
		_lockBack = false;
	}

	#endregion

	#region PasswordChar

	///<summary>
	///Character to display instead of the actual password.
	///</summary>
	/// <remarks>Default Value: '*'</remarks>
	public static readonly DependencyProperty PasswordCharProperty 
		= DependencyProperty.Register(nameof(PasswordChar), typeof(char),
			typeof(PassBox), new FrameworkPropertyMetadata('*',
				FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
				PasswordCharPropertyChanged, null, false, 
				UpdateSourceTrigger.PropertyChanged));
	/// <inheritdoc cref="PasswordProperty"/>
	public char PasswordChar
	{
		get => (char)GetValue(PasswordCharProperty);
		set => SetValue(PasswordCharProperty, value);
	}

	/// <summary>
	/// Applies a change of <see cref="PasswordCharProperty"/> value to <see cref="PasswordBox.PasswordChar"/>.
	/// </summary>
	private static void PasswordCharPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is not PassBox p) return;
		p.PasswordBox.PasswordChar = p.PasswordChar;
	}

	#endregion

	#region MaxLength

	/// <summary>
	/// Maximum number of characters the <see cref="PassBox"/> can accept.
	/// </summary>
	public static readonly DependencyProperty MaxLengthProperty
		= DependencyProperty.Register(nameof(MaxLength), typeof(int),
			typeof(PassBox), new UIPropertyMetadata((int)uint.MinValue, MaxLengthPropertyChanged));
	/// <inheritdoc cref="MaxLengthProperty"/>
	public int MaxLength
	{
		get => (int)GetValue(MaxLengthProperty);
		set => SetValue(MaxLengthProperty, value);
	}

	/// <summary>
	/// Applies a change of <see cref="MaxLengthProperty"/> value to <see cref="Controls.PasswordBox.MaxLengthProperty"/>.
	/// </summary>
	private static void MaxLengthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is not PassBox p) return;
		p.PasswordBox.MaxLength = p.MaxLength;
	}

	#endregion

	#region ScrollViewer

	/// <summary>
	/// The <see cref="ScrollViewer"/> attached to the current <see cref="PassBox"/>.
	/// </summary>
	public static readonly DependencyProperty ScrollViewerProperty =
		DependencyProperty.RegisterAttached(nameof(ScrollViewer), typeof(ScrollViewer),
			typeof(PassBox), new UIPropertyMetadata(default, ScrollViewerPropertyChanged));
	/// <inheritdoc cref="ScrollViewerProperty"/>
	public ScrollViewer ScrollViewer
	{
		get => (ScrollViewer)GetValue(ScrollViewerProperty);
		set => SetValue(ScrollViewerProperty, value);
	}

	/// <summary>
	/// Applies a change of <see cref="ScrollViewerProperty"/>.
	/// </summary>
	private static void ScrollViewerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is not PassBox p) return;
		p.PreviewMouseWheel -= p.PasswordBox_PreviewMouseWheel;
		if (e.NewValue is ScrollViewer) p.PreviewMouseWheel += p.PasswordBox_PreviewMouseWheel;
	}

	/// <summary>
	/// Responds to the mouse wheel scroll change event.
	/// </summary>
	protected void PasswordBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
	{
		if (e.Delta != 0) 
			ScrollViewer.ScrollToVerticalOffset
				(ScrollViewer.VerticalOffset - e.Delta);

		e.Handled = true;
	}

	#endregion

	/// <summary>
	/// Empty constructor.
	/// </summary>
	public PassBox() => InitializeComponent();
}
