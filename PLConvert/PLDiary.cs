// Decompiled with JetBrains decompiler
// Type: PLConvert.PLDiary
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLDiary : TransactionData
  {
    private CPostItem m_MatterID;
    private CPostItem m_EntryID;
    private CPostItem m_Active;
    private CPostItem m_DiaryCodeID;
    private CPostItem m_LocationID;
    private CPostItem m_ReminderDate;
    private CPostItem m_DueDate;
    private CPostItem m_EnteredDate;
    private CPostItem m_CompletionDate;
    private CPostItem m_MinutesToRemind;
    private CPostItem m_StartTime;
    private CPostItem m_CompletionStatus;
    private CPostItem m_EntryType;
    private CPostItem m_DurationSeconds;
    private CPostItem m_ActionOrNotes;
    private CPostItem m_LawyerID;
    //private List<int> ArrLawyers;
    private List<bool> ArrMSGRead;
    private CPostItem m_ContactID;
    private List<int> ArrContacts;
    private CPostItem m_MsgUserID;
    private CPostItem m_PhoneCallRead;
    private CPostItem m_Subject;
    private CPostItem m_NoteShortDescription;
    private CPostItem m_CallContactName;
    private CPostItem m_CallPhoneNumber;
    private CPostItem m_CallOut;
    private CPostItem m_Priority;
    private CPostItem m_PhoneCallPleaseCall;
    private CPostItem m_PhoneCallReturnedCall;
    private CPostItem m_PhoneCallWillCallAgain;
    private CPostItem m_PhoneCallAction;
    private CPostItem m_IsRecurringEntry;
    private CPostItem m_RecurringFreq;
    private CPostItem m_RecurringType;
    private CPostItem m_RecurringStartDate;
    private CPostItem m_RecurringEndDate;
    private CPostItem m_RecurringDayOfWeek;
    private CPostItem m_RecurringDayOfMonth;
    private CPostItem m_RecurringWeekOfMonth;
    private CPostItem m_RecurringMonthOfYear;
    private CPostItem m_RecurringAdjust;
    private CPostItem m_RecurringRepeatUnit;
    private CPostItem m_RecurringStartTime;
    private CPostItem m_RecurringDuration;
    private CPostItem m_RecurringDurationSeconds;
    private CPostItem m_RecurringDescription;

    public bool AllDayEvent { get; set; }

    public string CallContactName
    {
      get
      {
        return this.m_CallContactName.sValue;
      }
      set
      {
        this.m_CallContactName.SetValue(value);
      }
    }

    public bool CallDirectionOut
    {
      get
      {
        return this.m_CallOut.bValue;
      }
      set
      {
        this.m_CallOut.SetValue(value);
      }
    }

    public PLXMLData.eSTATUS Active
    {
        get
        {
            return (PLXMLData.eSTATUS)this.m_Status.nValue;
        }
        set
        {
            this.m_Status.SetValue((int)value);
        }
    }

    public int EntryID
    {
        get
        {
            return this.m_EntryID.nValue;
        }
        set
        {
            this.m_EntryID.SetValue(value);
        }
    }

    public string CallPhoneNumber
    {
      get
      {
        return this.m_CallPhoneNumber.sValue;
      }
      set
      {
        this.m_CallPhoneNumber.SetValue(value);
      }
    }

    public bool Completed
    {
      get
      {
        return this.m_CompletionStatus.nValue != 0;
      }
      set
      {
        this.m_CompletionStatus.SetValue(!value ? 0 : 1);
      }
    }

    public int CompletionDate
    {
      get
      {
        return this.m_CompletionDate.nValue;
      }
      set
      {
        this.m_CompletionDate.SetValue(value);
      }
    }

    public string Description
    {
      get
      {
        return this.m_ActionOrNotes.sValue;
      }
      set
      {
        this.m_ActionOrNotes.SetValue(value);
      }
    }

    public int DiaryCodeID
    {
      get
      {
        return this.m_DiaryCodeID.nValue;
      }
      set
      {
        this.m_DiaryCodeID.SetValue(value);
      }
    }

    public string DiaryCodeNN
    {
      get
      {
        return PLDiaryCode.GetNNFromID(this.m_DiaryCodeID.nValue);
      }
      set
      {
        this.m_DiaryCodeID.SetValue(PLDiaryCode.GetIDFromNN(value));
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

    public double Duration
    {
      get
      {
        return (double) this.m_DurationSeconds.nValue / 3600.0;
      }
      set
      {
        this.m_DurationSeconds.SetValue((int) (value * 3600.0));
      }
    }

    public int DurationSeconds
    {
      get
      {
        return this.m_DurationSeconds.nValue;
      }
      set
      {
        this.m_DurationSeconds.SetValue(value);
      }
    }

    public int EnteredDate
    {
      get
      {
        return this.m_EnteredDate.nValue;
      }
      set
      {
        this.m_EnteredDate.SetValue(value);
      }
    }

    public PLDiary.eType EntryType
    {
      get
      {
        return (PLDiary.eType) this.m_EntryType.nValue;
      }
      set
      {
        this.m_EntryType.SetValue((int) value);
      }
    }

    public bool IsRecurringEntry
    {
      get
      {
        return this.m_IsRecurringEntry.bValue;
      }
      set
      {
        this.m_IsRecurringEntry.SetValue(value);
      }
    }

    public int LocationCodeID
    {
      get
      {
        return this.m_LocationID.nValue;
      }
      set
      {
        this.m_LocationID.SetValue(value);
      }
    }

    public string LocationCodeNN
    {
      get
      {
        return PLLocationCode.GetNNFromID(this.m_LocationID.nValue);
      }
      set
      {
        this.m_LocationID.SetValue(PLLocationCode.GetIDFromNN(value));
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

    public int UserID
    {
        get
        {
            return this.m_MsgUserID.nValue;
        }
        set
        {
            this.m_MsgUserID.SetValue(value);
        }
    }

    public int ContactID
    {
        get
        {
            return this.m_ContactID.nValue;
        }
        set
        {
            this.m_ContactID.SetValue(value);
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

    public int MinutesToRemind
    {
      get
      {
        return this.m_MinutesToRemind.nValue;
      }
      set
      {
        this.m_MinutesToRemind.SetValue(value);
      }
    }

    public string NoteShortDescription
    {
      get
      {
        return this.m_NoteShortDescription.sValue;
      }
      set
      {
        this.m_NoteShortDescription.SetValue(value);
      }
    }

    public PLDiary.eCallAction PhoneCallAction
    {
      get
      {
        return (PLDiary.eCallAction) this.m_PhoneCallAction.nValue;
      }
      set
      {
        this.m_PhoneCallAction.SetValue((int) value);
      }
    }

    public bool PhoneCallPleaseCall
    {
      get
      {
        return this.m_PhoneCallPleaseCall.bValue;
      }
      set
      {
        this.m_PhoneCallPleaseCall.SetValue(value);
      }
    }

    public bool PhoneCallReturnedCall
    {
      get
      {
        return this.m_PhoneCallReturnedCall.bValue;
      }
      set
      {
        this.m_PhoneCallReturnedCall.SetValue(value);
      }
    }

    public bool PhoneCallWillCallAgain
    {
      get
      {
        return this.m_PhoneCallWillCallAgain.bValue;
      }
      set
      {
        this.m_PhoneCallWillCallAgain.SetValue(value);
      }
    }

    public PLDiary.ePriority Priority
    {
      get
      {
        return (PLDiary.ePriority) this.m_Priority.nValue;
      }
      set
      {
        this.m_Priority.SetValue((int) value);
      }
    }

    public PLDiary.eAdjust RecurringAdjust
    {
      get
      {
        return (PLDiary.eAdjust) this.m_RecurringAdjust.nValue;
      }
      set
      {
        this.m_RecurringAdjust.SetValue((int) value);
      }
    }

    public int RecurringDayOfMonth
    {
      get
      {
        return this.m_RecurringDayOfMonth.nValue;
      }
      set
      {
        this.m_RecurringDayOfMonth.SetValue(value);
      }
    }

    public PLDiary.eDay RecurringDayOfWeek
    {
      get
      {
        return (PLDiary.eDay) this.m_RecurringDayOfWeek.nValue;
      }
      set
      {
        this.m_RecurringDayOfWeek.SetValue((int) value);
      }
    }

    private string RecurringDescription
    {
      get
      {
        return this.m_RecurringDescription.sValue;
      }
      set
      {
        this.m_RecurringDescription.SetValue(value);
      }
    }

    private double RecurringDuration
    {
      get
      {
        return this.m_RecurringDuration.dValue;
      }
      set
      {
        this.m_RecurringDuration.SetValue(value);
      }
    }

    public int RecurringDurationSeconds
    {
      get
      {
        return this.m_RecurringDurationSeconds.nValue;
      }
      set
      {
        this.m_RecurringDurationSeconds.SetValue(value);
      }
    }

    public int RecurringEndDate
    {
      get
      {
        return this.m_RecurringEndDate.nValue;
      }
      set
      {
        this.m_RecurringEndDate.SetValue(value);
      }
    }

    public int RecurringFreq
    {
      get
      {
        return this.m_RecurringFreq.nValue;
      }
      set
      {
        this.m_RecurringFreq.SetValue(value);
      }
    }

    public int RecurringMonthOfYear
    {
      get
      {
        return this.m_RecurringMonthOfYear.nValue;
      }
      set
      {
        this.m_RecurringMonthOfYear.SetValue(value);
      }
    }

    public PLDiary.eRepeatUnit RecurringRepeatUnit
    {
      get
      {
        return (PLDiary.eRepeatUnit) this.m_RecurringRepeatUnit.nValue;
      }
      set
      {
        this.m_RecurringRepeatUnit.SetValue((int) value);
      }
    }

    public int RecurringStartDate
    {
      get
      {
        return this.m_RecurringStartDate.nValue;
      }
      set
      {
        this.m_RecurringStartDate.SetValue(value);
      }
    }

    private int RecurringStartTime
    {
      get
      {
        return this.m_RecurringStartTime.nValue;
      }
      set
      {
        this.m_RecurringStartTime.SetValue(value);
      }
    }

    private PLDiary.eType RecurringType
    {
      get
      {
        return (PLDiary.eType) this.m_RecurringType.nValue;
      }
      set
      {
        this.m_RecurringType.SetValue((int) value);
      }
    }

    public int RecurringWeekOfMonth
    {
      get
      {
        return this.m_RecurringWeekOfMonth.nValue;
      }
      set
      {
        this.m_RecurringWeekOfMonth.SetValue(value);
      }
    }

    public int ReminderDate
    {
      get
      {
        return this.m_ReminderDate.nValue;
      }
      set
      {
        this.m_ReminderDate.SetValue(value);
      }
    }

    public int StartTime
    {
      get
      {
        return this.m_StartTime.nValue;
      }
      set
      {
        this.m_StartTime.SetValue(value);
      }
    }

    public string Subject
    {
      get
      {
        return this.m_Subject.sValue;
      }
      set
      {
        this.m_Subject.SetValue(value);
      }
    }

    public PLDiary()
    {
      this.Initialize();
    }

    public void AddContact(int nID)
    {
      this.ArrContacts.Add(nID);
    }

  //  public void AddLawyer(string sNN)
  ////  {
   //     this.m_LawyerID.nValue = 
  //  }

   // public void AddLawyer(int nID)
   // {
  //      this.m_LawyerID.SetValue(nID);
  //  }

    public override void AddRecord()
    {
      PLDiary.eType entryType = this.EntryType;
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if (this.EntryType == PLDiary.eType.Appointment)
      {
        if (this.AllDayEvent)
        {
          this.StartTime = 700;
          this.DurationSeconds = 43200;
        }
        else if ((this.StartTime > 700 ? 0 : (this.DurationSeconds > 43200 ? 1 : 0)) != 0)
        {
          this.StartTime = 700;
          this.DurationSeconds = 43200;
        }
        this.AllDayEvent = false;
        if (this.DurationSeconds < 360)
          this.DurationSeconds = 360;
      }
      if (this.EntryType == PLDiary.eType.TODO && this.DurationSeconds < 360)
        this.DurationSeconds = 360;
      if (this.IsRecurringEntry)
      {
        this.RecurringType = this.EntryType;
        this.RecurringDescription = this.Description;
        this.RecurringStartTime = this.StartTime;
        this.RecurringDuration = this.Duration;
        if (this.RecurringRepeatUnit != PLDiary.eRepeatUnit.Year || (this.RecurringMonthOfYear == 0 || this.RecurringWeekOfMonth == 0 ? 0 : (this.RecurringDayOfWeek == (PLDiary.eDay) 0 ? 1 : 0)) == 0);
        if (this.RecurringRepeatUnit != PLDiary.eRepeatUnit.Month || (this.RecurringWeekOfMonth == 0 ? 0 : (this.RecurringDayOfWeek == (PLDiary.eDay) 0 ? 1 : 0)) == 0);
      }
      if (this.EntryType == PLDiary.eType.Call)
      {
        this.ReminderDate = this.DueDate;
        this.EnteredDate = this.DueDate;
      }
      if (this.ReminderDate == 0)
        this.ReminderDate = this.DueDate;
      if (this.EntryType == PLDiary.eType.Holiday)
      {
        //this.ArrLawyers.Clear();
        this.ArrMSGRead.Clear();
        this.ArrContacts.Clear();
        this.m_StartTime.Clear();
        this.m_DurationSeconds.Clear();
        this.m_ReminderDate.Clear();
      }
      this.Completed = this.m_CompletionDate.m_bIsSet;
      if ((m_LawyerID != null && m_MsgUserID != null) && (m_LawyerID.nValue > 0 && m_MsgUserID.nValue > 0))
      {
          this.m_LawyerID.AddField(this.m_hndPOST);
          //this.m_MsgUserID.SetValue(m_MsgUserID.nValue);
          this.m_MsgUserID.AddField(this.m_hndPOST);

        this.ArrMSGRead.Clear();
      }
      else
      {
          this.m_LawyerID.SetValue(PLLawyer.GetIDFromNN("~IT"));
          this.m_LawyerID.AddField(this.m_hndPOST);
          this.m_MsgUserID.SetValue(PLLawyer.GetIDFromNN("~IT"));
          this.m_MsgUserID.AddField(this.m_hndPOST);
      }
      base.AddRecord();
      this.m_EntryType.AddField(this.m_hndPOST);
      if (this.ArrContacts.Count > 0)
      {
        for (int nRepeat = 1; nRepeat <= this.ArrContacts.Count; ++nRepeat)
        {
          this.m_ContactID.SetValue(Convert.ToInt32(this.ArrContacts[nRepeat - 1]));
          this.m_ContactID.AddRepeatField(this.m_hndPOST, nRepeat);
        }
        this.ArrContacts.Clear();
      }
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLDiary plDiary = this;
      plDiary.m_lCounter = plDiary.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }


    public override void Clear()
    {
      base.Clear();
      this.ArrMSGRead.Clear();
      this.m_LawyerID.Clear();
      this.m_MsgUserID.Clear();
      this.m_PhoneCallRead.Clear();
      this.ArrContacts.Clear();
      this.m_ContactID.Clear();
      this.m_MsgUserID.Clear();
      this.m_EntryID.Clear();
      this.m_PhoneCallRead.Clear();
      this.AllDayEvent = false;
    }

    protected override bool GetAllowEntOnClosedMtr()
    {
      return false;
    }

    protected override void Initialize()
    {
      this.m_lCounter = 0;
      this.m_sTableName = "DiaryEntry";
      this.m_hndPOST = 0U;
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "MatterID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_MatterID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "DiaryCodeID");
      CPostItem cpostItem4 = cpostItem3;
      this.m_DiaryCodeID = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.LONG, "LocationID");
      CPostItem cpostItem6 = cpostItem5;
      this.m_LocationID = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryReminderDate");
      CPostItem cpostItem8 = cpostItem7;
      this.m_ReminderDate = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryDueDate");
      CPostItem cpostItem10 = cpostItem9;
      this.m_DueDate = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryEnteredDate");
      CPostItem cpostItem12 = cpostItem11;
      this.m_EnteredDate = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryCompletionDate");
      CPostItem cpostItem14 = cpostItem13;
      this.m_CompletionDate = cpostItem13;
      postItems7.Add(cpostItem14);
      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryMinutesToRemind");
      CPostItem cpostItem16 = cpostItem15;
      this.m_MinutesToRemind = cpostItem15;
      postItems8.Add(cpostItem16);
      List<CPostItem> postItems9 = this.PostItems;
      CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryStartTime");
      CPostItem cpostItem18 = cpostItem17;
      this.m_StartTime = cpostItem17;
      postItems9.Add(cpostItem18);
      List<CPostItem> postItems10 = this.PostItems;
      CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryCompletionStatus");
      CPostItem cpostItem20 = cpostItem19;
      this.m_CompletionStatus = cpostItem19;
      postItems10.Add(cpostItem20);
      List<CPostItem> postItems11 = this.PostItems;
      CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryType");
      CPostItem cpostItem22 = cpostItem21;
      this.m_EntryType = cpostItem21;
      postItems11.Add(cpostItem22);
      List<CPostItem> postItems12 = this.PostItems;
      CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryDurationSeconds");
      CPostItem cpostItem24 = cpostItem23;
      this.m_DurationSeconds = cpostItem23;
      postItems12.Add(cpostItem24);
      List<CPostItem> postItems13 = this.PostItems;
      CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.STRING, "DiaryEntryActionOrNotes");
      CPostItem cpostItem26 = cpostItem25;
      this.m_ActionOrNotes = cpostItem25;
      postItems13.Add(cpostItem26);
      this.ArrMSGRead = new List<bool>();
      this.ArrContacts = new List<int>();
      this.m_PhoneCallRead = new CPostItem(CPostItem.DataType.RepeatBOOL, "PhoneCallReadUnread");
      List<CPostItem> postItems14 = this.PostItems;
      CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.STRING, "DiaryEntrySubject");
      CPostItem cpostItem28 = cpostItem27;
      this.m_Subject = cpostItem27;
      postItems14.Add(cpostItem28);
      List<CPostItem> postItems15 = this.PostItems;
      CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "DiaryEntryShortDescription");
      CPostItem cpostItem30 = cpostItem29;
      this.m_NoteShortDescription = cpostItem29;
      postItems15.Add(cpostItem30);
      List<CPostItem> postItems16 = this.PostItems;
      CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.STRING, "DiaryEntryCallContactName");
      CPostItem cpostItem32 = cpostItem31;
      this.m_CallContactName = cpostItem31;
      postItems16.Add(cpostItem32);
      List<CPostItem> postItems17 = this.PostItems;
      CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.STRING, "DiaryEntryCallPhoneNumber");
      CPostItem cpostItem34 = cpostItem33;
      this.m_CallPhoneNumber = cpostItem33;
      postItems17.Add(cpostItem34);
      List<CPostItem> postItems18 = this.PostItems;
      CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.BOOL, "DiaryEntryCallInOut");
      CPostItem cpostItem36 = cpostItem35;
      this.m_CallOut = cpostItem35;
      postItems18.Add(cpostItem36);
      List<CPostItem> postItems19 = this.PostItems;
      CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.RepeatLONG, "DiaryEntryHasPriority");
      CPostItem cpostItem38 = cpostItem37;
      this.m_Priority = cpostItem37;
      postItems19.Add(cpostItem38);
      List<CPostItem> postItems20 = this.PostItems;
      CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.BOOL, "DiaryEntryMsgPleaseCall");
      CPostItem cpostItem40 = cpostItem39;
      this.m_PhoneCallPleaseCall = cpostItem39;
      postItems20.Add(cpostItem40);
      List<CPostItem> postItems21 = this.PostItems;
      CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.BOOL, "DiaryEntryMsgReturnedCall");
      CPostItem cpostItem42 = cpostItem41;
      this.m_PhoneCallReturnedCall = cpostItem41;
      postItems21.Add(cpostItem42);
      List<CPostItem> postItems22 = this.PostItems;
      CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.BOOL, "DiaryEntryMsgWillCallAgain");
      CPostItem cpostItem44 = cpostItem43;
      this.m_PhoneCallWillCallAgain = cpostItem43;
      postItems22.Add(cpostItem44);
      List<CPostItem> postItems23 = this.PostItems;
      CPostItem cpostItem45 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryCallAction");
      CPostItem cpostItem46 = cpostItem45;
      this.m_PhoneCallAction = cpostItem45;
      postItems23.Add(cpostItem46);
      List<CPostItem> postItems24 = this.PostItems;
      CPostItem cpostItem47 = new CPostItem(CPostItem.DataType.BOOL, "DiaryEntryIsRecurringEntry");
      CPostItem cpostItem48 = cpostItem47;
      this.m_IsRecurringEntry = cpostItem47;
      postItems24.Add(cpostItem48);
      List<CPostItem> postItems25 = this.PostItems;
      CPostItem cpostItem49 = new CPostItem(CPostItem.DataType.LONG, "RecurringFreq");
      CPostItem cpostItem50 = cpostItem49;
      this.m_RecurringFreq = cpostItem49;
      postItems25.Add(cpostItem50);
      List<CPostItem> postItems26 = this.PostItems;
      CPostItem cpostItem51 = new CPostItem(CPostItem.DataType.LONG, "RecurringType");
      CPostItem cpostItem52 = cpostItem51;
      this.m_RecurringType = cpostItem51;
      postItems26.Add(cpostItem52);
      List<CPostItem> postItems27 = this.PostItems;
      CPostItem cpostItem53 = new CPostItem(CPostItem.DataType.LONG, "RecurringStartDate");
      CPostItem cpostItem54 = cpostItem53;
      this.m_RecurringStartDate = cpostItem53;
      postItems27.Add(cpostItem54);
      List<CPostItem> postItems28 = this.PostItems;
      CPostItem cpostItem55 = new CPostItem(CPostItem.DataType.LONG, "RecurringEndDate");
      CPostItem cpostItem56 = cpostItem55;
      this.m_RecurringEndDate = cpostItem55;
      postItems28.Add(cpostItem56);
      List<CPostItem> postItems29 = this.PostItems;
      CPostItem cpostItem57 = new CPostItem(CPostItem.DataType.LONG, "RecurringDayOfWeek");
      CPostItem cpostItem58 = cpostItem57;
      this.m_RecurringDayOfWeek = cpostItem57;
      postItems29.Add(cpostItem58);
      List<CPostItem> postItems30 = this.PostItems;
      CPostItem cpostItem59 = new CPostItem(CPostItem.DataType.LONG, "RecurringDayOfMonth");
      CPostItem cpostItem60 = cpostItem59;
      this.m_RecurringDayOfMonth = cpostItem59;
      postItems30.Add(cpostItem60);
      List<CPostItem> postItems31 = this.PostItems;
      CPostItem cpostItem61 = new CPostItem(CPostItem.DataType.LONG, "RecurringWeekOfMonth");
      CPostItem cpostItem62 = cpostItem61;
      this.m_RecurringWeekOfMonth = cpostItem61;
      postItems31.Add(cpostItem62);
      List<CPostItem> postItems32 = this.PostItems;
      CPostItem cpostItem63 = new CPostItem(CPostItem.DataType.LONG, "RecurringMonthOfYear");
      CPostItem cpostItem64 = cpostItem63;
      this.m_RecurringMonthOfYear = cpostItem63;
      postItems32.Add(cpostItem64);
      List<CPostItem> postItems33 = this.PostItems;
      CPostItem cpostItem65 = new CPostItem(CPostItem.DataType.LONG, "RecurringAdjust");
      CPostItem cpostItem66 = cpostItem65;
      this.m_RecurringAdjust = cpostItem65;
      postItems33.Add(cpostItem66);
      List<CPostItem> postItems34 = this.PostItems;
      CPostItem cpostItem67 = new CPostItem(CPostItem.DataType.LONG, "RecurringRepeatUnit");
      CPostItem cpostItem68 = cpostItem67;
      this.m_RecurringRepeatUnit = cpostItem67;
      postItems34.Add(cpostItem68);
      List<CPostItem> postItems35 = this.PostItems;
      CPostItem cpostItem69 = new CPostItem(CPostItem.DataType.LONG, "RecurringStartTime");
      CPostItem cpostItem70 = cpostItem69;
      this.m_RecurringStartTime = cpostItem69;
      postItems35.Add(cpostItem70);
      List<CPostItem> postItems36 = this.PostItems;
      CPostItem cpostItem71 = new CPostItem(CPostItem.DataType.DOUBLE, "RecurringDuration");
      CPostItem cpostItem72 = cpostItem71;
      this.m_RecurringDuration = cpostItem71;
      postItems36.Add(cpostItem72);
      List<CPostItem> postItems37 = this.PostItems;
      CPostItem cpostItem73 = new CPostItem(CPostItem.DataType.LONG, "RecurringDurationSeconds");
      CPostItem cpostItem74 = cpostItem73;
      this.m_RecurringDurationSeconds = cpostItem73;
      postItems37.Add(cpostItem74);
      List<CPostItem> postItems38 = this.PostItems;
      CPostItem cpostItem75 = new CPostItem(CPostItem.DataType.STRING, "RecurringDescription");
      CPostItem cpostItem76 = cpostItem75;
      this.m_RecurringDescription = cpostItem75;
      postItems38.Add(cpostItem76);

      List<CPostItem> postItems39 = this.PostItems;
      CPostItem cpostItem77 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryID");
      CPostItem cpostItem78 = cpostItem77;
      this.m_EntryID = cpostItem77;
      postItems39.Add(cpostItem78);

      List<CPostItem> postItems40 = this.PostItems;
      CPostItem cpostItem79 = new CPostItem(CPostItem.DataType.LONG, "ContactID");
      CPostItem cpostItem80 = cpostItem79;
      this.m_ContactID = cpostItem79;
      postItems40.Add(cpostItem80);

      List<CPostItem> postItems41 = this.PostItems;
      CPostItem cpostItem81 = new CPostItem(CPostItem.DataType.LONG, "DiaryUserID");
      CPostItem cpostItem82 = cpostItem81;
      this.m_LawyerID = cpostItem81;
      postItems41.Add(cpostItem82);

      List<CPostItem> postItems42 = this.PostItems;
      CPostItem cpostItem83 = new CPostItem(CPostItem.DataType.LONG, "DiaryEntryStatus");
      CPostItem cpostItem84 = cpostItem83;
      this.m_Status = cpostItem83;
      postItems42.Add(cpostItem84);

      List<CPostItem> postItems43 = this.PostItems;
      CPostItem cpostItem85 = new CPostItem(CPostItem.DataType.LONG, "MsgUserID");
      CPostItem cpostItem86 = cpostItem85;
      this.m_MsgUserID = cpostItem85;
      postItems43.Add(cpostItem86);

      //this.m_LawyerID = new CPostItem(CPostItem.DataType.RepeatLONG, "LawyerID");
    //  this.m_ContactID = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactID");
     // this.m_MsgUserID = new CPostItem(CPostItem.DataType.RepeatLONG, "MsgUserID");
     // this.m_EntryID = new CPostItem(CPostItem.DataType.RepeatLONG, "DiaryEntryID");






      this.AllDayEvent = false;
    }

    public override string ToString()
    {
      return "DiaryEntry";
    }

    public enum eAdjust : byte
    {
      SameDay,
      NextBusDay,
      PrevBusDay,
      Closet,
      CancelEntry,
    }

    public enum eCallAction : byte
    {
      Busy,
      LeftMsg,
      NoAnswer,
      Spoke,
      VoiceMail,
    }

    public enum eDay : byte
    {
      Non = 1,
      Tue = 2,
      Wed = 3,
      Thur = 4,
      Fri = 5,
      Sat = 6,
      Sun = 7,
    }

    public enum ePriority : byte
    {
      Normal,
      Low,
      High,
    }

    public enum eRepeatUnit : byte
    {
      CalendarDay,
      BusinessDay,
      Week,
      Month,
      Year,
    }

    public enum eType : byte
    {
      Appointment = 0,
      TODO = 1,
      Call = 2,
      Notes = 6,
      Holiday = 8,
      Message = 9,
    }
  }
}
