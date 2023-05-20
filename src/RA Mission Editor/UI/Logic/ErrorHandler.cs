using System.Windows.Forms;

namespace RA_Mission_Editor.UI.Logic
{
  public delegate ErrorResolution ErrorDelegate(string message, ErrorType type, bool hasRetry);
  public enum ErrorType { PROMPT, WARNING, FATAL }
  public enum ErrorResolution { ACK, RETRY, CANCEL }

  public static class ErrorHandler
  {
    public static ErrorResolution OnError(string message, ErrorType type, bool hasRetry)
    {
      MessageBoxButtons buttons = hasRetry ? MessageBoxButtons.RetryCancel : MessageBoxButtons.OK;
      MessageBoxIcon icon;
      switch (type)
      {
        default:
        case ErrorType.PROMPT:
          icon = MessageBoxIcon.None;
          break;
        case ErrorType.WARNING:
          icon = MessageBoxIcon.Warning;
          break;
        case ErrorType.FATAL:
          icon = MessageBoxIcon.Stop;
          break;
      }
      switch (MessageBox.Show(message, Resources.Strings.Title, buttons, icon))
      {
        default:
        case DialogResult.OK:
          return ErrorResolution.ACK;
        case DialogResult.Retry:
          return ErrorResolution.RETRY;
        case DialogResult.Cancel:
          return ErrorResolution.CANCEL;
      }
    }
  }
}
