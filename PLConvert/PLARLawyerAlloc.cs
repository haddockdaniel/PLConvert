// Decompiled with JetBrains decompiler
// Type: PLConvert.PLARLawyerAlloc
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System.Collections.Generic;

namespace PLConvert
{
  public class PLARLawyerAlloc : TransactionData
  {
    private CPostItem m_LawyerID;
    private CPostItem m_GLID;
    private CPostItem m_Hours;
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

    public double Hours
    {
      get
      {
        return this.m_Hours.dValue;
      }
      set
      {
        this.m_Hours.SetValue(value);
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
        this.m_LawyerID.SetValue(PLLawyer.GetIDFromNN(value));
      }
    }

    public int Seconds
    {
      get
      {
        return (int) (this.m_Hours.dValue * 3600.0);
      }
      set
      {
        this.m_Hours.SetValue((double) value / 3600.0);
      }
    }

    public PLARLawyerAlloc()
    {
      this.Initialize();
    }

    public override void AddRecord()
    {
    }

    public void AddRepeatFields(uint handle, int nRepeat)
    {
      this.m_hndPOST = handle;
      if (!this.m_LawyerID.m_bIsSet)
        this.LawyerID = 0;
      this.m_LawyerID.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_GLID.m_bIsSet)
        this.GLNN = "9999";
      this.m_GLID.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_Hours.m_bIsSet)
        this.Seconds = 0;
      if ((!this.m_Hours.m_bIsSet || !this.Seconds.Equals(0) ? (this.m_Hours.m_bIsSet ? 1 : 0) : 0) != 0)
        this.m_EntryType.SetValue(2);
      else
        this.m_EntryType.SetValue(3);
      this.m_EntryType.AddRepeatField(this.m_hndPOST, nRepeat);
      this.m_Hours.AddRepeatField(this.m_hndPOST, nRepeat);
      if (!this.m_Amount.m_bIsSet)
        this.Amount = 0.0;
      this.m_Amount.AddRepeatField(this.m_hndPOST, nRepeat);
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
      this.m_hndGET = handle;
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetRepeatField(this.m_hndGET, nRepeat);
    }

    protected override void Initialize()
    {
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.RepeatLONG, "FeeAllocLawyerID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_LawyerID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.RepeatLONG, "FeeAllocGLID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_GLID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "FeeAllocHours");
      CPostItem cpostItem6 = cpostItem5;
      this.m_Hours = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.RepeatDOUBLE, "FeeAllocAmount");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Amount = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.RepeatLONG, "FeeAllocEntryType");
      CPostItem cpostItem10 = cpostItem9;
      this.m_EntryType = cpostItem9;
      postItems5.Add(cpostItem10);
    }
  }
}
