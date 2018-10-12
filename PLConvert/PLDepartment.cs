// Decompiled with JetBrains decompiler
// Type: PLConvert.PLDepartment
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLDepartment : StaticData
  {
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    private CPostItem m_Name;
    private static Dictionary<int, string> m_MapPLIDtoQBID;

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

    public PLDepartment()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLDepartment.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLDepartment.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLDepartment.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLDepartment.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLDepartment.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLDepartment.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLDepartment.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLDepartment.m_MapNNtoID.Add(Key, Value);
    }

    public static void AddMapPLIDtoQBID(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLDepartment.m_MapPLIDtoQBID == null)
        PLDepartment.m_MapPLIDtoQBID = new Dictionary<int, string>();
      if (PLDepartment.m_MapPLIDtoQBID.ContainsKey(Key))
        PLDepartment.m_MapPLIDtoQBID.Remove(Key);
      PLDepartment.m_MapPLIDtoQBID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      if (!this.m_NickName.m_bIsSet)
        this.NickName = this.MakeNN(true);
      else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLDepartment.GetIDFromNN(this.NickName) > 0)
        this.NickName = this.MakeNN(true);
      else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 20 ? 1 : 0)) != 0)
        this.NickName = this.MakeNN(true);
      StaticData.AddNicknameToList(this.NickName);
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLDepartment plDepartment = this;
      plDepartment.m_lCounter = plDepartment.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLDepartment.m_MapExtID1toPLID == null)
        return;
      PLDepartment.m_MapExtID1toPLID.Clear();
      PLDepartment.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLDepartment.m_MapExtID2toPLID == null)
        return;
      PLDepartment.m_MapExtID2toPLID.Clear();
      PLDepartment.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLDepartment.m_MapIDtoNN == null)
        return;
      PLDepartment.m_MapIDtoNN.Clear();
      PLDepartment.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLDepartment.m_MapNNtoID == null)
        return;
      PLDepartment.m_MapNNtoID.Clear();
      PLDepartment.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static void ClearMapPLIDtoQBID()
    {
      if (PLDepartment.m_MapPLIDtoQBID == null)
        return;
      PLDepartment.m_MapPLIDtoQBID.Clear();
      PLDepartment.m_MapPLIDtoQBID = (Dictionary<int, string>) null;
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLDepartment.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLDepartment.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLDepartment.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLDepartment.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLDepartment.bRead)
        PLDepartment.ReadTable();
      Key = Key.ToUpper();
      return PLDepartment.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLDepartment.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLDepartment.bRead)
        PLDepartment.ReadTable();
      return PLDepartment.m_MapIDtoNN.ContainsKey(nID) ? PLDepartment.m_MapIDtoNN[nID].ToString() : "";
    }

    public static int GetPLIDFromQBID(string sQBID)
    {
      int num1;
      if (!sQBID.Equals(""))
      {
        if (!PLDepartment.bRead)
          PLDepartment.ReadTable();
        if (PLDepartment.m_MapPLIDtoQBID == null)
          num1 = 0;
        else if (PLDepartment.m_MapPLIDtoQBID.ContainsValue(sQBID))
        {
          int num2 = 0;
          Dictionary<int, string>.Enumerator enumerator = PLDepartment.m_MapPLIDtoQBID.GetEnumerator();
          while (enumerator.MoveNext())
          {
            Dictionary<int, string> mapPliDtoQbid = PLDepartment.m_MapPLIDtoQBID;
            KeyValuePair<int, string> current = enumerator.Current;
            if (mapPliDtoQbid[current.Key].ToUpper().CompareTo(sQBID.ToUpper()) == 0)
            {
              current = enumerator.Current;
              num2 = current.Key;
            }
          }
          num1 = num2;
        }
        else
          num1 = 0;
      }
      else
        num1 = 0;
      return num1;
    }

    public static string GetQBIDFromPLID(int nID)
    {
      string str;
      if (!nID.Equals(0))
      {
        if (!PLDepartment.bRead)
          PLDepartment.ReadTable();
        str = PLDepartment.m_MapPLIDtoQBID == null ? "" : (PLDepartment.m_MapPLIDtoQBID.ContainsKey(nID) ? Convert.ToString(PLDepartment.m_MapPLIDtoQBID[nID]) : "");
      }
      else
        str = "";
      return str;
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "Department";
      this.m_hndPOST = 0U;
      this.m_hndGET = 0U;
      this.m_hndExisting = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "DepartmentStatus");
      CPostItem cpostItem2 = cpostItem1;
      this.m_Status = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "DepartmentID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_ID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "DepartmentNickName");
      CPostItem cpostItem6 = cpostItem5;
      this.m_NickName = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "DepartmentName");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Name = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "DepartmentTransactionChangeID");
      CPostItem cpostItem10 = cpostItem9;
      this.m_TransactionChgID = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "DepartmentTransNewID");
      CPostItem cpostItem12 = cpostItem11;
      this.m_TransactionNewID = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, "DepartmentQuickBooksID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_QuickBooksID = cpostItem13;
      postItems7.Add(cpostItem14);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLDepartment.bRead)
        PLDepartment.ReadTable();
      string str = this.MakeListNN(this.Name, StaticData.m_NNs, (short) 20);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLDepartment.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("Department", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "DepartmentStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "DepartmentNickName", "", ref szValue);
        string str1 = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "DepartmentID");
        PLDepartment.AddMapNNtoID(str1, recordFieldValueI32);
        PLDepartment.AddMapIDtoNN(recordFieldValueI32, str1);
        StaticData.AddNicknameToList(str1);
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "DepartmentQuickBooksID", "", ref szValue);
        string str2 = szValue.ToString().ToUpper().Trim();
        if (!str2.Equals(""))
          PLDepartment.AddMapPLIDtoQBID(recordFieldValueI32, str2);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLDepartment.bRead = true;
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
      string empty = string.Empty;
      this.m_lSendErrorCount = 0L;
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLDepartment plDepartment = this;
        plDepartment.m_lSendErrorCount = plDepartment.m_lSendErrorCount + 1L;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLDepartment.AddMapIDtoNN(int32, szValue.ToString());
          PLDepartment.AddMapNNtoID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLDepartment.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLDepartment.AddMapExtID2toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "DepartmentQuickBooksID", szDefault, ref szValue);
          string str = szValue.ToString().ToUpper().Trim();
          if (!str.Equals(""))
            PLDepartment.AddMapPLIDtoQBID(int32, str);
        }
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }
  }
}
