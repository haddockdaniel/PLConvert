// Decompiled with JetBrains decompiler
// Type: PLConvert.PCLawConversion
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Windows.Forms;

namespace PLConvert
{
  public class PCLawConversion
  {
    public PLLink PL;
    public PLGenInfo GenInf;
    public PLLawyer Lawyer;
    public PLUser User;
    public PLRate Rate;
    public PLContactType ContactType;
    public PLDiaryCode DiaryCode;
    public PLExpCode ExpCode;
    public PLGLAccts GLAccts;
    public PLTask Task;
    public PLGBAcct GBAcct;
    public PLTBAcct TBAcct;
    public PLTypeOfLaw TypeOfLaw;
    public PLLocationCode Location;
    public PLDepartment Department;
    public PLRefSource RefSource;
    public PLClient Client;
    public PLContact Contact;
    public PLMatter Matter;
    public PLVendor Vendor;
    public PLBilling Bill;
    public PLWUD WUD;
    public PLTimeEntry TimeEntry;
    public PLTBEnt Trust;
    public PLGBEnt General;
    public PLExpense Expense;
    public PLPayableEntry Payable;
    public PLGJEntry GJ;
    public PLDiary Diary;
    public PLSafeCustStageGroup SCStageGroup;
    public PLSafeCustStage SCStage;
    public PLSafeCustType SCType;
    public PLSafeCustStatus SCStatus;
    public PLSafeCustPacket SCPacket;
    public PLSafeCustEntry SCSafeCustRecord;
    public PLSafeCustMovement SCMovements;
    public PLCustomTab CustomTab;

    public PCLawConversion()
    {
      try
      {
        this.PL = new PLLink();
        this.GenInf = new PLGenInfo();
        this.Lawyer = new PLLawyer();
        this.User = new PLUser();
        this.Rate = new PLRate();
        this.ContactType = new PLContactType();
        this.DiaryCode = new PLDiaryCode();
        this.ExpCode = new PLExpCode();
        this.GLAccts = new PLGLAccts();
        this.Task = new PLTask();
        this.GBAcct = new PLGBAcct();
        this.TBAcct = new PLTBAcct();
        this.TypeOfLaw = new PLTypeOfLaw();
        this.Location = new PLLocationCode();
        this.Department = new PLDepartment();
        this.RefSource = new PLRefSource();
        this.Client = new PLClient();
        this.Contact = new PLContact();
        this.Matter = new PLMatter();
        this.Vendor = new PLVendor();
        this.Bill = new PLBilling();
        this.WUD = new PLWUD();
        this.TimeEntry = new PLTimeEntry();
        this.Trust = new PLTBEnt();
        this.General = new PLGBEnt();
        this.Expense = new PLExpense();
        this.Payable = new PLPayableEntry();
        this.GJ = new PLGJEntry();
        this.Diary = new PLDiary();
        this.SCStageGroup = new PLSafeCustStageGroup();
        this.SCStage = new PLSafeCustStage();
        this.SCType = new PLSafeCustType();
        this.SCStatus = new PLSafeCustStatus();
        this.SCPacket = new PLSafeCustPacket();
        this.SCSafeCustRecord = new PLSafeCustEntry();
        this.SCMovements = new PLSafeCustMovement();
        this.CustomTab = new PLCustomTab();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }
  }
}
