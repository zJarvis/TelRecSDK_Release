using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpDemo
{
    public class TelRecInterface
    {
        /*DLL File Path*/
        const string TelRecSDK_DLL_Path = "../../../../TelRecSDK.dll";

        #region SDK
        #region Array Length
        public const int DeviceID_Length = 20;
        public const int UserNameLengthMax = 19;
        public const int KeyControlLengthMax = 10;
        public const int FileNameLengthMax = 27;
        public const int ChannelNameLengthMax = 27;
        public const int PlayBackListSize = 20;
        public const int PhoneNumLengthMax = 20;
        public const int KeyLengthMax = 20;
        public const int ExNumLengthMax = 10;
        public const int NotesLengthMax = 64;
        #endregion
        #region Data Structure
        public enum TelRecEventType
        {
            UpdateProgress = 0,
            FoundDevice,
            GotDataSize,
            GotData,
            ConnectStatusChanged,
            StorageStatusChanged,
            CloudServerStatusChanged,
            OnlineUserListChanged,
            ChannelStatusChanged,
            ChannelTalkTimeChanged,
            ChannelMonitorChanged,
            ChannelPlayBackChanged,
            ChannelRecordEnd
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct FoundDeviceInfoStruct
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = DeviceID_Length)]
            public byte[] DeviceID;
            public IntPtr Model;
            public int Channels;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Version;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] IPaddress;
            public ushort NetPort;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct StorageStatusStruct
        {
            public int Status;
            public int Capacity;
            public int Free;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct NetStatusStruct
        {
            public uint IP;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct ChannelStatusStruct
        {
            public byte PhoneStatus;
            public byte RingCount;
            public byte PlayBackEnabled;
            public byte PhoneNumLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PhoneNumLengthMax)]
            public byte[] PhoneNum;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct OnlineUserStruct
        {
            public byte UserNameLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = UserNameLengthMax)]
            public byte[] UserName;
            public uint IP;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] MAC;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] LoginTime;
            public uint SDKVersion;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct OnlineUserListStruct
        {
            public int Count;
            public IntPtr OnlineUsers;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct DateTimeStruct
        {
            public byte Year;
            public byte Month;
            public byte Day;
            public byte Hour;
            public byte Minutes;
            public byte Seconds;
            public byte Week;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct PlayBackFileName
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = FileNameLengthMax + 1)]
            public byte[] Name;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct PlayBackFilesStruct
        {
            public byte Count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PlayBackListSize)]
            public PlayBackFileName[] FileName;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct BaseSettingStruct
        {
            public byte RecordTimeMin;
            public byte RecordTimeMax;
            public byte RingEndTime;
            public byte PhoneNumLengthMin;
            public byte CircuitOutNum;
            public byte VoiceSensitivity;
            public byte SaveMissedCall;
            public byte ReserveSpace;
            public byte LoopUseStorage;
            public byte DialWaitOffHookTime;
            public byte KeyRecordStartLength;
            public byte KeyRecordEndLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyControlLengthMax)]
            public byte[] KeyRecordStart;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyControlLengthMax)]
            public byte[] KeyRecordEnd;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            byte[] Reserved;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct ReplyTimeSlotStruct
        {
            public byte Enable;
            public byte StartHour;
            public byte StartMinute;
            public byte EndHour;
            public byte EndMinute;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = FileNameLengthMax + 1)]
            public byte[] FileName;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct AutoReplyStruct
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public ReplyTimeSlotStruct[] ReplyTimeSlot;
            public byte AllDayLongReply;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = FileNameLengthMax + 1)]
            public byte[] FileName;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct ChannelSettingStruct
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public AutoReplyStruct[] AutoReply;
            public byte EnableLostWarning;
            public byte EnableAnnouncement;
            public byte SaveAnnouncementToRecord;
            public byte RecordCondition;
            public byte EnableAutoReply;
            public byte SaveAutoReplyToRecord;
            public byte AutoReplyRingCount;
            public byte LeaveWordMaxTime;
            public byte LostVoltage;
            public byte OnHookVoltage;
            public byte OffHookVoltage;
            public byte RingVoltage;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ChannelNameLengthMax + 1)]
            public byte[] ChannelName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = FileNameLengthMax + 1)]
            public byte[] AnnouncementFileName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] Reserved;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct PlayBackStartKeyStruct
        {
            public byte Enable;
            public byte KeyLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyControlLengthMax)]
            public byte[] Key;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = FileNameLengthMax + 1)]
            public byte[] FileName;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct KeyControlSettingStruct
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public PlayBackStartKeyStruct[] PlayBackStartKey;
            public byte PlayBackEndKeyLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = KeyControlLengthMax)]
            public byte[] PlayBackEndKey;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
            public byte[] Reserved;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct NetSettingStruct
        {
            public uint IP;
            public uint Mask;
            public uint Gateway;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] MAC;
            public ushort Port;
            public byte Mode;
            public byte EnableCloud;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct SMDRSettingStruct
        {
            public byte Enable;
            public byte CheckTime;
            public byte InExNumLocation;
            public byte InExNumLength;
            public byte InPhoneNumLocation;
            public byte InPhoneNumLength;
            public byte OutExNumLocation;
            public byte OutExNumLength;
            public byte OutPhoneNumLocation;
            public byte OutPhoneNumLength;
            public byte ConnectType;
            public byte BaudrateOption;
            public byte DataBitOption;
            public byte StopBitOption;
            public byte CheckBitOption;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 49)]
            public byte[] Reserved;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct UserInfoStruct
        {
            public byte UserNameLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = UserNameLengthMax)]
            public byte[] UserName;
            /*Permission*/
            public byte ManageUsersPermission;
            public byte ChangeSettingPermission;
            public byte DownloadPermission;
            public byte DeletePermission;
            public byte MonitorPermission;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] ChannelPermission;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct UserListStruct
        {
            public int Count;
            public IntPtr Users;
        }
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        struct RecordDeleteItemStruct
        {
            public byte Year;
            public byte Month;
            public byte Day;
            public byte Hour;
            public byte Minutes;
            public byte Seconds;
            public byte Channel;
            public byte HasWavFile;
            public ushort Offset;
        }
        #endregion
        #region C++ API
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate int EventCallBack(int Event, int Device, IntPtr Data, int Length);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_Init();
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_Exit();
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_CheckDeviceID(byte[] DeviceID);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_CS_SearchDevice(EventCallBack CallBack);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_CreateDevice(byte[] DeviceID);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_DeleteDevice(int Device);
        /*Set Login Parameter*/
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_SetNetAddr(int Device, byte[] IPaddress, ushort Port);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_SetUserPassword(int Device, byte[] UserName, int UserNameLength, byte[] Password);
        /*Device Info*/
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_DeviceModel(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_FirmwareVersion(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_DeviceChannels(int Device);
        /*Device Status*/
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_ConnectStatus(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_StorageStatus(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_NetStatus(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_ChannelStatus(int Device, int Channel);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_OnlineUserList(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static bool TelRecAPI_CloudServerHasConnected(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static bool TelRecAPI_SimulateOffHookIsEnabled(int Device, int Channel);
        /*Device Setting*/
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_DateTime(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_PlayBackFileList(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_BaseSetting(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_ChannelSetting(int Device, int Channel);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_KeyControlSetting(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_NetSetting(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_SMDRSetting(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr TelRecAPI_UserList(int Device);
        /*Operation*/
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_Login(int Device, bool RemoteLogin);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_Logout(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_CS_CreateHeartbeatThread(int Device, EventCallBack CallBack);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetStorageStatus(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetNetStatus(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetTime(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_SetTime(int Device, IntPtr NewDateTime);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetPlayBackFileList(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetBaseSetting(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_SetBaseSetting(int Device, IntPtr Setting);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetChannelSetting(int Device, int Channel);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_SetChannelSetting(int Device, int Channel, IntPtr Setting);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetKeyControlSetting(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_SetKeyControlSetting(int Device, IntPtr Setting);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetNetSetting(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_SetNetSetting(int Device, IntPtr Setting);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetSMDRSetting(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_SetSMDRSetting(int Device, IntPtr Setting);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetUserList(int Device);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_AddUser(int Device, IntPtr User, byte[] Password);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_EditUser(int Device, IntPtr User, byte[] Password);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_DeleteUser(int Device, IntPtr User);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_CS_UploadFile(int Device, byte[] SrcFilePath, byte[] UploadDir, byte[] UploadFileName, EventCallBack CallBack);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_CS_DownloadFile(int Device, byte[] FilePath, EventCallBack CallBack);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_RemoveFile(int Device, byte[] FilePath);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetLatestRecordTime(int Device, out int Year, out int Month, out int Day);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetEarliestRecordTime(int Device, out int Year, out int Month, out int Day);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_GetDayListFromMonthDir(int Device, int Year, int Month, byte[] Day);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_EditRecordNotes(int Device, int ItemOffset, int Year, int Month, int Day, int Channel, byte[] Notes);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_DeleteRecord(int Device, IntPtr Item);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_StartMonitor(int Device, int Channel);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_StopMonitor();
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_Dial(int Device, int Channel, byte[] PhoneNum, int PhoneNumLength);

        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_PlayerSetVolume(int Volume);
        [DllImport(TelRecSDK_DLL_Path, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        extern static int TelRecAPI_PlayerWriteData(byte[] Data);
        #endregion
        #endregion

        #region C# Interface
        #region C# Data Structure 
        #region Errno
        public enum TelRecErrno
        {
            /*Common*/
            Succeed = 0,
            NeedWaitBusy,
            OperateFailed,
            TimeOut,
            ParameterInvalid,
            MemAllocFailed,
            /*File*/
            FileNotExist = 20,
            FileOpenFailed,
            FileWriteReadFailed,
            /*Version*/
            FirmwareVersionTooLow = 40,
            SDKVersionTooLow,
            /*Device*/
            NotLogin = 100,
            UserPasswordWrong,
            UserAlreadyExist,
            UsersOverLimit,
            ChannelBusy,
        }
        #endregion
        #region Status
        public enum ConnectStatusType
        {
            NotConnected = 0,
            Connecting,
            Connected
        };
        public enum StorageStatusType
        {
            NotFound = 0,
            Normal,
            Fill
        };
        public enum PhoneStatusType
        {
            Lost,
            OnHook,
            OffHook,
            Ringing,
            Incoming,
            Outgoing,
            AutoReply,
            VoiceCtrlEnabled,
            VoiceCtrlDisabled,
        };
        public class TelRecStorageStatus
        {
            public StorageStatusType Status;
            public int Capacity;//MB
            public int Free;//MB
        }
        public class TelRecNetStatus
        {
            public string IPaddress;
        }
        public class TelRecChannelStatus
        {
            public PhoneStatusType PhoneStatus;
            public int RingCount;
            public bool PlayBackEnabled;
            public string PhoneNum;
        }
        public class TelRecOnlineUser
        {
            public string UserName;
            public string IP;
            public string MAC;
            public string LoginTime;
            public string SDKVersion;
        }
        #endregion
        #region Setting
        public enum RecordCondition
        {
            No = 0,
            Hook,
            Key,
            Voice,
            Keep
        }
        public enum NetMode
        {
            DHCP = 0,
            Static
        }
        public class TelRecDateTime
        {
            public int Year;
            public int Month;
            public int Day;
            public int Hour;
            public int Minutes;
            public int Seconds;
            public int Week;//[0 = Sunday] [1 = Monday] ... [6 = Saturday]
            public override string ToString()
            {
                return (Year + 2000) + " - " +
                        Month.ToString().PadLeft(2, '0') + " - " +
                        Day.ToString().PadLeft(2, '0') + "   " +
                        Hour.ToString().PadLeft(2, '0') + " : " +
                        Minutes.ToString().PadLeft(2, '0');
            }
        }
        public class TelRecBaseSetting
        {
            public int RecordTimeMin;
            public int RecordTimeMax;
            public int RingEndTime;
            public int PhoneNumLengthMin;
            public string CircuitOutNum;
            public int VoiceSensitivity;
            public bool SaveMissedCall;
            public int ReserveSpace;
            public bool LoopUseStorage;
            public int DialWaitOffHookTime;
            public string KeyRecordStart;
            public string KeyRecordEnd;
        }
        public class TelRecReplyTimeSlot
        {
            public bool Enable;
            public int StartHour;
            public int StartMinute;
            public int EndHour;
            public int EndMinute;
            public string FileName;
        }
        public class TelRecAutoReply
        {
            public TelRecReplyTimeSlot[] ReplyTimeSlot;
            public bool AllDayLongReply;
            public string FileName;
            public TelRecAutoReply()
            {
                ReplyTimeSlot = new TelRecReplyTimeSlot[3];
                for (int TimeSlot = 0; TimeSlot < 3; TimeSlot++)
                {
                    ReplyTimeSlot[TimeSlot] = new TelRecReplyTimeSlot();
                }
            }
        }
        public class TelRecChannelSetting
        {
            public TelRecAutoReply[] AutoReply;
            public bool EnableLostWarning;
            public bool EnableAnnouncement;
            public bool SaveAnnouncementToRecord;
            public RecordCondition RecordCondition;
            public bool EnableAutoReply;
            public bool SaveAutoReplyToRecord;
            public int AutoReplyRingCount;
            public int LeaveWordMaxTime;
            public int LostVoltage;
            public int OnHookVoltage;
            public int OffHookVoltage;
            public int RingVoltage;
            public string ChannelName;
            public string AnnouncementFileName;
            public TelRecChannelSetting()
            {
                AutoReply = new TelRecAutoReply[7];
                for (int Week = 0; Week < 7; Week++)
                {
                    AutoReply[Week] = new TelRecAutoReply();
                }
            }
        }
        public class TelRecPlayBackStartKey
        {
            public bool Enable;
            public string Key;
            public string FileName;
        }
        public class TelRecKeyControlSetting
        {
            public TelRecPlayBackStartKey[] PlayBackStartKey;
            public string PlayBackEndKey;
            public TelRecKeyControlSetting()
            {
                PlayBackStartKey = new TelRecPlayBackStartKey[10];
                for (int i = 0; i < 10; i++)
                {
                    PlayBackStartKey[i] = new TelRecPlayBackStartKey();
                }
            }
        }
        public class TelRecNetSetting
        {
            public string IP;
            public string Mask;
            public string Gateway;
            public string MAC;
            public int Port;
            public NetMode Mode;
            public bool EnableCloud;
        }
        public class TelRecSMDRSetting
        {
            public bool Enable;
            public int CheckTime;
            public int InExNumLocation;
            public int InExNumLength;
            public int InPhoneNumLocation;
            public int InPhoneNumLength;
            public int OutExNumLocation;
            public int OutExNumLength;
            public int OutPhoneNumLocation;
            public int OutPhoneNumLength;
            public int ConnectType;
            public int BaudrateOption;
            public int DataBitOption;
            public int StopBitOption;
            public int CheckBitOption;
        }
        public class TelRecUserInfo
        {
           public string UserName;
            /*Permission*/
            public bool ManageUsersPermission;
            public bool ChangeSettingPermission;
            public bool DownloadPermission;
            public bool DeletePermission;
            public bool MonitorPermission;
            public bool[] ChannelPermission;
            public TelRecUserInfo()
            {
                ChannelPermission = new bool[64];
            }
        }
        #endregion
        public class TelRecFoundDeviceInfo
        {
            public string DeviceID;
            public string Model;
            public string Version;
            public string IPaddress;
            public int NetPort;
            public int Channels;
        }
        public class TelRecRecordDeleteItem
        {
            public int Year;
            public int Month;
            public int Day;
            public int Hour;
            public int Minutes;
            public int Seconds;
            public int Channel;
            public bool HasWavFile;
            public int Offset;
        }
        #endregion
        #region C# API
        /*CallBack*/
        public delegate void FoundDeviceCallBack(TelRecFoundDeviceInfo Info, int SearchProgress);
        public delegate void DeviceEventCallBack(TelRecEventType Event, int Device, int Channel, int Arg);
        public delegate bool UploadCallBack(int Device, int Progress);
        public delegate bool DownloadCallBack(int Device, byte[] Data, int Length);
        /*API*/
        public static bool IPaddressParse(string IP, out uint Output)
        {
            uint[] valuelist = { 0, 0, 0, 0 };
            string[] strlist = IP.Split('.');
            Output = 0;
            if (strlist.Length != 4)
                return false;
            for (int i = 0; i < 4; i++)
            {
                if (!uint.TryParse(strlist[i], out valuelist[i]))
                    return false;
                if (valuelist[i] > 255)
                    return false;
            }
            Output =((valuelist[3] << 24) | (valuelist[2] << 16) | (valuelist[1] << 8) | valuelist[0]);
            return true;
        }
        public static bool MACaddressParse(string MAC, byte[] OutBytes)
        {
            string[] strlist = MAC.Split(':');
            if (strlist.Length != 6)
                return false;
            for (int i = 0; i < 6; i++)
            {
                if (!byte.TryParse(strlist[i], System.Globalization.NumberStyles.HexNumber, null, out OutBytes[i]))
                    return false;
            }
            return true;
        }
        public static string IPaddressToString(uint IP)
        {
            return ((IP) & 0xFF) + "." + ((IP >> 8) & 0xFF) + "." + ((IP >> 16) & 0xFF) + "." + ((IP >> 24) & 0xFF);
        }
        public static string MACaddressToString(byte[] MAC)
        {
            return (Convert.ToString(MAC[0], 16).PadLeft(2, '0') + ':' +
                    Convert.ToString(MAC[1], 16).PadLeft(2, '0') + ':' +
                    Convert.ToString(MAC[2], 16).PadLeft(2, '0') + ':' +
                    Convert.ToString(MAC[3], 16).PadLeft(2, '0') + ':' +
                    Convert.ToString(MAC[4], 16).PadLeft(2, '0') + ':' +
                    Convert.ToString(MAC[5], 16).PadLeft(2, '0')).ToUpper();
        }
        public static string TimeArrayToString(byte[] Time)
        {
            return Convert.ToString(Time[0] + 2000, 10).PadLeft(4, '0') + '-' +
                   Convert.ToString(Time[1], 10).PadLeft(2, '0') + '-' +
                   Convert.ToString(Time[2], 10).PadLeft(2, '0') + '-' +
                   Convert.ToString(Time[3], 10).PadLeft(2, '0') + ' ' +
                   Convert.ToString(Time[4], 10).PadLeft(2, '0') + ':' +
                   Convert.ToString(Time[5], 10).PadLeft(2, '0');
        }
        public static string TalkTimeToString(int TalkTime)
        {
            return Convert.ToString(TalkTime / 60, 10).PadLeft(2, '0') + ':' +
                   Convert.ToString(TalkTime % 60, 10).PadLeft(2, '0');
        }
        public static void Init()
        {
            TelRecAPI_Init();
        }
        public static void Exit()
        {
            TelRecAPI_Exit();
        }
        public static bool CheckDeviceID(string DeviceID)
        {
            byte[] DeviceIDBytes = Encoding.ASCII.GetBytes(DeviceID);
            if (DeviceIDBytes.Length != DeviceID_Length)
                return false;
            if (TelRecAPI_CheckDeviceID(DeviceIDBytes) == (int)TelRecErrno.Succeed)
            {
                return true;
            }
            return false;
        }
        public static void SearchDevice(FoundDeviceCallBack CallBack)
        {
            TelRecAPI_CS_SearchDevice((int Event, int Device, IntPtr Data, int Length) =>
            {
                if (Event == (int)TelRecEventType.UpdateProgress)
                {
                    //Update Search Progress
                    CallBack(null, Length);
                }
                else if (Event == (int)TelRecEventType.FoundDevice)
                {
                    FoundDeviceInfoStruct InfoStruct = (FoundDeviceInfoStruct)Marshal.PtrToStructure(Data, typeof(FoundDeviceInfoStruct));
                    TelRecFoundDeviceInfo DeviceInfo = new TelRecFoundDeviceInfo
                    {
                        DeviceID = Encoding.ASCII.GetString(InfoStruct.DeviceID, 0, DeviceID_Length),
                        Model = Marshal.PtrToStringAnsi(InfoStruct.Model),
                        Version = Encoding.ASCII.GetString(InfoStruct.Version, 0, 16).TrimEnd('\0'),
                        IPaddress = Encoding.ASCII.GetString(InfoStruct.IPaddress, 0, 16).TrimEnd('\0'),
                        NetPort = InfoStruct.NetPort,
                        Channels = InfoStruct.Channels
                    };
                    /*Found Device*/
                    CallBack(DeviceInfo, 0);
                }
                return 0;
            });
        }
        public static int CreateDevice(string DeviceID)
        {
            byte[] DeviceIDBytes = Encoding.ASCII.GetBytes(DeviceID);
            if (DeviceIDBytes.Length != DeviceID_Length)
                return 0;
            return TelRecAPI_CreateDevice(DeviceIDBytes);
        }
        public static void DeleteDevice(int Device)
        {
            if (Device == 0)
                return;
            TelRecAPI_DeleteDevice(Device);
        }
        /*Device Info*/
        public static string DeviceModel(int Device)
        {
            if (Device == 0)
                return "";
            return Marshal.PtrToStringAnsi(TelRecAPI_DeviceModel(Device));
        }
        public static string DeviceFirmwareVersion(int Device)
        {
            if (Device == 0)
                return "";
            return Marshal.PtrToStringAnsi(TelRecAPI_FirmwareVersion(Device));
        }
        public static int DeviceChannels(int Device)
        {
            if (Device == 0)
                return 0;
            return TelRecAPI_DeviceChannels(Device);
        }
        /*Device Status*/
        public static ConnectStatusType ConnectStatus(int Device)
        {
            if (Device == 0)
                return ConnectStatusType.NotConnected;
            return (ConnectStatusType)TelRecAPI_ConnectStatus(Device);
        }
        public static TelRecStorageStatus StorageStatus(int Device)
        {
            if (Device == 0)
                return null;
            StorageStatusStruct StatusStruct = (StorageStatusStruct)Marshal.PtrToStructure(TelRecAPI_StorageStatus(Device), typeof(StorageStatusStruct));
            return new TelRecStorageStatus
            {
                Status = (StorageStatusType)StatusStruct.Status,
                Capacity = StatusStruct.Capacity,
                Free = StatusStruct.Free
            };
        }
        public static TelRecNetStatus NetStatus(int Device)
        {
            if (Device == 0)
                return null;
            NetStatusStruct StatusStruct = (NetStatusStruct)Marshal.PtrToStructure(TelRecAPI_NetStatus(Device), typeof(NetStatusStruct));
            return new TelRecNetStatus
            {
                IPaddress = IPaddressToString(StatusStruct.IP)
            };
        }
        public static TelRecChannelStatus ChannelStatus(int Device, int Channel)
        {
            if (Device == 0)
                return null;
            ChannelStatusStruct StatusStruct = (ChannelStatusStruct)Marshal.PtrToStructure(TelRecAPI_ChannelStatus(Device, Channel), typeof(ChannelStatusStruct));
            return new TelRecChannelStatus
            {
                PhoneStatus = (PhoneStatusType)StatusStruct.PhoneStatus,
                RingCount = StatusStruct.RingCount,
                PlayBackEnabled = (StatusStruct.PlayBackEnabled > 0),
                PhoneNum = Encoding.ASCII.GetString(StatusStruct.PhoneNum, 0, StatusStruct.PhoneNumLength)
            };
        }
        public static List<TelRecOnlineUser> OnlineUserList(int Device)
        {
            List<TelRecOnlineUser> UserList = new List<TelRecOnlineUser>();
            OnlineUserListStruct ListStruct = (OnlineUserListStruct)Marshal.PtrToStructure(TelRecAPI_OnlineUserList(Device), typeof(OnlineUserListStruct));
            IntPtr Offset = ListStruct.OnlineUsers;
            for (int i = 0; i < ListStruct.Count; i++)
            {
                OnlineUserStruct UserStruct = (OnlineUserStruct)Marshal.PtrToStructure(Offset, typeof(OnlineUserStruct));
                UserList.Add(new TelRecOnlineUser
                {
                    UserName = Encoding.ASCII.GetString(UserStruct.UserName, 0, UserStruct.UserNameLength),
                    IP = IPaddressToString(UserStruct.IP),
                    MAC = MACaddressToString(UserStruct.MAC),
                    LoginTime = TimeArrayToString(UserStruct.LoginTime),
                    SDKVersion = IPaddressToString(UserStruct.SDKVersion),
                });
                Offset += Marshal.SizeOf(UserStruct);
            }
            return UserList;
        }
        public static bool CloudServerHasConnected(int Device)
        {
            return TelRecAPI_CloudServerHasConnected(Device);
        }
        /*Device Setting*/
        public static TelRecDateTime DateTime(int Device)
        {
            if (Device == 0)
                return null;
            DateTimeStruct TimeStruct = (DateTimeStruct)Marshal.PtrToStructure(TelRecAPI_DateTime(Device), typeof(DateTimeStruct));
            return new TelRecDateTime
            {
                Year = TimeStruct.Year,
                Month = TimeStruct.Month,
                Day = TimeStruct.Day,
                Hour = TimeStruct.Hour,
                Minutes = TimeStruct.Minutes,
                Seconds = TimeStruct.Seconds,
                Week = TimeStruct.Week
            };
        }
        public static List<string> PlayBackFiles(int Device)
        {
            List<string> Files = new List<string>();
            PlayBackFilesStruct FilesStruct = (PlayBackFilesStruct)Marshal.PtrToStructure(TelRecAPI_PlayBackFileList(Device), typeof(PlayBackFilesStruct));
            for (int i = 0; i < FilesStruct.Count; i++)
            {
                Files.Add(Encoding.UTF8.GetString(FilesStruct.FileName[i].Name, 0, FileNameLengthMax).TrimEnd('\0'));
            }
            return Files;
        }
        public static TelRecBaseSetting BaseSetting(int Device)
        {
            if (Device == 0)
                return null;
            BaseSettingStruct SettingStruct = (BaseSettingStruct)Marshal.PtrToStructure(TelRecAPI_BaseSetting(Device), typeof(BaseSettingStruct));
            return new TelRecBaseSetting
            {
                RecordTimeMin = SettingStruct.RecordTimeMin,
                RecordTimeMax = SettingStruct.RecordTimeMax,
                RingEndTime = SettingStruct.RingEndTime,
                PhoneNumLengthMin = SettingStruct.PhoneNumLengthMin,
                CircuitOutNum = Convert.ToChar(SettingStruct.CircuitOutNum).ToString().TrimEnd('\0'),
                VoiceSensitivity = SettingStruct.VoiceSensitivity,
                SaveMissedCall = (SettingStruct.SaveMissedCall > 0),
                ReserveSpace = SettingStruct.ReserveSpace,
                LoopUseStorage = (SettingStruct.LoopUseStorage > 0),
                DialWaitOffHookTime = SettingStruct.DialWaitOffHookTime,
                KeyRecordStart = Encoding.ASCII.GetString(SettingStruct.KeyRecordStart, 0, SettingStruct.KeyRecordStartLength),
                KeyRecordEnd = Encoding.ASCII.GetString(SettingStruct.KeyRecordEnd, 0, SettingStruct.KeyRecordEndLength)
            };
        }
        public static TelRecChannelSetting ChannelSetting(int Device, int Channel)
        {
            if (Device == 0)
                return null;
            ChannelSettingStruct SettingStruct = (ChannelSettingStruct)Marshal.PtrToStructure(TelRecAPI_ChannelSetting(Device, Channel), typeof(ChannelSettingStruct));
            TelRecChannelSetting Setting = new TelRecChannelSetting();
            for (int Week = 0; Week < 7; Week++)
            {
                /*TelRecAutoReply*/
                for (int TimeSolt = 0; TimeSolt < 3; TimeSolt++)
                {
                    /*TelRecReplyTimeSlot*/
                    Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].Enable = (SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].Enable > 0);
                    Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].StartHour = SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].StartHour;
                    Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].StartMinute = SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].StartMinute;
                    Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].EndHour = SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].EndHour;
                    Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].EndMinute = SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].EndMinute;
                    Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].FileName = Encoding.UTF8.GetString(SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].FileName, 0, FileNameLengthMax).TrimEnd('\0');
                }
                Setting.AutoReply[Week].AllDayLongReply = (SettingStruct.AutoReply[Week].AllDayLongReply > 0);
                Setting.AutoReply[Week].FileName = Encoding.UTF8.GetString(SettingStruct.AutoReply[Week].FileName, 0, FileNameLengthMax).TrimEnd('\0');
            }
            Setting.EnableLostWarning = (SettingStruct.EnableLostWarning > 0);
            Setting.EnableAnnouncement = (SettingStruct.EnableAnnouncement > 0);
            Setting.SaveAnnouncementToRecord = (SettingStruct.SaveAnnouncementToRecord > 0);
            Setting.RecordCondition = (RecordCondition)SettingStruct.RecordCondition;
            Setting.EnableAutoReply = (SettingStruct.EnableAutoReply > 0);
            Setting.SaveAutoReplyToRecord = (SettingStruct.SaveAutoReplyToRecord > 0);
            Setting.AutoReplyRingCount = SettingStruct.AutoReplyRingCount;
            Setting.LeaveWordMaxTime = SettingStruct.LeaveWordMaxTime;
            Setting.LostVoltage = SettingStruct.LostVoltage;
            Setting.OnHookVoltage = SettingStruct.OnHookVoltage;
            Setting.OffHookVoltage = SettingStruct.OffHookVoltage;
            Setting.RingVoltage = SettingStruct.RingVoltage;
            Setting.ChannelName = Encoding.UTF8.GetString(SettingStruct.ChannelName, 0, ChannelNameLengthMax).TrimEnd('\0');
            Setting.AnnouncementFileName = Encoding.UTF8.GetString(SettingStruct.AnnouncementFileName, 0, FileNameLengthMax).TrimEnd('\0');
            return Setting;
        }
        public static TelRecKeyControlSetting KeyControlSetting(int Device)
        {
            if (Device == 0)
                return null;
            KeyControlSettingStruct SettingStruct = (KeyControlSettingStruct)Marshal.PtrToStructure(TelRecAPI_KeyControlSetting(Device), typeof(KeyControlSettingStruct));
            TelRecKeyControlSetting Setting = new TelRecKeyControlSetting();
            for (int i = 0; i < 10; i++)
            {
                Setting.PlayBackStartKey[i].Enable = (SettingStruct.PlayBackStartKey[i].Enable > 0);
                Setting.PlayBackStartKey[i].Key = Encoding.ASCII.GetString(SettingStruct.PlayBackStartKey[i].Key, 0, SettingStruct.PlayBackStartKey[i].KeyLength);
                Setting.PlayBackStartKey[i].FileName = Encoding.ASCII.GetString(SettingStruct.PlayBackStartKey[i].FileName, 0, FileNameLengthMax).TrimEnd('\0');
            }
            Setting.PlayBackEndKey = Encoding.ASCII.GetString(SettingStruct.PlayBackEndKey, 0, SettingStruct.PlayBackEndKeyLength);
            return Setting;
        }
        public static TelRecNetSetting NetSetting(int Device)
        {
            if (Device == 0)
                return null;
            NetSettingStruct SettingStruct = (NetSettingStruct)Marshal.PtrToStructure(TelRecAPI_NetSetting(Device), typeof(NetSettingStruct));
            return new TelRecNetSetting
            {
                IP = IPaddressToString(SettingStruct.IP),
                Mask = IPaddressToString(SettingStruct.Mask),
                Gateway = IPaddressToString(SettingStruct.Gateway),
                MAC = MACaddressToString(SettingStruct.MAC),
                Port = SettingStruct.Port,
                Mode = (NetMode)SettingStruct.Mode,
                EnableCloud = (SettingStruct.EnableCloud > 0)
            };
        }
        public static TelRecSMDRSetting SMDRSetting(int Device)
        {
            if (Device == 0)
                return null;
            SMDRSettingStruct SettingStruct = (SMDRSettingStruct)Marshal.PtrToStructure(TelRecAPI_SMDRSetting(Device), typeof(SMDRSettingStruct));
            return new TelRecSMDRSetting
            {
                Enable = (SettingStruct.Enable > 0),
                CheckTime = SettingStruct.CheckTime * 100,
                InExNumLocation = SettingStruct.InExNumLocation,
                InExNumLength = SettingStruct.InExNumLength,
                InPhoneNumLocation = SettingStruct.InPhoneNumLocation,
                InPhoneNumLength = SettingStruct.InPhoneNumLength,
                OutExNumLocation = SettingStruct.OutExNumLocation,
                OutExNumLength = SettingStruct.OutExNumLength,
                OutPhoneNumLocation = SettingStruct.OutPhoneNumLocation,
                OutPhoneNumLength = SettingStruct.OutPhoneNumLength,
                ConnectType = SettingStruct.ConnectType,
                BaudrateOption = SettingStruct.BaudrateOption,
                DataBitOption = SettingStruct.DataBitOption,
                StopBitOption = SettingStruct.StopBitOption,
                CheckBitOption = SettingStruct.CheckBitOption
            };
        }
        public static List<TelRecUserInfo> UserList(int Device)
        {
            List<TelRecUserInfo> UserList = new List<TelRecUserInfo>();
            UserListStruct ListStruct = (UserListStruct)Marshal.PtrToStructure(TelRecAPI_UserList(Device), typeof(UserListStruct));
            IntPtr Offset = ListStruct.Users;
            for (int i = 0; i < ListStruct.Count; i++)
            {
                UserInfoStruct UserStruct = (UserInfoStruct)Marshal.PtrToStructure(Offset, typeof(UserInfoStruct));
                TelRecUserInfo UserInfo = new TelRecUserInfo
                {
                    UserName = Encoding.ASCII.GetString(UserStruct.UserName, 0, UserStruct.UserNameLength),
                    ManageUsersPermission = (UserStruct.ManageUsersPermission > 0),
                    ChangeSettingPermission = (UserStruct.ChangeSettingPermission > 0),
                    DownloadPermission = (UserStruct.DownloadPermission > 0),
                    DeletePermission = (UserStruct.DeletePermission > 0),
                    MonitorPermission = (UserStruct.MonitorPermission > 0),
                };
                for (int Channel = 0; Channel < 64; Channel++)
                {
                    UserInfo.ChannelPermission[Channel] = (UserStruct.ChannelPermission[Channel] > 0);
                }
                UserList.Add(UserInfo);
                Offset += Marshal.SizeOf(UserStruct);
            }
            return UserList;
        }
        /*Operation*/
        public static TelRecErrno Login(int Device, string IPaddress, ushort Port, string UserName, string Password, bool RemoteLogin)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            byte[] UserNameBytes = Encoding.ASCII.GetBytes(UserName);
            byte[] PasswordBytes = Encoding.ASCII.GetBytes(Password + '\0');
            byte[] IPaddressBytes = Encoding.ASCII.GetBytes(IPaddress + '\0');
            TelRecAPI_SetNetAddr(Device, IPaddressBytes, Port);
            TelRecAPI_SetUserPassword(Device, UserNameBytes, UserNameBytes.Length, PasswordBytes);
            return (TelRecErrno)TelRecAPI_Login(Device, RemoteLogin);
        }
        public static TelRecErrno Logout(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_Logout(Device);
        }
        private static EventCallBack HeartbeatCallBack = null;
        public static TelRecErrno CreateHeartbeatThread(int Device, DeviceEventCallBack CallBack)
        {
            int Errno;
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            if(HeartbeatCallBack == null)
            {
                HeartbeatCallBack = new EventCallBack(
                (int Event, int EventDevice, IntPtr Data, int Length) =>
                {
                    CallBack((TelRecEventType)Event, EventDevice, (int)Data, Length);
                    return 0;
                });
            }
            Errno = TelRecAPI_CS_CreateHeartbeatThread(Device, HeartbeatCallBack);
            return (TelRecErrno)Errno;
        }
        public static TelRecErrno GetStorageStatus(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetStorageStatus(Device);
        }
        public static TelRecErrno GetNetStatus(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetNetStatus(Device);
        }
        public static TelRecErrno GetTime(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetTime(Device);
        }
        public static TelRecErrno SetTime(int Device, TelRecDateTime NewDateTime)
        {
            TelRecErrno Errno;
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            DateTimeStruct NewDateTimeStruct = new DateTimeStruct
            {
                Year = (byte)NewDateTime.Year,
                Month = (byte)NewDateTime.Month,
                Day = (byte)NewDateTime.Day,
                Hour = (byte)NewDateTime.Hour,
                Minutes = (byte)NewDateTime.Minutes,
                Seconds = (byte)NewDateTime.Seconds,
                Week = (byte)NewDateTime.Week
            };
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(DateTimeStruct)));
            Marshal.StructureToPtr(NewDateTimeStruct, p, false);
            Errno = (TelRecErrno)TelRecAPI_SetTime(Device, p);
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno GetPlayBackFileList(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetPlayBackFileList(Device);
        }
        public static TelRecErrno GetBaseSetting(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetBaseSetting(Device);
        }
        public static TelRecErrno SetBaseSetting(int Device, TelRecBaseSetting Setting)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            TelRecErrno Errno;
            byte[] KeyRecordStartBytes = Encoding.ASCII.GetBytes(Setting.KeyRecordStart);
            byte[] KeyRecordEndBytes = Encoding.ASCII.GetBytes(Setting.KeyRecordEnd);
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(BaseSettingStruct)));
            BaseSettingStruct SettingStruct = (BaseSettingStruct)Marshal.PtrToStructure(p, typeof(BaseSettingStruct));
            SettingStruct.RecordTimeMin = (byte)Setting.RecordTimeMin;
            SettingStruct.RecordTimeMax = (byte)Setting.RecordTimeMax;
            SettingStruct.RingEndTime = (byte)Setting.RingEndTime;
            SettingStruct.PhoneNumLengthMin = (byte)Setting.PhoneNumLengthMin;
            SettingStruct.CircuitOutNum = (byte)((Setting.CircuitOutNum.Length > 0) ? Setting.CircuitOutNum[0] : 0);
            SettingStruct.VoiceSensitivity = (byte)Setting.VoiceSensitivity;
            SettingStruct.SaveMissedCall = (byte)(Setting.SaveMissedCall ? 1 : 0);
            SettingStruct.ReserveSpace = (byte)Setting.ReserveSpace;
            SettingStruct.LoopUseStorage = (byte)(Setting.LoopUseStorage ? 1 : 0);
            SettingStruct.DialWaitOffHookTime = (byte)Setting.DialWaitOffHookTime;
            SettingStruct.KeyRecordStartLength = (byte)Math.Min(KeyRecordStartBytes.Length, KeyControlLengthMax);
            SettingStruct.KeyRecordEndLength = (byte)Math.Min(KeyRecordEndBytes.Length, KeyControlLengthMax);
            Array.Copy(KeyRecordStartBytes, SettingStruct.KeyRecordStart, SettingStruct.KeyRecordStartLength);
            Array.Copy(KeyRecordEndBytes, SettingStruct.KeyRecordEnd, SettingStruct.KeyRecordEndLength);
            Marshal.StructureToPtr(SettingStruct, p, true);
            Errno = (TelRecErrno)TelRecAPI_SetBaseSetting(Device, p);
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno GetChannelSetting(int Device, int Channel)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetChannelSetting(Device, Channel);
        }
        public static TelRecErrno SetChannelSetting(int Device, int Channel, TelRecChannelSetting Setting)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            TelRecErrno Errno;
            byte[] NameBytes;
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ChannelSettingStruct)));
            ChannelSettingStruct SettingStruct = (ChannelSettingStruct)Marshal.PtrToStructure(p, typeof(ChannelSettingStruct));
            for (int Week = 0; Week < 7; Week++)
            {
                /*TelRecAutoReply*/
                for (int TimeSolt = 0; TimeSolt < 3; TimeSolt++)
                {
                    /*TelRecReplyTimeSlot*/
                    SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].Enable = (byte)(Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].Enable ? 1 : 0);
                    SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].StartHour = (byte)Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].StartHour;
                    SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].StartMinute = (byte)Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].StartMinute;
                    SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].EndHour = (byte)Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].EndHour;
                    SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].EndMinute = (byte)Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].EndMinute;
                    NameBytes = Encoding.UTF8.GetBytes(Setting.AutoReply[Week].ReplyTimeSlot[TimeSolt].FileName);
                    Array.Copy(NameBytes, SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].FileName, NameBytes.Length);
                    SettingStruct.AutoReply[Week].ReplyTimeSlot[TimeSolt].FileName[NameBytes.Length] = (byte)'\0';
                }
                SettingStruct.AutoReply[Week].AllDayLongReply = (byte)(Setting.AutoReply[Week].AllDayLongReply ? 1 : 0);
                NameBytes = Encoding.UTF8.GetBytes(Setting.AutoReply[Week].FileName);
                Array.Copy(NameBytes, SettingStruct.AutoReply[Week].FileName, NameBytes.Length);
                SettingStruct.AutoReply[Week].FileName[NameBytes.Length] = (byte)'\0';
            }
            SettingStruct.EnableLostWarning = (byte)(Setting.EnableLostWarning ? 1 : 0);
            SettingStruct.EnableAnnouncement = (byte)(Setting.EnableAnnouncement ? 1 : 0);
            SettingStruct.SaveAnnouncementToRecord = (byte)(Setting.SaveAnnouncementToRecord ? 1 : 0);
            SettingStruct.RecordCondition = (byte)Setting.RecordCondition;
            SettingStruct.EnableAutoReply = (byte)(Setting.EnableAutoReply ? 1 : 0);
            SettingStruct.SaveAutoReplyToRecord = (byte)(Setting.SaveAutoReplyToRecord ? 1 : 0);
            SettingStruct.AutoReplyRingCount = (byte)Setting.AutoReplyRingCount;
            SettingStruct.LeaveWordMaxTime = (byte)Setting.LeaveWordMaxTime;
            SettingStruct.LostVoltage = (byte)Setting.LostVoltage;
            SettingStruct.OnHookVoltage = (byte)Setting.OnHookVoltage;
            SettingStruct.OffHookVoltage = (byte)Setting.OffHookVoltage;
            SettingStruct.RingVoltage = (byte)Setting.RingVoltage;
            NameBytes = Encoding.UTF8.GetBytes(Setting.ChannelName);
            Array.Copy(NameBytes, SettingStruct.ChannelName, NameBytes.Length);
            SettingStruct.ChannelName[NameBytes.Length] = (byte)'\0';
            NameBytes = Encoding.UTF8.GetBytes(Setting.AnnouncementFileName);
            Array.Copy(NameBytes, SettingStruct.AnnouncementFileName, NameBytes.Length);
            SettingStruct.AnnouncementFileName[NameBytes.Length] = (byte)'\0';
            Marshal.StructureToPtr(SettingStruct, p, true);
            Errno = (TelRecErrno)TelRecAPI_SetChannelSetting(Device, Channel, p);
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno GetKeyControlSetting(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetKeyControlSetting(Device);
        }
        public static TelRecErrno SetKeyControlSetting(int Device, TelRecKeyControlSetting Setting)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            TelRecErrno Errno;
            byte[] StrBytes;
            int StrLength;
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ChannelSettingStruct)));
            KeyControlSettingStruct SettingStruct = (KeyControlSettingStruct)Marshal.PtrToStructure(p, typeof(KeyControlSettingStruct));
            for (int i = 0; i < 10; i++)
            {
                SettingStruct.PlayBackStartKey[i].Enable = (byte)(Setting.PlayBackStartKey[i].Enable ? 1 : 0);
                /*Key*/
                StrBytes = Encoding.ASCII.GetBytes(Setting.PlayBackStartKey[i].Key);
                StrLength = Math.Min(StrBytes.Length, KeyControlLengthMax);
                SettingStruct.PlayBackStartKey[i].KeyLength = (byte)StrLength;
                Array.Copy(StrBytes, SettingStruct.PlayBackStartKey[i].Key, StrLength);
                /*FileName*/
                StrBytes = Encoding.ASCII.GetBytes(Setting.PlayBackStartKey[i].FileName);
                Array.Copy(StrBytes, SettingStruct.PlayBackStartKey[i].FileName, StrBytes.Length);
                SettingStruct.PlayBackStartKey[i].FileName[StrBytes.Length] = (byte)'\0';
            }
            StrBytes = Encoding.ASCII.GetBytes(Setting.PlayBackEndKey);
            StrLength = Math.Min(StrBytes.Length, KeyControlLengthMax);
            SettingStruct.PlayBackEndKeyLength = (byte)StrLength;
            Array.Copy(StrBytes, SettingStruct.PlayBackEndKey, StrLength);
            Marshal.StructureToPtr(SettingStruct, p, true);
            Errno = (TelRecErrno)TelRecAPI_SetKeyControlSetting(Device, p);
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno GetNetSetting(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetNetSetting(Device);
        }
        public static TelRecErrno SetNetSetting(int Device, TelRecNetSetting Setting)
        {
            TelRecErrno Errno;
            byte[] tMAC = new byte[6];
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            if (!IPaddressParse(Setting.IP, out uint tIP))
                return TelRecErrno.ParameterInvalid;
            if (!IPaddressParse(Setting.Mask, out uint tMask))
                return TelRecErrno.ParameterInvalid;
            if (!IPaddressParse(Setting.Gateway, out uint tGateway))
                return TelRecErrno.ParameterInvalid;
            if (!MACaddressParse(Setting.MAC, tMAC))
                return TelRecErrno.ParameterInvalid;
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NetSettingStruct)));
            NetSettingStruct SettingStruct = (NetSettingStruct)Marshal.PtrToStructure(p, typeof(NetSettingStruct));
            SettingStruct.IP = tIP;
            SettingStruct.Mask = tMask;
            SettingStruct.Gateway = tGateway;
            Array.Copy(tMAC, SettingStruct.MAC, 6);
            SettingStruct.Port = (ushort)Setting.Port;
            SettingStruct.Mode = (byte)Setting.Mode;
            SettingStruct.EnableCloud = (byte)(Setting.EnableCloud ? 1 : 0);
            Marshal.StructureToPtr(SettingStruct, p, true);
            Errno = (TelRecErrno)TelRecAPI_SetNetSetting(Device, p);
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno GetSMDRSetting(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetSMDRSetting(Device);
        }
        public static TelRecErrno SetSMDRSetting(int Device, TelRecSMDRSetting Setting)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            TelRecErrno Errno;
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SMDRSettingStruct)));
            SMDRSettingStruct SettingStruct = (SMDRSettingStruct)Marshal.PtrToStructure(p, typeof(SMDRSettingStruct));
            SettingStruct.Enable = (byte)(Setting.Enable ? 1 : 0);
            SettingStruct.CheckTime = (byte)(Setting.CheckTime / 100);
            SettingStruct.InExNumLocation = (byte)Setting.InExNumLocation;
            SettingStruct.InExNumLength = (byte)Setting.InExNumLength;
            SettingStruct.InPhoneNumLocation = (byte)Setting.InPhoneNumLocation;
            SettingStruct.InPhoneNumLength = (byte)Setting.InPhoneNumLength;
            SettingStruct.OutExNumLocation = (byte)Setting.OutExNumLocation;
            SettingStruct.OutExNumLength = (byte)Setting.OutExNumLength;
            SettingStruct.OutPhoneNumLocation = (byte)Setting.OutPhoneNumLocation;
            SettingStruct.OutPhoneNumLength = (byte)Setting.OutPhoneNumLength;
            SettingStruct.ConnectType = (byte)Setting.ConnectType;
            SettingStruct.BaudrateOption = (byte)Setting.BaudrateOption;
            SettingStruct.DataBitOption = (byte)Setting.DataBitOption;
            SettingStruct.StopBitOption = (byte)Setting.StopBitOption;
            SettingStruct.CheckBitOption = (byte)Setting.CheckBitOption;
            Marshal.StructureToPtr(SettingStruct, p, true);
            Errno = (TelRecErrno)TelRecAPI_SetSMDRSetting(Device, p);
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno GetUserList(int Device)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetUserList(Device);
        }
        public static TelRecErrno AddUser(int Device, TelRecUserInfo User, string Password)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            TelRecErrno Errno;
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(UserInfoStruct)));
            UserInfoStruct UserStruct = (UserInfoStruct)Marshal.PtrToStructure(p, typeof(UserInfoStruct));
            byte[] NameBytes = Encoding.UTF8.GetBytes(User.UserName);
            UserStruct.UserNameLength = (byte)NameBytes.Length;
            Array.Copy(NameBytes, UserStruct.UserName, NameBytes.Length);
            UserStruct.ManageUsersPermission = (byte)(User.ManageUsersPermission ? 1 : 0);
            UserStruct.ChangeSettingPermission = (byte)(User.ChangeSettingPermission ? 1 : 0);
            UserStruct.DownloadPermission = (byte)(User.DownloadPermission ? 1 : 0);
            UserStruct.DeletePermission = (byte)(User.DeletePermission ? 1 : 0);
            UserStruct.MonitorPermission = (byte)(User.MonitorPermission ? 1 : 0);
            for (int Channel = 0; Channel < 64; Channel++)
            {
                UserStruct.ChannelPermission[Channel] = (byte)(User.ChannelPermission[Channel] ? 1 : 0);
            }
            Marshal.StructureToPtr(UserStruct, p, true);
            Errno = (TelRecErrno)TelRecAPI_AddUser(Device, p, Encoding.ASCII.GetBytes(Password + '\0'));
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno EditUser(int Device, TelRecUserInfo User, string Password)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            TelRecErrno Errno;
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(UserInfoStruct)));
            UserInfoStruct UserStruct = (UserInfoStruct)Marshal.PtrToStructure(p, typeof(UserInfoStruct));
            byte[] NameBytes = Encoding.UTF8.GetBytes(User.UserName);
            UserStruct.UserNameLength = (byte)NameBytes.Length;
            Array.Copy(NameBytes, UserStruct.UserName, NameBytes.Length);
            UserStruct.ManageUsersPermission = (byte)(User.ManageUsersPermission ? 1 : 0);
            UserStruct.ChangeSettingPermission = (byte)(User.ChangeSettingPermission ? 1 : 0);
            UserStruct.DownloadPermission = (byte)(User.DownloadPermission ? 1 : 0);
            UserStruct.DeletePermission = (byte)(User.DeletePermission ? 1 : 0);
            UserStruct.MonitorPermission = (byte)(User.MonitorPermission ? 1 : 0);
            for (int Channel = 0; Channel < 64; Channel++)
            {
                UserStruct.ChannelPermission[Channel] = (byte)(User.ChannelPermission[Channel] ? 1 : 0);
            }
            Marshal.StructureToPtr(UserStruct, p, true);
            Errno = (TelRecErrno)TelRecAPI_EditUser(Device, p, Encoding.ASCII.GetBytes(Password + '\0'));
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno DeleteUser(int Device, TelRecUserInfo User)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            TelRecErrno Errno;
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(UserInfoStruct)));
            UserInfoStruct UserStruct = (UserInfoStruct)Marshal.PtrToStructure(p, typeof(UserInfoStruct));
            byte[] NameBytes = Encoding.UTF8.GetBytes(User.UserName);
            UserStruct.UserNameLength = (byte)NameBytes.Length;
            Array.Copy(NameBytes, UserStruct.UserName, NameBytes.Length);
            Marshal.StructureToPtr(UserStruct, p, true);
            Errno = (TelRecErrno)TelRecAPI_DeleteUser(Device, p);
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno UploadFile(int Device, string SrcFilePath, string UploadDir, string UploadFileName, UploadCallBack CallBack)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            TelRecErrno Errno;
            Errno = (TelRecErrno)TelRecAPI_CS_UploadFile(Device,
                Encoding.Default.GetBytes(SrcFilePath + '\0'),
                Encoding.Default.GetBytes(UploadDir + '\0'),
                (UploadFileName == null) ? null : Encoding.Default.GetBytes(UploadFileName + '\0'),
                (int Event, int EventDevice, IntPtr Data, int Length) =>
                {
                    if (Event == (int)TelRecEventType.UpdateProgress)
                    {
                        return (CallBack(EventDevice, Length) ? 1 : 0);
                    }
                    return 0;
                });
            return Errno;
        }
        public static TelRecErrno DownloadFile(int Device, string FilePath, DownloadCallBack CallBack)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            TelRecErrno Errno;
            Errno = (TelRecErrno)TelRecAPI_CS_DownloadFile(Device,
                Encoding.Default.GetBytes(FilePath + '\0'),
                (int Event, int EventDevice, IntPtr Data, int Length) =>
                {
                    if (Event == (int)TelRecEventType.GotData)
                    {
                        byte[] Buffer = new byte[Length];
                        Marshal.Copy(Data, Buffer, 0, Length);
                        return (CallBack(EventDevice, Buffer, Length) ? 1 : 0);
                    }
                    else if (Event == (int)TelRecEventType.GotDataSize)
                    {
                        return (CallBack(EventDevice, null, Length) ? 1 : 0);
                    }
                    return 0;
                });
            return Errno;
        }
        public static TelRecErrno RemoveFile(int Device, string FilePath)
        {
            return (TelRecErrno)TelRecAPI_RemoveFile(Device, Encoding.Default.GetBytes(FilePath + '\0'));
        }
        public static TelRecErrno GetLatestRecordTime(int Device, out int Year, out int Month, out int Day)
        {
            if (Device == 0)
            {
                Year = 0;
                Month = 0;
                Day = 0;
                return TelRecErrno.ParameterInvalid;
            }
            return (TelRecErrno)TelRecAPI_GetLatestRecordTime(Device, out Year, out Month, out Day);
        }
        public static TelRecErrno GetEarliestRecordTime(int Device, out int Year, out int Month, out int Day)
        {
            if (Device == 0)
            {
                Year = 0;
                Month = 0;
                Day = 0;
                return TelRecErrno.ParameterInvalid;
            }
            return (TelRecErrno)TelRecAPI_GetEarliestRecordTime(Device, out Year, out Month, out Day);
        }
        public static TelRecErrno GetDayListFromMonthDir(int Device, int Year, int Month, byte[] DayArray)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_GetDayListFromMonthDir(Device, Year, Month, DayArray);
        }
        public static TelRecErrno EditRecordNotes(int Device, int ItemOffset, int Year, int Month, int Day, int Channel, string Notes)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_EditRecordNotes(Device, ItemOffset, Year, Month, Day, Channel, Encoding.UTF8.GetBytes(Notes + '\0'));
        }
        public static TelRecErrno DeleteRecord(int Device, TelRecRecordDeleteItem Item)
        {
            TelRecErrno Errno;
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            RecordDeleteItemStruct ItemStruct = new RecordDeleteItemStruct
            {
                Year = (byte)Item.Year,
                Month = (byte)Item.Month,
                Day = (byte)Item.Day,
                Hour = (byte)Item.Hour,
                Minutes = (byte)Item.Minutes,
                Seconds = (byte)Item.Seconds,
                Channel = (byte)Item.Channel,
                HasWavFile = (byte)(Item.HasWavFile ? 1 : 0),
                Offset = (byte)Item.Offset
            };
            IntPtr p = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(RecordDeleteItemStruct)));
            Marshal.StructureToPtr(ItemStruct, p, false);
            Errno = (TelRecErrno)TelRecAPI_DeleteRecord(Device, p);
            Marshal.FreeHGlobal(p);
            return Errno;
        }
        public static TelRecErrno StartMonitor(int Device, int Channel)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            return (TelRecErrno)TelRecAPI_StartMonitor(Device, Channel);
        }
        public static void StopMonitor()
        {
            TelRecAPI_StopMonitor();
        }
        public static TelRecErrno Dial(int Device, int Channel, string PhoneNum)
        {
            if (Device == 0)
                return TelRecErrno.ParameterInvalid;
            if (string.IsNullOrEmpty(PhoneNum))
                return TelRecErrno.ParameterInvalid;
            byte[] PhoneNumBytes = Encoding.ASCII.GetBytes(PhoneNum);
            return (TelRecErrno)TelRecAPI_Dial(Device, Channel, PhoneNumBytes, PhoneNumBytes.Length);
        }


        public static void PlayerSetVolume(int Volume)
        {
            TelRecAPI_PlayerSetVolume(Volume);
        }
        public static void PlayerWriteData(byte[] Data)
        {
            TelRecAPI_PlayerWriteData(Data);
        }
        #endregion
        #endregion
    }
}
