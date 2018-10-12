// Decompiled with JetBrains decompiler
// Type: PLConvert.PLContactType
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLContactType : StaticData
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

    public PLContactType()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!PLContactType.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLContactType.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!PLContactType.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLContactType.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLContactType.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLContactType.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((string.IsNullOrEmpty(Key) ? 0 : (!PLContactType.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLContactType.m_MapNNtoID.Add(Key, Value);
    }

    protected new static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (PLContactType.m_NNs == null)
        PLContactType.m_NNs = new List<string>();
      PLContactType.m_NNs.Add(sNickname.ToLower());
    }

    public override void AddRecord()
    {
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLContactType.GetIDFromNN(this.NickName) > 0)
        this.NickName = this.MakeNN(true);
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 4 ? 1 : 0)) != 0)
        this.NickName = this.MakeNN(true);
      PLContactType.AddNicknameToList(this.NickName);
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLContactType plContactType = this;
      plContactType.m_lCounter = plContactType.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLContactType.m_MapExtID1toPLID == null)
        return;
      PLContactType.m_MapExtID1toPLID.Clear();
      PLContactType.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLContactType.m_MapExtID2toPLID == null)
        return;
      PLContactType.m_MapExtID2toPLID.Clear();
      PLContactType.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLContactType.m_MapIDtoNN == null)
        return;
      PLContactType.m_MapIDtoNN.Clear();
      PLContactType.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLContactType.m_MapNNtoID == null)
        return;
      PLContactType.m_MapNNtoID.Clear();
      PLContactType.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static int GetIDFromExtID1(string Key)
    {
      if (!PLContactType.bRead)
        PLContactType.ReadTable();
      return PLContactType.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLContactType.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      if (!PLContactType.bRead)
        PLContactType.ReadTable();
      return PLContactType.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLContactType.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLContactType.bRead)
        PLContactType.ReadTable();
      Key = Key.ToUpper();
      return PLContactType.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLContactType.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLContactType.bRead)
        PLContactType.ReadTable();
      return PLContactType.m_MapIDtoNN.ContainsKey(nID) ? PLContactType.m_MapIDtoNN[nID].ToString() : "";
    }

    protected override void Initialize()
    {
      this.m_sTableName = "ContactType";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "ContactTypeID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "ContactTypeStatus");
      CPostItem cpostItem4 = cpostItem3;
      this.m_Status = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "ContactTypeExplanation");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Name = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "ContactTypeNN");
      CPostItem cpostItem8 = cpostItem7;
      this.m_NickName = cpostItem7;
      postItems4.Add(cpostItem8);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLContactType.bRead)
        PLContactType.ReadTable();
      string str = this.MakeListNN(this.Name, PLContactType.m_NNs, (short) 4);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLContactType.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("ContactType", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "ContactTypeStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "ContactTypeNN", "", ref szValue);
        string str = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "ContactTypeID");
        PLContactType.AddMapIDtoNN(recordFieldValueI32, str);
        PLContactType.AddMapNNtoID(str, recordFieldValueI32);
        PLContactType.AddNicknameToList(str);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLContactType.bRead = true;
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
      string empty = string.Empty;
      this.m_lSendErrorCount = 0L;
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, empty, ref szValue);
          PLContactType.AddMapIDtoNN(int32, szValue.ToString());
          PLContactType.AddMapNNtoID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, empty, ref szValue);
          if (!string.IsNullOrEmpty(szValue.ToString()))
            PLContactType.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, empty, ref szValue);
          if (!string.IsNullOrEmpty(szValue.ToString()))
            PLContactType.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLContactType plContactType = this;
        plContactType.m_lSendErrorCount = plContactType.m_lSendErrorCount + 1L;
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
