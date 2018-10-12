// Decompiled with JetBrains decompiler
// Type: PLConvert.PLSafeCustType
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLSafeCustType : StaticData
  {
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    private CPostItem m_Description;
    private CPostItem m_StageGroup;
    private CPostItem m_ReminderDays;

    public string Description
    {
      get
      {
        return this.m_Description.sValue;
      }
      set
      {
        this.m_Description.SetValue(value);
      }
    }

    public string ReminderDays
    {
      get
      {
        return this.m_ReminderDays.sValue;
      }
      set
      {
        this.m_ReminderDays.SetValue(value);
      }
    }

    public string StageGroup
    {
      get
      {
        return this.m_StageGroup.sValue;
      }
      set
      {
        this.m_StageGroup.SetValue(value);
      }
    }

    public PLSafeCustType()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustType.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustType.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustType.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustType.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLSafeCustType.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustType.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLSafeCustType.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustType.m_MapNNtoID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLSafeCustType.GetIDFromNN(this.NickName) > 0)
        this.NickName = this.MakeNN(true);
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 4 ? 1 : 0)) != 0)
        this.NickName = this.MakeNN(true);
      this.m_Status.AddField(this.m_hndPOST);
      this.m_ID.AddField(this.m_hndPOST);
      this.m_NickName.AddField(this.m_hndPOST);
      this.m_Description.AddField(this.m_hndPOST);
      this.m_StageGroup.AddField(this.m_hndPOST);
      this.m_ReminderDays.AddField(this.m_hndPOST);
      this.m_ExternalID_1.AddField(this.m_hndPOST);
      this.m_ExternalID_2.AddField(this.m_hndPOST);
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLSafeCustType plSafeCustType = this;
      plSafeCustType.m_lCounter = plSafeCustType.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      this.m_Status.Clear();
      this.m_ID.Clear();
      this.m_NickName.Clear();
      this.m_Description.Clear();
      this.m_StageGroup.Clear();
      this.m_ReminderDays.Clear();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLSafeCustType.m_MapExtID1toPLID == null)
        return;
      PLSafeCustType.m_MapExtID1toPLID.Clear();
      PLSafeCustType.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLSafeCustType.m_MapExtID2toPLID == null)
        return;
      PLSafeCustType.m_MapExtID2toPLID.Clear();
      PLSafeCustType.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLSafeCustType.m_MapIDtoNN == null)
        return;
      PLSafeCustType.m_MapIDtoNN.Clear();
      PLSafeCustType.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLSafeCustType.m_MapNNtoID == null)
        return;
      PLSafeCustType.m_MapNNtoID.Clear();
      PLSafeCustType.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public override void GetExistingRecord()
    {
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLSafeCustType.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustType.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLSafeCustType.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustType.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLSafeCustType.bRead)
        PLSafeCustType.ReadTable();
      Key = Key.ToUpper();
      return PLSafeCustType.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustType.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLSafeCustType.bRead)
        PLSafeCustType.ReadTable();
      return PLSafeCustType.m_MapIDtoNN.ContainsKey(nID) ? PLSafeCustType.m_MapIDtoNN[nID].ToString() : "";
    }

    public override void GetRecord()
    {
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      this.m_Status.GetField(this.m_hndGET);
      this.m_ID.GetField(this.m_hndGET);
      this.m_NickName.GetField(this.m_hndGET);
      this.m_Description.GetField(this.m_hndGET);
      this.m_StageGroup.GetField(this.m_hndGET);
      this.m_ReminderDays.GetField(this.m_hndGET);
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "SafeCustType";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      this.m_Status = new CPostItem(CPostItem.DataType.LONG, "SCTypeStatus");
      this.m_ID = new CPostItem(CPostItem.DataType.LONG, "SCTypeID");
      this.m_StageGroup = new CPostItem(CPostItem.DataType.LONG, "SCTypeStageGroupID");
      this.m_ReminderDays = new CPostItem(CPostItem.DataType.LONG, "SCTypeRemindDays");
      this.m_NickName = new CPostItem(CPostItem.DataType.STRING, "SCTypeNickName");
      this.m_Description = new CPostItem(CPostItem.DataType.STRING, "SCTypeDescription");
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLSafeCustType.bRead)
        PLSafeCustType.ReadTable();
      string str = this.MakeListNN(this.Description, StaticData.m_NNs, (short) 6);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    public string MakeNN(List<string> ListNNs, bool bSetNickName)
    {
      if (!PLSafeCustType.bRead)
        PLSafeCustType.ReadTable();
      string str = this.MakeListNN(this.Description, ListNNs, (short) 6);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLSafeCustType.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("SafeCustType", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "SCTypeStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "SCTypeNickName", "", ref szValue);
        string Key = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "SCTypeID");
        PLSafeCustType.AddMapNNtoID(Key, recordFieldValueI32);
        PLSafeCustType.AddMapIDtoNN(recordFieldValueI32, Key);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLSafeCustType.bRead = true;
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
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLSafeCustType.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLSafeCustType.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustType.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustType.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
