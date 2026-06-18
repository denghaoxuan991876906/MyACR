using OmenTools.Dalamud;
using 嗨呀.黑魔.设置;

namespace 嗨呀.黑魔.UI;

public class BLMRotationUI : IRotationUI
{
    public void RegisterControls(IAcrUiBuilder builder)
    {
        builder.AddBuiltinQt(BuiltinQt.Burst, true);
        builder.AddBuiltinQt(BuiltinQt.Potion, false);
        builder.AddBuiltinQt(BuiltinQt.Hold, false);
        builder.AddBuiltinQt(BuiltinQt.Mitigation, true);
        builder.AddBuiltinQt(BuiltinQt.AoE, true);
        builder.AddBuiltinQt(BuiltinQt.TTK, false);

        builder.AddQtToggle(QTKey.三连,  true);
        builder.AddQtToggle(QTKey.即刻, true);
        builder.AddQtToggle(QTKey.墨泉, true);
        builder.AddQtToggle(QTKey.黑魔纹, true);
        builder.AddQtToggle(QTKey.详述, true);
        builder.AddQtToggle(QTKey.通晓, true);
        builder.AddQtToggle(QTKey.Dot, true);
        builder.AddQtToggle(QTKey.高级循环, false);
        builder.AddQtToggle(QTKey.冰悖论, true);
        builder.AddQtToggle(QTKey.火悖论, true);
        
        builder.AddQtHotkey("爆发药", new HotkeyResolver_吃药("爆发药", 49237));
        builder.AddQtHotkey("黑魔纹", new HotkeyResolver_技能("黑魔纹", BLMHelper.黑魔纹));
        
        builder.AddTab("Test");
        builder.AddLabel("label测试");
        var booltest = BLM_Setting.Instance.test1;
        if (builder.AddCheckbox("checkbox测试", ref booltest))
        {
            BLM_Setting.Instance.test1 =  booltest;
            BLM_Setting.Instance.Save();
        }
        var inttest = BLM_Setting.Instance.test2;
        if(builder.AddIntInput("intinput测试", ref inttest))
        {
            BLM_Setting.Instance.test2 =  inttest;
            BLM_Setting.Instance.Save();
        }

        if (builder.AddButton("检测设置"))
        {
            DLog.Debug($"{nameof(BLM_Setting.Instance.test1)}:{BLM_Setting.Instance.test1}");
            DLog.Debug($"{nameof(BLM_Setting.Instance.test2)}:{BLM_Setting.Instance.test2}");
        }
        builder.EndTab();
        
    }
}