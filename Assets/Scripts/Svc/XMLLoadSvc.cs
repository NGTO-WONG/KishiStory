using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XMLLoadSvc : BaseManager<XMLLoadSvc>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    //public T LoadXML<T>(string xmlPath) where T:new()
    //{
    //    List<string> FirstNameList = new List<string>();
    //    List<string> LastNameList = new List<string>();
    //    var xml = ResMgr.GetInstance().Load<TextAsset>(xmlPath);
    //    XmlDocument doc = new XmlDocument();
    //    doc.LoadXml(xml.text);
    //    XmlNodeList nodeList = doc.SelectSingleNode("root").ChildNodes;
    //    int index = 0;


    //    T t = new T();

    //    //Debug.Log(item.Name + item.InnerText);
    //    foreach (XmlElement item2 in nodeList[index])
    //    {
    //        switch (item2.Name)
    //        {
    //            case "mapName":
    //                mapCfg.mapName = item2.InnerText;
    //                break;
    //            case "sceneName":
    //                mapCfg.sceneName = item2.InnerText;
    //                break;
    //            case "mainCamPos":
    //                mapCfg.mainCamPos = StringToV3(item2.InnerText);
    //                break;
    //            case "mainCamRote":
    //                mapCfg.mainCamRote = StringToV3(item2.InnerText);
    //                break;
    //            case "playerBornPos":
    //                mapCfg.playerBornPos = StringToV3(item2.InnerText);
    //                break;
    //            case "playerBornRote":
    //                mapCfg.playerBornRote = StringToV3(item2.InnerText);
    //                break;
    //        }
    //    }

    //    return mapCfg;
    //}

    public List<Equipment> LoadEqpXML()
    {
        List<string> FirstNameList = new List<string>();
        List<string> LastNameList = new List<string>();
        var xml = ResMgr.GetInstance().Load<TextAsset>(GameConfig.XML_equipment);
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml.text);
        XmlNodeList nodeList = doc.SelectSingleNode("root").ChildNodes;
        int index = 0;


        List<Equipment> tempList = new List<Equipment>();

        foreach (XmlElement item in nodeList)
        {

            foreach (XmlElement item2 in item)
            {

                //Debug.Log(item2.Name + "  " + item2.InnerText);
                Equipment tempEquipment = new Equipment();
                switch (item2.Name)
                {
                    case "id":
                        Debug.Log(item2.InnerText);
                        tempEquipment.id = int.Parse(item2.InnerText);
                        break;
                    case "name":
                        Debug.Log(item2.InnerText);

                        tempEquipment.name = item2.InnerText;
                        break;
                }
                tempList.Add(tempEquipment);
            }
        }
        

        return tempList;
    }



}
