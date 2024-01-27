using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

abstract public class Skill : MonoBehaviour
{
    abstract public void ActivateSkill();
}

public class AdrielSkill : Skill {
    public override void ActivateSkill()
    {
        throw new System.NotImplementedException();
    }
}
public class DianaSkill : Skill
{
    public override void ActivateSkill()
    {
        throw new System.NotImplementedException();
    }
}
public class MichealSkill : Skill
{
    public override void ActivateSkill()
    {
        throw new System.NotImplementedException();
    }
}