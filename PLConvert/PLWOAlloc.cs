// Decompiled with JetBrains decompiler
// Type: PLConvert.PLWOAlloc
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System.Collections.Generic;

namespace PLConvert
{
  public class PLWOAlloc : TransactionData
  {
    private CPostItem m_LawyerID;
    private CPostItem m_GLID;
    private CPostItem m_Amount;
    private CPostItem m_EntryType;

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

    public PLWOAlloc.eWOAllocEntryType EntryType
    {
      get
      {
        return (PLWOAlloc.eWOAllocEntryType) this.m_EntryType.nValue;
      }
      set
      {
        this.m_EntryType.SetValue((int) value);
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
        int idFromNn = PLGLAccts.GetIDFromNN(value);
        if (idFromNn == 0)
          return;
        this.m_GLID.SetValue(idFromNn);
      }
    }

    public int LawyerID
    {
      get
      {
        return this.m_LawyerID.nValue;
      }
      set
      {
        this.m_LawyerID.SetValue(value);
      }
    }

    public string LawyerNN
    {
      get
      {
        return PLLawyer.GetNNFromID(this.m_LawyerID.nValue);
      }
      set
      {
        int idFromNn = PLLawyer.GetIDFromNN(value);
        if (idFromNn == 0)
          return;
        this.m_LawyerID.SetValue(idFromNn);
      }
    }

    public PLWOAlloc()
    {
      this.Initialize();
    }

    public PLWOAlloc(int LawyerrID, int GLID, double Amount, PLWOAlloc.eWOAllocEntryType EntryType, PLXMLData.eSTATUS Status)
    {
      this.Initialize();
      this.LawyerID = this.LawyerID;
      this.GLID = GLID;
      this.Amount = Amount;
      this.EntryType = EntryType;
      this.Status = Status;
    }

    public PLWOAlloc(int LawyerrID, int GLID, double Amount, PLWOAlloc.eWOAllocEntryType EntryType)
    {
      this.Initialize();
      this.LawyerID = this.LawyerID;
      this.GLID = GLID;
      this.Amount = Amount;
      this.EntryType = EntryType;
    }

    public override void AddRecord()
    {
      base.AddRecord();
    }

    public void AddRepeatFields(uint handle, int nRepeat)
    {
      if (!this.m_GLID.m_bIsSet)
        this.GLID = 0;
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddRepeatField(handle, nRepeat);
    }

    public override void Clear()
    {
      base.Clear();
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return PLBilling.m_bAllowEntOnClosedMtr;
    }

    public void GetRepeatFields(uint handle, int nRepeat)
    {
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetRepeatField(handle, nRepeat);
    }

    protected override void Initialize()
    {
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.RepeatLONG, "WOSplitLwrID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_LawyerID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.RepeatLONG, "WOSplitGLID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_GLID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "WOSplitAmount");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Amount = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.RepeatLONG, "WOSplitEntryTypeFlag");
      CPostItem cpostItem8 = cpostItem7;
      this.m_EntryType = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.RepeatLONG, "WOSplitStatus");
      CPostItem cpostItem10 = cpostItem9;
      this.m_Status = cpostItem9;
      postItems5.Add(cpostItem10);
    }

    public enum eWOAllocEntryType : short
    {
      FEE_WO_STAX_ADJ = 800,
      FEE_WO_STAX_BADDEBT = 801,
      FEE_WO_GST_ADJ = 802,
      FEE_WO_GST_BADDEBT = 803,
      FEE_WO_ADJ = 998,
      FEE_WO_BADDEBT = 999,
      DISB_WO_STAX_ADJ = 1800,
      DISB_WO_STAX_BADDEBT = 1801,
      DISB_WO_GST_ADJ = 1802,
      DISB_WO_GST_BADDEBT = 1803,
      DISB_WO_ADJ = 1898,
      DISB_WO_BADDEBT = 1899
    }
  }
}
