// Decompiled with JetBrains decompiler
// Type: PLConvert.PLSafeCustStageGroup
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLSafeCustStageGroup : StaticData
  {
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    private CPostItem m_Flags;

    public string Flags
    {
      get
      {
        return this.m_Flags.sValue;
      }
      set
      {
        this.m_Flags.SetValue(value);
      }
    }

    public PLSafeCustStageGroup()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustStageGroup.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStageGroup.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustStageGroup.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStageGroup.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLSafeCustStageGroup.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStageGroup.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLSafeCustStageGroup.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStageGroup.m_MapNNtoID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLSafeCustStageGroup.GetIDFromNN(this.NickName) > 0)
        this.NickName = this.MakeNN(true);
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 4 ? 1 : 0)) != 0)
        this.NickName = this.MakeNN(true);
      this.m_Status.AddField(this.m_hndPOST);
      this.m_ID.AddField(this.m_hndPOST);
      this.m_NickName.AddField(this.m_hndPOST);
      this.m_Flags.AddField(this.m_hndPOST);
      this.m_ExternalID_1.AddField(this.m_hndPOST);
      this.m_ExternalID_2.AddField(this.m_hndPOST);
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLSafeCustStageGroup safeCustStageGroup = this;
      safeCustStageGroup.m_lCounter = safeCustStageGroup.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      this.m_Status.Clear();
      this.m_ID.Clear();
      this.m_NickName.Clear();
      this.m_Flags.Clear();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLSafeCustStageGroup.m_MapExtID1toPLID == null)
        return;
      PLSafeCustStageGroup.m_MapExtID1toPLID.Clear();
      PLSafeCustStageGroup.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLSafeCustStageGroup.m_MapExtID2toPLID == null)
        return;
      PLSafeCustStageGroup.m_MapExtID2toPLID.Clear();
      PLSafeCustStageGroup.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLSafeCustStageGroup.m_MapIDtoNN == null)
        return;
      PLSafeCustStageGroup.m_MapIDtoNN.Clear();
      PLSafeCustStageGroup.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLSafeCustStageGroup.m_MapNNtoID == null)
        return;
      PLSafeCustStageGroup.m_MapNNtoID.Clear();
      PLSafeCustStageGroup.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public override void GetExistingRecord()
    {
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLSafeCustStageGroup.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustStageGroup.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLSafeCustStageGroup.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustStageGroup.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLSafeCustStageGroup.bRead)
        PLSafeCustStageGroup.ReadTable();
      Key = Key.ToUpper();
      return PLSafeCustStageGroup.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustStageGroup.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLSafeCustStageGroup.bRead)
        PLSafeCustStageGroup.ReadTable();
      return PLSafeCustStageGroup.m_MapIDtoNN.ContainsKey(nID) ? PLSafeCustStageGroup.m_MapIDtoNN[nID].ToString() : "";
    }

    public override void GetRecord()
    {
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      this.m_Status.GetField(this.m_hndGET);
      this.m_ID.GetField(this.m_hndGET);
      this.m_NickName.GetField(this.m_hndGET);
      this.m_Flags.GetField(this.m_hndGET);
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "SafeCustStageGroup";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      this.m_Status = new CPostItem(CPostItem.DataType.LONG, "SCStageGroupStatus");
      this.m_ID = new CPostItem(CPostItem.DataType.LONG, "SCStageGroupID");
      this.m_Flags = new CPostItem(CPostItem.DataType.LONG, "SCStageGroupFlags");
      this.m_NickName = new CPostItem(CPostItem.DataType.STRING, "SCStageGroupDescription");
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    private static void ReadTable()
    {
      if (PLSafeCustStageGroup.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("SafeCustStageGroup", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "SCStageGroupStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "SCStageGroupDescription", "", ref szValue);
        string Key = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "SCStageGroupID");
        PLSafeCustStageGroup.AddMapNNtoID(Key, recordFieldValueI32);
        PLSafeCustStageGroup.AddMapIDtoNN(recordFieldValueI32, Key);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLSafeCustStageGroup.bRead = true;
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
      this.m_lSendErrorCount = 0L;
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLSafeCustStageGroup safeCustStageGroup = this;
        safeCustStageGroup.m_lSendErrorCount = safeCustStageGroup.m_lSendErrorCount + 1L;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLSafeCustStageGroup.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLSafeCustStageGroup.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustStageGroup.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustStageGroup.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
