using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TestJson 
{
    public string equipment_number { get; set; }
    public string equipment_name { get; set; }
    public string equipment_level { get; set; }
    public string equipment_type { get; set; }
    public string attack_bonus { get; set; }
    public string defense_bonus { get; set; }
    public string health_bonus { get; set; }
    public string equipment_description { get; set; }
    public string rarity { get; set; }
}




public class TestJsonRoot
{
    /// <summary>
    /// 
    /// </summary>
    public List<TestJson> TestData { get; set; }
}
