
namespace 嗨呀.黑魔.UI;

public class BLMRotationUI : IRotationUI
{
    public void RegisterControls(IUiBuilder builder)
    {
        //QT
        builder.AddBuiltinQt(BuiltinQt.Burst);
        builder.AddBuiltinQt(BuiltinQt.Potion);
        builder.AddBuiltinQt(BuiltinQt.Hold);
        builder.AddBuiltinQt(BuiltinQt.Mitigation);
    }
    
}