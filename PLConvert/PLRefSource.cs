// Decompiled with JetBrains decompiler
// Type: PLConvert.PLRefSource
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLRefSource : StaticData
  {
    private new static List<string> m_NNs = new List<string>();
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    private CPostItem m_Name;

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

    public PLRefSource()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLRefSource.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLRefSource.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLRefSource.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLRefSource.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLRefSource.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLRefSource.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLRefSource.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLRefSource.m_MapNNtoID.Add(Key, Value);
    }

    protected new static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (PLRefSource.m_NNs == null)
        PLRefSource.m_NNs = new List<string>();
      PLRefSource.m_NNs.Add(sNickname.ToLower());
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLRefSource.GetIDFromNN(this.NickName) > 0)
        this.NickName = this.MakeNN(true);
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 4 ? 1 : 0)) != 0)
        this.NickName = this.MakeNN(true);
      PLRefSource.AddNicknameToList(this.NickName);
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddField(this.m_hndPOST);
      this.m_ExternalID_1.AddField(this.m_hndPOST);
      this.m_ExternalID_2.AddField(this.m_hndPOST);
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLRefSource plRefSource = this;
      plRefSource.m_lCounter = plRefSource.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLRefSource.m_MapExtID1toPLID == null)
        return;
      PLRefSource.m_MapExtID1toPLID.Clear();
      PLRefSource.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLRefSource.m_MapExtID2toPLID == null)
        return;
      PLRefSource.m_MapExtID2toPLID.Clear();
      PLRefSource.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLRefSource.m_MapIDtoNN == null)
        return;
      PLRefSource.m_MapIDtoNN.Clear();
      PLRefSource.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLRefSource.m_MapNNtoID == null)
        return;
      PLRefSource.m_MapNNtoID.Clear();
      PLRefSource.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLRefSource.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLRefSource.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLRefSource.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLRefSource.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLRefSource.bRead)
        PLRefSource.ReadTable();
      Key = Key.ToUpper();
      return PLRefSource.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLRefSource.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLRefSource.bRead)
        PLRefSource.ReadTable();
      return PLRefSource.m_MapIDtoNN.ContainsKey(nID) ? PLRefSource.m_MapIDtoNN[nID].ToString() : "";
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "ReferralSources";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "RefSourceStatus");
      CPostItem cpostItem2 = cpostItem1;
      this.m_Status = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "RefSourceID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_ID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "RefSourceNickName");
      CPostItem cpostItem6 = cpostItem5;
      this.m_NickName = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "RefSourceName");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Name = cpostItem7;
      postItems4.Add(cpostItem8);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLRefSource.bRead)
        PLRefSource.ReadTable();
      string str = this.MakeListNN(this.Name, PLRefSource.m_NNs, (short) 20);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLRefSource.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("ReferralSources", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "RefSourceStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "RefSourceNickName", "", ref szValue);
        string str = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "RefSourceID");
        PLRefSource.AddMapNNtoID(str, recordFieldValueI32);
        PLRefSource.AddMapIDtoNN(recordFieldValueI32, str);
        PLRefSource.AddNicknameToList(str);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLRefSource.bRead = true;
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
        PLRefSource plRefSource = this;
        plRefSource.m_lSendErrorCount = plRefSource.m_lSendErrorCount + 1L;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLRefSource.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLRefSource.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLRefSource.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLRefSource.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
