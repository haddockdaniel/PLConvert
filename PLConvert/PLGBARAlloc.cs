// Decompiled with JetBrains decompiler
// Type: PLConvert.PLGBARAlloc
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System.Collections.Generic;

namespace PLConvert
{
  public class PLGBARAlloc : TransactionData
  {
    private CPostItem m_InvID;
    private CPostItem m_Amount;
    private CPostItem m_ARAllocType;
    private CPostItem m_ApplyTo;
    private CPostItem m_ApplyToLawyer;

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

    public PLGBARAlloc.eApplyTo ApplyTo
    {
      get
      {
        return (PLGBARAlloc.eApplyTo) this.m_ApplyTo.nValue;
      }
      set
      {
        this.m_ApplyTo.SetValue((int) value);
      }
    }

    public int ApplyToLawyer
    {
      get
      {
        return this.m_ApplyToLawyer.nValue;
      }
      set
      {
        this.m_ApplyToLawyer.SetValue(value);
      }
    }

    public PLGBARAlloc.eAllocType ARAllocType
    {
      get
      {
        return (PLGBARAlloc.eAllocType) this.m_ARAllocType.nValue;
      }
      set
      {
        this.m_ARAllocType.SetValue((int) value);
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

    public PLGBARAlloc()
    {
      this.Initialize();
    }

    public PLGBARAlloc(PLGBARAlloc a)
    {
      this.Initialize();
      if (a.m_Amount.m_bIsSet)
        this.Amount = a.Amount;
      if (a.m_ApplyTo.m_bIsSet)
        this.ApplyTo = a.ApplyTo;
      if (a.m_ApplyToLawyer.m_bIsSet)
        this.ApplyToLawyer = a.ApplyToLawyer;
      if (a.m_ARAllocType.m_bIsSet)
        this.ARAllocType = a.ARAllocType;
      if (!a.m_InvID.m_bIsSet)
        return;
      this.InvID = a.InvID;
    }

    public override void AddRecord()
    {
    }

    public void AddRepeatFields(uint handle, int nRepeat)
    {
      this.m_hndPOST = handle;
      this.Status = PLXMLData.eSTATUS.ACTIVE;
      this.m_Status.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_InvID.m_bIsSet)
        this.InvID = 0;
      this.m_InvID.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_Amount.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_ARAllocType.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_ApplyTo.m_bIsSet)
        this.ApplyTo = PLGBARAlloc.eApplyTo.AT_NOT_APPLIED;
      this.m_ApplyTo.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_ApplyToLawyer.m_bIsSet)
        this.ApplyToLawyer = 0;
      this.m_ApplyToLawyer.AddRepeatField(this.m_hndPOST, nRepeat);
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
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.RepeatLONG, "ARAllocStatus");
      CPostItem cpostItem2 = cpostItem1;
      this.m_Status = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.RepeatLONG, "ARAllocInvoiceID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_InvID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "ARAllocAmount");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Amount = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.RepeatLONG, "ARAllocEntryTypeFlag");
      CPostItem cpostItem8 = cpostItem7;
      this.m_ARAllocType = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.RepeatLONG, "ARAllocApplyToFlag");
      CPostItem cpostItem10 = cpostItem9;
      this.m_ApplyTo = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.RepeatLONG, "ARAllocApplyToLwrID");
      CPostItem cpostItem12 = cpostItem11;
      this.m_ApplyToLawyer = cpostItem11;
      postItems6.Add(cpostItem12);
    }

    public enum eAllocType : byte
    {
      PAYMENT = 0,
      RETAINER = 2,
      INTEREST = 5,
      REQ_BILL = 8,
      BILL_FLOW = 16,
      PAYABLE = 64,
    }

    public enum eApplyTo : byte
    {
      AT_NOT_APPLIED,
      AT_GST_DISBS,
      AT_GST_FEES,
      AT_PST_DISBS,
      AT_PST_FEES,
      AT_HARD_COSTS,
      AT_SOFT_COSTS,
      AT_FEES,
      AT_INTEREST,
    }
  }
}
