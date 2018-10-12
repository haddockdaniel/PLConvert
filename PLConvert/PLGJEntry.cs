// Decompiled with JetBrains decompiler
// Type: PLConvert.PLGJEntry
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLGJEntry : TransactionData
  {
    protected CPostItem m_Date;
    protected CPostItem m_EOMID;
    protected CPostItem m_GBCommID;
    protected CPostItem m_Reference;
    protected CPostItem m_Explanation;
    protected CPostItem m_UserID;
    public List<PLGJEntry.GJAlloc> listAllocations;
    protected CPostItem m_AllocAmount;
    protected CPostItem m_AllocGLID;

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

    public int EOMID
    {
      get
      {
        return this.m_EOMID.nValue;
      }
      set
      {
        this.m_EOMID.SetValue(value);
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

    public int GBCommID
    {
      get
      {
        return this.m_GBCommID.nValue;
      }
      set
      {
        this.m_GBCommID.SetValue(value);
      }
    }

    public string Reference
    {
      get
      {
        return this.m_Reference.sValue;
      }
      set
      {
        this.m_Reference.SetValue(value);
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

    public PLGJEntry()
    {
      this.Initialize();
    }

    public void AddGJAllocation(int iGLID, double dAmount)
    {
      if (iGLID == 0)
        return;
      this.listAllocations.Add(new PLGJEntry.GJAlloc(iGLID, dAmount));
    }

    public void AddGJAllocation(string GLNN, double dAmount)
    {
      this.AddGJAllocation(PLGLAccts.GetIDFromNN(GLNN), dAmount);
    }

    public override void AddRecord()
    {
      Decimal num = new Decimal(0);
      for (int index = 1; index <= this.listAllocations.Count; ++index)
        num += (Decimal) this.listAllocations[index - 1].Amount;
      if (num != new Decimal(0))
        return;
      base.AddRecord();
      for (int nRepeat = 1; nRepeat <= this.listAllocations.Count; ++nRepeat)
      {
        this.m_AllocGLID.SetValue(this.listAllocations[nRepeat - 1].GLID);
        this.m_AllocGLID.AddRepeatField(this.m_hndPOST, nRepeat);
        this.m_AllocAmount.SetValue(this.listAllocations[nRepeat - 1].Amount);
        this.m_AllocAmount.AddRepeatField(this.m_hndPOST, nRepeat);
      }
      this.listAllocations.Clear();
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLGJEntry plgjEntry = this;
      plgjEntry.m_lCounter = plgjEntry.m_lCounter + 1;
      if (this.m_lCounter >= PLXMLData.m_nMaxCounter)
        this.Send();
    }

    public override void Clear()
    {
      base.Clear();
      this.m_AllocGLID.Clear();
      this.m_AllocAmount.Clear();
      this.listAllocations.Clear();
    }

    public override void GetExistingRecord()
    {
      base.GetExistingRecord();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndExisting, "EntryGJAllocGLID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.m_AllocGLID.GetRepeatField(this.m_hndExisting, nRepeat);
        this.m_AllocAmount.GetRepeatField(this.m_hndExisting, nRepeat);
        this.AddGJAllocation(this.m_AllocGLID.nValue, this.m_AllocAmount.dValue);
        this.m_AllocGLID.Clear();
        this.m_AllocAmount.Clear();
      }
    }

    public override void GetRecord()
    {
      base.GetRecord();
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, "EntryGJAllocGLID");
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.m_AllocGLID.GetRepeatField(this.m_hndGET, nRepeat);
        this.m_AllocAmount.GetRepeatField(this.m_hndGET, nRepeat);
        this.AddGJAllocation(this.m_AllocGLID.nValue, this.m_AllocAmount.dValue);
        this.m_AllocGLID.Clear();
        this.m_AllocAmount.Clear();
      }
    }

    protected override void Initialize()
    {
      this.m_sTableName = "EntryGenJour";
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "EntryGJStatus");
      CPostItem cpostItem2 = cpostItem1;
      this.m_Status = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "EntryGJID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_ID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "EntryGJDate");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Date = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "EntryGJEOMID");
      CPostItem cpostItem8 = cpostItem7;
      this.m_EOMID = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "EntryGJGBCommID");
      CPostItem cpostItem10 = cpostItem9;
      this.m_GBCommID = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.STRING, "EntryGJReference");
      CPostItem cpostItem12 = cpostItem11;
      this.m_Reference = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, "EntryGJExplanation");
      CPostItem cpostItem14 = cpostItem13;
      this.m_Explanation = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "EntryGJUserID");
      CPostItem cpostItem16 = cpostItem15;
      this.m_UserID = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.STRING, "EntryGJQuickBooksID");
      CPostItem cpostItem18 = cpostItem17;
      this.m_QuickBooksID = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.LONG, "EntryGJReverseID");
      CPostItem cpostItem20 = cpostItem19;
      this.m_ReverseEntryID = cpostItem19;
      postItems10.Add(cpostItem20);
      this.listAllocations = new List<PLGJEntry.GJAlloc>();
      this.m_AllocAmount = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "EntryGJAllocAmount");
      this.m_AllocGLID = new CPostItem(CPostItem.DataType.RepeatLONG, "EntryGJAllocGLID");
    }

    public class GJAlloc
    {
      public int GLID;
      public double Amount;

      public GJAlloc()
      {
        this.GLID = 0;
        this.Amount = 0.0;
      }

      public GJAlloc(int iGLID, double dAmount)
      {
        this.GLID = iGLID;
        this.Amount = dAmount;
      }
    }
  }
}
