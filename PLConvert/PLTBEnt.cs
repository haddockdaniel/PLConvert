// Decompiled with JetBrains decompiler
// Type: PLConvert.PLTBEnt
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLTBEnt : TransactionData
  {
    public static bool m_bAllowEntOnClosedMtr = false;
    public PLTBAlloc Alloc;
    private CPostItem m_BankAcctID;
    private CPostItem m_Date;
    private CPostItem m_TotalAmount;
    private CPostItem m_PaidTo;
    private CPostItem m_EntryType;
    private CPostItem m_PmtMethodFlag;
    private CPostItem m_CheckNum;
    private CPostItem m_OrigBank;
    private CPostItem m_ClientCheckNum;
    private CPostItem m_DateEntered;
    private CPostItem m_GSTAmount;
    private CPostItem m_IsTrustCostDisb;
    private CPostItem m_TransferAdvance;
    private CPostItem m_TransferGain;
    private CPostItem m_Interest;
    private CPostItem m_InterestRWT;
    private CPostItem m_IntCommission;
    private CPostItem m_IntGross;
    private CPostItem m_AddrLine1;
    private CPostItem m_AddrLine2;
    private CPostItem m_AddrCity;
    private CPostItem m_AddrState;
    private CPostItem m_AddrZip;
    private CPostItem m_AddrCountry;
    private CPostItem m_AddrCheckExpl;
    private List<PLTBAlloc> m_AllocArray;

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
        return Convert.ToInt32(PLTBAcct.GetNNFromID(this.m_BankAcctID.nValue));
      }
      set
      {
        this.m_BankAcctID.SetValue(PLTBAcct.GetIDFromNN(value.ToString()));
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

    public PLTBEnt.eTBEntryType EntryType
    {
      get
      {
        return (PLTBEnt.eTBEntryType) this.m_EntryType.nValue;
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

    public double IntCommission
    {
      get
      {
        return this.m_IntCommission.dValue;
      }
      set
      {
        this.m_IntCommission.SetValue(value);
      }
    }

    public double Interest
    {
      get
      {
        return this.m_Interest.dValue;
      }
      set
      {
        this.m_Interest.SetValue(value);
      }
    }

    public double InterestRWT
    {
      get
      {
        return this.m_InterestRWT.dValue;
      }
      set
      {
        this.m_InterestRWT.SetValue(value);
      }
    }

    public double IntGross
    {
      get
      {
        return this.m_IntGross.dValue;
      }
      set
      {
        this.m_IntGross.SetValue(value);
      }
    }

    public bool IsTrustCostDisb
    {
      get
      {
        return this.m_IsTrustCostDisb.bValue;
      }
      set
      {
        this.m_IsTrustCostDisb.SetValue(value);
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

    public PLTBEnt.ePmtMethod PmtMethodFlag
    {
      get
      {
        return (PLTBEnt.ePmtMethod) this.m_PmtMethodFlag.nValue;
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

    public double TransferAdvance
    {
      get
      {
        return this.m_TransferAdvance.dValue;
      }
      set
      {
        this.m_TransferAdvance.SetValue(value);
      }
    }

    public double TransferGain
    {
      get
      {
        return this.m_TransferGain.dValue;
      }
      set
      {
        this.m_TransferGain.SetValue(value);
      }
    }

    public PLTBEnt()
    {
      this.Initialize();
    }

    public void AddAllocation()
    {
      if (this.Alloc.Amount != 0.0)
      {
        PLTBAlloc pltbAlloc = new PLTBAlloc()
        {
          Amount = this.Alloc.Amount
        };
        if (!pltbAlloc.ExpCodeID.Equals(0))
          pltbAlloc.ExpCodeID = this.Alloc.ExpCodeID;
        pltbAlloc.Explanation = this.Alloc.Explanation;
        pltbAlloc.MatterID = this.Alloc.MatterID;
        pltbAlloc.AdvanceAmount = this.Alloc.AdvanceAmount;
        pltbAlloc.GainAmount = this.Alloc.GainAmount;
        pltbAlloc.GSTAmount = this.Alloc.GSTAmount;
        pltbAlloc.InvDate = this.Alloc.InvDate;
        pltbAlloc.InvID = this.Alloc.InvID;
        pltbAlloc.InvNumber = this.Alloc.InvNumber;
        this.m_AllocArray.Add(pltbAlloc);
        this.Alloc.Clear();
      }
      else
        this.Alloc.Clear();
    }

    public override void AddRecord()
    {
      if (this.m_AllocArray.Count == 0)
        return;
      if (this.PaidTo.Equals(""))
        this.PaidTo = "---";
      foreach (PLTBAlloc alloc in this.m_AllocArray)
      {
        if ((alloc.ExpCodeID != 0 ? 0 : (alloc.Explanation.Trim() == "" ? 1 : 0)) != 0)
        {
          switch (this.EntryType)
          {
            case PLTBEnt.eTBEntryType.Check:
              alloc.Explanation = "Disbursement";
              break;
            case PLTBEnt.eTBEntryType.Recipt:
              alloc.Explanation = "Receipt";
              break;
            default:
              alloc.Explanation = "Trust Transaction";
              break;
          }
        }
      }
      if ((int) this.m_hndPOST == 0)
      {
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
        this.GetLink().TablePOST_AddDirective(this.m_hndPOST, "allowentonclosedmtr", PLTBEnt.m_bAllowEntOnClosedMtr ? "1" : "0");
      }
      base.AddRecord();
      for (int nRepeat = 1; nRepeat <= this.m_AllocArray.Count; ++nRepeat)
        this.m_AllocArray[nRepeat - 1].AddRepeatFields(this.m_hndPOST, nRepeat);
      this.m_AllocArray.Clear();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLTBEnt pltbEnt = this;
      pltbEnt.m_lCounter = pltbEnt.m_lCounter + 1;
      if (this.m_lCounter >= PLXMLData.m_nMaxCounter)
        this.Send();
    }

    public override void Clear()
    {
      base.Clear();
      this.m_AllocArray.Clear();
    }

    public List<PLTBAlloc> GetAllocArray()
    {
      return this.m_AllocArray;
    }

    public int GetAllocCount()
    {
      return this.m_AllocArray.Count;
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return PLTBEnt.m_bAllowEntOnClosedMtr;
    }

    public override void GetExistingRecord()
    {
      this.Clear();
      base.GetExistingRecord();
      this.m_AllocArray.Clear();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "TrustAllocAllocID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.Alloc.GetRepeatFields(this.m_hndExisting, nRepeat);
        this.AddAllocation();
      }
    }

    public override void GetRecord()
    {
      this.Clear();
      base.GetRecord();
      this.m_AllocArray.Clear();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "TrustAllocAllocID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.Alloc.GetRepeatFields(this.m_hndGET, nRepeat);
        this.AddAllocation();
      }
    }

    protected override void Initialize()
    {
      this.m_sTableName = "EntryTrust";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "TrustEntryID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "TrustEntryStatus");
      CPostItem cpostItem4 = cpostItem3;
      this.m_Status = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "TrustBankAcctID");
      CPostItem cpostItem6 = cpostItem5;
      this.m_BankAcctID = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "TrustEntryDate");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Date = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.DOUBLE, "TrustEntryTotalAmount");
      CPostItem cpostItem10 = cpostItem9;
      this.m_TotalAmount = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryPaidTo");
      CPostItem cpostItem12 = cpostItem11;
      this.m_PaidTo = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "TrustEntryEntryType");
      CPostItem cpostItem14 = cpostItem13;
      this.m_EntryType = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "TrustEntryPmtMethodFlag");
      CPostItem cpostItem16 = cpostItem15;
      this.m_PmtMethodFlag = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryCheckNum");
      CPostItem cpostItem18 = cpostItem17;
      this.m_CheckNum = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryOrigBank");
      CPostItem cpostItem20 = cpostItem19;
      this.m_OrigBank = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryClientCheckNum");
      CPostItem cpostItem22 = cpostItem21;
      this.m_ClientCheckNum = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "TrustEntryDateEntered");
      CPostItem cpostItem24 = cpostItem23;
      this.m_DateEntered = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.DOUBLE, "TrustEntryGSTAmount");
      CPostItem cpostItem26 = cpostItem25;
      this.m_GSTAmount = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.BOOL, "TrustEntryIsTrustCostDisb");
      CPostItem cpostItem28 = cpostItem27;
      this.m_IsTrustCostDisb = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.DOUBLE, "TrustEntryTransferAdvance");
      CPostItem cpostItem30 = cpostItem29;
      this.m_TransferAdvance = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.DOUBLE, "TrustEntryTransferGain");
      CPostItem cpostItem32 = cpostItem31;
      this.m_TransferGain = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.DOUBLE, "TrustEntryInterest");
      CPostItem cpostItem34 = cpostItem33;
      this.m_Interest = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.DOUBLE, "TrustEntryInterestRWT");
      CPostItem cpostItem36 = cpostItem35;
      this.m_InterestRWT = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.DOUBLE, "TrustEntryIntCommission");
      CPostItem cpostItem38 = cpostItem37;
      this.m_IntCommission = cpostItem37;
      postItems19.Add(cpostItem38);
      List<CPostItem> postItems20 = this.PostItems;
      CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.DOUBLE, "TrustEntryIntGross");
      CPostItem cpostItem40 = cpostItem39;
      this.m_IntGross = cpostItem39;
      postItems20.Add(cpostItem40);
      List<CPostItem> postItems21 = this.PostItems;
      CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryQuickBooksID");
      CPostItem cpostItem42 = cpostItem41;
      this.m_QuickBooksID = cpostItem41;
      postItems21.Add(cpostItem42);
      List<CPostItem> postItems22 = this.PostItems;
      CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryAddrLine1");
      CPostItem cpostItem44 = cpostItem43;
      this.m_AddrLine1 = cpostItem43;
      postItems22.Add(cpostItem44);
      List<CPostItem> postItems23 = this.PostItems;
      CPostItem cpostItem45 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryAddrLine2");
      CPostItem cpostItem46 = cpostItem45;
      this.m_AddrLine2 = cpostItem45;
      postItems23.Add(cpostItem46);
      List<CPostItem> postItems24 = this.PostItems;
      CPostItem cpostItem47 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryAddrCity");
      CPostItem cpostItem48 = cpostItem47;
      this.m_AddrCity = cpostItem47;
      postItems24.Add(cpostItem48);
      List<CPostItem> postItems25 = this.PostItems;
      CPostItem cpostItem49 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryAddrState");
      CPostItem cpostItem50 = cpostItem49;
      this.m_AddrState = cpostItem49;
      postItems25.Add(cpostItem50);
      List<CPostItem> postItems26 = this.PostItems;
      CPostItem cpostItem51 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryAddrZip");
      CPostItem cpostItem52 = cpostItem51;
      this.m_AddrZip = cpostItem51;
      postItems26.Add(cpostItem52);
      List<CPostItem> postItems27 = this.PostItems;
      CPostItem cpostItem53 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryAddrCountry");
      CPostItem cpostItem54 = cpostItem53;
      this.m_AddrCountry = cpostItem53;
      postItems27.Add(cpostItem54);
      List<CPostItem> postItems28 = this.PostItems;
      CPostItem cpostItem55 = new CPostItem(CPostItem.DataType.STRING, "TrustEntryAddrExpl");
      CPostItem cpostItem56 = cpostItem55;
      this.m_AddrCheckExpl = cpostItem55;
      postItems28.Add(cpostItem56);
      List<CPostItem> postItems29 = this.PostItems;
      CPostItem cpostItem57 = new CPostItem(CPostItem.DataType.LONG, "TrustEntryReverseID");
      CPostItem cpostItem58 = cpostItem57;
      this.m_ReverseEntryID = cpostItem57;
      postItems29.Add(cpostItem58);
      this.Alloc = new PLTBAlloc();
      this.m_AllocArray = new List<PLTBAlloc>();
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

    public enum eTBEntryType : short
    {
        Check = 2049,
        Recipt = 2050,
        OpeningBal = 2051,
        TrustToTrustTransfer = 2052,
        TRUST_TDT = 2053,
        TRUST_GTT = 2054,
        TRUST_RCPT_COB = 2055,
        TrustCOB = 2400,
        TRUST_PRIOR_CHECK = 2500,
        TRUST_PRIOR_RCPT = 2501,
        TRUST_BANK_ERROR = 2502
    }
  }
}
