using System;

public static class Characters
{
    public static BaseChar EricFrost = new BaseChar("Eric Frost", 1, 0, 
        setupEricsStat(), Archetypes.Stormer, 
        Helper.getImage("character pics/stormer"), setupEricsItems());
    public static BaseChar FrostEric = new BaseChar("Frost Eric", 1, 0,
        setupEricsStat(), Archetypes.Stormer,
        Helper.getImage("character pics/stormer"), setupEricsItems());

    private static BaseStat[] setupEricsStat()
    {
        BaseStat[] attr;
        attr = new BaseStat[Enum.GetValues(typeof(AttrNames)).Length];

        for (int i = 0; i < attr.Length; i++)
            attr[i] = new BaseStat(((AttrNames)i).ToString());

        attr[(int)AttrNames.Strength].baseValue = 30;
        attr[(int)AttrNames.Dexterity].baseValue = 15;
        attr[(int)AttrNames.Vitality].baseValue = 20;
        attr[(int)AttrNames.Soulpower].baseValue = 10;
        attr[(int)AttrNames.Technique].baseValue = 10;

        return attr;
    }

    private static Item[] setupEricsItems()
    {
        Item[] items = new Item[] {Items.MarineArmor, Items.RangerArmor,
            Items.MedicKit, Items.Pistol1, Items.BladeStaff, 
            Items.CombatKnife, Items.FlameThrower, Items.LaserCarbine,
            Items.PlasmaRifle};

        return items;
    }
}
