namespace System.Windows.Interop;

/// <summary>
/// Provides the ability to resize windows.
/// </summary>
public class HwndResizer : HwndMessenger
{
	/// <summary>
	/// System resize command.
	/// </summary>
	private const int WmSysCmd = 0x112;

	/// <inheritdoc/>
	public HwndResizer(HwndSource hwndSource) : base(hwndSource) { }

	/// <summary>
	/// Sends the resize message to the window.
	/// </summary>
	/// <param name="code">Resize direction code.</param>
	public void Resize(HwndResizeCode? code) 
		=> Send(WmSysCmd, (IntPtr)code, IntPtr.Zero);
}
