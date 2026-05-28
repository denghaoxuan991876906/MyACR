namespace 嗨呀.舞者.UI;

public class DNCRotationUI : IRotationUI
{
    public void RegisterControls(IAcrUiBuilder builder)
    {
        builder.AddBuiltinQt(BuiltinQt.Burst);
        builder.AddBuiltinQt(BuiltinQt.Potion);
        builder.AddBuiltinQt(BuiltinQt.Hold);
        builder.AddBuiltinQt(BuiltinQt.Mitigation);
        builder.AddBuiltinQt(BuiltinQt.AoE);

        builder.AddQtToggle(QTKey.小舞, true);
        builder.AddQtToggle(QTKey.大舞, true);
        builder.AddQtToggle(QTKey.剑舞, true);
        builder.AddQtToggle(QTKey.百花, true);
        builder.AddQtToggle(QTKey.探戈, true);
        builder.AddQtToggle(QTKey.扇舞, true);
    }
}
