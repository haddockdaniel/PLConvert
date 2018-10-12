// Decompiled with JetBrains decompiler
// Type: PLConvert.PLLocationCode
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLLocationCode : StaticData
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

    public PLLocationCode()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLLocationCode.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLLocationCode.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLLocationCode.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLLocationCode.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLLocationCode.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLLocationCode.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLLocationCode.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLLocationCode.m_MapNNtoID.Add(Key, Value);
    }

    protected new static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (PLLocationCode.m_NNs == null)
        PLLocationCode.m_NNs = new List<string>();
      PLLocationCode.m_NNs.Add(sNickname.ToLower());
    }

    public override void AddRecord()
    {
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLLocationCode plLocationCode = this;
      plLocationCode.m_lCounter = plLocationCode.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLLocationCode.m_MapExtID1toPLID == null)
        return;
      PLLocationCode.m_MapExtID1toPLID.Clear();
      PLLocationCode.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLLocationCode.m_MapExtID2toPLID == null)
        return;
      PLLocationCode.m_MapExtID2toPLID.Clear();
      PLLocationCode.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLLocationCode.m_MapIDtoNN == null)
        return;
      PLLocationCode.m_MapIDtoNN.Clear();
      PLLocationCode.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLLocationCode.m_MapNNtoID == null)
        return;
      PLLocationCode.m_MapNNtoID.Clear();
      PLLocationCode.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLLocationCode.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLLocationCode.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLLocationCode.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLLocationCode.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLLocationCode.bRead)
        PLLocationCode.ReadTable();
      Key = Key.ToUpper();
      return PLLocationCode.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLLocationCode.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLLocationCode.bRead)
        PLLocationCode.ReadTable();
      return PLLocationCode.m_MapIDtoNN.ContainsKey(nID) ? PLLocationCode.m_MapIDtoNN[nID].ToString() : "";
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "Location";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "LocationStatus");
      CPostItem cpostItem2 = cpostItem1;
      this.m_Status = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "LocationID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_ID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "LocationNickName");
      CPostItem cpostItem6 = cpostItem5;
      this.m_NickName = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "LocationName");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Name = cpostItem7;
      postItems4.Add(cpostItem8);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLLocationCode.bRead)
        PLLocationCode.ReadTable();
      string str = this.MakeListNN(this.Name, PLLocationCode.m_NNs, (short) 20);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLLocationCode.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("Location", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "LocationStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "LocationNickName", "", ref szValue);
        string sNickname = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "LocationID");
        PLLocationCode.AddMapNNtoID(sNickname.ToUpper(), recordFieldValueI32);
        PLLocationCode.AddMapIDtoNN(recordFieldValueI32, sNickname.ToUpper());
        PLLocationCode.AddNicknameToList(sNickname);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLLocationCode.bRead = true;
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
        PLLocationCode plLocationCode = this;
        plLocationCode.m_lSendErrorCount = plLocationCode.m_lSendErrorCount + 1L;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLLocationCode.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLLocationCode.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLLocationCode.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLLocationCode.AddMapExtID2toPLID(szValue.ToString(), int32);
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
