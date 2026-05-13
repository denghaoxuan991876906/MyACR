namespace 嗨呀.黑魔.设置;

public class BLM_Setting
{
    public static string SettingFolder { get; private set; } = "黑魔设置";

    public static void Init(string settingFolder)
    {
        SettingFolder = settingFolder;
    }
}