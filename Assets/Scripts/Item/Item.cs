using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int itemId;
    public string itemName;
    public Effect effect;

    public void Use()
    {
        if (effect != null)
        {
            effect.Activate();
        }
    }
}

[System.Serializable]
public class Effect
{
    public string effectName;
    public float effectValue;

    public virtual void Activate()
    {
        Debug.Log("Effect activated: " + effectName + ", value: " + effectValue);
    }
}

public class ExampleEffect : Effect
{
    public override void Activate()
    {
        base.Activate();
        // Add your custom code here
    }
}