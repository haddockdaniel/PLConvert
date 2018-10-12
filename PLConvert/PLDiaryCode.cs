// Decompiled with JetBrains decompiler
// Type: PLConvert.PLDiaryCode
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLDiaryCode : StaticData
  {
    private new static List<string> m_NNs = new List<string>();
    public static int m_nNN = 0;
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

    public PLDiaryCode()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLDiaryCode.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLDiaryCode.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLDiaryCode.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLDiaryCode.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLDiaryCode.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLDiaryCode.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLDiaryCode.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLDiaryCode.m_MapNNtoID.Add(Key, Value);
    }

    protected new static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (PLDiaryCode.m_NNs == null)
        PLDiaryCode.m_NNs = new List<string>();
      PLDiaryCode.m_NNs.Add(sNickname.ToLower());
    }

    public override void AddRecord()
    {
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLDiaryCode.GetIDFromNN(this.NickName) > 0)
        this.NickName = this.MakeNN(true);
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 4 ? 1 : 0)) != 0)
        this.NickName = this.MakeNN(true);
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLDiaryCode plDiaryCode = this;
      plDiaryCode.m_lCounter = plDiaryCode.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLDiaryCode.m_MapExtID1toPLID == null)
        return;
      PLDiaryCode.m_MapExtID1toPLID.Clear();
      PLDiaryCode.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLDiaryCode.m_MapExtID2toPLID == null)
        return;
      PLDiaryCode.m_MapExtID2toPLID.Clear();
      PLDiaryCode.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLDiaryCode.m_MapIDtoNN == null)
        return;
      PLDiaryCode.m_MapIDtoNN.Clear();
      PLDiaryCode.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLDiaryCode.m_MapNNtoID == null)
        return;
      PLDiaryCode.m_MapNNtoID.Clear();
      PLDiaryCode.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static int GetIDFromExtID1(string Key)
    {
      return (PLDiaryCode.m_MapExtID1toPLID == null ? 1 : (PLDiaryCode.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) != 0 ? Convert.ToInt32(PLDiaryCode.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLDiaryCode.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLDiaryCode.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLDiaryCode.bRead)
        PLDiaryCode.ReadTable();
      Key = Key.ToUpper();
      return PLDiaryCode.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLDiaryCode.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int Key)
    {
      if (!PLDiaryCode.bRead)
        PLDiaryCode.ReadTable();
      return PLDiaryCode.m_MapIDtoNN.ContainsKey(Key) ? PLDiaryCode.m_MapIDtoNN[Key].ToString() : "";
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "DiaryCode";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "DiaryCodeID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.STRING, "DiaryCodeNickName");
      CPostItem cpostItem4 = cpostItem3;
      this.m_NickName = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "DiaryCodeStatus");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Status = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "DiaryCodeName");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Name = cpostItem7;
      postItems4.Add(cpostItem8);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLDiaryCode.bRead)
        PLDiaryCode.ReadTable();
      string str = this.MakeListNN(this.Name, PLDiaryCode.m_NNs, (short) 20);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLDiaryCode.bRead)
        return;
      uint num = 0;
      object obj = new object();
      num = PLLink.GetLink().TableGET_CreateHandle("DiaryCode", 0, 0, 0);
      PLLink.GetLink().TableGET_AddFilter(num, "DiaryCodeStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(num) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(num, "DiaryCodeNickName", "", ref obj);
        string str = obj.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(num, "DiaryCodeID");
        PLDiaryCode.AddMapNNtoID(str, recordFieldValueI32);
        PLDiaryCode.AddMapIDtoNN(recordFieldValueI32, str);
        PLDiaryCode.AddNicknameToList(str);
      }
      PLLink.GetLink().TableGET_CloseHandle(num);
      num = 0U;
      PLDiaryCode.bRead = true;
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
          PLDiaryCode.AddMapIDtoNN(int32, szValue.ToString());
          PLDiaryCode.AddMapNNtoID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLDiaryCode.AddMapExtID1toPLID(szValue.ToString(), Convert.ToInt32(int32));
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLDiaryCode.AddMapExtID2toPLID(szValue.ToString(), Convert.ToInt32(int32));
        }
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLDiaryCode plDiaryCode = this;
        plDiaryCode.m_lSendErrorCount = plDiaryCode.m_lSendErrorCount + 1L;
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
