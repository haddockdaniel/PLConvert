// Decompiled with JetBrains decompiler
// Type: PLConvert.PLGLAccts
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLGLAccts : StaticData
  {
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static string m_ExpRecovNN = "";
    private static int m_ExpRecovID = 0;
    private static string m_SuspenseNN = "";
    private static int m_SuspenseID = 0;
    private static string m_APAccountNN = "";
    private static int m_APAccountID = 0;
    private static string m_ARAccountNN = "";
    private static int m_ARAccountID = 0;
    private static int m_FeesEarnedAccountID = 0;
    private static int m_TrustLiabilityID = 0;
    private static bool bRead = false;
    private CPostItem m_Name;
    private CPostItem m_DepartmentID;
    private CPostItem m_LawyerID;
    private CPostItem m_SpecialAcct;
    private CPostItem m_AcctType;
    private CPostItem m_CostCenter;
    private CPostItem m_Category;
    private CPostItem m_SubAcctOfID;
    private static Dictionary<int, string> m_MapPLIDtoQBID;

    public PLGLAccts.eACCOUNT_TYPE AcctType
    {
      get
      {
        return (PLGLAccts.eACCOUNT_TYPE) this.m_AcctType.nValue;
      }
      set
      {
        this.m_AcctType.SetValue((int) value);
      }
    }

    public string Category
    {
      get
      {
        return this.m_Category.sValue;
      }
      set
      {
        this.m_Category.SetValue(value);
      }
    }

    public string CostCenter
    {
      get
      {
        return this.m_CostCenter.sValue;
      }
      set
      {
        this.m_CostCenter.SetValue(value);
      }
    }

    public string DepartmentNN
    {
      get
      {
        return this.m_DepartmentID.sValue;
      }
      set
      {
        this.m_DepartmentID.SetValue(value);
      }
    }

    public int LawyerID
    {
      get
      {
        return this.m_LawyerID.nValue;
      }
      set
      {
        this.m_LawyerID.SetValue(value);
      }
    }

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

    public PLGLAccts.eSPEC_ACCT SpecialAcct
    {
      get
      {
        return (PLGLAccts.eSPEC_ACCT) this.m_SpecialAcct.nValue;
      }
      set
      {
        this.m_SpecialAcct.SetValue((int) value);
      }
    }

    public string SuBAcctOfNN
    {
      get
      {
        return this.m_SubAcctOfID.sValue;
      }
      set
      {
        this.m_SubAcctOfID.SetValue(value);
      }
    }

    public PLGLAccts()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if (PLGLAccts.m_MapExtID1toPLID.ContainsKey(Key))
        return;
      PLGLAccts.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if (PLGLAccts.m_MapExtID2toPLID.ContainsKey(Key))
        return;
      PLGLAccts.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if (PLGLAccts.m_MapIDtoNN.ContainsKey(Key))
        return;
      PLGLAccts.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if (PLGLAccts.m_MapNNtoID.ContainsKey(Key))
        return;
      PLGLAccts.m_MapNNtoID.Add(Key, Value);
    }

    public static void AddMapPLIDtoQBID(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLGLAccts.m_MapPLIDtoQBID == null)
        PLGLAccts.m_MapPLIDtoQBID = new Dictionary<int, string>();
      if (!PLGLAccts.m_MapPLIDtoQBID.ContainsKey(Key))
        PLGLAccts.m_MapPLIDtoQBID.Add(Key, Value);
    }

    public override void AddRecord()
    {
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLGLAccts plglAccts = this;
      plglAccts.m_lCounter = plglAccts.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapPLIDtoQBID()
    {
      if (PLGLAccts.m_MapPLIDtoQBID == null)
        return;
      PLGLAccts.m_MapPLIDtoQBID.Clear();
      PLGLAccts.m_MapPLIDtoQBID = (Dictionary<int, string>) null;
    }

    public static int GetAPAccountID()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_APAccountID;
    }

    public static string GetAPAccountNN()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_APAccountNN;
    }

    public static int GetARAccountID()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_ARAccountID;
    }

    public static string GetARAccountNN()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_ARAccountNN;
    }

    public static int GetExpRecovID()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_ExpRecovID;
    }

    public static string GetExpRecovNN()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_ExpRecovNN;
    }

    public static int GetFeesEarnedAccountID()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_FeesEarnedAccountID;
    }

    public static int GetIDFromExtID1(string Key)
    {
      return !Key.Equals("") ? (PLGLAccts.m_MapExtID1toPLID == null ? 0 : (PLGLAccts.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLGLAccts.m_MapExtID1toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return !Key.Equals("") ? (PLGLAccts.m_MapExtID2toPLID == null ? 0 : (PLGLAccts.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLGLAccts.m_MapExtID2toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLGLAccts.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int Key)
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_MapIDtoNN.ContainsKey(Key) ? PLGLAccts.m_MapIDtoNN[Key].ToString() : "";
    }

    public static int GetPLIDFromQBID(string sQBID)
    {
      int num1;
      if (!sQBID.Equals(""))
      {
        if (!PLGLAccts.bRead)
          PLGLAccts.ReadTable();
        if (PLGLAccts.m_MapPLIDtoQBID == null)
          num1 = 0;
        else if (PLGLAccts.m_MapPLIDtoQBID.ContainsValue(sQBID))
        {
          int num2 = 0;
          Dictionary<int, string>.Enumerator enumerator = PLGLAccts.m_MapPLIDtoQBID.GetEnumerator();
          while (enumerator.MoveNext())
          {
            Dictionary<int, string> mapPliDtoQbid = PLGLAccts.m_MapPLIDtoQBID;
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
        if (!PLGLAccts.bRead)
          PLGLAccts.ReadTable();
        str = PLGLAccts.m_MapPLIDtoQBID == null ? "" : (PLGLAccts.m_MapPLIDtoQBID.ContainsKey(nID) ? Convert.ToString(PLGLAccts.m_MapPLIDtoQBID[nID]) : "");
      }
      else
        str = "";
      return str;
    }

    public static int GetSuspenseID()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_SuspenseID;
    }

    public static string GetSuspenseNN()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_SuspenseNN;
    }

    public static int GetTrustLiabilityID()
    {
      if (!PLGLAccts.bRead)
        PLGLAccts.ReadTable();
      return PLGLAccts.m_TrustLiabilityID;
    }

    protected override void Initialize()
    {
      this.m_sTableName = "PostRef";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.STRING, "PostRefNickName");
      CPostItem cpostItem2 = cpostItem1;
      this.m_NickName = cpostItem1;
      postItems1.Add(cpostItem2);
      this.sNicknameLinkName = "PostRefNickName";
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.STRING, "PostRefName");
      CPostItem cpostItem4 = cpostItem3;
      this.m_Name = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "PostRefID");
      CPostItem cpostItem6 = cpostItem5;
      this.m_ID = cpostItem5;
      postItems3.Add(cpostItem6);
      this.sIDLinkName = "PostRefID";
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "DepartmentID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_DepartmentID = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "LawyerID");
      CPostItem cpostItem10 = cpostItem9;
      this.m_LawyerID = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "PostRefSpecialAcct");
      CPostItem cpostItem12 = cpostItem11;
      this.m_SpecialAcct = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "PostRefStatus");
      CPostItem cpostItem14 = cpostItem13;
      this.m_Status = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "PostRefType");
      CPostItem cpostItem16 = cpostItem15;
      this.m_AcctType = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.STRING, "PostRefCostCenter");
      CPostItem cpostItem18 = cpostItem17;
      this.m_CostCenter = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.STRING, "PostRefCategory");
      CPostItem cpostItem20 = cpostItem19;
      this.m_Category = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.LONG, "PostRefSubAcctOf");
      CPostItem cpostItem22 = cpostItem21;
      this.m_SubAcctOfID = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "PostRefTransactionChangeID");
      CPostItem cpostItem24 = cpostItem23;
      this.m_TransactionChgID = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.LONG, "PostRefTransNewID");
      CPostItem cpostItem26 = cpostItem25;
      this.m_TransactionNewID = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.STRING, "PostRefQuickBooksID");
      CPostItem cpostItem28 = cpostItem27;
      this.m_QuickBooksID = cpostItem27;
      postItems14.Add(cpostItem28);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    private static void ReadTable()
    {
      if (PLGLAccts.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("PostRef", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "PostRefStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "PostRefNickName", "", ref szValue);
        string Key = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32_1 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "PostRefID");
        PLGLAccts.AddMapNNtoID(Key, recordFieldValueI32_1);
        PLGLAccts.AddMapIDtoNN(recordFieldValueI32_1, Key);
        int recordFieldValueI32_2 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "LawyerID");
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "PostRefSpecialAcct", "", ref szValue);
        if (!szValue.ToString().Equals(""))
        {
          if (Convert.ToInt32(szValue) == Convert.ToInt32((object) PLGLAccts.eSPEC_ACCT.DISB_REC))
          {
            PLGLAccts.m_ExpRecovNN = Key;
            PLGLAccts.m_ExpRecovID = recordFieldValueI32_1;
          }
          else if (Convert.ToInt32(szValue) == Convert.ToInt32((object) PLGLAccts.eSPEC_ACCT.SUSPENSE))
          {
            PLGLAccts.m_SuspenseNN = Key;
            PLGLAccts.m_SuspenseID = recordFieldValueI32_1;
          }
          else if (Convert.ToInt32(szValue) == Convert.ToInt32((object) PLGLAccts.eSPEC_ACCT.AP))
          {
            PLGLAccts.m_APAccountNN = Key;
            PLGLAccts.m_APAccountID = recordFieldValueI32_1;
          }
          else if (Convert.ToInt32(szValue) == Convert.ToInt32((object) PLGLAccts.eSPEC_ACCT.AR))
          {
            PLGLAccts.m_ARAccountNN = Key;
            PLGLAccts.m_ARAccountID = recordFieldValueI32_1;
          }
          else if (recordFieldValueI32_2 == 0 && Convert.ToInt32(szValue) == Convert.ToInt32((object) PLGLAccts.eSPEC_ACCT.FEES))
            PLGLAccts.m_FeesEarnedAccountID = recordFieldValueI32_1;
          else if (Convert.ToInt32(szValue) == Convert.ToInt32((object) PLGLAccts.eSPEC_ACCT.TRUST_LIABILITY))
            PLGLAccts.m_TrustLiabilityID = recordFieldValueI32_1;
        }
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "PostRefQuickBooksID", "", ref szValue);
        string str = szValue.ToString().ToUpper().Trim();
        if (!str.Equals(""))
          PLGLAccts.AddMapPLIDtoQBID(recordFieldValueI32_1, str);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLGLAccts.bRead = true;
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
      string szDefault = "";
      this.m_lSendErrorCount = 0L;
      this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_NickName.sLinkName, szDefault, ref szValue);
          PLGLAccts.AddMapIDtoNN(int32, szValue.ToString());
          PLGLAccts.AddMapNNtoID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLGLAccts.AddMapExtID1toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLGLAccts.AddMapExtID2toPLID(szValue.ToString(), Convert.ToInt32(vunIDCreated));
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "PostRefQuickBooksID", szDefault, ref szValue);
          string str = szValue.ToString().ToUpper().Trim();
          if (!str.Equals(""))
            PLGLAccts.AddMapPLIDtoQBID(int32, str);
        }
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLGLAccts plglAccts = this;
        plglAccts.m_lSendErrorCount = plglAccts.m_lSendErrorCount + 1L;
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }

    public enum eACCOUNT_TYPE : short
    {
      CURRENT_ASSET = 1000,
      FIXED_ASSET = 2000,
      SHORT_LIABILITY = 3000,
      LONG_LIABILITY = 3500,
      EQUITY = 4000,
      RETAINED = 5000,
      INCOME = 6000,
      EXPENSE = 7000,
      SPEC_RETAINED = 8000,
    }

    public enum eSPEC_ACCT : byte
    {
      NOT_SET,
      GBANK,
      TBANK,
      AR,
      DISB_REC,
      AP,
      TRUST_LIABILITY,
      GST,
      PST,
      AP_DISCOUNT,
      PARTNERS_EQUITY,
      RET_EARNINGS,
      DRAWINGS,
      FEES,
      INTEREST,
      BAD_DEBT,
      SUSPENSE,
      SPECIAL_RETAINED,
      SOFT_COSTS,
      MARKUP_INCOME,
      PROV_BAD_DEBT,
      TRUST_INTEREST,
      TRUST_INTEREST_COMMISSION,
      TRUST_ADV_CONTROL,
    }
  }
}
