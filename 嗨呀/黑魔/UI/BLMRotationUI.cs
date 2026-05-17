namespace 嗨呀.黑魔.UI;

public class BLMRotationUI : IRotationUI
{
    public void RegisterControls(IUiBuilder builder)
    {
        builder.AddBuiltinQt(BuiltinQt.Burst);
        builder.AddBuiltinQt(BuiltinQt.Potion);
        builder.AddBuiltinQt(BuiltinQt.Hold);
        builder.AddBuiltinQt(BuiltinQt.Mitigation);
        builder.AddBuiltinQt(BuiltinQt.AoE);
        builder.AddBuiltinQt(BuiltinQt.TTK);

        builder.AddQtToggle(QTKey.三连, "使用三连", true);
        builder.AddQtToggle(QTKey.墨泉, "使用墨泉", true);
        builder.AddQtToggle(QTKey.黑魔纹, "使用黑魔纹", true);
        builder.AddQtToggle(QTKey.通晓, "使用通晓技能", true);
        builder.AddQtToggle(QTKey.Dot, "使用雷Dot", true);
    }
}