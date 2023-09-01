Imports System.Runtime.InteropServices

Friend Module NativeMethods

    ''' <summary>
    ''' Windows API function to animate a window.
    ''' </summary>
    <DllImport("user32")>
    Friend Function AnimateWindow(ByVal hWnd As IntPtr, ByVal dwTime As Integer, ByVal dwFlags As Integer) As Boolean
    End Function

    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Friend Function CreateRoundRectRgn(ByVal nLeftRect As Integer, ByVal nTopRect As Integer, ByVal nRightRect As Integer, ByVal nBottomRect As Integer, ByVal nWidthEllipse As Integer, ByVal nHeightEllipse As Integer) As IntPtr ' x-coordinate of upper-left corner
        ' y-coordinate of upper-left corner
        ' x-coordinate of lower-right corner
        ' y-coordinate of lower-right corner
        ' width of ellipse
        ' height of ellipse
    End Function

    ''' <summary>
    ''' Gets the handle of the window that currently has focus.
    ''' </summary>
    ''' <returns>
    ''' The handle of the window that currently has focus.
    ''' </returns>
    <DllImport("user32")>
    Friend Function GetForegroundWindow() As IntPtr
    End Function

    ''' <summary>
    ''' Activates the specified window.
    ''' </summary>
    ''' <param name="hWnd">
    ''' The handle of the window to be focused.
    ''' </param>>
    ''' <returns>
    ''' True if the window was focused; False otherwise.
    ''' </returns>
    <DllImport("user32")>
    Friend Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

End Module