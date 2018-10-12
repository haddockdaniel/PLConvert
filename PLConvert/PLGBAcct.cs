// Decompiled with JetBrains decompiler
// Type: PLConvert.PLGBAcct
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLGBAcct : StaticData
  {
    public static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    public static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    public static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    public static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    public static Dictionary<int, string> m_MapIDtoGLNN = new Dictionary<int, string>();
    private CPostItem m_DeptID;
    private CPostItem m_BankName;
    private CPostItem m_Branch1;
    private CPostItem m_Branch2;
    private CPostItem m_AcctHolder;
    private CPostItem m_Balance;
    private CPostItem m_BankAcctNumber;
    private CPostItem m_Transit;
    private CPostItem m_GLNN;
    private static Dictionary<int, string> m_MapPLIDtoQBID;
    private static bool bRead;

    public string AcctHolder
    {
      get
      {
        return this.m_AcctHolder.sValue;
      }
      set
      {
        this.m_AcctHolder.SetValue(value);
      }
    }

    public double Balance
    {
      get
      {
        return this.m_Balance.dValue;
      }
      set
      {
        this.m_Balance.SetValue(value);
      }
    }

    public string BankAcctNumber
    {
      get
      {
        return this.m_BankAcctNumber.sValue;
      }
      set
      {
        this.m_BankAcctNumber.SetValue(value);
      }
    }

    public string BankName
    {
      get
      {
        return this.m_BankName.sValue;
      }
      set
      {
        this.m_BankName.SetValue(value);
      }
    }

    public string Branch1
    {
      get
      {
        return this.m_Branch1.sValue;
      }
      set
      {
        this.m_Branch1.SetValue(value);
      }
    }

    public string Branch2
    {
      get
      {
        return this.m_Branch2.sValue;
      }
      set
      {
        this.m_Branch2.SetValue(value);
      }
    }

    public string GLNN
    {
      get
      {
        return this.m_GLNN.sValue;
      }
      set
      {
        this.m_GLNN.SetValue(value);
      }
    }

    public string sDeptNN
    {
      get
      {
        return this.m_DeptID.sValue;
      }
      set
      {
        this.m_DeptID.SetValue(value);
      }
    }

    public string Transit
    {
      get
      {
        return this.m_Transit.sValue;
      }
      set
      {
        this.m_Transit.SetValue(value);
      }
    }

    public PLGBAcct()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if (PLGBAcct.m_MapExtID1toPLID.ContainsKey(Key))
        return;
      PLGBAcct.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if (PLGBAcct.m_MapExtID2toPLID.ContainsKey(Key))
        return;
      PLGBAcct.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoGLNN(int Key, string Value)
    {
      if (PLGBAcct.m_MapIDtoGLNN.ContainsKey(Key))
        return;
      PLGBAcct.m_MapIDtoGLNN.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if (PLGBAcct.m_MapIDtoNN.ContainsKey(Key))
        return;
      PLGBAcct.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if (PLGBAcct.m_MapNNtoID.ContainsKey(Key))
        return;
      PLGBAcct.m_MapNNtoID.Add(Key, Value);
    }

    public static void AddMapPLIDtoQBID(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLGBAcct.m_MapPLIDtoQBID == null)
        PLGBAcct.m_MapPLIDtoQBID = new Dictionary<int, string>();
      if (!PLGBAcct.m_MapPLIDtoQBID.ContainsKey(Key))
        PLGBAcct.m_MapPLIDtoQBID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLGBAcct plgbAcct = this;
      plgbAcct.m_lCounter = plgbAcct.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapPLIDtoQBID()
    {
      if (PLGBAcct.m_MapPLIDtoQBID == null)
        return;
      PLGBAcct.m_MapPLIDtoQBID.Clear();
      PLGBAcct.m_MapPLIDtoQBID = (Dictionary<int, string>) null;
    }

    public static string GetGLNNFromID(int nID)
    {
      if (!PLGBAcct.bRead)
        PLGBAcct.ReadTable();
      return PLGBAcct.m_MapIDtoGLNN.ContainsKey(nID) ? PLGBAcct.m_MapIDtoGLNN[nID].ToString() : "";
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLGBAcct.m_MapExtID1toPLID.ContainsKey(Key) ? PLGBAcct.m_MapExtID1toPLID[Key] : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLGBAcct.m_MapExtID2toPLID.ContainsKey(Key) ? PLGBAcct.m_MapExtID2toPLID[Key] : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLGBAcct.bRead)
        PLGBAcct.ReadTable();
      Key = Key.ToUpper();
      return PLGBAcct.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLGBAcct.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int nID)
    {
      if (!PLGBAcct.bRead)
        PLGBAcct.ReadTable();
      return PLGBAcct.m_MapIDtoNN.ContainsKey(nID) ? PLGBAcct.m_MapIDtoNN[nID].ToString() : "";
    }

    public static int GetPLIDFromQBID(string sQBID)
    {
      int num1;
      if (!sQBID.Equals(""))
      {
        if (!PLGBAcct.bRead)
          PLGBAcct.ReadTable();
        if (PLGBAcct.m_MapPLIDtoQBID == null)
          num1 = 0;
        else if (PLGBAcct.m_MapPLIDtoQBID.ContainsValue(sQBID))
        {
          int num2 = 0;
          Dictionary<int, string>.Enumerator enumerator = PLGBAcct.m_MapPLIDtoQBID.GetEnumerator();
          while (enumerator.MoveNext())
          {
            Dictionary<int, string> mapPliDtoQbid = PLGBAcct.m_MapPLIDtoQBID;
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
        if (!PLGBAcct.bRead)
          PLGBAcct.ReadTable();
        str = PLGBAcct.m_MapPLIDtoQBID == null ? "" : (PLGBAcct.m_MapPLIDtoQBID.ContainsKey(nID) ? Convert.ToString(PLGBAcct.m_MapPLIDtoQBID[nID]) : "");
      }
      else
        str = "";
      return str;
    }

    protected override void Initialize()
    {
      this.m_sTableName = "GeneralBankAcct";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "DeptID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_DeptID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.STRING, "GeneralBankAcctBankName");
      CPostItem cpostItem4 = cpostItem3;
      this.m_BankName = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "GeneralBankAcctBranch1");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Branch1 = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "GeneralBankAcctBranch2");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Branch2 = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.STRING, "GeneralBankAcctHolder");
      CPostItem cpostItem10 = cpostItem9;
      this.m_AcctHolder = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "GeneralBankAcctID");
      CPostItem cpostItem12 = cpostItem11;
      this.m_ID = cpostItem11;
      postItems6.Add(cpostItem12);
      this.sIDLinkName = "GeneralBankAcctID";
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.DOUBLE, "GeneralBankAcctBalance");
      CPostItem cpostItem14 = cpostItem13;
      this.m_Balance = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.STRING, "GeneralBankAcctNickName");
      CPostItem cpostItem16 = cpostItem15;
      this.m_NickName = cpostItem15;
      postItems8.Add(cpostItem16);
      this.sNicknameLinkName = "GeneralBankAcctNickName";
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.STRING, "GeneralBankAcctNumber");
      CPostItem cpostItem18 = cpostItem17;
      this.m_BankAcctNumber = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.LONG, "GeneralBankAcctStatus");
      CPostItem cpostItem20 = cpostItem19;
      this.m_Status = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.STRING, "GeneralBankAcctTransit");
      CPostItem cpostItem22 = cpostItem21;
      this.m_Transit = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.STRING, "GeneralBankAcctPostRefNickName");
      CPostItem cpostItem24 = cpostItem23;
      this.m_GLNN = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.LONG, "GeneralBankAcctTransactionChangeID");
      CPostItem cpostItem26 = cpostItem25;
      this.m_TransactionChgID = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.LONG, "GeneralBankAcctTransNewID");
      CPostItem cpostItem28 = cpostItem27;
      this.m_TransactionNewID = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "GeneralBankAcctQuickBooksID");
      CPostItem cpostItem30 = cpostItem29;
      this.m_QuickBooksID = cpostItem29;
      postItems15.Add(cpostItem30);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    private static void ReadTable()
    {
      if (PLGBAcct.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("GeneralBankAcct", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "GeneralBankAcctStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "GeneralBankAcctNickName", "", ref szValue);
        string Key = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "GeneralBankAcctID");
        PLGBAcct.AddMapNNtoID(Key, recordFieldValueI32);
        PLGBAcct.AddMapIDtoNN(recordFieldValueI32, Key);
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "GeneralBankAcctPostRefNickName", "", ref szValue);
        string str1 = szValue.ToString().ToUpper().Trim();
        PLGBAcct.AddMapIDtoGLNN(recordFieldValueI32, str1);
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "GeneralBankAcctQuickBooksID", "", ref szValue);
        string str2 = szValue.ToString().ToUpper().Trim();
        if (!str2.Equals(""))
          PLGBAcct.AddMapPLIDtoQBID(recordFieldValueI32, str2);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLGBAcct.bRead = true;
    }

    public static void ResetReadFlag()
    {
      PLGBAcct.bRead = false;
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
      string str1 = "";
      PLGLAccts plglAccts = new PLGLAccts();
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLGBAcct.AddMapIDtoNN(int32, szValue.ToString());
          PLGBAcct.AddMapNNtoID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_GLNN.sLinkName, szDefault, ref szValue);
          PLGBAcct.AddMapIDtoGLNN(int32, szValue.ToString());
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLGBAcct.AddMapExtID1toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLGBAcct.AddMapExtID2toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "GeneralBankAcctQuickBooksID", szDefault, ref szValue);
          szValue = (object) szValue.ToString().ToUpper().Trim();
          if (!szValue.Equals((object) ""))
          {
            PLGBAcct.AddMapPLIDtoQBID(int32, szValue.ToString());
            str1 = szValue.ToString();
          }
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "GeneralBankAcctPostRefNickName", szDefault, ref szValue);
          szValue = (object) szValue.ToString().ToUpper().Trim();
          if (!szValue.Equals((object) ""))
          {
            string str2 = szValue.ToString();
            plglAccts.AddFilter(plglAccts.NickName_LinkName, PLXMLData.eFilterCompare.EQ, str2, 1);
            while (plglAccts.GetNextRecord() == 0)
            {
              PLGLAccts.AddMapNNtoID(str2, plglAccts.ID);
              PLGLAccts.AddMapIDtoNN(plglAccts.ID, str2);
              plglAccts.ReadExisting((uint) plglAccts.ID);
              if (str1 != "")
              {
                plglAccts.QuickBooksID = str1;
                plglAccts.AddRecord();
                plglAccts.SendLast();
              }
            }
          }
        }
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLGBAcct plgbAcct = this;
        plgbAcct.m_lSendErrorCount = plgbAcct.m_lSendErrorCount + 1L;
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }

    public void ZeroBalances()
    {
      PLGBEnt plgbEnt = new PLGBEnt();
      uint num = 0;
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("GeneralBankAcct", 0, 0, 0U);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "GeneralBankAcctID");
        double fieldValueDouble = PLLink.GetLink().TableGET_RecordField_ValueDOUBLE(createHandle, "GeneralBankAcctBalance");
        if (!fieldValueDouble.Equals(0.0))
        {
          plgbEnt.BankAcctID = recordFieldValueI32;
          plgbEnt.CheckNum = "Zero";
          plgbEnt.Date = 19900101;
          plgbEnt.EntryType = PLGBEnt.eGBEntryType.GEN_RCPT;
          plgbEnt.PaidTo = "Adjusting Entry";
          plgbEnt.TotalAmount = -fieldValueDouble;
          plgbEnt.Alloc.Amount = -fieldValueDouble;
          plgbEnt.Alloc.EntryType = PLGBAlloc.eGBAllocEntryType.GEN_RCPT;
          plgbEnt.Alloc.Explanation = "Zero General Bank Balance";
          plgbEnt.Alloc.GLNN = "9999";
          plgbEnt.AddGBAllocation();
          plgbEnt.AddRecord();
        }
      }
      plgbEnt.SendLast();
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
    }
  }
}
