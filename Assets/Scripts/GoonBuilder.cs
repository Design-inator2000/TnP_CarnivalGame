using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GoonBuilder
{
    protected TargetBehavior targetBehavior;
    protected GameObject goonPrefab;

    public ObjectPool<TargetBehavior> pool { get; protected set; }

    public GoonBuilder(GameObject myGoonPrefab)
    {
        goonPrefab = myGoonPrefab;
        pool = new ObjectPool<TargetBehavior> ( 25, goonPrefab );
    }

    public TargetBehavior ConstructGoon(Vector3 position)
    {
        targetBehavior = pool.Spawn(position);
        SetSpeed();
        SetPointVal();
        SetSprite();
        return targetBehavior;
    }

    protected abstract void SetSpeed();
    
    protected abstract void SetPointVal();

    protected abstract void SetSprite();
}

public class HatGoon : GoonBuilder
{
    public HatGoon(GameObject myGoonPrefab) : base(myGoonPrefab)
    {
    }

    protected override void SetPointVal()
    {
        targetBehavior.SetPointVal(30);
    }

    protected override void SetSpeed()
    {
        targetBehavior.SetSpeed(2f);
    }

    protected override void SetSprite()
    {
        targetBehavior.SetSprite(0);
    }
}

public class ParaGoon : GoonBuilder
{
    public ParaGoon(GameObject myGoonPrefab) : base(myGoonPrefab)
    {
    }

    protected override void SetPointVal()
    {
        targetBehavior.SetPointVal(50);
    }

    protected override void SetSpeed()
    {
        targetBehavior.SetSpeed(3f);
    }

    protected override void SetSprite()
    {
        targetBehavior.SetSprite(2);
    }
}

public class HeliGoon : GoonBuilder
{
    public HeliGoon(GameObject myGoonPrefab) : base(myGoonPrefab)
    {
    }

    protected override void SetPointVal()
    {
        targetBehavior.SetPointVal(75);
    }

    protected override void SetSpeed()
    {
        targetBehavior.SetSpeed(4f);
    }

    protected override void SetSprite()
    {
        targetBehavior.SetSprite(1);
    }
}


