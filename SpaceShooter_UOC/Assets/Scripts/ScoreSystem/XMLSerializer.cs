using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System;

public class XMLSerializer : BaseSerializer
{
    string path = Application.persistentDataPath;

    public override Data LoadData(string fileName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        string[] files = Directory.GetFiles(path);

        if (files.Length > 0)
        {
            StreamReader stream = null;
            foreach (string file in files)
            {
                stream = new StreamReader(path + "/" + fileName + "Data.xml");
                Data data = (Data) serializer.Deserialize(stream);
                if(data.level == fileName)
                {
                    stream.Close();
                    return data;
                }
            }
        }
        else
        {
            Debug.LogWarning("No se han encontrado datos guardados");
        }
        return null;
    }

    public override void SaveData(Data data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        StreamWriter streamWriter = null;
        try
        {

            streamWriter = new StreamWriter(path + "/" + data.level + "Data.xml");
            serializer.Serialize(streamWriter.BaseStream, data);
        }
        catch (Exception e) {
            Debug.LogError("Error al intentar guardar los datos:" + e.Message);
        }
        finally
        {
            if(streamWriter != null)
                streamWriter.Close();
        }
    }

 
}
