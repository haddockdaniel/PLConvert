// Decompiled with JetBrains decompiler
// Type: PLConvert.PLExpCode
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLExpCode : StaticData
  {
    private new static List<string> m_NNs = new List<string>();
    private static Dictionary<string, int> m_MapNNtoID = new Dictionary<string, int>();
    private static Dictionary<int, string> m_MapIDtoNN = new Dictionary<int, string>();
    private static Dictionary<int, string> m_MapIDtoExplanation = new Dictionary<int, string>();
    private static Dictionary<string, int> m_MapExtID1toPLID = new Dictionary<string, int>();
    private static Dictionary<string, int> m_MapExtID2toPLID = new Dictionary<string, int>();
    private static bool bRead = false;
    private CPostItem m_DefTaxCategory;
    private CPostItem m_ExplanationType;
    private CPostItem m_SummarizeOnBill;
    private CPostItem m_ForceSummarizeOnBill;
    private CPostItem m_IsSpecialFee;
    private CPostItem m_IsTAFEligible;
    private CPostItem m_IsUseForMarkup;
    private CPostItem m_IsUseForMilage;
    private CPostItem m_IsUseForCounsel;
    private CPostItem m_IsUseForQuantity;
    private CPostItem m_MarkUpPercent;
    private CPostItem m_Name;
    private CPostItem m_RateID;
    private CPostItem m_RateAmount;
    private CPostItem m_UseTask;
    private CPostItem m_GLID;
    private static Dictionary<int, string> m_MapPLIDtoQBID;

    public PLExpCode.eEXPL_TYPE ExplType
    {
      get
      {
        return (PLExpCode.eEXPL_TYPE) this.m_ExplanationType.nValue;
      }
      set
      {
        this.m_ExplanationType.SetValue((int) value);
      }
    }

    public string GLNN
    {
      get
      {
        return PLGLAccts.GetNNFromID(this.m_GLID.nValue);
      }
      set
      {
        this.m_GLID.SetValue(PLGLAccts.GetIDFromNN(value));
      }
    }

    public PLExpCode.eGST_CAT GSTCat
    {
      get
      {
        return (PLExpCode.eGST_CAT) this.m_DefTaxCategory.nValue;
      }
      set
      {
        this.m_DefTaxCategory.SetValue((int) value);
      }
    }

    public bool IsSpecialFee
    {
      get
      {
        return this.m_IsSpecialFee.bValue;
      }
      set
      {
        this.m_IsSpecialFee.SetValue(value);
      }
    }

    public bool IsTAFEligible
    {
      get
      {
        return this.m_IsTAFEligible.bValue;
      }
      set
      {
        this.m_IsTAFEligible.SetValue(value);
      }
    }

    public bool IsUseForCounsel
    {
      get
      {
        return this.m_IsUseForCounsel.bValue;
      }
      set
      {
        this.m_IsUseForCounsel.SetValue(value);
      }
    }

    public bool IsUseForMarkup
    {
      get
      {
        return this.m_IsUseForMarkup.bValue;
      }
      set
      {
        this.m_IsUseForMarkup.SetValue(value);
      }
    }

    public bool IsUseForMilage
    {
      get
      {
        return this.m_IsUseForMilage.bValue;
      }
      set
      {
        this.m_IsUseForMilage.SetValue(value);
      }
    }

    public bool IsUseForQuantity
    {
      get
      {
        return this.m_IsUseForQuantity.bValue;
      }
      set
      {
        this.m_IsUseForQuantity.SetValue(value);
      }
    }

    public double MarkUpPercent
    {
      get
      {
        return this.m_MarkUpPercent.dValue;
      }
      set
      {
        this.m_MarkUpPercent.SetValue(value);
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

    public double RateAmount
    {
      get
      {
        return this.m_RateAmount.dValue;
      }
      set
      {
        this.m_RateAmount.SetValue(value);
      }
    }

    public string RateNN
    {
      get
      {
        return PLRate.GetNNFromID(this.m_RateID.nValue);
      }
      set
      {
        this.m_RateID.SetValue(PLRate.GetIDFromNN(value));
      }
    }

    public PLExpCode.eSUMMARIZE Summarize
    {
      get
      {
        return (PLExpCode.eSUMMARIZE) this.m_ForceSummarizeOnBill.nValue;
      }
      set
      {
        switch (this.Summarize)
        {
          case PLExpCode.eSUMMARIZE.DO_NOT_SUMMARIZE:
            this.m_SummarizeOnBill.SetValue(false);
            this.m_ForceSummarizeOnBill.SetValue(false);
            break;
          case PLExpCode.eSUMMARIZE.SUMMARIZE_IF_NO_EXTRA_TEXT:
            this.m_SummarizeOnBill.SetValue(true);
            this.m_ForceSummarizeOnBill.SetValue(false);
            break;
          case PLExpCode.eSUMMARIZE.ALWAYS_SUMMARIZE:
            this.m_SummarizeOnBill.SetValue(false);
            this.m_ForceSummarizeOnBill.SetValue(true);
            break;
        }
      }
    }

    public bool UseTask
    {
      get
      {
        return this.m_UseTask.bValue;
      }
      set
      {
        this.m_UseTask.SetValue(value);
      }
    }

    public PLExpCode()
    {
      this.Initialize();
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLExpCode.m_MapExtID1toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLExpCode.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((Key.Equals("") ? 0 : (!PLExpCode.m_MapExtID2toPLID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLExpCode.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapIDtoExplanation(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLExpCode.m_MapIDtoExplanation.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLExpCode.m_MapIDtoExplanation.Add(Key, Value);
    }

    public static void AddMapIDtoNN(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!PLExpCode.m_MapIDtoNN.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLExpCode.m_MapIDtoNN.Add(Key, Value);
    }

    public static void AddMapNNtoID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((Key.Equals("") ? 0 : (!PLExpCode.m_MapNNtoID.ContainsKey(Key) ? 1 : 0)) == 0)
        return;
      PLExpCode.m_MapNNtoID.Add(Key, Value);
    }

    public static void AddMapPLIDtoQBID(int Key, string Value)
    {
      if ((Key.Equals(0) ? 0 : (!Value.Equals("") ? 1 : 0)) == 0)
        return;
      if (PLExpCode.m_MapPLIDtoQBID == null)
        PLExpCode.m_MapPLIDtoQBID = new Dictionary<int, string>();
      if (PLExpCode.m_MapPLIDtoQBID.ContainsKey(Key))
        PLExpCode.m_MapPLIDtoQBID.Remove(Key);
      PLExpCode.m_MapPLIDtoQBID.Add(Key, Value);
    }

    protected new static void AddNicknameToList(string sNickname)
    {
      if (string.IsNullOrEmpty(sNickname))
        return;
      if (PLExpCode.m_NNs == null)
        PLExpCode.m_NNs = new List<string>();
      PLExpCode.m_NNs.Add(sNickname.ToLower());
    }

    public override void AddRecord()
    {
      //if (!this.m_NickName.m_bIsSet)
      //  this.NickName = this.MakeNN(true);
      //else if ((this.m_ID.m_bIsSet && this.m_ID.nValue.Equals(0) || !this.m_ID.m_bIsSet) && PLExpCode.GetIDFromNN(this.NickName) > 0)
       // this.NickName = this.MakeNN(true);
      //else if ((this.NickName.Length.Equals(0) ? 1 : (this.NickName.Length > 6 ? 1 : 0)) != 0)
        //this.NickName = this.MakeNN(true);
      PLExpCode.AddNicknameToList(this.NickName);
      base.AddRecord();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLExpCode plExpCode = this;
      plExpCode.m_lCounter = plExpCode.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLExpCode.m_MapExtID1toPLID == null)
        return;
      PLExpCode.m_MapExtID1toPLID.Clear();
      PLExpCode.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLExpCode.m_MapExtID2toPLID == null)
        return;
      PLExpCode.m_MapExtID2toPLID.Clear();
      PLExpCode.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapIDtoExplanation()
    {
      if (PLExpCode.m_MapIDtoExplanation == null)
        return;
      PLExpCode.m_MapIDtoExplanation.Clear();
      PLExpCode.m_MapIDtoExplanation = (Dictionary<int, string>) null;
    }

    public static void ClearMapIDtoNN()
    {
      if (PLExpCode.m_MapIDtoNN == null)
        return;
      PLExpCode.m_MapIDtoNN.Clear();
      PLExpCode.m_MapIDtoNN = (Dictionary<int, string>) null;
    }

    public static void ClearMapNNtoID()
    {
      if (PLExpCode.m_MapNNtoID == null)
        return;
      PLExpCode.m_MapNNtoID.Clear();
      PLExpCode.m_MapNNtoID = (Dictionary<string, int>) null;
    }

    public static void ClearMapPLIDtoQBID()
    {
      if (PLExpCode.m_MapPLIDtoQBID == null)
        return;
      PLExpCode.m_MapPLIDtoQBID.Clear();
      PLExpCode.m_MapPLIDtoQBID = (Dictionary<int, string>) null;
    }

    public static string GetExplanationFromID(int Key)
    {
      if (!PLExpCode.bRead)
        PLExpCode.ReadTable();
      return PLExpCode.m_MapIDtoExplanation.ContainsKey(Key) ? PLExpCode.m_MapIDtoExplanation[Key].ToString() : "";
    }

    public static int GetIDFromExtID1(string Key)
    {
      return PLExpCode.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLExpCode.m_MapExtID1toPLID[Key]) : 0;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return PLExpCode.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLExpCode.m_MapExtID2toPLID[Key]) : 0;
    }

    public static int GetIDFromNN(string Key)
    {
      if (!PLExpCode.bRead)
        PLExpCode.ReadTable();
      Key = Key.ToUpper();
      return PLExpCode.m_MapNNtoID.ContainsKey(Key) ? Convert.ToInt32(PLExpCode.m_MapNNtoID[Key]) : 0;
    }

    public static string GetNNFromID(int Key)
    {
      if (!PLExpCode.bRead)
        PLExpCode.ReadTable();
      return PLExpCode.m_MapIDtoNN.ContainsKey(Key) ? PLExpCode.m_MapIDtoNN[Key].ToString() : "";
    }

    public static int GetPLIDFromQBID(string sQBID)
    {
      int num1;
      if (!sQBID.Equals(""))
      {
        if (!PLExpCode.bRead)
          PLExpCode.ReadTable();
        if (PLExpCode.m_MapPLIDtoQBID == null)
          num1 = 0;
        else if (PLExpCode.m_MapPLIDtoQBID.ContainsValue(sQBID))
        {
          int num2 = 0;
          Dictionary<int, string>.Enumerator enumerator = PLExpCode.m_MapPLIDtoQBID.GetEnumerator();
          while (enumerator.MoveNext())
          {
            Dictionary<int, string> mapPliDtoQbid = PLExpCode.m_MapPLIDtoQBID;
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
        if (!PLExpCode.bRead)
          PLExpCode.ReadTable();
        str = PLExpCode.m_MapPLIDtoQBID == null ? "" : (PLExpCode.m_MapPLIDtoQBID.ContainsKey(nID) ? Convert.ToString(PLExpCode.m_MapPLIDtoQBID[nID]) : "");
      }
      else
        str = "";
      return str;
    }

    protected override void Initialize()
    {
      this.m_sTableName = "Explanation";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.BOOL, "ActivityForceSummarizeOnBill");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ForceSummarizeOnBill = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.BOOL, "ActivityIsSpecialFee");
      CPostItem cpostItem4 = cpostItem3;
      this.m_IsSpecialFee = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.BOOL, "ActivityIsTAFEligible");
      CPostItem cpostItem6 = cpostItem5;
      this.m_IsTAFEligible = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.BOOL, "ActivityIsUseForMarkup");
      CPostItem cpostItem8 = cpostItem7;
      this.m_IsUseForMarkup = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.BOOL, "ActivityIsUseforMileage");
      CPostItem cpostItem10 = cpostItem9;
      this.m_IsUseForMilage = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.BOOL, "ActivityUseForCounsel");
      CPostItem cpostItem12 = cpostItem11;
      this.m_IsUseForCounsel = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.BOOL, "ActivityIsUseForQuantity");
      CPostItem cpostItem14 = cpostItem13;
      this.m_IsUseForQuantity = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.BOOL, "ActivitySummarizeOnBill");
      CPostItem cpostItem16 = cpostItem15;
      this.m_SummarizeOnBill = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.BOOL, "ActivityUseTask");
      CPostItem cpostItem18 = cpostItem17;
      this.m_UseTask = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.DOUBLE, "ActivityMarkUpPercent");
      CPostItem cpostItem20 = cpostItem19;
      this.m_MarkUpPercent = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.DOUBLE, "ActivityRateAmount");
      CPostItem cpostItem22 = cpostItem21;
      this.m_RateAmount = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "ActivityDefTaxCategory");
      CPostItem cpostItem24 = cpostItem23;
      this.m_DefTaxCategory = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.LONG, "ActivityExplanationType");
      CPostItem cpostItem26 = cpostItem25;
      this.m_ExplanationType = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.LONG, "ActivityID");
      CPostItem cpostItem28 = cpostItem27;
      this.m_ID = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.LONG, "RateID");
      CPostItem cpostItem30 = cpostItem29;
      this.m_RateID = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.LONG, "ActivityStatus");
      CPostItem cpostItem32 = cpostItem31;
      this.m_Status = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.LONG, "PostRefID");
      CPostItem cpostItem34 = cpostItem33;
      this.m_GLID = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.STRING, "ActivityName");
      CPostItem cpostItem36 = cpostItem35;
      this.m_Name = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.STRING, "ActivityNickName");
      CPostItem cpostItem38 = cpostItem37;
      this.m_NickName = cpostItem37;
      postItems19.Add(cpostItem38);
      List<CPostItem> postItems20 = this.PostItems;
      CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.LONG, "ActivityTransactionChangeID");
      CPostItem cpostItem40 = cpostItem39;
      this.m_TransactionChgID = cpostItem39;
      postItems20.Add(cpostItem40);
      List<CPostItem> postItems21 = this.PostItems;
      CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.LONG, "ActivityTransNewID");
      CPostItem cpostItem42 = cpostItem41;
      this.m_TransactionNewID = cpostItem41;
      postItems21.Add(cpostItem42);
      List<CPostItem> postItems22 = this.PostItems;
      CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.STRING, "ActivityQuickBooksID");
      CPostItem cpostItem44 = cpostItem43;
      this.m_QuickBooksID = cpostItem43;
      postItems22.Add(cpostItem44);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
    }

    public override string MakeNN(bool bSetNickName)
    {
      if (!PLExpCode.bRead)
        PLExpCode.ReadTable();
      string str = this.MakeListNN(this.Name, PLExpCode.m_NNs, (short) 6);
      if (bSetNickName)
        this.NickName = str;
      return str;
    }

    private static void ReadTable()
    {
      if (PLExpCode.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      uint createHandle = PLLink.GetLink().TableGET_CreateHandle("Explanation", 0, 0, 0U);
      PLLink.GetLink().TableGET_AddFilter(createHandle, "ActivityStatus", "EQ", "0", 1);
      while (PLLink.GetLink().TableGET_GetNextRecord(createHandle) == 0)
      {
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "ActivityNickName", "", ref szValue);
        string sNickname = szValue.ToString().ToUpper().Trim();
        int recordFieldValueI32 = PLLink.GetLink().TableGET_RecordField_ValueI32(createHandle, "ActivityID");
        PLExpCode.AddMapIDtoNN(recordFieldValueI32, sNickname.ToUpper());
        PLExpCode.AddMapNNtoID(sNickname.ToUpper(), recordFieldValueI32);
        PLExpCode.AddNicknameToList(sNickname);
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "ActivityName", "", ref szValue);
        PLExpCode.AddMapIDtoExplanation(recordFieldValueI32, szValue.ToString());
        PLLink.GetLink().TableGET_RecordField_ValueString(createHandle, "ActivityQuickBooksID", "", ref szValue);
        string str = szValue.ToString().ToUpper().Trim();
        if (!str.Equals(""))
          PLExpCode.AddMapPLIDtoQBID(recordFieldValueI32, str);
      }
      PLLink.GetLink().TableGET_CloseHandle(createHandle);
      num = 0U;
      PLExpCode.bRead = true;
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
          PLExpCode.AddMapIDtoNN(int32, szValue.ToString().ToUpper());
          PLExpCode.AddMapNNtoID(szValue.ToString().ToUpper(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_Name.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLExpCode.AddMapIDtoExplanation(int32, szValue.ToString());
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLExpCode.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, szDefault, ref szValue);
          if (!szValue.ToString().Equals(""))
            PLExpCode.AddMapExtID2toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "ActivityQuickBooksID", szDefault, ref szValue);
          PLExpCode.AddMapPLIDtoQBID(Convert.ToInt32(vunIDCreated), szValue.ToString());
        }
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLExpCode plExpCode = this;
        plExpCode.m_lSendErrorCount = plExpCode.m_lSendErrorCount + 1L;
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
    }

    public enum eEXPL_TYPE : byte
    {
      TIME = 4,
      EXPENSE = 8,
      ALL = 12,
    }

    public enum eGST_CAT
    {
      NOT_SET = 0,
      BOTH = 98,
      NO = 110,
      PST = 112,
      YES = 121,
    }

    public enum eSUMMARIZE : byte
    {
      DO_NOT_SUMMARIZE,
      SUMMARIZE_IF_NO_EXTRA_TEXT,
      ALWAYS_SUMMARIZE,
    }
  }
}
