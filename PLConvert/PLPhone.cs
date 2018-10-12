// Decompiled with JetBrains decompiler
// Type: PLConvert.PLPhone
// Assembly: PLConvert, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC1F0050-AC43-49A6-B4BD-95C619E8FF70
// Assembly location: C:\Users\haddocdx\Desktop\Conv DLLs\PLConvert.dll

using System;
using System.Collections.Generic;

namespace PLConvert
{
  public class PLPhone : StaticData
  {
    private CPostItem m_BusEMail;
    private CPostItem m_BusFax;
    private CPostItem m_BusPhone;
    private CPostItem m_OtherPhone;
    private CPostItem m_CellPhone;
    private CPostItem m_HomeEMail;
    private CPostItem m_HomeFax;
    private CPostItem m_HomePhone;
    private CPostItem m_WebPage;
    private CPostItem m_Pager;

    public string BusEMail
    {
      get
      {
        return this.m_BusEMail.sValue;
      }
      set
      {
        this.m_BusEMail.SetValue(value);
      }
    }

    public string BusFax
    {
      get
      {
        return this.m_BusFax.sValue;
      }
      set
      {
        this.m_BusFax.SetValue(value);
      }
    }

    public string BusPhone
    {
      get
      {
        return this.m_BusPhone.sValue;
      }
      set
      {
        this.m_BusPhone.SetValue(value);
      }
    }

    public string CellPhone
    {
      get
      {
        return this.m_CellPhone.sValue;
      }
      set
      {
        this.m_CellPhone.SetValue(value);
      }
    }

    public string HomeEMail
    {
      get
      {
        return this.m_HomeEMail.sValue;
      }
      set
      {
        this.m_HomeEMail.SetValue(value);
      }
    }

    public string HomeFax
    {
      get
      {
        return this.m_HomeFax.sValue;
      }
      set
      {
        this.m_HomeFax.SetValue(value);
      }
    }

    public string HomePhone
    {
      get
      {
        return this.m_HomePhone.sValue;
      }
      set
      {
        this.m_HomePhone.SetValue(value);
      }
    }

    public string OtherPhone
    {
      get
      {
        return this.m_OtherPhone.sValue;
      }
      set
      {
        this.m_OtherPhone.SetValue(value);
      }
    }

    public string Pager
    {
      get
      {
        return this.m_Pager.sValue;
      }
      set
      {
        this.m_Pager.SetValue(value);
      }
    }

    public string WebPage
    {
      get
      {
        return this.m_WebPage.sValue;
      }
      set
      {
        this.m_WebPage.SetValue(value);
      }
    }

    public PLPhone()
    {
    }

    public PLPhone(PLPhone.ePhoneType PT)
    {
      switch (PT)
      {
        case PLPhone.ePhoneType.CLIENT:
          List<CPostItem> postItems1 = this.PostItems;
          CPostItem cpostItem1 = new CPostItem(CPostItem.DataType.STRING, "ClientInternetAddr");
          CPostItem cpostItem2 = cpostItem1;
          this.m_BusEMail = cpostItem1;
          postItems1.Add(cpostItem2);
          List<CPostItem> postItems2 = this.PostItems;
          CPostItem cpostItem3 = new CPostItem(CPostItem.DataType.STRING, "ClientFaxNum");
          CPostItem cpostItem4 = cpostItem3;
          this.m_BusFax = cpostItem3;
          postItems2.Add(cpostItem4);
          List<CPostItem> postItems3 = this.PostItems;
          CPostItem cpostItem5 = new CPostItem(CPostItem.DataType.STRING, "ClientBusNum");
          CPostItem cpostItem6 = cpostItem5;
          this.m_BusPhone = cpostItem5;
          postItems3.Add(cpostItem6);
          List<CPostItem> postItems4 = this.PostItems;
          CPostItem cpostItem7 = new CPostItem(CPostItem.DataType.STRING, "ClientOtherPhone");
          CPostItem cpostItem8 = cpostItem7;
          this.m_OtherPhone = cpostItem7;
          postItems4.Add(cpostItem8);
          List<CPostItem> postItems5 = this.PostItems;
          CPostItem cpostItem9 = new CPostItem(CPostItem.DataType.STRING, "ClientCellNum");
          CPostItem cpostItem10 = cpostItem9;
          this.m_CellPhone = cpostItem9;
          postItems5.Add(cpostItem10);
          List<CPostItem> postItems6 = this.PostItems;
          CPostItem cpostItem11 = new CPostItem(CPostItem.DataType.STRING, "ClientEmailAddress2");
          CPostItem cpostItem12 = cpostItem11;
          this.m_HomeEMail = cpostItem11;
          postItems6.Add(cpostItem12);
          List<CPostItem> postItems7 = this.PostItems;
          CPostItem cpostItem13 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem14 = cpostItem13;
          this.m_HomeFax = cpostItem13;
          postItems7.Add(cpostItem14);
          List<CPostItem> postItems8 = this.PostItems;
          CPostItem cpostItem15 = new CPostItem(CPostItem.DataType.STRING, "ClientHomeNum");
          CPostItem cpostItem16 = cpostItem15;
          this.m_HomePhone = cpostItem15;
          postItems8.Add(cpostItem16);
          List<CPostItem> postItems9 = this.PostItems;
          CPostItem cpostItem17 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem18 = cpostItem17;
          this.m_WebPage = cpostItem17;
          postItems9.Add(cpostItem18);
          List<CPostItem> postItems10 = this.PostItems;
          CPostItem cpostItem19 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem20 = cpostItem19;
          this.m_Pager = cpostItem19;
          postItems10.Add(cpostItem20);
          break;
        case PLPhone.ePhoneType.MatCLIENT:
          List<CPostItem> postItems11 = this.PostItems;
          CPostItem cpostItem21 = new CPostItem(CPostItem.DataType.STRING, "ClientInternetAddr");
          CPostItem cpostItem22 = cpostItem21;
          this.m_BusEMail = cpostItem21;
          postItems11.Add(cpostItem22);
          List<CPostItem> postItems12 = this.PostItems;
          CPostItem cpostItem23 = new CPostItem(CPostItem.DataType.STRING, "ClientFaxNum");
          CPostItem cpostItem24 = cpostItem23;
          this.m_BusFax = cpostItem23;
          postItems12.Add(cpostItem24);
          List<CPostItem> postItems13 = this.PostItems;
          CPostItem cpostItem25 = new CPostItem(CPostItem.DataType.STRING, "ClientBusNum");
          CPostItem cpostItem26 = cpostItem25;
          this.m_BusPhone = cpostItem25;
          postItems13.Add(cpostItem26);
          List<CPostItem> postItems14 = this.PostItems;
          CPostItem cpostItem27 = new CPostItem(CPostItem.DataType.STRING, "ClientOtherNum");
          CPostItem cpostItem28 = cpostItem27;
          this.m_OtherPhone = cpostItem27;
          postItems14.Add(cpostItem28);
          List<CPostItem> postItems15 = this.PostItems;
          CPostItem cpostItem29 = new CPostItem(CPostItem.DataType.STRING, "ClientCellNum");
          CPostItem cpostItem30 = cpostItem29;
          this.m_CellPhone = cpostItem29;
          postItems15.Add(cpostItem30);
          List<CPostItem> postItems16 = this.PostItems;
          CPostItem cpostItem31 = new CPostItem(CPostItem.DataType.STRING, "ClientEmailAddress2");
          CPostItem cpostItem32 = cpostItem31;
          this.m_HomeEMail = cpostItem31;
          postItems16.Add(cpostItem32);
          List<CPostItem> postItems17 = this.PostItems;
          CPostItem cpostItem33 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem34 = cpostItem33;
          this.m_HomeFax = cpostItem33;
          postItems17.Add(cpostItem34);
          List<CPostItem> postItems18 = this.PostItems;
          CPostItem cpostItem35 = new CPostItem(CPostItem.DataType.STRING, "ClientHomeNum");
          CPostItem cpostItem36 = cpostItem35;
          this.m_HomePhone = cpostItem35;
          postItems18.Add(cpostItem36);
          List<CPostItem> postItems19 = this.PostItems;
          CPostItem cpostItem37 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem38 = cpostItem37;
          this.m_WebPage = cpostItem37;
          postItems19.Add(cpostItem38);
          List<CPostItem> postItems20 = this.PostItems;
          CPostItem cpostItem39 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem40 = cpostItem39;
          this.m_Pager = cpostItem39;
          postItems20.Add(cpostItem40);
          break;
        case PLPhone.ePhoneType.MAT_BILL1:
          List<CPostItem> postItems21 = this.PostItems;
          CPostItem cpostItem41 = new CPostItem(CPostItem.DataType.STRING, "BillingInternetAddr");
          CPostItem cpostItem42 = cpostItem41;
          this.m_BusEMail = cpostItem41;
          postItems21.Add(cpostItem42);
          List<CPostItem> postItems22 = this.PostItems;
          CPostItem cpostItem43 = new CPostItem(CPostItem.DataType.STRING, "BillingFaxNum");
          CPostItem cpostItem44 = cpostItem43;
          this.m_BusFax = cpostItem43;
          postItems22.Add(cpostItem44);
          List<CPostItem> postItems23 = this.PostItems;
          CPostItem cpostItem45 = new CPostItem(CPostItem.DataType.STRING, "BillingBusNum");
          CPostItem cpostItem46 = cpostItem45;
          this.m_BusPhone = cpostItem45;
          postItems23.Add(cpostItem46);
          List<CPostItem> postItems24 = this.PostItems;
          CPostItem cpostItem47 = new CPostItem(CPostItem.DataType.STRING, "BillingOtherNum");
          CPostItem cpostItem48 = cpostItem47;
          this.m_OtherPhone = cpostItem47;
          postItems24.Add(cpostItem48);
          List<CPostItem> postItems25 = this.PostItems;
          CPostItem cpostItem49 = new CPostItem(CPostItem.DataType.STRING, "BillingCellNum");
          CPostItem cpostItem50 = cpostItem49;
          this.m_CellPhone = cpostItem49;
          postItems25.Add(cpostItem50);
          List<CPostItem> postItems26 = this.PostItems;
          CPostItem cpostItem51 = new CPostItem(CPostItem.DataType.STRING, "BillingEmailAddress2");
          CPostItem cpostItem52 = cpostItem51;
          this.m_HomeEMail = cpostItem51;
          postItems26.Add(cpostItem52);
          List<CPostItem> postItems27 = this.PostItems;
          CPostItem cpostItem53 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem54 = cpostItem53;
          this.m_HomeFax = cpostItem53;
          postItems27.Add(cpostItem54);
          List<CPostItem> postItems28 = this.PostItems;
          CPostItem cpostItem55 = new CPostItem(CPostItem.DataType.STRING, "BillingHomeNum");
          CPostItem cpostItem56 = cpostItem55;
          this.m_HomePhone = cpostItem55;
          postItems28.Add(cpostItem56);
          List<CPostItem> postItems29 = this.PostItems;
          CPostItem cpostItem57 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem58 = cpostItem57;
          this.m_WebPage = cpostItem57;
          postItems29.Add(cpostItem58);
          List<CPostItem> postItems30 = this.PostItems;
          CPostItem cpostItem59 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem60 = cpostItem59;
          this.m_Pager = cpostItem59;
          postItems30.Add(cpostItem60);
          break;
        case PLPhone.ePhoneType.MAT_BILL2:
          List<CPostItem> postItems31 = this.PostItems;
          CPostItem cpostItem61 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingInternetAddr");
          CPostItem cpostItem62 = cpostItem61;
          this.m_BusEMail = cpostItem61;
          postItems31.Add(cpostItem62);
          List<CPostItem> postItems32 = this.PostItems;
          CPostItem cpostItem63 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingFaxNum");
          CPostItem cpostItem64 = cpostItem63;
          this.m_BusFax = cpostItem63;
          postItems32.Add(cpostItem64);
          List<CPostItem> postItems33 = this.PostItems;
          CPostItem cpostItem65 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingBusNum");
          CPostItem cpostItem66 = cpostItem65;
          this.m_BusPhone = cpostItem65;
          postItems33.Add(cpostItem66);
          List<CPostItem> postItems34 = this.PostItems;
          CPostItem cpostItem67 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingOtherNum");
          CPostItem cpostItem68 = cpostItem67;
          this.m_OtherPhone = cpostItem67;
          postItems34.Add(cpostItem68);
          List<CPostItem> postItems35 = this.PostItems;
          CPostItem cpostItem69 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingCellNum");
          CPostItem cpostItem70 = cpostItem69;
          this.m_CellPhone = cpostItem69;
          postItems35.Add(cpostItem70);
          List<CPostItem> postItems36 = this.PostItems;
          CPostItem cpostItem71 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingEmailAddress2");
          CPostItem cpostItem72 = cpostItem71;
          this.m_HomeEMail = cpostItem71;
          postItems36.Add(cpostItem72);
          List<CPostItem> postItems37 = this.PostItems;
          CPostItem cpostItem73 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem74 = cpostItem73;
          this.m_HomeFax = cpostItem73;
          postItems37.Add(cpostItem74);
          List<CPostItem> postItems38 = this.PostItems;
          CPostItem cpostItem75 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingHomeNum");
          CPostItem cpostItem76 = cpostItem75;
          this.m_HomePhone = cpostItem75;
          postItems38.Add(cpostItem76);
          List<CPostItem> postItems39 = this.PostItems;
          CPostItem cpostItem77 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem78 = cpostItem77;
          this.m_WebPage = cpostItem77;
          postItems39.Add(cpostItem78);
          List<CPostItem> postItems40 = this.PostItems;
          CPostItem cpostItem79 = new CPostItem(CPostItem.DataType.STRING, string.Empty);
          CPostItem cpostItem80 = cpostItem79;
          this.m_Pager = cpostItem79;
          postItems40.Add(cpostItem80);
          break;
        case PLPhone.ePhoneType.CONTACT:
          List<CPostItem> postItems41 = this.PostItems;
          CPostItem cpostItem81 = new CPostItem(CPostItem.DataType.STRING, "ContactBusEmail");
          CPostItem cpostItem82 = cpostItem81;
          this.m_BusEMail = cpostItem81;
          postItems41.Add(cpostItem82);
          List<CPostItem> postItems42 = this.PostItems;
          CPostItem cpostItem83 = new CPostItem(CPostItem.DataType.STRING, "ContactBusFaxNum");
          CPostItem cpostItem84 = cpostItem83;
          this.m_BusFax = cpostItem83;
          postItems42.Add(cpostItem84);
          List<CPostItem> postItems43 = this.PostItems;
          CPostItem cpostItem85 = new CPostItem(CPostItem.DataType.STRING, "ContactBusNum");
          CPostItem cpostItem86 = cpostItem85;
          this.m_BusPhone = cpostItem85;
          postItems43.Add(cpostItem86);
          List<CPostItem> postItems44 = this.PostItems;
          CPostItem cpostItem87 = new CPostItem(CPostItem.DataType.STRING, "ContactCarNum");
          CPostItem cpostItem88 = cpostItem87;
          this.m_OtherPhone = cpostItem87;
          postItems44.Add(cpostItem88);
          List<CPostItem> postItems45 = this.PostItems;
          CPostItem cpostItem89 = new CPostItem(CPostItem.DataType.STRING, "ContactCellNum");
          CPostItem cpostItem90 = cpostItem89;
          this.m_CellPhone = cpostItem89;
          postItems45.Add(cpostItem90);
          List<CPostItem> postItems46 = this.PostItems;
          CPostItem cpostItem91 = new CPostItem(CPostItem.DataType.STRING, "ContactHomeEmail");
          CPostItem cpostItem92 = cpostItem91;
          this.m_HomeEMail = cpostItem91;
          postItems46.Add(cpostItem92);
          List<CPostItem> postItems47 = this.PostItems;
          CPostItem cpostItem93 = new CPostItem(CPostItem.DataType.STRING, "ContactHomeFaxNum");
          CPostItem cpostItem94 = cpostItem93;
          this.m_HomeFax = cpostItem93;
          postItems47.Add(cpostItem94);
          List<CPostItem> postItems48 = this.PostItems;
          CPostItem cpostItem95 = new CPostItem(CPostItem.DataType.STRING, "ContactHomeNum");
          CPostItem cpostItem96 = cpostItem95;
          this.m_HomePhone = cpostItem95;
          postItems48.Add(cpostItem96);
          List<CPostItem> postItems49 = this.PostItems;
          CPostItem cpostItem97 = new CPostItem(CPostItem.DataType.STRING, "ContactInternetAddr");
          CPostItem cpostItem98 = cpostItem97;
          this.m_WebPage = cpostItem97;
          postItems49.Add(cpostItem98);
          List<CPostItem> postItems50 = this.PostItems;
          CPostItem cpostItem99 = new CPostItem(CPostItem.DataType.STRING, "ContactPager");
          CPostItem cpostItem100 = cpostItem99;
          this.m_Pager = cpostItem99;
          postItems50.Add(cpostItem100);
          break;
        case PLPhone.ePhoneType.VENDOR:
          List<CPostItem> postItems51 = this.PostItems;
          CPostItem cpostItem101 = new CPostItem(CPostItem.DataType.STRING, "VendorEMail");
          CPostItem cpostItem102 = cpostItem101;
          this.m_BusEMail = cpostItem101;
          postItems51.Add(cpostItem102);
          List<CPostItem> postItems52 = this.PostItems;
          CPostItem cpostItem103 = new CPostItem(CPostItem.DataType.STRING, "VendorPhoneFax");
          CPostItem cpostItem104 = cpostItem103;
          this.m_BusFax = cpostItem103;
          postItems52.Add(cpostItem104);
          List<CPostItem> postItems53 = this.PostItems;
          CPostItem cpostItem105 = new CPostItem(CPostItem.DataType.STRING, "VendorPhoneBus");
          CPostItem cpostItem106 = cpostItem105;
          this.m_BusPhone = cpostItem105;
          postItems53.Add(cpostItem106);
          List<CPostItem> postItems54 = this.PostItems;
          CPostItem cpostItem107 = new CPostItem(CPostItem.DataType.STRING, "VendorPhoneOther");
          CPostItem cpostItem108 = cpostItem107;
          this.m_OtherPhone = cpostItem107;
          postItems54.Add(cpostItem108);
          List<CPostItem> postItems55 = this.PostItems;
          CPostItem cpostItem109 = new CPostItem(CPostItem.DataType.STRING, "VendorPhoneCell");
          CPostItem cpostItem110 = cpostItem109;
          this.m_CellPhone = cpostItem109;
          postItems55.Add(cpostItem110);
          List<CPostItem> postItems56 = this.PostItems;
          CPostItem cpostItem111 = new CPostItem(CPostItem.DataType.STRING, "VendorEMailHome");
          CPostItem cpostItem112 = cpostItem111;
          this.m_HomeEMail = cpostItem111;
          postItems56.Add(cpostItem112);
          List<CPostItem> postItems57 = this.PostItems;
          CPostItem cpostItem113 = new CPostItem(CPostItem.DataType.STRING, "VendorPhoneHome");
          CPostItem cpostItem114 = cpostItem113;
          this.m_HomePhone = cpostItem113;
          postItems57.Add(cpostItem114);
          List<CPostItem> postItems58 = this.PostItems;
          CPostItem cpostItem115 = new CPostItem(CPostItem.DataType.STRING, "VendorWebPage");
          CPostItem cpostItem116 = cpostItem115;
          this.m_WebPage = cpostItem115;
          postItems58.Add(cpostItem116);
          List<CPostItem> postItems59 = this.PostItems;
          CPostItem cpostItem117 = new CPostItem(CPostItem.DataType.STRING, "homefaxisnotused");
          CPostItem cpostItem118 = cpostItem117;
          this.m_HomeFax = cpostItem117;
          postItems59.Add(cpostItem118);
          List<CPostItem> postItems60 = this.PostItems;
          CPostItem cpostItem119 = new CPostItem(CPostItem.DataType.STRING, "Pagerisnotused");
          CPostItem cpostItem120 = cpostItem119;
          this.m_Pager = cpostItem119;
          postItems60.Add(cpostItem120);
          break;
      }
    }

    public void AddFields(uint handle)
    {
      this.m_hndPOST = handle;
      this.AddRecord();
    }

    public override void AddRecord()
    {
      foreach (CPostItem postItem in this.PostItems)
        postItem.AddField(this.m_hndPOST);
    }

    public override void Clear()
    {
      base.Clear();
    }

    public void GetExistingRecord(uint handle)
    {
      this.m_hndExisting = handle;
      this.GetExistingRecord();
    }

    public override void GetExistingRecord()
    {
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndExisting);
    }

    public void GetRecord(uint handle)
    {
      this.m_hndGET = handle;
      this.GetRecord();
    }

    public override void GetRecord()
    {
      foreach (CPostItem postItem in this.PostItems)
        postItem.GetField(this.m_hndGET);
    }

    protected override void Initialize()
    {
    }

    public override string MakeNN(bool bSetNickName)
    {
      throw new NotImplementedException();
    }

    private static void ReadTable()
    {
    }

    public override void Send()
    {
    }

    public void SetFieldValues(string business_phone, string business_fax, string business_email, string home_phone, string home_fax, string home_email, string cell_phone, string other_phone, string pager, string webpage)
    {
      this.BusPhone = business_phone;
      this.BusFax = business_fax;
      this.BusEMail = business_email;
      this.HomePhone = home_phone;
      this.HomeFax = home_fax;
      this.HomeEMail = home_email;
      this.CellPhone = cell_phone;
      this.OtherPhone = other_phone;
      this.Pager = pager;
      this.WebPage = webpage;
    }

    public enum ePhoneType : byte
    {
      CLIENT = 1,
      MatCLIENT = 2,
      MAT_BILL1 = 3,
      MAT_BILL2 = 4,
      CONTACT = 5,
      VENDOR = 6,
    }
  }
}
