// Decompiled with JetBrains decompiler
// Type: PLConvert.PLPayableEntry
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System.Collections.Generic;

namespace PLConvert
{
  public class PLPayableEntry : TransactionData
  {
    private CPostItem m_UserID;
    private CPostItem m_VendorID;
    private CPostItem m_InvoiceDate;
    private CPostItem m_DueDate;
    private CPostItem m_Discount;
    private CPostItem m_AmountPaid;
    private CPostItem m_FederalTax;
    private CPostItem m_TotalBasePlusSalesTax;
    private CPostItem m_TaxRemitDate;
    private CPostItem m_PayTaxCategory;
    private CPostItem m_InvoiceNumber;
    private CPostItem m_Explanation;
    public APAlloc Alloc;
    public List<APAlloc> listAllocations;

    public double AmountPaid
    {
      get
      {
        return this.m_AmountPaid.dValue;
      }
      set
      {
        this.m_AmountPaid.SetValue(value);
      }
    }

    public double Discount
    {
      get
      {
        return this.m_Discount.dValue;
      }
      set
      {
        this.m_Discount.SetValue(value);
      }
    }

    public int DueDate
    {
      get
      {
        return this.m_DueDate.nValue;
      }
      set
      {
        this.m_DueDate.SetValue(value);
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

    public double FederalTax
    {
      get
      {
        return this.m_FederalTax.dValue;
      }
      set
      {
        this.m_FederalTax.SetValue(value);
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

    public string InvoiceNumber
    {
      get
      {
        return this.m_InvoiceNumber.sValue;
      }
      set
      {
        this.m_InvoiceNumber.SetValue(value);
      }
    }

    public int PayTaxCategory
    {
      get
      {
        return this.m_PayTaxCategory.nValue;
      }
      set
      {
        this.m_PayTaxCategory.SetValue(value);
      }
    }

    public int TaxRemitDate
    {
      get
      {
        return this.m_TaxRemitDate.nValue;
      }
      set
      {
        this.m_TaxRemitDate.SetValue(value);
      }
    }

    public double TotalBasePlusSalesTax
    {
      get
      {
        return this.m_TotalBasePlusSalesTax.dValue;
      }
      set
      {
        this.m_TotalBasePlusSalesTax.SetValue(value);
      }
    }

    public int UserID
    {
      get
      {
        return this.m_UserID.nValue;
      }
      set
      {
        this.m_UserID.SetValue(value);
      }
    }

    public int VendorID
    {
      get
      {
        return this.m_VendorID.nValue;
      }
      set
      {
        this.m_VendorID.SetValue(value);
      }
    }

    public PLPayableEntry()
    {
      this.Initialize();
    }

    public void AddAllocation()
    {
      APAlloc apAlloc = new APAlloc()
      {
        Amount = this.Alloc.Amount,
        HoldStatus = this.Alloc.HoldStatus,
        IsSoftCost = this.Alloc.IsSoftCost,
        Quantity = this.Alloc.Quantity,
        Rate = this.Alloc.Rate,
        MarkupAmount = this.Alloc.MarkupAmount,
        MarkupPercent = this.Alloc.MarkupPercent,
        Explanation = this.Alloc.Explanation,
        InvoiceDate = this.Alloc.InvoiceDate,
        InvoiceID = this.Alloc.InvoiceID,
        InvoiceNumber = this.Alloc.InvoiceNumber,
        MatterID = this.Alloc.MatterID,
        GLID = this.Alloc.GLID,
        ExplCodeID = this.Alloc.ExplCodeID
      };
      apAlloc.Amount = this.Alloc.Amount;
      apAlloc.BillTaxCategory = this.Alloc.BillTaxCategory;
      this.listAllocations.Add(apAlloc);
      this.Alloc.Clear();
    }

    public override void AddRecord()
    {
      if (this.listAllocations.Count == 0 || !this.m_VendorID.m_bIsSet)
        return;
      base.AddRecord();
      for (int nRepeat = 1; nRepeat <= this.listAllocations.Count; ++nRepeat)
        this.listAllocations[nRepeat - 1].AddRepeatFields(this.m_hndPOST, nRepeat);
      this.listAllocations.Clear();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLPayableEntry plPayableEntry = this;
      plPayableEntry.m_lCounter = plPayableEntry.m_lCounter + 1;
      if (this.m_lCounter >= PLXMLData.m_nMaxCounter)
        this.Send();
    }

    public override void Clear()
    {
      base.Clear();
      this.Alloc.Clear();
      this.listAllocations.Clear();
    }

    public override void GetExistingRecord()
    {
      base.GetExistingRecord();
      this.listAllocations.Clear();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "EntryPayableAllocGLID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.Alloc.GetRepeatFields(this.m_hndExisting, nRepeat);
        this.AddAllocation();
      }
    }

    public override void GetRecord()
    {
      base.GetRecord();
      this.listAllocations.Clear();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "EntryPayableAllocGLID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.Alloc.GetRepeatFields(this.m_hndGET, nRepeat);
        this.AddAllocation();
      }
    }

    protected override void Initialize()
    {
      this.m_sTableName = "EntryPayable";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "EntryPayableEntryID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "UserID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_UserID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "EntryPayableStatus");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Status = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "EntryPayableVendorID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_VendorID = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "EntryPayableInvoiceDate");
      CPostItem cpostItem10 = cpostItem9;
      this.m_InvoiceDate = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "EntryPayableDueDate");
      CPostItem cpostItem12 = cpostItem11;
      this.m_DueDate = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.DOUBLE, "EntryPayableDiscount");
      CPostItem cpostItem14 = cpostItem13;
      this.m_Discount = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.DOUBLE, "EntryPayableAmountPaid");
      CPostItem cpostItem16 = cpostItem15;
      this.m_AmountPaid = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.DOUBLE, "EntryPayableFederalTax");
      CPostItem cpostItem18 = cpostItem17;
      this.m_FederalTax = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.DOUBLE, "EntryPayableTotalBasePlusSalesTax");
      CPostItem cpostItem20 = cpostItem19;
      this.m_TotalBasePlusSalesTax = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.LONG, "EntryPayableTaxRemitDate");
      CPostItem cpostItem22 = cpostItem21;
      this.m_TaxRemitDate = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "EntryPayablePayTaxCategory");
      CPostItem cpostItem24 = cpostItem23;
      this.m_PayTaxCategory = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.STRING, "EntryPayableInvoiceNumber");
      CPostItem cpostItem26 = cpostItem25;
      this.m_InvoiceNumber = cpostItem25;
      postItems13.Add(cpostItem26);
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.STRING, "EntryPayableExplanation");
      CPostItem cpostItem28 = cpostItem27;
      this.m_Explanation = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "EntryPayableQuickBooksID");
      CPostItem cpostItem30 = cpostItem29;
      this.m_QuickBooksID = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.LONG, "EntryPayableReverseID");
      CPostItem cpostItem32 = cpostItem31;
      this.m_ReverseEntryID = cpostItem31;
      postItems16.Add(cpostItem32);
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
      this.Alloc = new APAlloc();
      this.listAllocations = new List<APAlloc>();
    }

    public override void Send()
    {
      base.Send();
    }

    public override void SendLast()
    {
      base.SendLast();
    }
  }
}
