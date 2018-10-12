// Decompiled with JetBrains decompiler
// Type: PLConvert.PLSettings.SettingsList
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections;

namespace PLConvert.PLSettings
{
  public class SettingsList
  {
    private Hashtable m_ht = new Hashtable();
    internal string[] m_sFields;
    internal bool m_bWasReadFromFile;

    public int Count
    {
      get
      {
        return this.m_ht.Count;
      }
    }

    public string this[string sField]
    {
      get
      {
        return this.m_ht[(object) sField].ToString();
      }
      set
      {
        if (!this.m_ht.ContainsKey((object) sField))
          return;
        this.m_ht[(object) sField] = (object) value.Trim();
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

    public SettingsList()
    {
      this.m_sFields = new string[0];
    }

    public SettingsList(string[] sFields)
    {
      this.m_sFields = sFields;
      foreach (object sField in this.m_sFields)
        this.m_ht.Add(sField, (object) "");
    }

    public void Add(string sField)
    {
      this.Add(sField, "");
    }

    public void Add(string[] sFields)
    {
      foreach (string sField in sFields)
        this.Add(sField);
    }

    public void Add(string sField, string sValue)
    {
      Array.Resize<string>(ref this.m_sFields, this.m_sFields.Length + 1);
      this.m_sFields[this.m_sFields.GetUpperBound(0)] = sField;
      this.m_ht.Add((object) sField, (object) sValue.Trim());
    }

    public bool ContainsField(string sField)
    {
      return this.m_ht.ContainsKey((object) sField);
    }

    public bool ContainsValue(string sValue)
    {
      return this.m_ht.ContainsValue((object) sValue);
    }

    public IDictionaryEnumerator GetEnumerator()
    {
      return this.m_ht.GetEnumerator();
    }

    public void Reset()
    {
      foreach (object sField in this.m_sFields)
        this.m_ht[sField] = (object) "";
      this.WasReadFromFile = false;
    }
  }
}
