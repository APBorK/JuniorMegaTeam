using System;
using System.IO;
using Newtonsoft.Json;
using Settings;
using Tiles;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class JSONController : MonoBehaviour
{ 
    [SerializeField] private PhisicsSettings _phisicsSettings; 
    [SerializeField] private ScreenWidthSettings _screenWidthSettings;
    [SerializeField] private SelectingListTails _selectingListTails;
    public SettingInformation _settingInformation;
    
    private void Start() 
    { 
        Load();
        _selectingListTails.SelectedObj(_settingInformation.tilesVersion);
        _screenWidthSettings.Screen(_settingInformation.screenWidth);
        _phisicsSettings.DropSpeed( _settingInformation.dropSpeed);
        _phisicsSettings.MatchSpeed(_settingInformation.matchSpeed);
        _phisicsSettings.SpawnVelocity(_settingInformation.spawnVelocity);
        _phisicsSettings.TilesBounce(_settingInformation.tilesBounce);
        _phisicsSettings.TilesDropDelay(_settingInformation.tilesDropDelay);
    }

    public void Save()
    { 
        _settingInformation.tilesVersion = _selectingListTails.IndexTil;
        _settingInformation.screenWidth = _screenWidthSettings.ButtonSreen;
        _settingInformation.tilesBounce = _phisicsSettings.ButtonBounce;
        _settingInformation.dropSpeed = _phisicsSettings.ButtonDropspeed;
        _settingInformation.tilesDropDelay = _phisicsSettings.ButtonDropDelay;
        _settingInformation.matchSpeed = _phisicsSettings.ButtonMatchSpeed;
        _settingInformation.spawnVelocity = _phisicsSettings.ButtonSpawnVelocity;
        File.WriteAllText(Application.dataPath + "/Save.json", JsonUtility.ToJson(_settingInformation));
    }

    public void Load()
    {
        _settingInformation =
            JsonUtility.FromJson<SettingInformation>(File.ReadAllText(Application.dataPath + "/Save.json"));
    }
    
    [Serializable]
    public class SettingInformation
    {
        public int screenWidth;
        public int tilesVersion;
        public int dropSpeed;
        public int tilesDropDelay;
        public int tilesBounce;
        public int matchSpeed;
        public int spawnVelocity;
    }
}
