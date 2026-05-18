namespace 嗨呀.黑魔.UI;

public class BLMRotationUI : IRotationUI
{
    public void RegisterControls(IUiBuilder builder)
    {
        builder.AddBuiltinQt(BuiltinQt.Burst, true);
        builder.AddBuiltinQt(BuiltinQt.Potion, false);
        builder.AddBuiltinQt(BuiltinQt.Hold, false);
        builder.AddBuiltinQt(BuiltinQt.Mitigation, true);
        builder.AddBuiltinQt(BuiltinQt.AoE, true);
        builder.AddBuiltinQt(BuiltinQt.TTK, false);

        builder.AddQtToggle(QTKey.三连, "使用三连", true);
        builder.AddQtToggle(QTKey.墨泉, "使用墨泉", true);
        builder.AddQtToggle(QTKey.黑魔纹, "使用黑魔纹", true);
        builder.AddQtToggle(QTKey.通晓, "使用通晓技能", true);
        builder.AddQtToggle(QTKey.Dot, "使用雷Dot", true);
        
        builder.AddQtHotkey("爆发药", new HotkeyResolver_吃药("item","爆发药", 49237));
        

    }
}