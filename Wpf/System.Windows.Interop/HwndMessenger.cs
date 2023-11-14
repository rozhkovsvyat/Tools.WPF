using System.Runtime.InteropServices;

namespace System.Windows.Interop;

/// <summary>
/// Provides the ability to send messages to windows.
/// </summary>
public class HwndMessenger
{
	/// <summary>
	/// Sends the specified message to the window.
	/// </summary>
	/// <param name="hWnd">Window handle.</param>
	/// <param name="msg">Message.</param>
	/// <param name="wParam">Parameter.</param>
	/// <param name="lParam">Parameter.</param>
	/// <returns>Message processing result.</returns>
	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr SendMessage
		(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

	/// <summary>
	/// <inheritdoc cref="SendMessage"/> 
	/// </summary>
	/// <param name="hwndSource">Window handle.</param>
	/// <param name="msg">Message.</param>
	/// <param name="wParam">Parameter.</param>
	/// <param name="lParam">Parameter.</param>
	public static void Send(HwndSource hwndSource, uint msg, IntPtr wParam, IntPtr lParam)
		=> SendMessage(hwndSource.Handle, msg, wParam, lParam);

	/// <summary>
	/// Window handle.
	/// </summary>
	private HwndSource _hwndSource;

	/// <summary>
	/// Constructor.
	/// </summary>
	/// <param name="hwndSource">Window handle.</param>
	public HwndMessenger(HwndSource hwndSource) 
		=> _hwndSource = hwndSource;

	/// <summary>
	/// Sets the window handle.
	/// </summary>
	/// <param name="hwndSource">Window handle.</param>
	/// <returns>This <see cref="HwndMessenger"/>.</returns>
	public HwndMessenger Set(HwndSource hwndSource)
	{
		_hwndSource = hwndSource;
		return this;
	}

	/// <summary>
	/// <inheritdoc cref="SendMessage"/> 
	/// </summary>
	/// <param name="msg">Message.</param>
	/// <param name="wParam">Parameter.</param>
	/// <param name="lParam">Parameter.</param>
	public void Send(uint msg, IntPtr wParam, IntPtr lParam)
		=> SendMessage(_hwndSource.Handle, msg, wParam, lParam);
}
