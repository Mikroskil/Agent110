Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Net.NetworkInformation

Public Class NetScanCompletedEventArgs
    Inherits EventArgs

    Private _reply As PingReply

    Public Property Reply() As PingReply
        Get
            Return _reply
        End Get
        Set(ByVal value As PingReply)
            _reply = value
        End Set
    End Property
End Class
