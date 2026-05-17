namespace 嗨呀.龙骑.UI;

public class DRGRotationUI : IRotationUI
{
    public void RegisterControls(IUiBuilder builder)
    {
        builder.AddBuiltinQt(BuiltinQt.Burst);
        builder.AddBuiltinQt(BuiltinQt.Potion);
        builder.AddBuiltinQt(BuiltinQt.Hold);
        builder.AddBuiltinQt(BuiltinQt.Mitigation);
        builder.AddBuiltinQt(BuiltinQt.AoE);
        builder.AddBuiltinQt(BuiltinQt.TTK);

        builder.AddQtToggle(QTKey.爆发, "爆发模式", true);
        builder.AddQtToggle(QTKey.真北, "自动真北", true);
        builder.AddQtToggle(QTKey.自动减伤, "自动减伤", true);
    }
}
