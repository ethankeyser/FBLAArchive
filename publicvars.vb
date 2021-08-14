Imports System.Timers

Module publicvars
    'Contains the variables that are needed globally throughout the program
    Public counter As Integer
    Public rng As Integer
    Public Q1 As Integer
    Public Q2 As Integer
    Public Q3 As Integer
    Public Q4 As Integer
    Public Q5 As Integer
    Public correct1 As Boolean
    Public correct2 As Boolean
    Public correct3 As Boolean
    Public correct4 As Boolean
    Public correct5 As Boolean
    Public rightans1 As Integer
    Public rightans2 As Integer
    Public rightans3 As Integer
    Public rightans4 As Integer
    Public warningMessage As Boolean = True
    Public identify As Integer
    Public score As Integer
    Public IDfield As Integer
    Public now As DateTime
    Public diff As TimeSpan
    Public StopWatch As Timer = New Timer(1000)
    Public IsPaused As Boolean = False
    Public PauseCount As Integer = 0
    Public PausedTime As TimeSpan
    Public PauseTime As Timer = New Timer(1000)
    Public now2 As DateTime
    Public diff2 As TimeSpan
    Public AccumulatedPauseTime
    Public IsResume As Boolean
    Public PulledTime As String
End Module
