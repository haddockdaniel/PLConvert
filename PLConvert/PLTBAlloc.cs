// Decompiled with JetBrains decompiler
// Type: PLConvert.PLTBAlloc
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System.Collections.Generic;

namespace PLConvert
{
  public class PLTBAlloc : TransactionData
  {
    private CPostItem m_MatterID;
    private CPostItem m_Amount;
    private CPostItem m_ActivityID;
    private CPostItem m_Explanation;
    private CPostItem m_InvDate;
    private CPostItem m_InvID;
    private CPostItem m_InvNumber;
    private CPostItem m_GSTAmount;
    private CPostItem m_AdvanceAmount;
    private CPostItem m_GainAmount;
    private CPostItem m_TaskID;
    private CPostItem m_IsOnHold;
    private CPostItem m_NumClearingDays;

    public double AdvanceAmount
    {
      get
      {
        return this.m_AdvanceAmount.dValue;
      }
      set
      {
        this.m_AdvanceAmount.SetValue(value);
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

    public int ExpCodeID
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

    public string ExpCodeNN
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

    public double GainAmount
    {
      get
      {
        return this.m_GainAmount.dValue;
      }
      set
      {
        this.m_GainAmount.SetValue(value);
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

    public PLTBAlloc()
    {
      this.Initialize();
    }

    public void AddRepeatFields(uint handle, int nRepeat)
    {
      this.m_hndPOST = handle;
      this.m_ID.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_MatterID.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_Amount.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_ActivityID.m_bIsSet)
        this.ExpCodeID = 0;
      if ((this.m_Explanation.m_bIsSet ? 0 : (this.ExpCodeID == 0 ? 1 : 0)) != 0)
        this.Explanation = "No explanation provided";
      if (!this.m_InvID.m_bIsSet)
        this.InvID = 0;
      if (!this.m_InvDate.m_bIsSet)
        this.InvDate = 0;
      if (!this.m_InvNumber.m_bIsSet)
        this.InvNumber = 0;
      this.m_TaskID.SetValue(0);
      this.m_IsOnHold.SetValue(0);
      this.m_NumClearingDays.SetValue(0);
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddRepeatField(this.m_hndPOST, nRepeat);
    }

    public override void Clear()
    {
      this.m_ID.Clear();
      this.m_MatterID.Clear();
      this.m_Amount.Clear();
      this.m_ActivityID.Clear();
      this.m_Explanation.Clear();
      this.m_InvDate.Clear();
      this.m_InvID.Clear();
      this.m_InvNumber.Clear();
      this.m_GSTAmount.Clear();
      this.m_TaskID.Clear();
      this.m_IsOnHold.Clear();
      this.m_NumClearingDays.Clear();
      this.m_AdvanceAmount.Clear();
      this.m_GainAmount.Clear();
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return PLTBEnt.m_bAllowEntOnClosedMtr;
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
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.RepeatLONG, "TrustAllocAllocID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.RepeatLONG, "TrustAllocMatterID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_MatterID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "TrustAllocAmount");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Amount = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.RepeatLONG, "TrustAllocActivityID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_ActivityID = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.RepeatSTRING, "TrustAllocExplanation");
      CPostItem cpostItem10 = cpostItem9;
      this.m_Explanation = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.RepeatLONG, "TrustAllocInvDate");
      CPostItem cpostItem12 = cpostItem11;
      this.m_InvDate = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.RepeatLONG, "TrustAllocInvID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_InvID = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.RepeatLONG, "TrustAllocInvNumber");
      CPostItem cpostItem16 = cpostItem15;
      this.m_InvNumber = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "TrustAllocGSTAmount");
      CPostItem cpostItem18 = cpostItem17;
      this.m_GSTAmount = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.RepeatLONG, "TrustAllocTaskID");
      CPostItem cpostItem20 = cpostItem19;
      this.m_TaskID = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.RepeatBOOL, "TrustAllocIsOnHold");
      CPostItem cpostItem22 = cpostItem21;
      this.m_IsOnHold = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.RepeatLONG, "TrustAllocClearingDays");
      CPostItem cpostItem24 = cpostItem23;
      this.m_NumClearingDays = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "TrustEntryAdvanceAmount");
      CPostItem cpostItem26 = cpostItem25;
      this.m_AdvanceAmount = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "TrustEntryGainAmount");
      CPostItem cpostItem28 = cpostItem27;
      this.m_GainAmount = cpostItem27;
      postItems14.Add(cpostItem28);
    }
  }
}
