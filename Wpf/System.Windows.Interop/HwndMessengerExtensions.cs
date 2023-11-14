using System.Windows.Media;

namespace System.Windows.Interop;

/// <summary>
/// Contains <see cref="HwndSource"/> extension methods.
/// </summary>
public static class HwndMessengerExtensions
{
	/// <summary>
	/// Casts an <see cref="object"/> to <see cref="HwndSource"/>.
	/// </summary>
	/// <param name="o">Current <see cref="object"/>.</param>
	/// <returns>Result as <see cref="HwndSource"/></returns>
	/// <exception cref="InvalidOperationException"></exception>
	public static HwndSource ToHwnd(this object? o) 
		=> PresentationSource.FromVisual((Visual)o!) as HwndSource ?? 
		   throw new InvalidOperationException($"{nameof(HwndSource)} casting failed.");
}

/// <summary>
/// Resize direction codes.
/// </summary>
public enum HwndResizeCode
{
	/// <summary>
	/// Left
	/// </summary>
	Left = 61441,
	/// <summary>
	/// Right
	/// </summary>
	Right = 61442,
	/// <summary>
	/// Top
	/// </summary>
	Top = 61443,
	/// <summary>
	/// TopLeft
	/// </summary>
	TopLeft = 61444,
	/// <summary>
	/// TopRight
	/// </summary>
	TopRight = 61445,
	/// <summary>
	/// Bottom
	/// </summary>
	Bottom = 61446,
	/// <summary>
	/// BottomLeft
	/// </summary>
	BottomLeft = 61447,
	/// <summary>
	/// BottomRight
	/// </summary>
	BottomRight = 61448
}
