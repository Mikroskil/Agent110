Imports System.Collections.Generic
Imports System.Text
Imports System.Net

Public Class PingRange
    Private _startRange As IPAddress
    Public Property StartRange() As IPAddress
        Get
            Return _startRange
        End Get

        Set(ByVal value As IPAddress)
            _startRange = value
        End Set
    End Property

    Private _endRange As IPAddress
    Public Property EndRange() As IPAddress

            get

            Return _endRange
        End Get

        Set(ByVal value As IPAddress)

            _endRange = value
        End Set
    End Property

    Public Sub New(ByVal startRange As IPAddress, ByVal endRange As IPAddress)
        _startRange = startRange
        _endRange = endRange
    End Sub

    Public Sub New(ByVal startRange As Long, ByVal endRange As Long)
        _startRange = New IPAddress(startRange)
        _endRange = New IPAddress(endRange)
    End Sub
End Class
