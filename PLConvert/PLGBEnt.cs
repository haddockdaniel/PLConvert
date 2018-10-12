// Decompiled with JetBrains decompiler
// Type: PLConvert.PLGBEnt
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLGBEnt : TransactionData
  {
    public static bool m_bAllowEntOnClosedMtr = false;
    public PLGBAlloc Alloc;
    private List<PLGBAlloc> m_AllocArray;
    public PLGBARAlloc RcptARAlloc;
    private List<PLGBARAlloc> m_ARAllocArray;
    private CPostItem m_BankAcctID;
    private CPostItem m_Date;
    private CPostItem m_TotalAmount;
    private CPostItem m_EntryGSTCat;
    private CPostItem m_GSTAmount;
    private CPostItem m_PaidTo;
    private CPostItem m_EntryType;
    private CPostItem m_PmtMethodFlag;
    private CPostItem m_CheckNum;
    private CPostItem m_OrigBank;
    private CPostItem m_ClientCheckNum;
    private CPostItem m_DateEntered;
    private CPostItem m_AddrLine1;
    private CPostItem m_AddrLine2;
    private CPostItem m_AddrCity;
    private CPostItem m_AddrState;
    private CPostItem m_AddrZip;
    private CPostItem m_AddrCountry;
    private CPostItem m_AddrCheckExpl;

    public string AddrCheckExpl
    {
      get
      {
        return this.m_AddrCheckExpl.sValue;
      }
      set
      {
        this.m_AddrCheckExpl.SetValue(value);
      }
    }

    public string AddrCity
    {
      get
      {
        return this.m_AddrCity.sValue;
      }
      set
      {
        this.m_AddrCity.SetValue(value);
      }
    }

    public string AddrCountry
    {
      get
      {
        return this.m_AddrCountry.sValue;
      }
      set
      {
        this.m_AddrCountry.SetValue(value);
      }
    }

    public string AddrLine1
    {
      get
      {
        return this.m_AddrLine1.sValue;
      }
      set
      {
        this.m_AddrLine1.SetValue(value);
      }
    }

    public string AddrLine2
    {
      get
      {
        return this.m_AddrLine2.sValue;
      }
      set
      {
        this.m_AddrLine2.SetValue(value);
      }
    }

    public string AddrState
    {
      get
      {
        return this.m_AddrState.sValue;
      }
      set
      {
        this.m_AddrState.SetValue(value);
      }
    }

    public string AddrZip
    {
      get
      {
        return this.m_AddrLine1.sValue;
      }
      set
      {
        this.m_AddrLine1.SetValue(value);
      }
    }

    public int BankAcctID
    {
      get
      {
        return this.m_BankAcctID.nValue;
      }
      set
      {
        this.m_BankAcctID.SetValue(value);
      }
    }

    public int BankAcctNum
    {
      get
      {
        return Convert.ToInt32(PLGBAcct.GetNNFromID(this.m_BankAcctID.nValue));
      }
      set
      {
        this.m_BankAcctID.SetValue(PLGBAcct.GetIDFromNN(value.ToString()));
      }
    }

    public string CheckNum
    {
      get
      {
        return this.m_CheckNum.sValue;
      }
      set
      {
        this.m_CheckNum.SetValue(value);
      }
    }

    public string ClientCheckNum
    {
      get
      {
        return this.m_ClientCheckNum.sValue;
      }
      set
      {
        this.m_ClientCheckNum.SetValue(value);
      }
    }

    public int Date
    {
      get
      {
        return this.m_Date.nValue;
      }
      set
      {
        this.m_Date.SetValue(value);
      }
    }

    public int DateEntered
    {
      get
      {
        return this.m_DateEntered.nValue;
      }
      set
      {
        this.m_DateEntered.SetValue(value);
      }
    }

    public TransactionData.eGST_CAT EntryGSTCat
    {
      get
      {
        return (TransactionData.eGST_CAT) this.m_EntryGSTCat.nValue;
      }
      set
      {
        this.m_EntryGSTCat.SetValue((int) value);
      }
    }

    public PLGBEnt.eGBEntryType EntryType
    {
      get
      {
        return (PLGBEnt.eGBEntryType) this.m_EntryType.nValue;
      }
      set
      {
        this.m_EntryType.SetValue((int) value);
      }
    }

    public double GSTAmount
    {
      get
      {
        return this.m_GSTAmount.dValue;
      }
      set
      {
        this.m_GSTAmount.SetValue(value);
      }
    }

    public string OrigBank
    {
      get
      {
        return this.m_OrigBank.sValue;
      }
      set
      {
        this.m_OrigBank.SetValue(value);
      }
    }

    public string PaidTo
    {
      get
      {
        return this.m_PaidTo.sValue;
      }
      set
      {
        this.m_PaidTo.SetValue(value);
      }
    }

    public PLGBEnt.ePmtMethod PmtMethodFlag
    {
      get
      {
        return (PLGBEnt.ePmtMethod) this.m_PmtMethodFlag.nValue;
      }
      set
      {
        this.m_PmtMethodFlag.SetValue((int) value);
      }
    }

    public double TotalAmount
    {
      get
      {
        return this.m_TotalAmount.dValue;
      }
      set
      {
        this.m_TotalAmount.SetValue(value);
      }
    }

    public PLGBEnt()
    {
      this.Initialize();
    }

    public void AddGBAllocation()
    {
      this.m_AllocArray.Add(new PLGBAlloc(this.Alloc));
      this.Alloc.Clear();
    }

    public void AddRcptARAllocation()
    {
      this.m_ARAllocArray.Add(new PLGBARAlloc(this.RcptARAlloc));
      this.RcptARAlloc.Clear();
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
      {
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
        this.GetLink().TablePOST_AddDirective(this.m_hndPOST, "allowentonclosedmtr", PLGBEnt.m_bAllowEntOnClosedMtr ? "1" : "0");
      }
      base.AddRecord();
      for (int nRepeat = 1; nRepeat <= this.m_AllocArray.Count; ++nRepeat)
        this.m_AllocArray[nRepeat - 1].AddRepeatFields(this.m_hndPOST, nRepeat);
      this.m_AllocArray.Clear();
      for (int nRepeat = 1; nRepeat <= this.m_ARAllocArray.Count; ++nRepeat)
        this.m_ARAllocArray[nRepeat - 1].AddRepeatFields(this.m_hndPOST, nRepeat);
      this.m_ARAllocArray.Clear();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLGBEnt plgbEnt = this;
      plgbEnt.m_lCounter = plgbEnt.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      base.Clear();
      this.Alloc.Clear();
      this.RcptARAlloc.Clear();
      this.m_AllocArray.Clear();
      this.m_ARAllocArray.Clear();
    }

    public List<PLGBAlloc> GetAllocArray()
    {
      return this.m_AllocArray;
    }

    public int GetAllocCount()
    {
      return this.m_AllocArray.Count;
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return PLGBEnt.m_bAllowEntOnClosedMtr;
    }

    public List<PLGBARAlloc> GetARAllocArray()
    {
      return this.m_ARAllocArray;
    }

    public int GetARAllocCount()
    {
      return this.m_ARAllocArray.Count;
    }

    public override void GetExistingRecord()
    {
      this.Clear();
      if ((int) this.m_hndExisting == 0)
        this.m_hndExisting = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      base.GetExistingRecord();
      this.m_AllocArray.Clear();
      int recurringFieldCount1 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "GeneralAllocAllocID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount1; ++nRepeat)
      {
        this.Alloc.GetRepeatFields(this.m_hndExisting, nRepeat);
        this.AddGBAllocation();
      }
      this.m_ARAllocArray.Clear();
      int recurringFieldCount2 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "ARAllocInvoiceID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount2; ++nRepeat)
      {
        this.RcptARAlloc.GetRepeatFields(this.m_hndExisting, nRepeat);
        this.AddRcptARAllocation();
      }
    }

    public override void GetRecord()
    {
      this.Clear();
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      base.GetRecord();
      this.m_AllocArray.Clear();
      int recurringFieldCount1 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "GeneralAllocAllocID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount1; ++nRepeat)
      {
        this.Alloc.GetRepeatFields(this.m_hndGET, nRepeat);
        this.AddGBAllocation();
      }
      this.m_ARAllocArray.Clear();
      int recurringFieldCount2 = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "ARAllocInvoiceID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount2; ++nRepeat)
      {
        this.RcptARAlloc.GetRepeatFields(this.m_hndGET, nRepeat);
        this.AddRcptARAllocation();
      }
    }

    public double GetTotalAmountAlloc()
    {
      double num = 0.0;
      for (int index = 1; index <= this.m_AllocArray.Count; ++index)
        num += this.m_AllocArray[index - 1].Amount;
      return num;
    }

    protected override void Initialize()
    {
      this.m_sTableName = "EntryGeneral";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "GeneralEntryID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "GeneralEntryStatus");
      CPostItem cpostItem4 = cpostItem3;
      this.m_Status = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "GeneralBankAcctID");
      CPostItem cpostItem6 = cpostItem5;
      this.m_BankAcctID = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "GeneralEntryDate");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Date = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.DOUBLE, "GeneralEntryTotalAmount");
      CPostItem cpostItem10 = cpostItem9;
      this.m_TotalAmount = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryPaidTo");
      CPostItem cpostItem12 = cpostItem11;
      this.m_PaidTo = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "GeneralEntryGSTCat");
      CPostItem cpostItem14 = cpostItem13;
      this.m_EntryGSTCat = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.DOUBLE, "GeneralEntryGSTAmount");
      CPostItem cpostItem16 = cpostItem15;
      this.m_GSTAmount = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.LONG, "GeneralEntryEntryType");
      CPostItem cpostItem18 = cpostItem17;
      this.m_EntryType = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.LONG, "GeneralEntryPmtMethodFlag");
      CPostItem cpostItem20 = cpostItem19;
      this.m_PmtMethodFlag = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryCheckNum");
      CPostItem cpostItem22 = cpostItem21;
      this.m_CheckNum = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryOrigBank");
      CPostItem cpostItem24 = cpostItem23;
      this.m_OrigBank = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryClientCheckNum");
      CPostItem cpostItem26 = cpostItem25;
      this.m_ClientCheckNum = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.LONG, "GeneralEntryDateEntered");
      CPostItem cpostItem28 = cpostItem27;
      this.m_DateEntered = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "GeneralQuickBooksID");
      CPostItem cpostItem30 = cpostItem29;
      this.m_QuickBooksID = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryAddrLine1");
      CPostItem cpostItem32 = cpostItem31;
      this.m_AddrLine1 = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryAddrLine2");
      CPostItem cpostItem34 = cpostItem33;
      this.m_AddrLine2 = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryAddrCity");
      CPostItem cpostItem36 = cpostItem35;
      this.m_AddrCity = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryAddrState");
      CPostItem cpostItem38 = cpostItem37;
      this.m_AddrState = cpostItem37;
      postItems19.Add(cpostItem38);
      List<CPostItem> postItems20 = this.PostItems;
      CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryAddrZip");
      CPostItem cpostItem40 = cpostItem39;
      this.m_AddrZip = cpostItem39;
      postItems20.Add(cpostItem40);
      List<CPostItem> postItems21 = this.PostItems;
      CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryAddrCountry");
      CPostItem cpostItem42 = cpostItem41;
      this.m_AddrCountry = cpostItem41;
      postItems21.Add(cpostItem42);
      List<CPostItem> postItems22 = this.PostItems;
      CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.STRING, "GeneralEntryAddrExpl");
      CPostItem cpostItem44 = cpostItem43;
      this.m_AddrCheckExpl = cpostItem43;
      postItems22.Add(cpostItem44);
      List<CPostItem> postItems23 = this.PostItems;
      CPostItem cpostItem45 = new CPostItem(CPostItem.DataType.LONG, "GeneralReverseEntryID");
      CPostItem cpostItem46 = cpostItem45;
      this.m_ReverseEntryID = cpostItem45;
      postItems23.Add(cpostItem46);
      this.Alloc = new PLGBAlloc();
      this.RcptARAlloc = new PLGBARAlloc();
      this.m_AllocArray = new List<PLGBAlloc>();
      this.m_ARAllocArray = new List<PLGBARAlloc>();
    }

    public enum eGBEntryType : short
    {
        GEN_RCPT_REQ_BILL = 1099,
        GEN_RCPT_INT = 1100,
        GEN_RCPT_PMNT = 1101,
        GEN_RCPT_RTNR = 1102, //if no invoiceid/number retainer, otherwise payment
        GEN_RCPT_RTNRALLOC = 1103,
        GEN_RCPT_RTNRADJ = 1104,
        GEN_RCPT_COB = 1105,
        GEN_OPENING_BAL = 1200,
        GEN_RCPT = 1300, //cannot be assigned a matterid because it is a general receipt
        //1301 – is the type used for the general bank receipt entry of a trust to general transfer. 
        //However, the general bank allocation does not use 1301
        //GEN_TDT = 1301,
        GEN_GEN_XFER = 1302,
        GEN_RCPT_GJ = 1303,
        GEN_CHE = 1400,
        GEN_AP_CHE = 1401,
        GEN_GTT = 1402,
        GEN_CHE_GJ = 1403,
        GEN_PRIOR_CHECK = 1550,
        GEN_PRIOR_RCPT = 1551,
        GEN_BANK_ERROR_CHECK = 1552,
        GEN_BANK_ERROR_RCPT = 1553,
        EXP_REC = 1600,
        EXP_COB = 1650,
        EXP_GST_COB = 1651,
        EXP_STAX_COB = 1652,
        EXP_ANT_DISB = 1653,
        DISB_GST = 1700,
        DISB_STAX = 1701,
        DISB_WO_STAX_ADJ = 1800,
        DISB_WO_STAX_BADDEBT,
        DISB_WO_GST_ADJ,
        DISB_WO_GST_BADDEBT,
        DISB_WO_ADJ = 1898,
        DISB_WO_BADDEBT = 1899,
        GST_FWD_REMIT = 1900,
        GST_FWD_CHECKS,
        GST_FWD_BILLINGS,
        GST_FWD_WRITEUP,
        GST_FWD_WRITEDOWN,
        GST_FWD_PREVBAL,
        SOFTDISB_WO_ADJ = 1910,
        SOFTDISB_WO_BADDEBT = 1911,
        TRANS_LEVY_RE = 2000,
        TRANS_LEVY_LIT = 2001,
        BC_TAF = 2002,
        GBANK_SUMM = 2010,
        GBANK_UNDOBILL = 2015
    }

    public enum ePmtMethod : byte
    {
      Check = 1,
      Money = 2,
      Credit = 3,
      Other = 4,
      Bank_Check = 5,
      Direct_Deposit = 6,
      Money_Order = 7,
      Wire = 8,
      Certified_Check = 9,
    }
  }
}
