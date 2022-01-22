using System;

[Serializable]
public class Equipment
{

    public int id;
    public string name;
    public string imagePath;
    public string type;
    public string rarity;

    public int level;
    public int atk;
    public int def;
    public int hp;
    public int upgrade_gold;
    public string description;

    public Equipment GetClone()
    {
        Equipment tempEquipment = new Equipment();
        tempEquipment.id = this.id;
        tempEquipment.name = this.name;
        tempEquipment.imagePath = this.imagePath;
        tempEquipment.type = this.type;
        tempEquipment.rarity = this.rarity;
        tempEquipment.level = this.level;
        tempEquipment.atk = this.atk;
        tempEquipment.def = this.def;
        tempEquipment.hp = this.hp;
        tempEquipment.description = this.description;
        tempEquipment.upgrade_gold = this.upgrade_gold;

        return tempEquipment;
    }
}