using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props
{
    public int id;
    public string name;
    public int type;
    public string describe;
    public int rarity;
    public int useable;



    public Props GetClone()
    {
        Props tempProps = new Props();
        tempProps.id = this.id;
        tempProps.name = this.name;
        tempProps.type = this.type;
        tempProps.describe = this.describe;
        tempProps.rarity = this.rarity;
        tempProps.useable = this.useable;
        return tempProps;
    }
}
