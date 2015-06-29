using UnityEngine;
using System.Collections;

public  abstract class Ability : MonoBehaviour
{
    public int Level{get;set;}
    public abstract void SpellCast();//施放技能

    //万能环绕 (命令unit围绕triggerUnit环绕,角速度,离心速度,提升速度,持续时间,刷新周期)
    public static void Around(Unit unit, Unit triggerUnit, float angleRate, float displacement, float riseRate, float timeout, float interval)
    {
        
    }
    void test()
    {
        
    }
 //   public abstract void LearnedSkill();//学习技能
}
