// Decompiled with JetBrains decompiler
// Type: PLConvert.PLSettings.SettingsContainer
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;

namespace PLConvert.PLSettings
{
  public class SettingsContainer
  {
    private Hashtable m_ht = new Hashtable();
    private string[] m_sLists;
    internal bool m_bWasReadFromFile;

    public int Count
    {
      get
      {
        return this.m_ht.Count;
      }
    }

    public SettingsList this[string sList]
    {
      get
      {
        return (SettingsList) this.m_ht[(object) sList];
      }
      set
      {
        if (!this.m_ht.ContainsKey((object) sList))
          return;
        this.m_ht[(object) sList] = (object) value;
      }
    }

    public bool WasReadFromFile
    {
      get
      {
        return this.m_bWasReadFromFile;
      }
      internal set
      {
        this.m_bWasReadFromFile = value;
      }
    }

    public SettingsContainer()
    {
      this.m_sLists = new string[0];
    }

    public SettingsContainer(string[] sLists)
    {
      this.m_sLists = sLists;
      foreach (object sList in this.m_sLists)
        this.m_ht.Add(sList, (object) "");
    }

    public void Add(string sList)
    {
      this.Add(sList, new SettingsList());
    }

    public void Add(string[] sLists)
    {
      foreach (string sList in sLists)
        this.Add(sList);
    }

    public void Add(string sList, string[] sFields)
    {
      this.m_ht.Add((object) sList, (object) new SettingsList(sFields));
    }

    public void Add(string sList, SettingsList Fields)
    {
      Array.Resize<string>(ref this.m_sLists, this.m_sLists.Length + 1);
      this.m_sLists[this.m_sLists.GetUpperBound(0)] = sList;
      this.m_ht.Add((object) sList, (object) Fields);
    }

    public bool ContainsList(string sList)
    {
      return this.m_ht.ContainsKey((object) sList);
    }

    public void ReadFromFile(string sFile)
    {
      XmlDocument xmlDocument = new XmlDocument();
      if (!File.Exists(sFile))
        return;
      xmlDocument.Load(sFile);
      XmlNode documentElement = (XmlNode) xmlDocument.DocumentElement;
      foreach (string sList in this.m_sLists)
      {
        if (documentElement[sList] != null)
        {
          this[sList].WasReadFromFile = true;
          XmlNode xmlNode = (XmlNode) documentElement[sList];
          foreach (string sField in this[sList].m_sFields)
          {
            if (xmlNode[sField] != null)
              this[sList][sField] = xmlNode[sField].InnerText;
          }
        }
      }
    }

    public void Reset()
    {
      foreach (string sList in this.m_sLists)
        this[sList].Reset();
      this.WasReadFromFile = false;
    }

    public void WriteToFile(string sFile)
    {
      XmlTextWriter xmlTextWriter = new XmlTextWriter(sFile, (Encoding) null);
      xmlTextWriter.WriteStartDocument();
      xmlTextWriter.Indentation = 4;
      xmlTextWriter.Settings.NewLineChars = "\r\n";
      xmlTextWriter.Flush();
      xmlTextWriter.WriteComment("This document contains the settings for LBConvert");
      xmlTextWriter.Flush();
      xmlTextWriter.WriteStartElement("ConvSettings");
      foreach (string sList in this.m_sLists)
      {
        xmlTextWriter.WriteStartElement(sList);
        foreach (string sField in this[sList].m_sFields)
        {
          xmlTextWriter.WriteElementString(sField, this[sList][sField]);
          xmlTextWriter.Flush();
        }
        xmlTextWriter.WriteEndElement();
        xmlTextWriter.Flush();
      }
      xmlTextWriter.WriteEndDocument();
      xmlTextWriter.Close();
    }
  }
}
