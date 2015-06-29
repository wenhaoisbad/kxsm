using UnityEngine;
using System;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;


public class NTSystrm 
{
    //Object To Xml 文件
    public static bool Serializer<T>(object obj, string path)
    {
        FileStream xmlfile = new FileStream(path, FileMode.OpenOrCreate);

        //创建序列化对象 
        XmlSerializer xml = new XmlSerializer(typeof(T));
        try
        {    //序列化对象
            xml.Serialize(xmlfile, obj);
            xmlfile.Close();
        }
        catch (InvalidOperationException)
        {
            throw;
        }

        return true;

    }
    //Xml To Object
    public static T Deserializer<T>(string path)
    {
        try
        {
            FileStream xmlfile = new FileStream(path, FileMode.Open);

            XmlSerializer xml = new XmlSerializer(typeof(T));
            //序列化对象 
            //xmlfile.Close(); 
            T t = (T)xml.Deserialize(xmlfile);
            xmlfile.Close();
            return t;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (FileNotFoundException)
        { throw; }
    }

}
