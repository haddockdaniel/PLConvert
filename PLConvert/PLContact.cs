// Decompiled with JetBrains decompiler
// Type: PLConvert.PLContact
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using PLXMLLnkLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace PLConvert
{
  public class PLContact : StaticData
  {
    protected uint m_hndSubFld = 0;
    private static bool bRead = false;
    public PLName Name;
    public PLAddress AddressMain;
    public PLAddress AddressOther;
    public PLPhone Phone;
    private CPostItem m_Notes;
    private CPostItem m_MainContTypeID;
    private CPostItem m_ContTypeID;
    private List<int> ContTypes;
    private CPostItem m_LawyerID;
    private List<PLContact.ContactMatter> conMatters;
    private CPostItem m_PartyId;
    private CPostItem m_AssocMatt;
    private CPostItem m_MatterID;
    private CPostItem m_AssocMattRole;
    private CPostItem m_AssocMattDelete;
    private CPostItem m_CustomTabID;
    private CPostItem m_CustomTabEntityID;
    private CPostItem m_CustomTabType;
    private CPostItem m_CustomTabLinkID;
    private CPostItem m_CustomTabFldIDs;
    private CPostItem m_CustomTabFldValuesRAW;
    private CPostItem m_CustomTabFldValuesDisp;
    private CPostItem m_CustomTabTemplate;
    private CPostItem m_CustomTabHelpType;
    private ArrayList m_CustomTabIDArr;
    private ArrayList m_CustomTabEntityIDArr;
    private ArrayList m_CustomTabTypeArr;
    private ArrayList m_CustomTabLinkIDArr;
    private ArrayList m_CustomTabFieldInfoArr;
    private ArrayList m_CustomTabFieldIDsArr;
    private ArrayList m_CustomTabFldValuesRAWArr;
    private ArrayList m_htCustomTabHelpTypeArr;
    private static Dictionary<string, int> m_MapExtID1toPLID;
    private static Dictionary<string, int> m_MapExtID2toPLID;
    private static Dictionary<string, int> m_MapNameKeytoPLID;

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

    public int MainContTypeID
    {
      get
      {
        return this.m_MainContTypeID.nValue;
      }
      set
      {
        this.m_MainContTypeID.SetValue(value);
      }
    }

    public string MainContTypeNN
    {
      get
      {
        return PLContactType.GetNNFromID(this.m_MainContTypeID.nValue);
      }
      set
      {
        this.m_MainContTypeID.SetValue(PLContactType.GetIDFromNN(value));
      }
    }

    public string Memos
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

    public PLContact()
    {
      this.Initialize();
    }

    public void AddContactType(string sContTypeNN)
    {
      if (PLContactType.GetIDFromNN(sContTypeNN).Equals(0))
        return;
      this.ContTypes.Add(PLContactType.GetIDFromNN(sContTypeNN));
    }

    public void AddContactType(int nID)
    {
      if (nID == 0)
        return;
      this.ContTypes.Add(nID);
    }

    public void AddCustomTab(int nTabID, int nTabEntityID, int nTabLinkID)
    {
      int num = 2;
      this.m_CustomTabIDArr.Add((object) nTabID);
      this.m_CustomTabEntityIDArr.Add((object) nTabEntityID);
      this.m_CustomTabTypeArr.Add((object) num);
      this.m_CustomTabLinkIDArr.Add((object) nTabLinkID);
      ArrayList arrayList = new ArrayList();
      this.m_CustomTabFieldIDsArr = new ArrayList();
      this.m_CustomTabFldValuesRAWArr = new ArrayList();
      this.m_htCustomTabHelpTypeArr = new ArrayList();
      arrayList.Add((object) this.m_CustomTabFieldIDsArr);
      arrayList.Add((object) this.m_CustomTabFldValuesRAWArr);
      arrayList.Add((object) this.m_htCustomTabHelpTypeArr);
      this.m_CustomTabFieldInfoArr.Add((object) arrayList);
    }

    public void AddCustomTabFields(int nTabIndex, int nFieldID, string sFieldValue, int nHelpType)
    {
      ArrayList arrayList = (ArrayList) null;
      if (this.m_CustomTabFieldInfoArr.Count > nTabIndex - 1)
        arrayList = (ArrayList) this.m_CustomTabFieldInfoArr[nTabIndex - 1];
      if (arrayList == null)
      {
        arrayList = new ArrayList();
        this.m_CustomTabFieldIDsArr = new ArrayList();
        this.m_CustomTabFldValuesRAWArr = new ArrayList();
        this.m_htCustomTabHelpTypeArr = new ArrayList();
        arrayList.Add((object) this.m_CustomTabFieldIDsArr);
        arrayList.Add((object) this.m_CustomTabFldValuesRAWArr);
        arrayList.Add((object) this.m_htCustomTabHelpTypeArr);
        this.m_CustomTabFieldInfoArr.Add((object) arrayList);
      }
      this.m_CustomTabFieldIDsArr = (ArrayList) arrayList[0];
      this.m_CustomTabFldValuesRAWArr = (ArrayList) arrayList[1];
      this.m_htCustomTabHelpTypeArr = (ArrayList) arrayList[2];
      this.m_CustomTabFieldIDsArr.Add((object) nFieldID);
      this.m_CustomTabFldValuesRAWArr.Add((object) sFieldValue);
      this.m_htCustomTabHelpTypeArr.Add((object) nHelpType);
    }

    public static void AddMapExtID1toPLID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLContact.m_MapExtID1toPLID == null)
        PLContact.m_MapExtID1toPLID = new Dictionary<string, int>();
      if (!PLContact.m_MapExtID1toPLID.ContainsKey(Key))
        PLContact.m_MapExtID1toPLID.Add(Key, Value);
    }

    public static void AddMapExtID2toPLID(string Key, int Value)
    {
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLContact.m_MapExtID2toPLID == null)
        PLContact.m_MapExtID2toPLID = new Dictionary<string, int>();
      if (!PLContact.m_MapExtID2toPLID.ContainsKey(Key))
        PLContact.m_MapExtID2toPLID.Add(Key, Value);
    }

    public static void AddMapNameKeytoPLID(string Key, int Value)
    {
      Key = Key.ToUpper();
      if ((string.IsNullOrEmpty(Key) ? 0 : (!Value.Equals(0) ? 1 : 0)) == 0)
        return;
      if (PLContact.m_MapNameKeytoPLID == null)
        PLContact.m_MapNameKeytoPLID = new Dictionary<string, int>();
      if ((string.IsNullOrEmpty(Key) ? 0 : (!PLContact.m_MapNameKeytoPLID.ContainsKey(Key) ? 1 : 0)) != 0)
        PLContact.m_MapNameKeytoPLID.Add(Key, Value);
    }

    public void AddMatter(int nMattID, int nRoleID)
    {
      if (nMattID.Equals(0))
        return;
      for (int index = 0; index < this.conMatters.Count; ++index)
      {
        if (this.conMatters[index].MatterID == nMattID)
        {
          if (nRoleID == 0)
            return;
          this.conMatters[index].RollID = nRoleID;
          return;
        }
      }
      this.conMatters.Add(new PLContact.ContactMatter(nMattID, nRoleID, false));
    }

    public void AddMatter(int nMattID)
    {
      if (nMattID.Equals(0))
        return;
      for (int index = 0; index < this.conMatters.Count; ++index)
      {
        if (this.conMatters[index].MatterID == nMattID)
          return;
      }
      this.AddMatter(nMattID, 0);
    }

    public void AddMatter(string sMattNN)
    {
      int idFromNn = PLMatter.GetIDFromNN(sMattNN);
      if (idFromNn.Equals(0))
        return;
      this.AddMatter(idFromNn, 0);
    }

    public void AddMatter(string sMattNN, string sRole)
    {
      int idFromNn = PLMatter.GetIDFromNN(sMattNN);
      if (idFromNn.Equals(0))
        return;
      this.AddMatter(idFromNn, PLContactType.GetIDFromNN(sRole));
    }

    public override void AddRecord()
    {
      object Result = new object();
      if ((int) this.m_hndPOST == 0)
        this.m_hndPOST = this.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
      if ((int) this.m_hndSubFld == 0)
        this.m_hndSubFld = this.GetLink().SubField_CreateHandle();
      this.Name.AddFields(this.m_hndPOST);
      this.AddressMain.AddFields(this.m_hndPOST);
      this.AddressOther.AddFields(this.m_hndPOST);
      this.Phone.AddFields(this.m_hndPOST);
      this.m_ID.AddField(this.m_hndPOST);
      this.m_Status.AddField(this.m_hndPOST);
      this.m_Notes.AddField(this.m_hndPOST);
      for (short index = 1; (int) index <= this.ContTypes.Count; ++index)
      {
        this.m_ContTypeID.SetValue(Convert.ToInt32(this.ContTypes[(int) index - 1]));
        if (this.m_ContTypeID.nValue != 0)
        {
          this.m_ContTypeID.m_bIsSet = true;
          this.m_ContTypeID.AddRepeatField(this.m_hndPOST, (int) index);
        }
        if (!this.m_MainContTypeID.m_bIsSet)
          this.m_MainContTypeID.SetValue(Convert.ToInt32(this.ContTypes[(int) index - 1]));
      }
      this.ContTypes.Clear();
      this.m_MainContTypeID.AddField(this.m_hndPOST);
      this.m_LawyerID.AddField(this.m_hndPOST);
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddField(this.m_hndPOST);
      for (short index = 1; (int) index <= this.conMatters.Count; ++index)
      {
        this.m_PartyId.SetValue(0);
        this.m_PartyId.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_AssocMatt.SetValue(Convert.ToInt32(this.conMatters[(int) index - 1].MatterID));
        this.m_AssocMatt.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_AssocMattRole.SetValue(Convert.ToInt32(this.conMatters[(int) index - 1].RollID));
        this.m_AssocMattRole.AddRepeatField(this.m_hndPOST, (int) index);
        this.m_AssocMattDelete.SetValue(Convert.ToBoolean(this.conMatters[(int) index - 1].DeleteContact));
        this.m_AssocMattDelete.AddRepeatField(this.m_hndPOST, (int) index);
      }
      this.m_ExternalID_1.AddField(this.m_hndPOST);
      this.m_ExternalID_2.AddField(this.m_hndPOST);
      for (short index1 = 1; (int) index1 <= this.m_CustomTabIDArr.Count; ++index1)
      {
        this.m_CustomTabID.SetValue(Convert.ToInt32(this.m_CustomTabIDArr[(int) index1 - 1]));
        this.m_CustomTabID.AddRepeatField(this.m_hndPOST, (int) index1);
        this.m_CustomTabEntityID.SetValue(Convert.ToInt32(this.m_CustomTabEntityIDArr[(int) index1 - 1]));
        this.m_CustomTabEntityID.AddRepeatField(this.m_hndPOST, (int) index1);
        this.m_CustomTabType.SetValue(Convert.ToInt32(this.m_CustomTabTypeArr[(int) index1 - 1]));
        this.m_CustomTabType.AddRepeatField(this.m_hndPOST, (int) index1);
        this.m_CustomTabLinkID.SetValue(Convert.ToInt32(this.m_CustomTabLinkIDArr[(int) index1 - 1]));
        this.m_CustomTabLinkID.AddRepeatField(this.m_hndPOST, (int) index1);
        ArrayList arrayList = (ArrayList) this.m_CustomTabFieldInfoArr[(int) index1 - 1];
        if (arrayList != null)
        {
          this.m_CustomTabFieldIDsArr = (ArrayList) arrayList[0];
          this.GetLink().SubField_Reset(this.m_hndSubFld);
          for (short index2 = 0; (int) index2 < this.m_CustomTabFieldIDsArr.Count; ++index2)
            this.GetLink().SubField_AddValueString(this.m_hndSubFld, (int) index2 + 1, this.m_CustomTabFieldIDsArr[(int) index2].ToString());
          this.GetLink().SubField_String(this.m_hndSubFld, ref Result);
          this.m_CustomTabFldIDs.SetValue(Result.ToString());
          this.m_CustomTabFldIDs.AddRepeatField(this.m_hndPOST, (int) index1);
          this.m_CustomTabFldValuesRAWArr = (ArrayList) arrayList[1];
          this.GetLink().SubField_Reset(this.m_hndSubFld);
          for (short index2 = 0; (int) index2 < this.m_CustomTabFldValuesRAWArr.Count; ++index2)
            this.GetLink().SubField_AddValueString(this.m_hndSubFld, (int) index2 + 1, this.m_CustomTabFldValuesRAWArr[(int) index2].ToString());
          this.GetLink().SubField_String(this.m_hndSubFld, ref Result);
          this.m_CustomTabFldValuesRAW.SetValue(Result.ToString());
          this.m_CustomTabFldValuesRAW.AddRepeatField(this.m_hndPOST, (int) index1);
          this.m_htCustomTabHelpTypeArr = (ArrayList) arrayList[2];
          this.GetLink().SubField_Reset(this.m_hndSubFld);
          for (short index2 = 0; (int) index2 < this.m_htCustomTabHelpTypeArr.Count; ++index2)
            this.GetLink().SubField_AddValueString(this.m_hndSubFld, (int) index2 + 1, this.m_htCustomTabHelpTypeArr[(int) index2].ToString());
          this.GetLink().SubField_String(this.m_hndSubFld, ref Result);
          this.m_CustomTabHelpType.SetValue(Result.ToString());
          this.m_CustomTabHelpType.AddRepeatField(this.m_hndPOST, (int) index1);
          this.m_CustomTabFieldIDsArr.Clear();
          while (this.m_CustomTabFieldIDsArr.Count > 0)
            this.m_CustomTabFieldIDsArr.RemoveAt(0);
          this.m_CustomTabFldValuesRAWArr.Clear();
          while (this.m_CustomTabFldValuesRAWArr.Count > 0)
            this.m_CustomTabFldValuesRAWArr.RemoveAt(0);
          this.m_htCustomTabHelpTypeArr.Clear();
          while (this.m_htCustomTabHelpTypeArr.Count > 0)
            this.m_htCustomTabHelpTypeArr.RemoveAt(0);
        }
      }
      this.m_CustomTabIDArr.Clear();
      while (this.m_CustomTabIDArr.Count > 0)
        this.m_CustomTabIDArr.RemoveAt(0);
      this.m_CustomTabEntityIDArr.Clear();
      while (this.m_CustomTabEntityIDArr.Count > 0)
        this.m_CustomTabEntityIDArr.RemoveAt(0);
      this.m_CustomTabTypeArr.Clear();
      while (this.m_CustomTabTypeArr.Count > 0)
        this.m_CustomTabTypeArr.RemoveAt(0);
      this.m_CustomTabLinkIDArr.Clear();
      while (this.m_CustomTabLinkIDArr.Count > 0)
        this.m_CustomTabLinkIDArr.RemoveAt(0);
      this.m_CustomTabFieldInfoArr.Clear();
      while (this.m_CustomTabFieldInfoArr.Count > 0)
        this.m_CustomTabFieldInfoArr.RemoveAt(0);
      this.GetLink().TablePOST_AddRecord(this.m_hndPOST);
      PLContact plContact = this;
      plContact.m_lCounter = plContact.m_lCounter + 1;
      if (this.m_lCounter < PLXMLData.m_nMaxCounter)
        return;
      this.Send();
    }

    public override void Clear()
    {
      base.Clear();
      this.m_ExternalID_1.Clear();
      this.m_ExternalID_2.Clear();
      this.Name.Clear();
      this.AddressMain.Clear();
      this.AddressOther.Clear();
      this.Phone.Clear();
      this.ContTypes.Clear();
      this.m_ContTypeID.Clear();
      this.m_LawyerID.Clear();
      this.m_AssocMatt.Clear();
      this.m_AssocMattRole.Clear();
      this.m_AssocMattDelete.Clear();
      this.conMatters.Clear();
      this.m_CustomTabID.Clear();
      this.m_CustomTabEntityID.Clear();
      this.m_CustomTabType.Clear();
      this.m_CustomTabLinkID.Clear();
      this.m_CustomTabFldIDs.Clear();
      this.m_CustomTabFldValuesRAW.Clear();
      this.m_CustomTabFldValuesDisp.Clear();
      this.m_CustomTabTemplate.Clear();
      this.m_CustomTabHelpType.Clear();
    }

    public static void ClearMapExtID1toPLID()
    {
      if (PLContact.m_MapExtID1toPLID == null)
        return;
      PLContact.m_MapExtID1toPLID.Clear();
      PLContact.m_MapExtID1toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapExtID2toPLID()
    {
      if (PLContact.m_MapExtID2toPLID == null)
        return;
      PLContact.m_MapExtID2toPLID.Clear();
      PLContact.m_MapExtID2toPLID = (Dictionary<string, int>) null;
    }

    public static void ClearMapNameKeytoPLID()
    {
      if (PLContact.m_MapNameKeytoPLID == null)
        return;
      PLContact.m_MapNameKeytoPLID.Clear();
      PLContact.m_MapNameKeytoPLID = (Dictionary<string, int>) null;
    }

    public override void GetExistingRecord()
    {
      this.Clear();
      this.Name.GetRecord(this.m_hndExisting);
      this.AddressMain.GetRecord(this.m_hndExisting);
      this.AddressOther.GetRecord(this.m_hndExisting);
      this.Phone.GetRecord(this.m_hndExisting);
      this.m_ID.GetField(this.m_hndExisting);
      this.m_Status.GetField(this.m_hndExisting);
      this.m_Notes.GetField(this.m_hndExisting);
      this.m_MainContTypeID.GetField(this.m_hndExisting);
      this.m_LawyerID.GetField(this.m_hndExisting);
      this.m_MatterID.GetField(this.m_hndExisting);
    }

    public static int GetIDFromExtID1(string Key)
    {
      int num;
      if (!string.IsNullOrEmpty(Key))
      {
        if (PLContact.m_MapExtID1toPLID == null)
          PLContact.m_MapExtID1toPLID = new Dictionary<string, int>();
        num = PLContact.m_MapExtID1toPLID.ContainsKey(Key) ? Convert.ToInt32(PLContact.m_MapExtID1toPLID[Key]) : 0;
      }
      else
        num = 0;
      return num;
    }

    public static int GetIDFromExtID2(string Key)
    {
      return !string.IsNullOrEmpty(Key) ? (PLContact.m_MapExtID2toPLID == null ? 0 : (PLContact.m_MapExtID2toPLID.ContainsKey(Key) ? Convert.ToInt32(PLContact.m_MapExtID2toPLID[Key]) : 0)) : 0;
    }

    public static int GetIDFromNameKey(string Key)
    {
      Key = Key.ToUpper();
      int num;
      if (!string.IsNullOrEmpty(Key))
      {
        if (!PLContact.bRead)
          PLContact.ReadTable();
        num = PLContact.m_MapNameKeytoPLID == null ? 0 : (PLContact.m_MapNameKeytoPLID.ContainsKey(Key) ? Convert.ToInt32(PLContact.m_MapNameKeytoPLID[Key]) : 0);
      }
      else
        num = 0;
      return num;
    }

    public override void GetRecord()
    {
      this.Clear();
      if ((int) this.m_hndGET == 0)
        this.m_hndGET = this.GetLink().TableGET_CreateHandle(this.m_sTableName, 0, 0, 0U);
      this.Name.GetRecord(this.m_hndGET);
      this.AddressMain.GetRecord(this.m_hndGET);
      this.AddressOther.GetRecord(this.m_hndGET);
      this.Phone.GetRecord(this.m_hndGET);
      this.m_ID.GetField(this.m_hndGET);
      this.m_Status.GetField(this.m_hndGET);
      this.m_Notes.GetField(this.m_hndGET);
      this.m_MainContTypeID.GetField(this.m_hndGET);
      int recurringFieldCount = this.GetLink().TableGET_RecordRecurringField_Count(this.m_hndGET, this.m_ContTypeID.sLinkName);
      for (int nRepeat = 1; nRepeat <= recurringFieldCount; ++nRepeat)
      {
        this.m_ContTypeID.GetRepeatField(this.m_hndExisting, nRepeat);
        this.ContTypes.Add(this.m_ContTypeID.nValue);
      }
      this.m_LawyerID.GetField(this.m_hndGET);
      this.m_MatterID.GetField(this.m_hndGET);
    }

    protected override void Initialize()
    {
      this.m_sTableName = "Contact";
      this.Name = new PLName(PLName.eNameType.CONTACT);
      this.AddressMain = new PLAddress(PLAddress.eAddType.CONT_MainADDR);
      this.AddressOther = new PLAddress(PLAddress.eAddType.CONT_OthADDR);
      this.Phone = new PLPhone(PLPhone.ePhoneType.CONTACT);
      List<CPostItem> postItems1 = this.PostItems;
      CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.LONG, "ContactID");
      CPostItem cpostItem2 = cpostItem1;
      this.m_ID = cpostItem1;
      postItems1.Add(cpostItem2);
      List<CPostItem> postItems2 = this.PostItems;
      CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.LONG, "ContactStatus");
      CPostItem cpostItem4 = cpostItem3;
      this.m_Status = cpostItem3;
      postItems2.Add(cpostItem4);
      List<CPostItem> postItems3 = this.PostItems;
      CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "ContactNickName");
      CPostItem cpostItem6 = cpostItem5;
      this.m_NickName = cpostItem5;
      postItems3.Add(cpostItem6);
      List<CPostItem> postItems4 = this.PostItems;
      CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "ContactNotes");
      CPostItem cpostItem8 = cpostItem7;
      this.m_Notes = cpostItem7;
      postItems4.Add(cpostItem8);
      List<CPostItem> postItems5 = this.PostItems;
      CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.LONG, "MainContactTypeID");
      CPostItem cpostItem10 = cpostItem9;
      this.m_MainContTypeID = cpostItem9;
      postItems5.Add(cpostItem10);
      List<CPostItem> postItems6 = this.PostItems;
      CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.LONG, "LawyerID");
      CPostItem cpostItem12 = cpostItem11;
      this.m_LawyerID = cpostItem11;
      postItems6.Add(cpostItem12);
      List<CPostItem> postItems7 = this.PostItems;
      CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, "ContactQuickBooksID");
      CPostItem cpostItem14 = cpostItem13;
      this.m_QuickBooksID = cpostItem13;
      postItems7.Add(cpostItem14);

      List<CPostItem> postItems8 = this.PostItems;
      CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.LONG, "PartyMatterID");
      CPostItem cpostItem16 = cpostItem15;
      this.m_MatterID = cpostItem15;
      postItems8.Add(cpostItem16);

      this.m_ContTypeID = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactTypeTypeID");
      this.ContTypes = new List<int>();
      this.conMatters = new List<PLContact.ContactMatter>();
      this.m_PartyId = new CPostItem(CPostItem.DataType.RepeatLONG, "PartyID");
      this.m_AssocMatt = new CPostItem(CPostItem.DataType.RepeatLONG, "PartyMatterID");
      this.m_AssocMattRole = new CPostItem(CPostItem.DataType.RepeatLONG, "PartyContactTypeID");
      this.m_AssocMattDelete = new CPostItem(CPostItem.DataType.RepeatBOOL, "PartyDelete");
      this.m_CustomTabID = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactCustomTabID");
      this.m_CustomTabEntityID = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactCustomTabEntityID");
      this.m_CustomTabType = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactCustomTabEntityType");
      this.m_CustomTabLinkID = new CPostItem(CPostItem.DataType.RepeatLONG, "ContactCustomTabLinkID");
      this.m_CustomTabFldIDs = new CPostItem(CPostItem.DataType.RepeatSTRING, "ContactCustomTabFieldIDs");
      this.m_CustomTabFldValuesRAW = new CPostItem(CPostItem.DataType.RepeatSTRING, "ContactCustomTabFieldValuesRAW");
      this.m_CustomTabFldValuesDisp = new CPostItem(CPostItem.DataType.RepeatSTRING, "ContactCustomTabFieldValuesDISPLAY");
      this.m_CustomTabTemplate = new CPostItem(CPostItem.DataType.RepeatSTRING, "ContactCustomTabBillingTemplate");
      this.m_CustomTabHelpType = new CPostItem(CPostItem.DataType.RepeatSTRING, "ContactCustomTabHelpType");
      this.m_ExternalID_1 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_1");
      this.m_ExternalID_2 = new CPostItem(CPostItem.DataType.STRING, "ExternalID_2");
      this.m_CustomTabIDArr = new ArrayList();
      this.m_CustomTabEntityIDArr = new ArrayList();
      this.m_CustomTabTypeArr = new ArrayList();
      this.m_CustomTabLinkIDArr = new ArrayList();
      this.m_CustomTabFieldInfoArr = new ArrayList();
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    private static void ReadTable()
    {
      if (PLContact.bRead)
        return;
      uint num = 0;
      object szValue = new object();
      PCLawATLClass pcLawAtlClass = new PCLawATLClass();
      uint createHandle = pcLawAtlClass.TableGET_CreateHandle("Contact", 0, 0, 0U);
      pcLawAtlClass.TableGET_AddFilter(createHandle, "ContactStatus", "EQ", "0", 1);
      pcLawAtlClass.TableGET_AddDirective(createHandle, "FieldList", "ContactID|ContactFirstName|ContactMiddleName|ContactLastName|ContactCompany");
      while (pcLawAtlClass.TableGET_GetNextRecord(createHandle) == 0)
      {
        pcLawAtlClass.TableGET_RecordField_ValueString(createHandle, "ContactFirstName", "", ref szValue);
        string str1 = szValue.ToString().ToUpper().Trim();
        pcLawAtlClass.TableGET_RecordField_ValueString(createHandle, "ContactMiddleName", "", ref szValue);
        string str2 = szValue.ToString().ToUpper().Trim();
        pcLawAtlClass.TableGET_RecordField_ValueString(createHandle, "ContactLastName", "", ref szValue);
        string str3 = szValue.ToString().ToUpper().Trim();
        pcLawAtlClass.TableGET_RecordField_ValueString(createHandle, "ContactCompany", "", ref szValue);
        string str4 = szValue.ToString().ToUpper().Trim();
        string Key = (str1 + str2 + str3 + str4).ToString().ToUpper().Trim();
        while (Key.IndexOf("  ") > 0)
          Key = Key.Replace("  ", " ");
        if (!string.IsNullOrEmpty(Key))
          PLContact.AddMapNameKeytoPLID(Key, pcLawAtlClass.TableGET_RecordField_ValueI32(createHandle, "ContactID"));
      }
      pcLawAtlClass.TableGET_CloseHandle(createHandle);
      num = 0U;
      PLContact.bRead = true;
    }

    public override void Send()
    {
      object nProcessed = new object();
      object nExceptions = new object();
      object vunIDCreated = new object();
      object nExceptionError = new object();
      object szExceptionErrorMsg = new object();
      object szExceptionSentData = new object();
      object szValue = new object();
      string empty = string.Empty;
      this.m_lSendErrorCount = 0L;
      string str1;
      string str2;
      string str3;
      string message;
      string str4;
      string str5;
      string str6;
      try
      {
        this.GetLink().TablePOST_Send(this.m_hndPOST, ref nProcessed, ref nExceptions);
      }
      catch (NullReferenceException ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (AccessViolationException ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (FormatException ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        return;
      }
      catch (Exception ex)
      {
        str1 = ex.Data == null ? "" : ex.Data.ToString();
        str2 = ex.HelpLink == null ? "" : ex.HelpLink.ToString();
        str3 = ex.InnerException == null ? "" : ex.InnerException.ToString();
        message = ex.Message;
        str4 = ex.Source == null ? "" : ex.Source.ToString();
        str5 = ex.StackTrace == null ? "" : ex.StackTrace.ToString();
        str6 = ex.TargetSite == (MethodBase) null ? "" : ex.TargetSite.ToString();
        this.GetLink().TablePOST_Reset(this.m_hndPOST);
        this.m_lCounter = 0;
        return;
      }
      while (this.GetLink().TablePOST_GetNextResult(this.m_hndPOST, ref vunIDCreated, ref nExceptionError, ref szExceptionErrorMsg, ref szExceptionSentData) == 0)
      {
        if (Convert.ToInt32(nExceptionError) <= 0)
        {
          int int32 = Convert.ToInt32(vunIDCreated);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_1.sLinkName, empty, ref szValue);
          if (!string.IsNullOrEmpty(szValue.ToString()))
            PLContact.AddMapExtID1toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, this.m_ExternalID_2.sLinkName, empty, ref szValue);
          if (!string.IsNullOrEmpty(szValue.ToString()))
            PLContact.AddMapExtID2toPLID(szValue.ToString(), int32);
          this.GetLink().TablePOST_ResultDataField_String(this.m_hndPOST, "NameKey", empty, ref szValue);
          if (!string.IsNullOrEmpty(szValue.ToString()))
            PLContact.AddMapNameKeytoPLID(szValue.ToString(), int32);
        }
      }
      short int16_1 = Convert.ToInt16(nProcessed);
      short int16_2 = Convert.ToInt16(nExceptions);
      PLXMLData.m_lErrorCount += (long) int16_2;
      if (((int) int16_2 > 0 ? 1 : (this.m_lCounter != (int) int16_1 ? 1 : 0)) != 0)
      {
        this.GetLink().TablePOST_DumpExceptionsToLinkLog(this.m_hndPOST);
        PLContact plContact = this;
        plContact.m_lSendErrorCount = plContact.m_lSendErrorCount + 1L;
      }
      this.GetLink().TablePOST_Reset(this.m_hndPOST);
      this.m_lCounter = 0;
      this.GetLink().SubField_CloseHandle(this.m_hndSubFld);
      this.m_hndSubFld = 0U;
    }

    public class ContactMatter
    {
      public int MatterID;
      public int RollID;
      public bool DeleteContact;

      public ContactMatter(int mattID, int rollID, bool deleteContact)
      {
        this.MatterID = mattID;
        this.RollID = rollID;
        this.DeleteContact = deleteContact;
      }
    }

    public enum eCUSTOMTABLNKTYPE
    {
      MATTER,
      CLIENT,
      CONTACT,
      VENDOR,
    }
  }
}
