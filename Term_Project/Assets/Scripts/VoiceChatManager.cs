using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agora_RTC_Plugin;
using Agora.Rtc;
using Agora.Util;

public class VoiceChatManager : MonoBehaviour
{
    private string _appID = "f6cb3785304348309b435666ff9491ad";

    private string _channelName = "";

    internal IRtcEngine RtcEngine = null;

    private IAudioDeviceManager _audioDeviceManager;
    private DeviceInfo[] _audioPlaybackDeviceInfos;


    public static VoiceChatManager Instance;

    IRtcEngine rtcEngine;


    private void Update()
    {
        PermissionHelper.RequestMicrophontPermission();
    }



    public void LoadAssetData(string channelName)
    {
        _channelName = channelName;

    }
    public void InitRtcEngine()
    {
        RtcEngine = Agora.Rtc.RtcEngine.CreateAgoraRtcEngine();
        RtcEngineContext context = new RtcEngineContext(_appID, 0,
            CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING,
            AUDIO_SCENARIO_TYPE.AUDIO_SCENARIO_DEFAULT);

        RtcEngine.Initialize(context);
    }

    public void SetBasicConfiguration()
    {
        RtcEngine.EnableAudio();
        RtcEngine.SetChannelProfile(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_LIVE_BROADCASTING);
        RtcEngine.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);
    }

    #region -- Button Events ---
    public void JoinChannel()
    {
        RtcEngine.JoinChannel("", _channelName);
    }
    public void LeaveChannel()
    {
        RtcEngine.LeaveChannel();
    }
    public void GetAudioPlaybackDevice()
    {
        _audioDeviceManager = RtcEngine.GetAudioDeviceManager();

        // get all audio playback devices
        _audioPlaybackDeviceInfos = _audioDeviceManager.EnumeratePlaybackDevices();

        //set first device as default
        _audioDeviceManager.SetPlaybackDevice(_audioPlaybackDeviceInfos[0].deviceId);
    }


    #endregion
}
