// Decompiled with JetBrains decompiler
// Type: PLConvert.PLSafeCustStage
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLSafeCustStage : StaticData
  {
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    private CPostItem m_Description;
    private CPostItem m_StageNum;
    private CPostItem m_StageGroup;
    private CPostItem m_DaysToAdvance;
    private CPostItem m_UseEMail;
    private CPostItem m_UsePhone;
    private CPostItem m_IsOnHold;

    public string DaysToAdvance
    {
      get
      {
        return this.m_DaysToAdvance.sValue;
      }
      set
      {
        this.m_DaysToAdvance.SetValue(value);
      }
    }

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

    public string IsOnHold
    {
      get
      {
        return this.m_IsOnHold.sValue;
      }
      set
      {
        this.m_IsOnHold.SetValue(value);
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

    public int StageNum
    {
      get
      {
        return this.m_StageNum.nValue;
      }
      set
      {
        this.m_StageNum.SetValue(value);
      }
    }

    public string UseEMail
    {
      get
      {
        return this.m_UseEMail.sValue;
      }
      set
      {
        this.m_UseEMail.SetValue(value);
      }
    }

    public string UsePhone
    {
      get
      {
        return this.m_UsePhone.sValue;
      }
      set
      {
        this.m_UsePhone.SetValue(value);
      }
    }

    public PLSafeCustStage()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustStage.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStage.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLSafeCustStage.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStage.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLSafeCustStage.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStage.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLSafeCustStage.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLSafeCustStage.m_MapNNtoID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLSafeCustStage.GetIDFromNN(this.NickName) > 0)
        this.NickName = this.MakeNN(true);
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 4 ? 1 : 0)) != 0)
        this.NickName = this.MakeNN(true);
      this.m_Status.AddField(this.m_hndPOST);
      this.m_ID.AddField(this.m_hndPOST);
      this.m_NickName.AddField(this.m_hndPOST);
      this.m_StageNum.AddField(this.m_hndPOST);
      this.m_Description.AddField(this.m_hndPOST);
      this.m_StageGroup.AddField(this.m_hndPOST);
      this.m_DaysToAdvance.AddField(this.m_hndPOST);
      this.m_UseEMail.AddField(this.m_hndPOST);
      this.m_UsePhone.AddField(this.m_hndPOST);
      this.m_IsOnHold.AddField(this.m_hndPOST);
      this.m_ExternalID_1.AddField(this.m_hndPOST);
      this.m_ExternalID_2.AddField(this.m_hndPOST);
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLSafeCustStage plSafeCustStage = this;
      plSafeCustStage.m_lCounter = plSafeCustStage.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      this.m_Status.Clear();
      this.m_ID.Clear();
      this.m_NickName.Clear();
      this.m_StageNum.Clear();
      this.m_Description.Clear();
      this.m_StageGroup.Clear();
      this.m_DaysToAdvance.Clear();
      this.m_UseEMail.Clear();
      this.m_UsePhone.Clear();
      this.m_IsOnHold.Clear();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLSafeCustStage.m_MapExtID1toPLID == null)
        return;
      PLSafeCustStage.m_MapExtID1toPLID.Clear();
      PLSafeCustStage.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLSafeCustStage.m_MapExtID2toPLID == null)
        return;
      PLSafeCustStage.m_MapExtID2toPLID.Clear();
      PLSafeCustStage.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLSafeCustStage.m_MapIDtoNN == null)
        return;
      PLSafeCustStage.m_MapIDtoNN.Clear();
      PLSafeCustStage.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLSafeCustStage.m_MapNNtoID == null)
        return;
      PLSafeCustStage.m_MapNNtoID.Clear();
      PLSafeCustStage.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public override void GetExistingRecord()
    {
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLSafeCustStage.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustStage.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLSafeCustStage.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustStage.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLSafeCustStage.bRead)
        PLSafeCustStage.ReadTable();
      Key = Key.ToUpper();
      return PLSafeCustStage.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLSafeCustStage.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLSafeCustStage.bRead)
        PLSafeCustStage.ReadTable();
      return PLSafeCustStage.m_MapIDtoNN.ContainsKey(nID) ? PLSafeCustStage.m_MapIDtoNN[nID].ToString() : "";
    }

    public override void GetRecord()
    {
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      this.m_Status.GetField(this.m_hndGET);
      this.m_ID.GetField(this.m_hndGET);
      this.m_NickName.GetField(this.m_hndGET);
      this.m_StageNum.GetField(this.m_hndGET);
      this.m_Description.GetField(this.m_hndGET);
      this.m_StageGroup.GetField(this.m_hndGET);
      this.m_DaysToAdvance.GetField(this.m_hndGET);
      this.m_UseEMail.GetField(this.m_hndGET);
      this.m_UsePhone.GetField(this.m_hndGET);
      this.m_IsOnHold.GetField(this.m_hndGET);
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "SafeCustStage";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      this.m_Status = new CPostItem(CPostItem.DataType.LONG, "SCStageStatus");
      this.m_ID = new CPostItem(CPostItem.DataType.LONG, "SCStageID");
      this.m_StageNum = new CPostItem(CPostItem.DataType.LONG, "SCStageNum");
      this.m_StageGroup = new CPostItem(CPostItem.DataType.LONG, "SCStageStageGroupID");
      this.m_DaysToAdvance = new CPostItem(CPostItem.DataType.LONG, "SCStageDaysToAdvance");
      this.m_NickName = new CPostItem(CPostItem.DataType.STRING, "SCStageName");
      this.m_Description = new CPostItem(CPostItem.DataType.STRING, "SCStageDescription");
      this.m_UseEMail = new CPostItem(CPostItem.DataType.BOOL, "SCStageUseEMail");
      this.m_UsePhone = new CPostItem(CPostItem.DataType.BOOL, "SCStageUsePhone");
      this.m_IsOnHold = new CPostItem(CPostItem.DataType.BOOL, "SCStageIsOnHold");
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    private static void ReadTable()
    {
      if (PLSafeCustStage.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("SafeCustStage", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "SafeCustStageStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "SafeCustStageNickName", "", ref szValue);
        string Key = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "SafeCustStageID");
        PLSafeCustStage.AddMapNNtoID(Key, recordFieldValueI32);
        PLSafeCustStage.AddMapIDtoNN(recordFieldValueI32, Key);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLSafeCustStage.bRead = true;
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
        PLSafeCustStage plSafeCustStage = this;
        plSafeCustStage.m_lSendErrorCount = plSafeCustStage.m_lSendErrorCount + 1L;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLSafeCustStage.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLSafeCustStage.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustStage.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLSafeCustStage.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
