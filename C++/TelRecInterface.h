#ifndef TELRECINTERFACE_H
#define TELRECINTERFACE_H

#include <TelRecType.h>

/*API*/
extern "C"
{
    int TelRecAPI_Init();
    int TelRecAPI_Exit();
    int TelRecAPI_CheckDeviceID(char DeviceID[DeviceID_Length]);
    int TelRecAPI_SearchDevice(EventCallBack CallBack);
    int TelRecAPI_CreateDevice(char DeviceID[DeviceID_Length]);
    int TelRecAPI_DeleteDevice(int Device);
    unsigned int TelRecAPI_StringToIPaddress(const char *Str);
    unsigned int TelRecAPI_StringToVersion(const char *Str);
    void TelRecAPI_IPaddressToString(unsigned int IPaddress, char OutString[16]);
    void TelRecAPI_VersionToString(unsigned int Version, char OutString[16]);
    /*Login Parameter*/
    int TelRecAPI_SetNetAddr(int Device, const char *IPaddress, unsigned short Port);
    int TelRecAPI_SetUserPassword(int Device, const char *UserName, int UserNameLength, const char *Password);
    /*Device Info*/
    const char *TelRecAPI_DeviceModel(int Device);
    const char *TelRecAPI_FirmwareVersion(int Device);
    int TelRecAPI_DeviceChannels(int Device);
    bool TelRecAPI_IsSupportPlayBack(int Device);
    /*Permission*/
    bool TelRecAPI_Permission_ManageUsers(int Device);
    bool TelRecAPI_Permission_ChangeSetting(int Device);
    bool TelRecAPI_Permission_Download(int Device);
    bool TelRecAPI_Permission_Delete(int Device);
    bool TelRecAPI_Permission_Monitor(int Device);
    bool TelRecAPI_Permission_Channel(int Device, int Channel);
    /*Device Status*/
    ConnectStatusType TelRecAPI_ConnectStatus(int Device);
    TelRec_StorageStatus *TelRecAPI_StorageStatus(int Device);
    TelRec_NetStatus *TelRecAPI_NetStatus(int Device);
    TelRec_ChannelStatus *TelRecAPI_ChannelStatus(int Device, int Channel);
    TelRec_OnlineUserList *TelRecAPI_OnlineUserList(int Device);
    bool TelRecAPI_CloudServerHasConnected(int Device);
    bool TelRecAPI_SimulateOffHookIsEnabled(int Device, int Channel);
    /*Device Setting*/
    TelRec_DateTime *TelRecAPI_DateTime(int Device);
    TelRec_PlayBackFiles *TelRecAPI_PlayBackFileList(int Device);
    TelRec_BaseSetting *TelRecAPI_BaseSetting(int Device);
    TelRec_ChannelSetting *TelRecAPI_ChannelSetting(int Device, int Channel);
    TelRec_KeyControlSetting *TelRecAPI_KeyControlSetting(int Device);
    TelRec_NetSetting *TelRecAPI_NetSetting(int Device);
    TelRec_SMDRSetting *TelRecAPI_SMDRSetting(int Device);
    TelRec_UserList *TelRecAPI_UserList(int Device);
    TelRec_RecordTimeSetting *TelRecAPI_RecordTimeSetting(int Device);
    /*Device Operation*/
    int TelRecAPI_Login(int Device, bool RemoteLogin);
    int TelRecAPI_Logout(int Device);
    int TelRecAPI_CreateHeartbeatThread(int Device, EventCallBack CallBack);
    int TelRecAPI_GetStorageStatus(int Device);
    int TelRecAPI_GetNetStatus(int Device);
    int TelRecAPI_GetChannelVoltage(int Device, int Channel, int *Voltage);
    int TelRecAPI_GetCurrentRecordInfo(int Device, int Channel, CurrentRecordInfo *Info);
    int TelRecAPI_GetTime(int Device);
    int TelRecAPI_SetTime(int Device, TelRec_DateTime *NewDateTime);
    int TelRecAPI_GetPlayBackFileList(int Device);
    int TelRecAPI_GetBaseSetting(int Device);
    int TelRecAPI_SetBaseSetting(int Device, TelRec_BaseSetting *Setting);
    int TelRecAPI_GetChannelSetting(int Device, int Channel);
    int TelRecAPI_SetChannelSetting(int Device, int Channel, TelRec_ChannelSetting *Setting);
    int TelRecAPI_GetKeyControlSetting(int Device);
    int TelRecAPI_SetKeyControlSetting(int Device, TelRec_KeyControlSetting *Setting);
    int TelRecAPI_GetNetSetting(int Device);
    int TelRecAPI_SetNetSetting(int Device, TelRec_NetSetting *Setting);
    int TelRecAPI_GetSMDRSetting(int Device);
    int TelRecAPI_SetSMDRSetting(int Device, TelRec_SMDRSetting *Setting);
    int TelRecAPI_GetUserList(int Device);
    int TelRecAPI_AddUser(int Device, TelRec_UserInfo *User, const char *Password);
    int TelRecAPI_EditUser(int Device, TelRec_UserInfo *User, const char *Password);
    int TelRecAPI_DeleteUser(int Device, TelRec_UserInfo *User);
    int TelRecAPI_UploadFile(int Device, const char *SrcFilePath, const char *UploadDir, const char *UploadFileName, EventCallBack CallBack);
    int TelRecAPI_DownloadFile(int Device, const char *FilePath, EventCallBack CallBack);
    int TelRecAPI_RemoveFile(int Device, const char *FilePath);
    int TelRecAPI_GetLatestRecordTime(int Device, unsigned char *Year, unsigned char *Month, unsigned char *Day);
    int TelRecAPI_GetEarliestRecordTime(int Device, unsigned char *Year, unsigned char *Month, unsigned char *Day);
    int TelRecAPI_GetDayListFromMonthDir(int Device, unsigned char Year, unsigned char Month, unsigned char DayArray[32]);
    int TelRecAPI_EditRecordNotes(int Device, unsigned short ItemOffset, unsigned char Year, unsigned char Month, unsigned char Day, unsigned char Channel, const char *Notes);
    int TelRecAPI_DeleteRecord(int Device, RecordDeleteItem *Item);
    int TelRecAPI_StartMonitor(int Device, unsigned char Channel);
    int TelRecAPI_StopMonitor();
    int TelRecAPI_Dial(int Device, unsigned char Channel, const char *PhoneNum, int PhoneNumLength);
    int TelRecAPI_GetSMDR(int Device, int *Length, char **Data);
    int TelRecAPI_Reboot(int Device);
    int TelRecAPI_GetRecordTimeSetting(int Device);
    int TelRecAPI_SetRecordTimeSetting(int Device, TelRec_RecordTimeSetting *Setting);
    int TelRecAPI_GetNewVersionInfo(int Device, EventCallBack CallBack);
    int TelRecAPI_DownloadFirmware(int Device, const char *FileName, EventCallBack CallBack);
    int TelRecAPI_CheckFirmware(int Device, const char *FirmwarePath);
    int TelRecAPI_GetClientVersionInfo(EventCallBack CallBack);
    /*Player*/
    int TelRecAPI_PlayerSetVolume(int Volume);
    int TelRecAPI_PlayerWriteData(unsigned char *AudioData);
}

#endif
