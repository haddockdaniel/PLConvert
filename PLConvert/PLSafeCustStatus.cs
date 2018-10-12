// Decompiled with JetBrains decompiler
// Type: PLConvert.PLSafeCustStatus
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLSafeCustStatus : StaticData
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

    public PLSafeCustStatus()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustStatus.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStatus.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustStatus.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStatus.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLSafeCustStatus.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStatus.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLSafeCustStatus.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStatus.m_MapNNtoID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLSafeCustStatus.GetIDFromNN(this.NickName) > 0)
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
      PLSafeCustStatus plSafeCustStatus = this;
      plSafeCustStatus.m_lCounter = plSafeCustStatus.m_lCounter + 1;
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
      if (PLSafeCustStatus.m_MapExtID1toPLID == null)
        return;
      PLSafeCustStatus.m_MapExtID1toPLID.Clear();
      PLSafeCustStatus.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLSafeCustStatus.m_MapExtID2toPLID == null)
        return;
      PLSafeCustStatus.m_MapExtID2toPLID.Clear();
      PLSafeCustStatus.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLSafeCustStatus.m_MapIDtoNN == null)
        return;
      PLSafeCustStatus.m_MapIDtoNN.Clear();
      PLSafeCustStatus.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLSafeCustStatus.m_MapNNtoID == null)
        return;
      PLSafeCustStatus.m_MapNNtoID.Clear();
      PLSafeCustStatus.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public override void GetExistingRecord()
    {
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLSafeCustStatus.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustStatus.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLSafeCustStatus.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustStatus.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLSafeCustStatus.bRead)
        PLSafeCustStatus.ReadTable();
      Key = Key.ToUpper();
      return PLSafeCustStatus.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustStatus.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLSafeCustStatus.bRead)
        PLSafeCustStatus.ReadTable();
      return PLSafeCustStatus.m_MapIDtoNN.ContainsKey(nID) ? PLSafeCustStatus.m_MapIDtoNN[nID].ToString() : "";
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
      this.m_sTableName = "SafeCustStatus";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      this.m_Status = new CPostItem(CPostItem.DataType.LONG, "SCStatusStatus");
      this.m_ID = new CPostItem(CPostItem.DataType.LONG, "SCStatusID");
      this.m_Flags = new CPostItem(CPostItem.DataType.LONG, "SCStatusFlags");
      this.m_NickName = new CPostItem(CPostItem.DataType.STRING, "SCStatusDescription");
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    private static void ReadTable()
    {
      if (PLSafeCustStatus.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("SafeCustStatus", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "SCStatusStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "SCStatusDescription", "", ref szValue);
        string Key = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "SCStatusID");
        PLSafeCustStatus.AddMapNNtoID(Key, recordFieldValueI32);
        PLSafeCustStatus.AddMapIDtoNN(recordFieldValueI32, Key);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLSafeCustStatus.bRead = true;
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
        PLSafeCustStatus plSafeCustStatus = this;
        plSafeCustStatus.m_lSendErrorCount = plSafeCustStatus.m_lSendErrorCount + 1L;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLSafeCustStatus.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLSafeCustStatus.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustStatus.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustStatus.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
