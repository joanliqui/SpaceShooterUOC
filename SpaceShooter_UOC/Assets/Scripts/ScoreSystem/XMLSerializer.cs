using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class XMLSerializer : BaseSerializer
{
    string path = Application.persistentDataPath;

    public override void SaveData(ScoreSO data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ScoreSO));
        StreamWriter stream = new StreamWriter(path + "/" + data.level + "Data.xml");
        serializer.Serialize(stream.BaseStream, data);
        stream.Close();
    }

    public override int LoadMaxScore()
    {
        return 4500;
    }
}
