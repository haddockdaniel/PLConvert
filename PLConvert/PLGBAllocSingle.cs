// Decompiled with JetBrains decompiler
// Type: PLConvert.PLGBAllocSingle
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLGBAllocSingle : TransactionData
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
    private CPostItem m_AllocID;
    private CPostItem m_Quantity;
    private CPostItem m_Rate;
    private CPostItem m_MarkUpAmt;
    private CPostItem m_MarkUpPct;
    private CPostItem m_APInvID;
    private CPostItem m_HoldFlag;
    private CPostItem m_EntryType;
    private CPostItem m_TaskID;
    private CPostItem m_EOMFlag;
    private CPostItem m_LevyType;
    private CPostItem m_IsSoftCost;
    public static bool m_bAllowEntOnClosedMtr;

    public int AllocID
    {
      get
      {
        return this.m_AllocID.nValue;
      }
      set
      {
        this.m_AllocID.SetValue(value);
      }
    }

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

    public int APInvID
    {
      get
      {
        return this.m_APInvID.nValue;
      }
      set
      {
        this.m_APInvID.SetValue(value);
      }
    }

    public PLGBAllocSingle.eGBAllocEntryType EntryType
    {
      get
      {
        return (PLGBAllocSingle.eGBAllocEntryType) this.m_EntryType.nValue;
      }
      set
      {
        this.m_EntryType.SetValue((int) value);
      }
    }

    public int EOMFlag
    {
      get
      {
        return this.m_EOMFlag.nValue;
      }
      set
      {
        this.m_EOMFlag.SetValue(value);
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

    public PLGBAllocSingle.eGBAllocHoldFlag HoldFlag
    {
      get
      {
        return (PLGBAllocSingle.eGBAllocHoldFlag) this.m_HoldFlag.nValue;
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

    public bool IsSoftCost
    {
      get
      {
        return this.m_IsSoftCost.bValue;
      }
      set
      {
        this.m_IsSoftCost.SetValue(value);
      }
    }

    public int LevyType
    {
      get
      {
        return this.m_LevyType.nValue;
      }
      set
      {
        this.m_LevyType.SetValue(value);
      }
    }

    public double MarkUpAmt
    {
      get
      {
        return this.m_MarkUpAmt.dValue;
      }
      set
      {
        this.m_MarkUpAmt.SetValue(value);
      }
    }

    public double MarkUpPct
    {
      get
      {
        return this.m_MarkUpPct.dValue;
      }
      set
      {
        this.m_MarkUpPct.SetValue(value);
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

    public double Quantity
    {
      get
      {
        return this.m_Quantity.dValue;
      }
      set
      {
        this.m_Quantity.SetValue(value);
      }
    }

    public double Rate
    {
      get
      {
        return this.m_Rate.dValue;
      }
      set
      {
        this.m_Rate.SetValue(value);
      }
    }

    public int TaskID
    {
      get
      {
        return this.m_TaskID.nValue;
      }
      set
      {
        this.m_TaskID.SetValue(value);
      }
    }

    public PLGBAllocSingle()
    {
      this.Initialize();
    }

    public override void AddRecord()
    {
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return PLGBAllocSingle.m_bAllowEntOnClosedMtr;
    }

    protected override void Initialize()
    {
      this.m_sTableName = "GBAlloc";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "CheckID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "InvoiceID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_InvID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "MatterID");
      CPostItem cpostItem6 = cpostItem5;
      this.m_MatterID = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "GLID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_GLID = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "ActivityID");
      CPostItem cpostItem10 = cpostItem9;
      this.m_ActivityID = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "TaskID");
      CPostItem cpostItem12 = cpostItem11;
      this.m_TaskID = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "GBAllocStatus");
      CPostItem cpostItem14 = cpostItem13;
      this.m_Status = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "GBAllocID");
      CPostItem cpostItem16 = cpostItem15;
      this.m_AllocID = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.LONG, "InvoiceDate");
      CPostItem cpostItem18 = cpostItem17;
      this.m_InvDate = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.LONG, "InvoiceNumber");
      CPostItem cpostItem20 = cpostItem19;
      this.m_InvNumber = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.DOUBLE, "GBAllocAmount");
      CPostItem cpostItem22 = cpostItem21;
      this.m_Amount = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "GBAllocEntryType");
      CPostItem cpostItem24 = cpostItem23;
      this.m_EntryType = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.LONG, "GBAllocGstCat");
      CPostItem cpostItem26 = cpostItem25;
      this.m_GSTCat = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.LONG, "GBAllocHoldFlag");
      CPostItem cpostItem28 = cpostItem27;
      this.m_HoldFlag = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.BOOL, "GBAllocIsSoftCostFlag");
      CPostItem cpostItem30 = cpostItem29;
      this.m_IsSoftCost = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.LONG, "GBAllocLevyType");
      CPostItem cpostItem32 = cpostItem31;
      this.m_LevyType = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.LONG, "GBAllocEOM");
      CPostItem cpostItem34 = cpostItem33;
      this.m_EOMFlag = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.DOUBLE, "GBAllocQuantity");
      CPostItem cpostItem36 = cpostItem35;
      this.m_Quantity = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.DOUBLE, "GBAllocRate");
      CPostItem cpostItem38 = cpostItem37;
      this.m_Rate = cpostItem37;
      postItems19.Add(cpostItem38);
      List<CPostItem> postItems20 = this.PostItems;
      CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.DOUBLE, "GBAllocMarkup");
      CPostItem cpostItem40 = cpostItem39;
      this.m_MarkUpAmt = cpostItem39;
      postItems20.Add(cpostItem40);
      List<CPostItem> postItems21 = this.PostItems;
      CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.DOUBLE, "GBAllocMarkupPct");
      CPostItem cpostItem42 = cpostItem41;
      this.m_MarkUpPct = cpostItem41;
      postItems21.Add(cpostItem42);
      List<CPostItem> postItems22 = this.PostItems;
      CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.STRING, "GBAllocExplanation");
      CPostItem cpostItem44 = cpostItem43;
      this.m_Explanation = cpostItem43;
      postItems22.Add(cpostItem44);
      List<CPostItem> postItems23 = this.PostItems;
      CPostItem cpostItem45 = new CPostItem(CPostItem.DataType.LONG, "APInvID");
      CPostItem cpostItem46 = cpostItem45;
      this.m_APInvID = cpostItem45;
      postItems23.Add(cpostItem46);
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
