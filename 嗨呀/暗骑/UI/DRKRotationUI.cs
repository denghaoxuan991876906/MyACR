namespace 嗨呀.暗骑.UI;

public class DRKRotationUI : IRotationUI
{
    public void RegisterControls(IUiBuilder builder)
    {
        builder.AddBuiltinQt(BuiltinQt.Burst);
        builder.AddBuiltinQt(BuiltinQt.Potion);
        builder.AddBuiltinQt(BuiltinQt.Hold);
        builder.AddBuiltinQt(BuiltinQt.Mitigation);
        builder.AddBuiltinQt(BuiltinQt.AoE);
        builder.AddBuiltinQt(BuiltinQt.Dump);
        builder.AddBuiltinQt(BuiltinQt.TTK);

        builder.AddQtToggle(QTKey.爆发, "爆发模式", true);
        builder.AddQtToggle(QTKey.血乱, "使用血乱", true);
        builder.AddQtToggle(QTKey.暗影锋, "使用暗影锋", true);
        builder.AddQtToggle(QTKey.掠影, "使用掠影", true);
        builder.AddQtToggle(QTKey.腐秽大地, "使用腐秽大地", true);
        builder.AddQtToggle(QTKey.精雕怒斩, "使用精雕怒斩", true);
        builder.AddQtToggle(QTKey.暗影使者, "使用暗影使者", true);
        builder.AddQtToggle(QTKey.减伤, "使用减伤", false);
    }
}
