// Decompiled with JetBrains decompiler
// Type: PLConvert.PLSafeCustMovement
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

namespace PLConvert
{
  public class PLSafeCustMovement : TransactionData
  {
    private CPostItem m_SafeCustRecordID;
    private CPostItem m_Date;
    private CPostItem m_UserID;
    private CPostItem m_Flags;
    private CPostItem m_Notes;
    private CPostItem m_Recipient;

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

    public int Flags
    {
      get
      {
        return this.m_Flags.nValue;
      }
      set
      {
        this.m_Flags.SetValue(value);
      }
    }

    public string Notes
    {
      get
      {
        return this.m_Notes.sValue;
      }
      set
      {
        this.m_Notes.SetValue(value);
      }
    }

    public string Recipient
    {
      get
      {
        return this.m_Recipient.sValue;
      }
      set
      {
        this.m_Recipient.SetValue(value);
      }
    }

    public int SafeCustRecordID
    {
      get
      {
        return this.m_SafeCustRecordID.nValue;
      }
      set
      {
        this.m_SafeCustRecordID.SetValue(value);
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

    public PLSafeCustMovement()
    {
      this.Initialize();
    }

    public override void AddRecord()
    {
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      this.m_Status.AddField(this.m_hndPOST);
      this.m_ID.AddField(this.m_hndPOST);
      this.m_SafeCustRecordID.AddField(this.m_hndPOST);
      this.m_Date.AddField(this.m_hndPOST);
      this.m_UserID.AddField(this.m_hndPOST);
      this.m_Flags.AddField(this.m_hndPOST);
      this.m_Notes.AddField(this.m_hndPOST);
      this.m_Recipient.AddField(this.m_hndPOST);
      this.m_ExternalID_1.AddField(this.m_hndPOST);
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLSafeCustMovement safeCustMovement = this;
      safeCustMovement.m_lCounter = safeCustMovement.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      this.m_Status.Clear();
      this.m_ID.Clear();
      this.m_SafeCustRecordID.Clear();
      this.m_Date.Clear();
      this.m_UserID.Clear();
      this.m_Flags.Clear();
      this.m_Notes.Clear();
      this.m_Recipient.Clear();
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return true;
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "SafeCustMovement";
      this.m_hndPOST = 0U;
      this.m_Status = new CPostItem(CPostItem.DataType.LONG, "SCMovementStatus");
      this.m_ID = new CPostItem(CPostItem.DataType.LONG, "SCMovementID");
      this.m_SafeCustRecordID = new CPostItem(CPostItem.DataType.LONG, "SCMovementEntryID");
      this.m_Date = new CPostItem(CPostItem.DataType.LONG, "SCMovementDate");
      this.m_UserID = new CPostItem(CPostItem.DataType.LONG, "SCMovementUserID");
      this.m_Flags = new CPostItem(CPostItem.DataType.LONG, "SCMovementFlags");
      this.m_Notes = new CPostItem(CPostItem.DataType.STRING, "SCMovementNotes");
      this.m_Recipient = new CPostItem(CPostItem.DataType.STRING, "SCRecipient");
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
    }

    public override string ToString()
    {
      return "SafeCustMovement";
    }
  }
}
