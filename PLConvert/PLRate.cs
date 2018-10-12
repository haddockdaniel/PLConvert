// Decompiled with JetBrains decompiler
// Type: PLConvert.PLRate
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLRate : StaticData
  {
    private new static List<string> m_NNs = new List<string>();
    private static bool bRead = false;
    private CPostItem m_Name;
    private static Dictionary<string, int> m_MapNNtoID;
    private static Dictionary<int, string> m_MapIDtoNN;
    private static Dictionary<string, int> m_MapExtID1toPLID;
    private static Dictionary<string, int> m_MapExtID2toPLID;

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

    public PLRate()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLRate.m_MapExtID1toPLID == null)
        PLRate.m_MapExtID1toPLID = new Dictionary<string, int>();
      if (!PLRate.m_MapExtID1toPLID.ContainsKey(Key))
        PLRate.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLRate.m_MapExtID2toPLID == null)
        PLRate.m_MapExtID2toPLID = new Dictionary<string, int>();
      if (!PLRate.m_MapExtID2toPLID.ContainsKey(Key))
        PLRate.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLRate.m_MapIDtoNN == null)
        PLRate.m_MapIDtoNN = new Dictionary<int, string>();
      if (!PLRate.m_MapIDtoNN.ContainsKey(Key))
        PLRate.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLRate.m_MapNNtoID == null)
        PLRate.m_MapNNtoID = new Dictionary<string, int>();
      if (!PLRate.m_MapNNtoID.ContainsKey(Key))
        PLRate.m_MapNNtoID.Add(Key, Value);
    }

    protected new static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (PLRate.m_NNs == null)
        PLRate.m_NNs = new List<string>();
      PLRate.m_NNs.Add(sNickname.ToLower());
    }

    public override void AddRecord()
    {
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLRate plRate = this;
      plRate.m_lCounter = plRate.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static int GetIDFromExtID1(string Key)
    {
      return !string.IsNullOrEmpty(Key) ? (PLRate.m_MapExtID1toPLID == null ? 0 : (PLRate.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLRate.m_MapExtID1toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return !string.IsNullOrEmpty(Key) ? (PLRate.m_MapExtID2toPLID == null ? 0 : (PLRate.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLRate.m_MapExtID2toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      int num;
      if (!Key.Equals(""))
      {
        if (!PLRate.bRead)
          PLRate.ReadTable();
        num = PLRate.m_MapNNtoID == null ? 0 : (PLRate.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLRate.m_MapNNtoID[Key]) : 0);
      }
      else
        num = 0;
      return num;
    }

    public static string GetNNFromID(int Key)
    {
      string str;
      if (!Key.Equals(0))
      {
        if (!PLRate.bRead)
          PLRate.ReadTable();
        str = PLRate.m_MapIDtoNN == null ? "" : (PLRate.m_MapIDtoNN.ContainsKey(Key) ? PLRate.m_MapIDtoNN[Key].ToString() : "");
      }
      else
        str = "";
      return str;
    }

    protected override void Initialize()
    {
      this.m_sTableName = "Rate";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "RateID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.STRING, "RateName");
      CPostItem cpostItem4 = cpostItem3;
      this.m_Name = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "RateNickName");
      CPostItem cpostItem6 = cpostItem5;
      this.m_NickName = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "RateStatus");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Status = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "RateTransactionChange");
      CPostItem cpostItem10 = cpostItem9;
      this.m_TransactionChgID = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "RateTransactionNew");
      CPostItem cpostItem12 = cpostItem11;
      this.m_TransactionNewID = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, "RateQuickBooksID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_QuickBooksID = cpostItem13;
      postItems7.Add(cpostItem14);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLRate.bRead)
        PLRate.ReadTable();
      string str = this.MakeListNN(this.Name, PLRate.m_NNs, (short) 4);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLRate.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("Rate", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "RateStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "RateNickName", "", ref szValue);
        string sNickname = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "RateID");
        PLRate.AddMapNNtoID(sNickname.ToUpper(), recordFieldValueI32);
        PLRate.AddMapIDtoNN(recordFieldValueI32, sNickname.ToUpper());
        PLRate.AddNicknameToList(sNickname);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLRate.bRead = true;
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
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLRate.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLRate.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLRate.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLRate.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLRate plRate = this;
        plRate.m_lSendErrorCount = plRate.m_lSendErrorCount + 1L;
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
