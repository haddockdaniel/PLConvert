// Decompiled with JetBrains decompiler
// Type: PLConvert.APAlloc
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System.Collections.Generic;

namespace PLConvert
{
  public class APAlloc : TransactionData
  {
    private CPostItem m_HoldStatus;
    private CPostItem m_IsSoftCost;
    private CPostItem m_Quantity;
    private CPostItem m_Rate;
    private CPostItem m_MarkupAmount;
    private CPostItem m_MarkupPercent;
    private CPostItem m_Explanation;
    private CPostItem m_InvoiceDate;
    private CPostItem m_InvoiceID;
    private CPostItem m_InvoiceNumber;
    private CPostItem m_MatterID;
    private CPostItem m_GLID;
    private CPostItem m_ActivityID;
    private CPostItem m_Amount;
    private CPostItem m_BillTaxCategory;

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

    public TransactionData.eGST_CAT BillTaxCategory
    {
      get
      {
        return (TransactionData.eGST_CAT) this.m_BillTaxCategory.nValue;
      }
      set
      {
        this.m_BillTaxCategory.SetValue((int) value);
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

    public APAlloc.eHOLD_TYPE HoldStatus
    {
      get
      {
        return (APAlloc.eHOLD_TYPE) this.m_HoldStatus.nValue;
      }
      set
      {
        this.m_HoldStatus.SetValue((int) value);
      }
    }

    public int InvoiceDate
    {
      get
      {
        return this.m_InvoiceDate.nValue;
      }
      set
      {
        this.m_InvoiceDate.SetValue(value);
      }
    }

    public int InvoiceID
    {
      get
      {
        return this.m_InvoiceID.nValue;
      }
      set
      {
        this.m_InvoiceID.SetValue(value);
      }
    }

    public int InvoiceNumber
    {
      get
      {
        return this.m_InvoiceNumber.nValue;
      }
      set
      {
        this.m_InvoiceNumber.SetValue(value);
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

    public double MarkupAmount
    {
      get
      {
        return this.m_MarkupAmount.dValue;
      }
      set
      {
        this.m_MarkupAmount.SetValue(value);
      }
    }

    public double MarkupPercent
    {
      get
      {
        return this.m_MarkupPercent.dValue;
      }
      set
      {
        this.m_MarkupPercent.SetValue(value);
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

    public APAlloc()
    {
      this.Initialize();
    }

    public void AddRepeatFields(uint handle, int nRepeat)
    {
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddRepeatField(handle, nRepeat);
    }

    public void GetRepeatFields(uint handle, int nRepeat)
    {
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetRepeatField(handle, nRepeat);
    }

    protected override void Initialize()
    {
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.RepeatLONG, "EntryPayableAllocHoldStatus");
      CPostItem cpostItem2 = cpostItem1;
      this.m_HoldStatus = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.RepeatBOOL, "EntryPayableAllocIsSoftCost");
      CPostItem cpostItem4 = cpostItem3;
      this.m_IsSoftCost = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "EntryPayableAllocQuantity");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Quantity = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "EntryPayableAllocRate");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Rate = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "EntryPayableAllocMarkupAmount");
      CPostItem cpostItem10 = cpostItem9;
      this.m_MarkupAmount = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "EntryPayableAllocMarkupPercent");
      CPostItem cpostItem12 = cpostItem11;
      this.m_MarkupPercent = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.RepeatSTRING, "EntryPayableAllocExplanation");
      CPostItem cpostItem14 = cpostItem13;
      this.m_Explanation = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.RepeatLONG, "EntryPayableAllocInvoiceDate");
      CPostItem cpostItem16 = cpostItem15;
      this.m_InvoiceDate = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.RepeatLONG, "EntryPayableAllocInvoiceID");
      CPostItem cpostItem18 = cpostItem17;
      this.m_InvoiceID = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.RepeatLONG, "EntryPayableAllocInvoiceNumber");
      CPostItem cpostItem20 = cpostItem19;
      this.m_InvoiceNumber = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.RepeatLONG, "EntryPayableAllocMatterID");
      CPostItem cpostItem22 = cpostItem21;
      this.m_MatterID = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.RepeatLONG, "EntryPayableAllocGLID");
      CPostItem cpostItem24 = cpostItem23;
      this.m_GLID = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.RepeatLONG, "EntryPayableAllocActivityID");
      CPostItem cpostItem26 = cpostItem25;
      this.m_ActivityID = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "EntryPayableAllocAmount");
      CPostItem cpostItem28 = cpostItem27;
      this.m_Amount = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.RepeatLONG, "EntryPayableAllocBillTaxCategory");
      CPostItem cpostItem30 = cpostItem29;
      this.m_BillTaxCategory = cpostItem29;
      postItems15.Add(cpostItem30);
    }

    public enum eHOLD_TYPE : byte
    {
      NO_HOLD,
      HOLD,
      NEVER_BILL,
    }
  }
}
