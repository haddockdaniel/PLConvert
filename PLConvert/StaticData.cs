// Decompiled with JetBrains decompiler
// Type: PLConvert.StaticData
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public abstract class StaticData : PLXMLData
  {
    protected static List<string> m_NNs = new List<string>();
    protected CPostItem m_NickName;
    protected string sNicknameLinkName;

    public string NickName
    {
      get
      {
        return this.m_NickName.sValue;
      }
      set
      {
        this.m_NickName.SetValue(value);
      }
    }

    public string NickName_LinkName
    {
      get
      {
        return this.sNicknameLinkName;
      }
    }

    protected static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (StaticData.m_NNs == null)
        StaticData.m_NNs = new List<string>();
      StaticData.m_NNs.Add(sNickname.ToLower());
    }

    public static void ClearNickNameList()
    {
      StaticData.m_NNs.Clear();
    }

    protected virtual string MakeListNN(string sName, List<string> arrNN, short nNNLen)
    {
      string lower = this.MakeNN(sName).ToLower();
      string str1 = lower;
      int num = 0;
      while (true)
      {
        if ((arrNN.IndexOf(str1) < 0 ? 1 : (num >= 100 ? 1 : 0)) == 0)
        {
          ++num;
          string str2 = num.ToString();
          if (str2.Length <= (int) nNNLen)
            str1 = str2.Length + str1.Length > (int) nNNLen ? (str1.Length < (int) nNNLen ? lower.Substring(0, (int) nNNLen - ((int) nNNLen - str1.Length) - str2.Length) + num.ToString() : lower.Substring(0, (int) nNNLen - str2.Length) + num.ToString()) : lower + num.ToString();
          else
            break;
        }
        else
          goto label_5;
      }
      throw new Exception("Length of Nickname is too small");
label_5:
      return str1;
    }

    public abstract string MakeNN(bool bSetNickName);

    protected string MakeNN(string sName)
    {
      string[] strArray = sName.Replace("  ", " ").Split(' ');
      string str1 = "";
      if (strArray.Length != 1)
      {
        foreach (string str2 in strArray)
        {
          if (!str2.Trim().Equals(""))
            str1 += (string) (object) str2[0];
        }
      }
      else
        str1 = strArray[0].Length <= 4 ? strArray[0].Trim() : strArray[0].Substring(0, 4);
      return str1;
    }

    public string MakeNN()
    {
      return this.MakeNN(true);
    }
  }
}
