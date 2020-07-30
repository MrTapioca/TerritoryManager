Public Class ExplorerRefresh

    <System.Runtime.InteropServices.DllImport("shell32.dll")> _
    Shared Sub SHChangeNotify(ByVal wEventID As HChangeNotifyEventID, _
                              ByVal uFlags As HChangeNotifyFlags, _
                              ByVal dwItem1 As IntPtr, _
                              ByVal dwItem2 As IntPtr)
    End Sub

    <Flags()> _
       Public Enum HChangeNotifyFlags
        SHCNF_DWORD = &H3
        SHCNF_IDLIST = &H0
        SHCNF_PATHA = &H1
        SHCNF_PATHW = &H5
        SHCNF_PRINTERA = &H2
        ' SHCNF_PRINTERW = &H6
        SHCNF_FLUSH = &H1000
        SHCNF_FLUSHNOWAIT = &H2000
    End Enum

    <Flags()> _
       Public Enum HChangeNotifyEventID
        SHCNE_ALLEVENTS = &H7FFFFFFF
        SHCNE_ASSOCCHANGED = &H8000000
        SHCNE_ATTRIBUTES = &H800
        SHCNE_CREATE = &H2
        SHCNE_DELETE = &H4
        SHCNE_DRIVEADD = &H10
        SHCNE_DRIVEADDGUI = &H10000
        SHCNE_DRIVEREMOVED = &H80
        SHCNE_EXTENDED_EVENT = &H4000000
        SHCNE_FREESPACE = &H40000
        SHCNE_MEDIAINSERTED = &H20
        SHCNE_MEDIAREMOVED = &H40
        SHCNE_MKDIR = &H8
        SHCNE_NETSHARE = &H200
        SHCNE_NETUNSHARE = &H400
        SHCNE_RENAMEFOLDER = &H20000
        SHCNE_RENAMEITEM = &H1
        SHCNE_RMDIR = &H10
        SHCNE_SERVERDISCONNECT = &H4000
        SHCNE_UPDATEDIR = &H1000
        SHCNE_UPDATEIMAGE = &H8000
    End Enum

    Sub Refresh()

        SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero)

    End Sub

End Class
