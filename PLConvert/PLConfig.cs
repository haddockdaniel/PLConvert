// Decompiled with JetBrains decompiler
// Type: PLConvert.PLConfig
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLConfig : StaticData
  {
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static Dictionary<string, string> m_MapNametoValue = new Dictionary<string, string>();
    private static Dictionary<string, string> m_MapNametoSection = new Dictionary<string, string>();
    private static bool bRead = false;
    private CPostItem m_UserID;
    private CPostItem m_Name;
    private CPostItem m_Section;
    private CPostItem m_Value;

    public string Name
    {
      get
      {
        return this.m_Name.sValue;
      }
      set
      {
        this.m_Name.SetValue(value);
      }
    }

    public string Section
    {
      get
      {
        return this.m_Section.sValue;
      }
      set
      {
        this.m_Section.SetValue(value);
      }
    }

    public int UserID
    {
      get
      {
        return this.m_UserID.nValue;
      }
      set
      {
        this.m_UserID.SetValue(value);
      }
    }

    public string Value
    {
      get
      {
        return this.m_Value.sValue;
      }
      set
      {
        this.m_Value.SetValue(value);
      }
    }

    public PLConfig()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLConfig.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLConfig.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLConfig.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLConfig.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLConfig.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLConfig.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNametoSection(string Key, string Section)
    {
      Key = Key.ToUpper();
      if (Key.Equals(""))
        return;
      if (!PLConfig.m_MapNametoSection.ContainsKey(Key))
        PLConfig.m_MapNametoSection.Add(Key, Section);
      else
        PLConfig.m_MapNametoSection[Key] = Section;
    }

    public static void AddMapNametoValue(string Key, string Value)
    {
      Key = Key.ToUpper();
      if (Key.Equals(""))
        return;
      if (!PLConfig.m_MapNametoValue.ContainsKey(Key))
        PLConfig.m_MapNametoValue.Add(Key, Value);
      else
        PLConfig.m_MapNametoValue[Key] = Value;
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLConfig.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLConfig.m_MapNNtoID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      if (!this.m_Name.m_bIsSet)
        this.Name = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet ? (PLConfig.GetIDFromNN(this.Name) > 0 ? 1 : 0) : 0) != 0)
        this.Name = this.MakeNN(true);
      StaticData.AddNicknameToList(this.Name);
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLConfig plConfig = this;
      plConfig.m_lCounter = plConfig.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLConfig.m_MapExtID1toPLID == null)
        return;
      PLConfig.m_MapExtID1toPLID.Clear();
      PLConfig.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLConfig.m_MapExtID2toPLID == null)
        return;
      PLConfig.m_MapExtID2toPLID.Clear();
      PLConfig.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLConfig.m_MapIDtoNN == null)
        return;
      PLConfig.m_MapIDtoNN.Clear();
      PLConfig.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNametoSection()
    {
      if (PLConfig.m_MapNametoSection == null)
        return;
      PLConfig.m_MapNametoSection.Clear();
      PLConfig.m_MapNametoSection = (Dictionary<string, string>) null;
    }

    public static void ClearMapNametoValue()
    {
      if (PLConfig.m_MapNametoValue == null)
        return;
      PLConfig.m_MapNametoValue.Clear();
      PLConfig.m_MapNametoValue = (Dictionary<string, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLConfig.m_MapNNtoID == null)
        return;
      PLConfig.m_MapNNtoID.Clear();
      PLConfig.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static int GetIDFromExtID1(string Key)
    {
      int num;
      if (!Key.Equals(""))
      {
        if (!PLConfig.bRead)
          PLConfig.ReadTable();
        num = PLConfig.m_MapExtID1toPLID == null ? 0 : (PLConfig.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLConfig.m_MapExtID1toPLID[Key]) : 0);
      }
      else
        num = 0;
      return num;
    }

    public static int GetIDFromExtID2(string Key)
    {
      int num;
      if (!Key.Equals((object) 0))
      {
        if (!PLConfig.bRead)
          PLConfig.ReadTable();
        num = PLConfig.m_MapExtID2toPLID == null ? 0 : (PLConfig.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLConfig.m_MapExtID2toPLID[Key]) : 0);
      }
      else
        num = 0;
      return num;
    }

    public static int GetIDFromNN(string Key)
    {
      int num;
      if (!Key.Equals(""))
      {
        if (!PLConfig.bRead)
          PLConfig.ReadTable();
        if (PLConfig.m_MapNNtoID != null)
        {
          Key = Key.ToUpper();
          num = PLConfig.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLConfig.m_MapNNtoID[Key]) : 0;
        }
        else
          num = 0;
      }
      else
        num = 0;
      return num;
    }

    public static string GetNNFromID(int nID)
    {
      string str;
      if (!nID.Equals(0))
      {
        if (!PLConfig.bRead)
          PLConfig.ReadTable();
        str = PLConfig.m_MapIDtoNN == null ? "" : (PLConfig.m_MapIDtoNN.ContainsKey(nID) ? PLConfig.m_MapIDtoNN[nID].ToString() : "");
      }
      else
        str = "";
      return str;
    }

    public static string GetSectionFromName(string Key)
    {
      string str;
      if (!Key.Equals(""))
      {
        if (!PLConfig.bRead)
          PLConfig.ReadTable();
        if (PLConfig.m_MapNametoSection != null)
        {
          Key = Key.ToUpper();
          str = PLConfig.m_MapNametoSection.ContainsKey(Key) ? Convert.ToString(PLConfig.m_MapNametoSection[Key]) : "";
        }
        else
          str = "";
      }
      else
        str = "";
      return str;
    }

    public static string GetValueFromName(string Key)
    {
      string str;
      if (!Key.Equals(""))
      {
        if (!PLConfig.bRead)
          PLConfig.ReadTable();
        if (PLConfig.m_MapNametoValue != null)
        {
          Key = Key.ToUpper();
          str = PLConfig.m_MapNametoValue.ContainsKey(Key) ? Convert.ToString(PLConfig.m_MapNametoValue[Key]) : "";
        }
        else
          str = "";
      }
      else
        str = "";
      return str;
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "Configuration";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "ConfigStatus");
      CPostItem cpostItem2 = cpostItem1;
      this.m_Status = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "ConfigID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_ID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "ConfigUserID");
      CPostItem cpostItem6 = cpostItem5;
      this.m_UserID = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "ConfigName");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Name = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.STRING, "ConfigSection");
      CPostItem cpostItem10 = cpostItem9;
      this.m_Section = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.STRING, "ConfigValue");
      CPostItem cpostItem12 = cpostItem11;
      this.m_Value = cpostItem11;
      postItems6.Add(cpostItem12);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      return this.Name;
    }

    private static void ReadTable()
    {
      if (PLConfig.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("Configuration", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "ConfigStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "ConfigName", "", ref szValue);
        string str = szValue.ToString().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "ConfigID");
        PLConfig.AddMapNNtoID(str, recordFieldValueI32);
        PLConfig.AddMapIDtoNN(recordFieldValueI32, str);
        StaticData.AddNicknameToList(str);
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "ConfigValue", "", ref szValue);
        PLConfig.AddMapNametoValue(str, szValue.ToString().Trim());
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "ConfigSection", "", ref szValue);
        PLConfig.AddMapNametoSection(str, szValue.ToString().Trim());
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLConfig.bRead = true;
    }

    public static void RereadList()
    {
      PLConfig.m_MapNNtoID.Clear();
      PLConfig.m_MapIDtoNN.Clear();
      StaticData.ClearNickNameList();
      PLConfig.m_MapNametoValue.Clear();
      PLConfig.m_MapNametoSection.Clear();
      PLConfig.bRead = false;
    }

    public int ResetQuickBooksConnection()
    {
      if (!PLConfig.bRead)
        PLConfig.ReadTable();
      Dictionary<string, int>.Enumerator enumerator = PLConfig.m_MapNNtoID.GetEnumerator();
      while (enumerator.MoveNext())
      {
        KeyValuePair<string, int> current = enumerator.Current;
        bool flag;
        if (!current.Key.ToLower().Contains("qb_companyname"))
        {
          current = enumerator.Current;
          if (!current.Key.ToLower().Contains("qb_lastsyncdate"))
          {
            current = enumerator.Current;
            if (!current.Key.ToLower().Contains("qb_pclaw_"))
            {
              current = enumerator.Current;
              flag = !current.Key.ToLower().Contains("qb_employee_");
              goto label_8;
            }
          }
        }
        flag = false;
label_8:
        if (!flag)
        {
          current = enumerator.Current;
          if (current.Value != 0)
          {
            current = enumerator.Current;
            this.ReadExisting((uint) current.Value);
            this.Value = string.Empty;
            this.Section = string.Empty;
            this.UserID = 0;
          }
        }
      }
      return PLLink.GetLink().ResetAllQuickBooksIDs();
    }

    public override void Send()
    {
      object nProcessed = new object();
      object nExceptions = new object();
      object vunIDCreated = new object();
      object nExceptionError = new object();
      object szExceptionErrorMsg = new object();
      object szExceptionSentData = new object();
      object szValue = new object();
      string szDefault = "";
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      this.m_lSendErrorCount = 0L;
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLConfig plConfig = this;
        plConfig.m_lSendErrorCount = plConfig.m_lSendErrorCount + 1L;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_Name.sLinkName, szDefault, ref szValue);
          string Key = szValue.ToString();
          PLConfig.AddMapIDtoNN(int32, Key);
          PLConfig.AddMapNNtoID(Key, int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLConfig.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLConfig.AddMapExtID2toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_Value.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLConfig.AddMapNametoValue(Key, szValue.ToString());
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }

    public void WriteValueToPCLawConfig(string sName, string sValue, string sSection, int nUserID)
    {
      uint idFromNn = (uint) PLConfig.GetIDFromNN(sName);
      if ((int) idFromNn == 0)
      {
        this.Status = PLXMLData.eSTATUS.ACTIVE;
        this.Name = sName;
        this.Value = sValue;
        this.Section = sSection;
        this.UserID = nUserID;
      }
      else
      {
        this.ReadExisting(idFromNn);
        this.Value = sValue;
        this.Section = sSection;
        this.UserID = nUserID;
      }
      this.AddRecord();
      this.SendLast();
    }
  }
}
