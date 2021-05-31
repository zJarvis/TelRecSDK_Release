#ifndef TELRECTYPE_H
#define TELRECTYPE_H

#include <functional>

/*Array Length*/
#define DeviceID_Length         20
#define UserNameLengthMax       19
#define KeyControlLengthMax     10
#define FileNameLengthMax       27
#define ChannelNameLengthMax    27
#define PlayBackListSize        20
#define PhoneNumLengthMax       20
#define KeyLengthMax            20
#define ExNumLengthMax          10
#define NotesLengthMax          64

/*Event*/
enum class TelRec_EventType
{
    UpdateProgress,                     /*Data = nullptr,       Length = Progress*/
    FoundDevice,                        /*Data = FoundDevice,   Length = 0*/
    GotDataSize,                        /*Data = nullptr,       Length = File Size*/
    GotData,                            /*Data = Data,          Length = Data Length*/
    ConnectStatusChanged,               /*Data = nullptr,       Length = 0*/
    StorageStatusChanged,               /*Data = nullptr,       Length = 0*/
    CloudServerStatusChanged,           /*Data = nullptr,       Length = 0*/
    OnlineUserListChanged,              /*Data = nullptr,       Length = 0*/
    ChannelStatusChanged,               /*Data = Channel(Byte), Length = 0*/
    ChannelTalkTimeChanged,             /*Data = Channel(Byte), Length = TalkTime*/
    ChannelMonitorChanged,              /*Data = Channel(Byte), Length = Enabled(bool)*/
    ChannelPlayBackChanged,             /*Data = Channel(Byte), Length = Enabled(bool)*/
    ChannelRecordEnd                    /*Data = Channel(Byte), Length = 0*/
};
typedef std::function<int (TelRec_EventType Event, int Device, unsigned char *Data, int Length)> EventCallBack;

/*Found Device*/
typedef struct
{
    char DeviceID[DeviceID_Length];
    char *Model;
    int  Channels;
    char Version[16];
    char IPaddress[16];
    unsigned short NetPort;
}TelRec_FoundDeviceInfo;

/*Connect Status*/
enum class ConnectStatusType
{
    NotConnected = 0,
    Connecting,
    Connected
};

/*Storage Status*/
enum class StorageStatusType
{
    NotFound = 0,
    Normal,
    Full
};
typedef struct
{
    int Status;//(StorageStatusType)
    int Capacity;
    int Free;
}TelRec_StorageStatus;

/*Net Status*/
typedef struct
{
    unsigned int IP;
}TelRec_NetStatus;

/*Channel Status*/
enum class PhoneStatusType
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
    NotSupport,
    Max,
    Uninstalled = 255
};
typedef struct
{
    unsigned char PhoneStatus;//PhoneStatusType
    unsigned char RingCount;
    unsigned char PlayBackEnabled;
    unsigned char PhoneNumLength;
    char PhoneNum[PhoneNumLengthMax];
}TelRec_ChannelStatus;

/*Online User*/
typedef struct
{
    unsigned char UserNameLength;
    char UserName[UserNameLengthMax];
    unsigned int IP;
    unsigned char MAC[6];
    unsigned char LoginTime[6];
    unsigned int SDKVersion;
}TelRec_OnlineUser;
typedef struct
{
    int Count;
    TelRec_OnlineUser *OnlineUsers;
}TelRec_OnlineUserList;

/*Time Snapshoot*/
typedef struct
{
    unsigned char Year;
    unsigned char Month;
    unsigned char Day;
    unsigned char Hour;
    unsigned char Minutes;
    unsigned char Seconds;
    unsigned char Week;
}TelRec_DateTime;

/*Playback File List*/
typedef struct
{
    unsigned char Count;
    char FileName[PlayBackListSize][FileNameLengthMax + 1];
}TelRec_PlayBackFiles;

/*Base Setting*/
#define ReserveSpaceMax 30
typedef struct
{
    unsigned char RecordTimeMin;
    unsigned char RecordTimeMax;
    unsigned char RingEndTime;
    unsigned char PhoneNumLengthMin;
    char CircuitOutNum;
    unsigned char VoiceSensitivity;
    unsigned char SaveMissedCall;
    unsigned char ReserveSpace;
    unsigned char LoopUseStorage;
    unsigned char DialWaitOffHookTime;
    unsigned char KeyRecordStartLength;
    unsigned char KeyRecordEndLength;
    char KeyRecordStart[KeyControlLengthMax];
    char KeyRecordEnd[KeyControlLengthMax];
    unsigned char Reserved[32];
}TelRec_BaseSetting;

/*Channel Setting*/
#define RecordCondition_No      0
#define RecordCondition_Hook    1
#define RecordCondition_Key     2
#define RecordCondition_Voice   3
#define RecordCondition_Keep    4
#define AutoReplyRingCountMinimum   1
#define AutoReplyRingCountMaximum   10
#define LeaveWordMaxTimeMinimum     0
#define LeaveWordMaxTimeMaximum     200
typedef struct
{
    unsigned char Enable;
    unsigned char StartHour;
    unsigned char StartMinute;
    unsigned char EndHour;
    unsigned char EndMinute;
    char FileName[FileNameLengthMax + 1];
}TelRec_ReplyTimeSlot;
typedef struct
{
    TelRec_ReplyTimeSlot ReplyTimeSlot[3];
    unsigned char AllDayLongReply;
    char FileName[FileNameLengthMax + 1];
}TelRec_AutoReply;
typedef struct
{
    TelRec_AutoReply AutoReply[7];
    unsigned char EnableLostWarning;
    unsigned char EnableAnnouncement;
    unsigned char SaveAnnouncementToRecord;
    unsigned char RecordCondition;
    unsigned char EnableAutoReply;
    unsigned char SaveAutoReplyToRecord;
    unsigned char AutoReplyRingCount;
    unsigned char LeaveWordMaxTime;
    unsigned char LostVoltage;
    unsigned char OnHookVoltage;
    unsigned char OffHookVoltage;
    unsigned char RingVoltage;
    char ChannelName[ChannelNameLengthMax + 1];
    char AnnouncementFileName[FileNameLengthMax + 1];
    unsigned char Reserved[16];
}TelRec_ChannelSetting;

/*KeyControl PlayBack Setting*/
typedef struct
{
    unsigned char Enable;
    unsigned char KeyLength;
    char Key[KeyControlLengthMax];
    char FileName[FileNameLengthMax + 1];
}TelRec_PlayBackStartKey;
typedef struct
{
    TelRec_PlayBackStartKey PlayBackStartKey[10];
    unsigned char PlayBackEndKeyLength;
    char PlayBackEndKey[KeyControlLengthMax];
    unsigned char Reserved[17];
}TelRec_KeyControlSetting;

/*Net Setting*/
#define NetMode_DHCP 0
#define NetMode_Static 1
typedef struct
{
    unsigned int IP;
    unsigned int Mask;
    unsigned int Gateway;
    unsigned char MAC[6];
    unsigned short Port;
    unsigned char Mode;
    unsigned char EnableCloud;
}TelRec_NetSetting;

/*SMDR Setting*/
typedef struct
{
    unsigned char Enable;
    unsigned char CheckTime;
    unsigned char InExNumLocation;
    unsigned char InExNumLength;
    unsigned char InPhoneNumLocation;
    unsigned char InPhoneNumLength;
    unsigned char OutExNumLocation;
    unsigned char OutExNumLength;
    unsigned char OutPhoneNumLocation;
    unsigned char OutPhoneNumLength;
    unsigned char ConnectType;
    unsigned char BaudrateOption;
    unsigned char DataBitOption;
    unsigned char StopBitOption;
    unsigned char CheckBitOption;
    unsigned char Reserved[49];
}TelRec_SMDRSetting;

/*User List*/
typedef struct
{
    unsigned char UserNameLength;
    char UserName[UserNameLengthMax];
    /*Permission*/
    unsigned char ManageUsersPermission;
    unsigned char ChangeSettingPermission;
    unsigned char DownloadPermission;
    unsigned char DeletePermission;
    unsigned char MonitorPermission;
    unsigned char ChannelPermission[64];
}TelRec_UserInfo;
typedef struct
{
    int Count;
    TelRec_UserInfo *Users;
}TelRec_UserList;

/*Record Time Setting*/
typedef struct
{
    unsigned char Enable;
    unsigned char StartHour;
    unsigned char StartMinute;
    unsigned char EndHour;
    unsigned char EndMinute;
}TelRec_RecordTimeQuantum;
typedef struct
{
    unsigned char Enable;
    unsigned char Mode;
    unsigned char Reserved1[2];
    TelRec_RecordTimeQuantum Quantum[7][3];
    unsigned char Reserved2[11];
}TelRec_RecordTimeSetting;

/*Scheduled Restart Setting*/
typedef struct
{
    unsigned char Enable;
    unsigned char RestarHour;
    unsigned char RestarMinute;
    unsigned char Week[7];
    unsigned char Reserved[6];
}TelRec_ScheduledRestartSetting;

/*Record Index*/
#define RecordType_InComing     0
#define RecordType_Outgoing     1
#define RecordType_Missed       2
#define RecordType_KeyCtrl      3
#define RecordType_VoiceCtrl    4
#define RecordType_Keep         5
#define RecordType_AutoReply    6
#define RecordType_Timing       7
#define RecordType_Invalid      8
typedef struct
{
    unsigned char Year;
    unsigned char Month;
    unsigned char Day;
    unsigned char Hour;
    unsigned char Minutes;
    unsigned char Seconds;
    unsigned char RecordType;
    unsigned char RingCount;
    unsigned short TalkTime;
    unsigned char PhoneNumLength;
    unsigned char KeyLength;
    unsigned char ExNumLength;
    char PhoneNum[PhoneNumLengthMax];
    char Key[KeyLengthMax];
    char ExNum[ExNumLengthMax];
    char Notes[NotesLengthMax + 1];
}RecordIndexItem;

typedef struct
{
    unsigned char   Year;
    unsigned char   Month;
    unsigned char   Day;
    unsigned char   Hour;
    unsigned char   Minutes;
    unsigned char   Seconds;
    unsigned char   Channel;
    unsigned char   HasWavFile;
    unsigned short  Offset;
}RecordDeleteItem;

typedef struct
{
    unsigned char Year;
    unsigned char Month;
    unsigned char Day;
    unsigned char Hour;
    unsigned char Minutes;
    unsigned char Seconds;
    unsigned short RecordID;
    unsigned char RecordType;
    unsigned char PhoneNumLength;
    char PhoneNum[PhoneNumLengthMax];
}CurrentRecordInfo;

#endif
