namespace 嗨呀.舞者.UI;

public class DNCRotationUI : IRotationUI
{
    public void RegisterControls(IUiBuilder builder)
    {
        builder.AddBuiltinQt(BuiltinQt.Burst);
        builder.AddBuiltinQt(BuiltinQt.Potion);
        builder.AddBuiltinQt(BuiltinQt.Hold);
        builder.AddBuiltinQt(BuiltinQt.Mitigation);
        builder.AddBuiltinQt(BuiltinQt.AoE);

        builder.AddQtToggle(QTKey.小舞, "标准舞步", true);
        builder.AddQtToggle(QTKey.大舞, "技巧舞步", true);
        builder.AddQtToggle(QTKey.剑舞, "剑舞", true);
        builder.AddQtToggle(QTKey.百花, "百花争艳", true);
        builder.AddQtToggle(QTKey.探戈, "进攻之探戈", true);
        builder.AddQtToggle(QTKey.扇舞, "扇舞技能", true);
    }
}
