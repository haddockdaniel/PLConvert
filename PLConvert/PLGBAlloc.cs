// Decompiled with JetBrains decompiler
// Type: PLConvert.PLGBAlloc
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLGBAlloc : TransactionData
  {
    private CPostItem m_MatterID;
    private CPostItem m_Amount;
    private CPostItem m_ActivityID;
    private CPostItem m_Explanation;
    private CPostItem m_GLID;
    private CPostItem m_GSTCat;
    private CPostItem m_InvDate;
    private CPostItem m_InvID;
    private CPostItem m_InvNumber;
    private CPostItem m_HoldFlag;
    private CPostItem m_EntryType;
    private CPostItem m_TaskID;
    private CPostItem m_EOMFlag;
    private CPostItem m_IsSoftCost;
    private CPostItem m_LevyType;

    public double Amount
    {
      get
      {
        return this.m_Amount.dValue;
      }
      set
      {
        this.m_Amount.SetValue(value);
      }
    }

    public PLGBAlloc.eGBAllocEntryType EntryType
    {
      get
      {
        return (PLGBAlloc.eGBAllocEntryType) this.m_EntryType.nValue;
      }
      set
      {
        this.m_EntryType.SetValue((int) value);
      }
    }

    public string Explanation
    {
      get
      {
        return this.m_Explanation.sValue;
      }
      set
      {
        this.m_Explanation.SetValue(value);
      }
    }

    public int ExplCodeID
    {
      get
      {
        return this.m_ActivityID.nValue;
      }
      set
      {
        this.m_ActivityID.SetValue(value);
      }
    }

    public string ExplCodeNN
    {
      get
      {
        return PLExpCode.GetNNFromID(this.m_ActivityID.nValue);
      }
      set
      {
        this.m_ActivityID.SetValue(PLExpCode.GetIDFromNN(value));
      }
    }

    public int GLID
    {
      get
      {
        return this.m_GLID.nValue;
      }
      set
      {
        this.m_GLID.SetValue(value);
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

    public TransactionData.eGST_CAT GSTCat
    {
      get
      {
        return (TransactionData.eGST_CAT) this.m_GSTCat.nValue;
      }
      set
      {
        this.m_GSTCat.SetValue((int) value);
      }
    }

    public PLGBAlloc.eGBAllocHoldFlag HoldFlag
    {
      get
      {
        return (PLGBAlloc.eGBAllocHoldFlag) this.m_HoldFlag.nValue;
      }
      set
      {
        this.m_HoldFlag.SetValue(Convert.ToInt32((object) value));
      }
    }

    public int InvDate
    {
      get
      {
        return this.m_InvDate.nValue;
      }
      set
      {
        this.m_InvDate.SetValue(value);
      }
    }

    public int InvID
    {
      get
      {
        return this.m_InvID.nValue;
      }
      set
      {
        this.m_InvID.SetValue(value);
      }
    }

    public int InvNumber
    {
      get
      {
        return this.m_InvNumber.nValue;
      }
      set
      {
        this.m_InvNumber.SetValue(value);
      }
    }

    public int MatterID
    {
      get
      {
        return this.m_MatterID.nValue;
      }
      set
      {
        this.m_MatterID.SetValue(value);
      }
    }

    public string MatterNN
    {
      get
      {
        return PLMatter.GetNNFromID(this.m_MatterID.nValue);
      }
      set
      {
        this.m_MatterID.SetValue(PLMatter.GetIDFromNN(value));
      }
    }

    public PLGBAlloc()
    {
      this.Initialize();
    }

    public PLGBAlloc(PLGBAlloc a)
    {
      this.Initialize();
      if (a.m_Amount.m_bIsSet)
        this.Amount = a.Amount;
      if (a.m_EntryType.m_bIsSet)
        this.EntryType = a.EntryType;
      if (a.m_Amount.m_bIsSet)
        this.Explanation = a.Explanation;
      if (a.m_ActivityID.m_bIsSet)
        this.ExplCodeID = a.ExplCodeID;
      if (a.m_GLID.m_bIsSet)
        this.GLID = a.GLID;
      if (a.m_GSTCat.m_bIsSet)
        this.GSTCat = a.GSTCat;
      if (a.m_HoldFlag.m_bIsSet)
        this.HoldFlag = a.HoldFlag;
      if (a.m_ID.m_bIsSet)
        this.ID = a.ID;
      if (a.m_InvDate.m_bIsSet)
        this.InvDate = a.InvDate;
      if (a.m_InvID.m_bIsSet)
        this.InvID = a.InvID;
      if (a.m_InvNumber.m_bIsSet)
        this.InvNumber = a.InvNumber;
      if (a.m_MatterID.m_bIsSet)
        this.MatterID = a.MatterID;
      else
          this.MatterID = a.MatterID;
    }

    public override void AddRecord()
    {
    }

    public void AddRepeatFields(uint handle, int nRepeat)
    {
      this.m_hndPOST = handle;
      this.m_ID.AddRepeatField(this.m_hndPOST, nRepeat);
      //if (!this.m_MatterID.m_bIsSet)
       // this.MatterID = 0;
      this.m_MatterID.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_Amount.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_ActivityID.m_bIsSet)
        this.ExplCodeID = 0;
      this.m_ActivityID.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_Explanation.m_bIsSet)
        this.Explanation = "No explanation provided";
      this.m_Explanation.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_GLID.m_bIsSet)
        this.GLNN = "9999";
      this.m_GLID.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_GSTCat.m_bIsSet)
        this.GSTCat = TransactionData.eGST_CAT.NOT_SET;
      this.m_GSTCat.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_InvID.m_bIsSet)
        this.InvID = 0;
      this.m_InvID.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_InvDate.m_bIsSet)
        this.InvDate = 0;
      this.m_InvDate.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_InvNumber.m_bIsSet)
        this.InvNumber = 0;
      this.m_InvNumber.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_HoldFlag.m_bIsSet)
        this.HoldFlag = PLGBAlloc.eGBAllocHoldFlag.NO_HOLD;
      this.m_HoldFlag.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_EntryType.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_TaskID.SetValue(0);
      this.m_TaskID.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_EOMFlag.SetValue(0);
      this.m_EOMFlag.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_IsSoftCost.SetValue(false);
      this.m_IsSoftCost.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_LevyType.SetValue(0);
      this.m_LevyType.AddRepeatField(this.m_hndPOST, nRepeat);
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return PLGBEnt.m_bAllowEntOnClosedMtr;
    }

    public void GetRepeatFields(uint handle, int nRepeat)
    {
      this.m_hndGET = handle;
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetRepeatField(this.m_hndGET, nRepeat);
    }

    protected override void Initialize()
    {
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocAllocID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocMatterID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_MatterID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "GeneralAllocAmount");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Amount = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocActivityID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_ActivityID = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.RepeatSTRING, "GeneralAllocExplanation");
      CPostItem cpostItem10 = cpostItem9;
      this.m_Explanation = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocGLID");
      CPostItem cpostItem12 = cpostItem11;
      this.m_GLID = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocGSTCat");
      CPostItem cpostItem14 = cpostItem13;
      this.m_GSTCat = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocInvDate");
      CPostItem cpostItem16 = cpostItem15;
      this.m_InvDate = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocInvID");
      CPostItem cpostItem18 = cpostItem17;
      this.m_InvID = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocInvNumber");
      CPostItem cpostItem20 = cpostItem19;
      this.m_InvNumber = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocHoldStatusFlag");
      CPostItem cpostItem22 = cpostItem21;
      this.m_HoldFlag = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocEntryType");
      CPostItem cpostItem24 = cpostItem23;
      this.m_EntryType = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocTaskID");
      CPostItem cpostItem26 = cpostItem25;
      this.m_TaskID = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocEOMFlag");
      CPostItem cpostItem28 = cpostItem27;
      this.m_EOMFlag = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.RepeatBOOL, "GeneralAllocIsSoftCost");
      CPostItem cpostItem30 = cpostItem29;
      this.m_IsSoftCost = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.RepeatLONG, "GeneralAllocLevyTypeFlag");
      CPostItem cpostItem32 = cpostItem31;
      this.m_LevyType = cpostItem31;
      postItems16.Add(cpostItem32);
    }

    public enum eGBAllocEntryType : short
    {
      GEN_RCPT_INT = 1100,
      GEN_RCPT_PMNT = 1101,
      GEN_RCPT_RTNR = 1102,
      GEN_TDT = 1102,
      GEN_RCPT_RTNRALLOC = 1103,
      GEN_RCPT_RTNRADJ = 1104,
      GEN_RCPT_COB = 1105,
      GEN_OPENING_BAL = 1200,
      GEN_RCPT = 1300,
      GEN_GEN_XFER = 1302,
      GEN_CHE = 1400,
      GEN_AP_CHE = 1401,
      EXP_REC = 1600,
      EXP_COB = 1650,
      EXP_GST_COB = 1651,
      EXP_STAX_COB = 1652,
      EXP_ANT_DISB = 1653,
      DISB_GST = 1700,
      DISB_STAX = 1701,
      DISB_WO_STAX_ADJ = 1800,
      DISB_WO_STAX_BADDEBT = 1801,
      DISB_WO_GST_ADJ = 1802,
      DISB_WO_GST_BADDEBT = 1803,
      DISB_WO_ADJ = 1898,
      DISB_WO_BADDEBT = 1899,
      GST_FWD_REMIT = 1900,
      GST_FWD_CHECKS = 1901,
      GST_FWD_BILLINGS = 1902,
      GST_FWD_WRITEUP = 1903,
      GST_FWD_WRITEDOWN = 1904,
      GST_FWD_PREVBAL = 1905,
      SOFTDISB_WO_ADJ = 1910,
      SOFTDISB_WO_BADDEBT = 1911,
      TRANS_LEVY_RE = 2000,
      TRANS_LEVY_LIT = 2001,
      BC_TAF = 2002,
      GBANK_SUMM = 2010,
    }

    public enum eGBAllocHoldFlag : byte
    {
      NO_HOLD,
      HOLD,
      NEVER_BILL,
    }
  }
}
