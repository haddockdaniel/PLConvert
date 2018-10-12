using ConvHelper;
using System;
using System.Collections.Generic;

namespace PLConvert
{
    public class PLAddress : StaticData
    {
        private List<string> AddrLines;

        private CPostItem m_Addr1;

        private CPostItem m_Addr2;

        private CPostItem m_City;

        private CPostItem m_Prov;

        private CPostItem m_Postal;

        private CPostItem m_Country;

        private CPostItem m_Attn;

        public string Addr1
        {
            get
            {
                return this.m_Addr1.sValue;
            }
            set
            {
                this.m_Addr1.SetValue(value);
            }
        }

        public string Addr2
        {
            get
            {
                return this.m_Addr2.sValue;
            }
            set
            {
                this.m_Addr2.SetValue(value);
            }
        }

        public string Attn
        {
            get
            {
                return this.m_Attn.sValue;
            }
            set
            {
                this.m_Attn.SetValue(value);
            }
        }

        public string City
        {
            get
            {
                return this.m_City.sValue;
            }
            set
            {
                this.m_City.SetValue(value);
            }
        }

        public string Country
        {
            get
            {
                return this.m_Country.sValue;
            }
            set
            {
                this.m_Country.SetValue(value);
            }
        }

        public string Postal
        {
            get
            {
                return this.m_Postal.sValue;
            }
            set
            {
                this.m_Postal.SetValue(value);
            }
        }

        public string Prov
        {
            get
            {
                return this.m_Prov.sValue;
            }
            set
            {
                this.m_Prov.SetValue(value);
            }
        }

        public PLAddress()
        {
        }

        public PLAddress(PLAddress.eAddType AT)
        {
            this.Initialize(AT);
        }

        public void AddFields(uint handle)
        {
            this.m_hndPOST = handle;
            this.AddRecord();
        }

        public void AddLine(string sLine)
        {
            if (!string.IsNullOrEmpty(sLine.Trim()))
            {
                this.AddrLines.Add(sLine);
            }
        }

        public override void AddRecord()
        {
            if (this.AddrLines.Count > 0)
            {
                this.ParseAddress();
            }
            foreach (CPostItem postItem in this.PostItems)
            {
                postItem.AddField(this.m_hndPOST);
            }
            this.AddrLines.Clear();
        }

        public override void Clear()
        {
            base.Clear();
            this.AddrLines.Clear();
        }

        public void GetExistingRecord(uint handle)
        {
            this.m_hndExisting = handle;
            this.GetExistingRecord();
        }

        public override void GetExistingRecord()
        {
            foreach (CPostItem postItem in this.PostItems)
            {
                postItem.GetField(this.m_hndExisting);
            }
        }

        public void GetRecord(uint handle)
        {
            this.m_hndGET = handle;
            this.GetRecord();
        }

        public override void GetRecord()
        {
            foreach (CPostItem postItem in this.PostItems)
            {
                postItem.GetField(this.m_hndGET);
            }
        }

        private void Initialize(PLAddress.eAddType AT)
        {
            CPostItem cPostItem;
            this.AddrLines = new List<string>();
            switch (AT)
            {
                case PLAddress.eAddType.CLIENT:
                    {
                        List<CPostItem> postItems = this.PostItems;
                        CPostItem cPostItem1 = new CPostItem(CPostItem.DataType.STRING, "ClientAddr1");
                        cPostItem = cPostItem1;
                        this.m_Addr1 = cPostItem1;
                        postItems.Add(cPostItem);
                        List<CPostItem> cPostItems = this.PostItems;
                        CPostItem cPostItem2 = new CPostItem(CPostItem.DataType.STRING, "ClientAddr2");
                        cPostItem = cPostItem2;
                        this.m_Addr2 = cPostItem2;
                        cPostItems.Add(cPostItem);
                        List<CPostItem> postItems1 = this.PostItems;
                        CPostItem cPostItem3 = new CPostItem(CPostItem.DataType.STRING, "ClientCity");
                        cPostItem = cPostItem3;
                        this.m_City = cPostItem3;
                        postItems1.Add(cPostItem);
                        List<CPostItem> cPostItems1 = this.PostItems;
                        CPostItem cPostItem4 = new CPostItem(CPostItem.DataType.STRING, "ClientProv");
                        cPostItem = cPostItem4;
                        this.m_Prov = cPostItem4;
                        cPostItems1.Add(cPostItem);
                        List<CPostItem> postItems2 = this.PostItems;
                        CPostItem cPostItem5 = new CPostItem(CPostItem.DataType.STRING, "ClientCode");
                        cPostItem = cPostItem5;
                        this.m_Postal = cPostItem5;
                        postItems2.Add(cPostItem);
                        List<CPostItem> cPostItems2 = this.PostItems;
                        CPostItem cPostItem6 = new CPostItem(CPostItem.DataType.STRING, "ClientCountry");
                        cPostItem = cPostItem6;
                        this.m_Country = cPostItem6;
                        cPostItems2.Add(cPostItem);
                        List<CPostItem> postItems3 = this.PostItems;
                        CPostItem cPostItem7 = new CPostItem(CPostItem.DataType.STRING, "ClientAttention");
                        cPostItem = cPostItem7;
                        this.m_Attn = cPostItem7;
                        postItems3.Add(cPostItem);
                        break;
                    }
                case PLAddress.eAddType.CLNT_onMAT:
                    {
                        List<CPostItem> cPostItems3 = this.PostItems;
                        CPostItem cPostItem8 = new CPostItem(CPostItem.DataType.STRING, "ClientAddr1");
                        cPostItem = cPostItem8;
                        this.m_Addr1 = cPostItem8;
                        cPostItems3.Add(cPostItem);
                        List<CPostItem> postItems4 = this.PostItems;
                        CPostItem cPostItem9 = new CPostItem(CPostItem.DataType.STRING, "ClientAddr2");
                        cPostItem = cPostItem9;
                        this.m_Addr2 = cPostItem9;
                        postItems4.Add(cPostItem);
                        List<CPostItem> cPostItems4 = this.PostItems;
                        CPostItem cPostItem10 = new CPostItem(CPostItem.DataType.STRING, "ClientCity");
                        cPostItem = cPostItem10;
                        this.m_City = cPostItem10;
                        cPostItems4.Add(cPostItem);
                        List<CPostItem> postItems5 = this.PostItems;
                        CPostItem cPostItem11 = new CPostItem(CPostItem.DataType.STRING, "ClientProv");
                        cPostItem = cPostItem11;
                        this.m_Prov = cPostItem11;
                        postItems5.Add(cPostItem);
                        List<CPostItem> cPostItems5 = this.PostItems;
                        CPostItem cPostItem12 = new CPostItem(CPostItem.DataType.STRING, "ClientCode");
                        cPostItem = cPostItem12;
                        this.m_Postal = cPostItem12;
                        cPostItems5.Add(cPostItem);
                        List<CPostItem> postItems6 = this.PostItems;
                        CPostItem cPostItem13 = new CPostItem(CPostItem.DataType.STRING, "ClientCountry");
                        cPostItem = cPostItem13;
                        this.m_Country = cPostItem13;
                        postItems6.Add(cPostItem);
                        List<CPostItem> cPostItems6 = this.PostItems;
                        CPostItem cPostItem14 = new CPostItem(CPostItem.DataType.STRING, "ClientAttention");
                        cPostItem = cPostItem14;
                        this.m_Attn = cPostItem14;
                        cPostItems6.Add(cPostItem);
                        break;
                    }
                case PLAddress.eAddType.MAT_BILL1:
                    {
                        List<CPostItem> postItems7 = this.PostItems;
                        CPostItem cPostItem15 = new CPostItem(CPostItem.DataType.STRING, "BillingAddr1");
                        cPostItem = cPostItem15;
                        this.m_Addr1 = cPostItem15;
                        postItems7.Add(cPostItem);
                        List<CPostItem> cPostItems7 = this.PostItems;
                        CPostItem cPostItem16 = new CPostItem(CPostItem.DataType.STRING, "BillingAddr2");
                        cPostItem = cPostItem16;
                        this.m_Addr2 = cPostItem16;
                        cPostItems7.Add(cPostItem);
                        List<CPostItem> postItems8 = this.PostItems;
                        CPostItem cPostItem17 = new CPostItem(CPostItem.DataType.STRING, "BillingCity");
                        cPostItem = cPostItem17;
                        this.m_City = cPostItem17;
                        postItems8.Add(cPostItem);
                        List<CPostItem> cPostItems8 = this.PostItems;
                        CPostItem cPostItem18 = new CPostItem(CPostItem.DataType.STRING, "BillingProv");
                        cPostItem = cPostItem18;
                        this.m_Prov = cPostItem18;
                        cPostItems8.Add(cPostItem);
                        List<CPostItem> postItems9 = this.PostItems;
                        CPostItem cPostItem19 = new CPostItem(CPostItem.DataType.STRING, "BillingCode");
                        cPostItem = cPostItem19;
                        this.m_Postal = cPostItem19;
                        postItems9.Add(cPostItem);
                        List<CPostItem> cPostItems9 = this.PostItems;
                        CPostItem cPostItem20 = new CPostItem(CPostItem.DataType.STRING, "BillingCountry");
                        cPostItem = cPostItem20;
                        this.m_Country = cPostItem20;
                        cPostItems9.Add(cPostItem);
                        List<CPostItem> postItems10 = this.PostItems;
                        CPostItem cPostItem21 = new CPostItem(CPostItem.DataType.STRING, "BillingAttention");
                        cPostItem = cPostItem21;
                        this.m_Attn = cPostItem21;
                        postItems10.Add(cPostItem);
                        break;
                    }
                case PLAddress.eAddType.MAT_BILL2:
                    {
                        List<CPostItem> cPostItems10 = this.PostItems;
                        CPostItem cPostItem22 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingAddr1");
                        cPostItem = cPostItem22;
                        this.m_Addr1 = cPostItem22;
                        cPostItems10.Add(cPostItem);
                        List<CPostItem> postItems11 = this.PostItems;
                        CPostItem cPostItem23 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingAddr2");
                        cPostItem = cPostItem23;
                        this.m_Addr2 = cPostItem23;
                        postItems11.Add(cPostItem);
                        List<CPostItem> cPostItems11 = this.PostItems;
                        CPostItem cPostItem24 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingCity");
                        cPostItem = cPostItem24;
                        this.m_City = cPostItem24;
                        cPostItems11.Add(cPostItem);
                        List<CPostItem> postItems12 = this.PostItems;
                        CPostItem cPostItem25 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingProv");
                        cPostItem = cPostItem25;
                        this.m_Prov = cPostItem25;
                        postItems12.Add(cPostItem);
                        List<CPostItem> cPostItems12 = this.PostItems;
                        CPostItem cPostItem26 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingCode");
                        cPostItem = cPostItem26;
                        this.m_Postal = cPostItem26;
                        cPostItems12.Add(cPostItem);
                        List<CPostItem> postItems13 = this.PostItems;
                        CPostItem cPostItem27 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingCountry");
                        cPostItem = cPostItem27;
                        this.m_Country = cPostItem27;
                        postItems13.Add(cPostItem);
                        List<CPostItem> cPostItems13 = this.PostItems;
                        CPostItem cPostItem28 = new CPostItem(CPostItem.DataType.STRING, "SecondBillingAttention");
                        cPostItem = cPostItem28;
                        this.m_Attn = cPostItem28;
                        cPostItems13.Add(cPostItem);
                        break;
                    }
                case PLAddress.eAddType.VENDOR:
                    {
                        List<CPostItem> postItems14 = this.PostItems;
                        CPostItem cPostItem29 = new CPostItem(CPostItem.DataType.STRING, "VendorAddrLine1");
                        cPostItem = cPostItem29;
                        this.m_Addr1 = cPostItem29;
                        postItems14.Add(cPostItem);
                        List<CPostItem> cPostItems14 = this.PostItems;
                        CPostItem cPostItem30 = new CPostItem(CPostItem.DataType.STRING, "VendorAddrLine2");
                        cPostItem = cPostItem30;
                        this.m_Addr2 = cPostItem30;
                        cPostItems14.Add(cPostItem);
                        List<CPostItem> postItems15 = this.PostItems;
                        CPostItem cPostItem31 = new CPostItem(CPostItem.DataType.STRING, "VendorAddrCity");
                        cPostItem = cPostItem31;
                        this.m_City = cPostItem31;
                        postItems15.Add(cPostItem);
                        List<CPostItem> cPostItems15 = this.PostItems;
                        CPostItem cPostItem32 = new CPostItem(CPostItem.DataType.STRING, "VendorAddrProv");
                        cPostItem = cPostItem32;
                        this.m_Prov = cPostItem32;
                        cPostItems15.Add(cPostItem);
                        List<CPostItem> postItems16 = this.PostItems;
                        CPostItem cPostItem33 = new CPostItem(CPostItem.DataType.STRING, "VendorAddrCode");
                        cPostItem = cPostItem33;
                        this.m_Postal = cPostItem33;
                        postItems16.Add(cPostItem);
                        List<CPostItem> cPostItems16 = this.PostItems;
                        CPostItem cPostItem34 = new CPostItem(CPostItem.DataType.STRING, "VendorCountry");
                        cPostItem = cPostItem34;
                        this.m_Country = cPostItem34;
                        cPostItems16.Add(cPostItem);
                        List<CPostItem> postItems17 = this.PostItems;
                        CPostItem cPostItem35 = new CPostItem(CPostItem.DataType.STRING, "VendorAttn");
                        cPostItem = cPostItem35;
                        this.m_Attn = cPostItem35;
                        postItems17.Add(cPostItem);
                        break;
                    }
                case PLAddress.eAddType.CONT_MainADDR:
                    {
                        List<CPostItem> cPostItems17 = this.PostItems;
                        CPostItem cPostItem36 = new CPostItem(CPostItem.DataType.STRING, "ContactMainAddr1");
                        cPostItem = cPostItem36;
                        this.m_Addr1 = cPostItem36;
                        cPostItems17.Add(cPostItem);
                        List<CPostItem> postItems18 = this.PostItems;
                        CPostItem cPostItem37 = new CPostItem(CPostItem.DataType.STRING, "ContactMainAddr2");
                        cPostItem = cPostItem37;
                        this.m_Addr2 = cPostItem37;
                        postItems18.Add(cPostItem);
                        List<CPostItem> cPostItems18 = this.PostItems;
                        CPostItem cPostItem38 = new CPostItem(CPostItem.DataType.STRING, "ContactMainCity");
                        cPostItem = cPostItem38;
                        this.m_City = cPostItem38;
                        cPostItems18.Add(cPostItem);
                        List<CPostItem> postItems19 = this.PostItems;
                        CPostItem cPostItem39 = new CPostItem(CPostItem.DataType.STRING, "ContactMainProv");
                        cPostItem = cPostItem39;
                        this.m_Prov = cPostItem39;
                        postItems19.Add(cPostItem);
                        List<CPostItem> cPostItems19 = this.PostItems;
                        CPostItem cPostItem40 = new CPostItem(CPostItem.DataType.STRING, "ContactMainCode");
                        cPostItem = cPostItem40;
                        this.m_Postal = cPostItem40;
                        cPostItems19.Add(cPostItem);
                        List<CPostItem> postItems20 = this.PostItems;
                        CPostItem cPostItem41 = new CPostItem(CPostItem.DataType.STRING, "ContactMainCountry");
                        cPostItem = cPostItem41;
                        this.m_Country = cPostItem41;
                        postItems20.Add(cPostItem);
                        List<CPostItem> cPostItems20 = this.PostItems;
                        CPostItem cPostItem42 = new CPostItem(CPostItem.DataType.STRING, "ContactMainAttention");
                        cPostItem = cPostItem42;
                        this.m_Attn = cPostItem42;
                        cPostItems20.Add(cPostItem);
                        break;
                    }
                case PLAddress.eAddType.CONT_OthADDR:
                    {
                        List<CPostItem> postItems21 = this.PostItems;
                        CPostItem cPostItem43 = new CPostItem(CPostItem.DataType.STRING, "ContactOtherAddr1");
                        cPostItem = cPostItem43;
                        this.m_Addr1 = cPostItem43;
                        postItems21.Add(cPostItem);
                        List<CPostItem> cPostItems21 = this.PostItems;
                        CPostItem cPostItem44 = new CPostItem(CPostItem.DataType.STRING, "ContactOtherAddr2");
                        cPostItem = cPostItem44;
                        this.m_Addr2 = cPostItem44;
                        cPostItems21.Add(cPostItem);
                        List<CPostItem> postItems22 = this.PostItems;
                        CPostItem cPostItem45 = new CPostItem(CPostItem.DataType.STRING, "ContactOtherCity");
                        cPostItem = cPostItem45;
                        this.m_City = cPostItem45;
                        postItems22.Add(cPostItem);
                        List<CPostItem> cPostItems22 = this.PostItems;
                        CPostItem cPostItem46 = new CPostItem(CPostItem.DataType.STRING, "ContactOtherProv");
                        cPostItem = cPostItem46;
                        this.m_Prov = cPostItem46;
                        cPostItems22.Add(cPostItem);
                        List<CPostItem> postItems23 = this.PostItems;
                        CPostItem cPostItem47 = new CPostItem(CPostItem.DataType.STRING, "ContactOtherCode");
                        cPostItem = cPostItem47;
                        this.m_Postal = cPostItem47;
                        postItems23.Add(cPostItem);
                        List<CPostItem> cPostItems23 = this.PostItems;
                        CPostItem cPostItem48 = new CPostItem(CPostItem.DataType.STRING, "ContactOtherCountry");
                        cPostItem = cPostItem48;
                        this.m_Country = cPostItem48;
                        cPostItems23.Add(cPostItem);
                        List<CPostItem> postItems24 = this.PostItems;
                        CPostItem cPostItem49 = new CPostItem(CPostItem.DataType.STRING, "ContactOtherAttention");
                        cPostItem = cPostItem49;
                        this.m_Attn = cPostItem49;
                        postItems24.Add(cPostItem);
                        break;
                    }
            }
        }

        protected override void Initialize()
        {
        }

        public override string MakeNN(bool bSetNickName)
        {
            throw new NotImplementedException();
        }

        public void ParseAddress()
        {
            char chr;
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            int i = 0;
            int j = 0;
            string empty = string.Empty;
            int length = 0;
            bool flag4 = false;
            bool flag5 = false;
            string[] strArrays = new string[] { "united states", " usa", "u.s.a.", "canada", "england", " uk", "australia", "new zealand", "nz" };
            string[] strArrays1 = strArrays;
            i = 0;
            while (i < this.AddrLines.Count)
            {
                empty = this.AddrLines[i].ToString().Trim();
                if (!(empty.ToLower().IndexOf("attention") >= 0 || empty.ToLower().IndexOf("attn") >= 0 || empty.ToLower().IndexOf("att'n") >= 0 || empty.ToLower().IndexOf("att") >= 0 ? false : empty.ToLower().IndexOf("atn") < 0))
                {
                    this.Attn = empty.Substring(empty.IndexOf(":") + 1).Trim();
                    this.AddrLines.RemoveAt(i);
                    break;
                }
                else if ((empty.ToLower().IndexOf("mr.") >= 0 || empty.ToLower().IndexOf("ms.") >= 0 || empty.ToLower().IndexOf("mrs.") >= 0 ? false : empty.ToLower().IndexOf("miss") < 0))
                {
                    i++;
                }
                else
                {
                    this.Attn = empty;
                    this.AddrLines.RemoveAt(i);
                    break;
                }
            }
            if (!this.AddrLines.Count.Equals(0))
            {
                for (i = 0; i < this.AddrLines.Count; i++)
                {
                    empty = this.AddrLines[i].ToString().Trim();
                    for (j = 0; j <= strArrays1.GetUpperBound(0); j++)
                    {
                        if (empty.ToLower().IndexOf(strArrays1[j]) >= 0)
                        {
                            this.Country = empty.Substring(empty.ToLower().IndexOf(strArrays1[j]), strArrays1[j].Length);
                            empty = empty.Remove(empty.ToLower().IndexOf(strArrays1[j]), strArrays1[j].Length);
                            this.AddrLines[i] = empty.Trim();
                        }
                    }
                }
                for (i = 0; i <= this.AddrLines.Count - 2; i++)
                {
                    if (string.IsNullOrEmpty(this.AddrLines[i].ToString().Trim()))
                    {
                        for (j = i + 1; j < this.AddrLines.Count; j++)
                        {
                            this.AddrLines[j - 1] = this.AddrLines[j];
                            this.AddrLines[j] = string.Empty;
                        }
                    }
                }
                while (string.IsNullOrEmpty(this.AddrLines[this.AddrLines.Count - 1].ToString().Trim()))
                {
                    this.AddrLines.RemoveAt(this.AddrLines.Count - 1);
                }
                if (!this.AddrLines.Count.Equals(0))
                {
                    flag4 = false;
                    empty = this.AddrLines[this.AddrLines.Count - 1].ToString().Trim();
                    length = empty.Length;
                    if (StringManip.IsNumeric(empty))
                    {
                        this.Postal = empty;
                        this.AddrLines[this.AddrLines.Count - 1] = "";
                        flag4 = true;
                    }
                    if (flag4)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = (length.Equals(10) || length.Equals(5) || length.Equals(7) || length.Equals(8) ? false : !length.Equals(4));
                    }
                    if (!flag)
                    {
                        empty = string.Concat(" ", empty);
                        length++;
                    }
                    if ((flag4 ? false : length > 10))
                    {
                        if (!empty[length - 1 - 10].Equals(' '))
                        {
                            flag3 = true;
                        }
                        else
                        {
                            chr = empty[length - 1 - 4];
                            flag3 = !chr.Equals('-');
                        }
                        if (!flag3)
                        {
                            this.Postal = empty.Substring(length - 1 - 10);
                            empty = empty.Substring(0, length - 1 - 10).Trim();
                            this.AddrLines[this.AddrLines.Count - 1] = empty;
                            flag4 = true;
                        }
                    }
                    if ((flag4 ? false : length > 8))
                    {
                        if (!empty[length - 1 - 8].Equals(' '))
                        {
                            flag2 = true;
                        }
                        else
                        {
                            chr = empty[length - 1 - 3];
                            flag2 = !chr.Equals(' ');
                        }
                        if (!flag2)
                        {
                            this.Postal = empty.Substring(length - 1 - 8);
                            empty = empty.Substring(0, length - 1 - 8).Trim();
                            this.AddrLines[this.AddrLines.Count - 1] = empty;
                            flag4 = true;
                        }
                    }
                    if ((flag4 ? false : length > 7))
                    {
                        if (!empty[length - 1 - 7].Equals(' '))
                        {
                            flag1 = true;
                        }
                        else
                        {
                            chr = empty[length - 1 - 3];
                            flag1 = !chr.Equals(' ');
                        }
                        if (!flag1)
                        {
                            this.Postal = empty.Substring(length - 1 - 7);
                            empty = empty.Substring(0, length - 1 - 7).Trim();
                            this.AddrLines[this.AddrLines.Count - 1] = empty;
                            flag4 = true;
                        }
                    }
                    if ((flag4 ? false : length > 5))
                    {
                        if ((!empty[length - 1 - 5].Equals(' ') ? false : StringManip.IsNumeric(empty.Substring(length - 5))))
                        {
                            this.Postal = empty.Substring(length - 1 - 5).Trim();
                            empty = empty.Substring(0, length - 1 - 5).Trim();
                            this.AddrLines[this.AddrLines.Count - 1] = empty;
                            flag4 = true;
                        }
                    }
                    if ((flag4 ? false : length > 4))
                    {
                        if ((!empty[length - 1 - 4].Equals(' ') ? false : StringManip.IsNumeric(empty.Substring(length - 4))))
                        {
                            this.Postal = empty.Substring(length - 1 - 4).Trim();
                            empty = (length != 5 ? empty.Substring(0, length - 1 - 4).Trim() : "");
                            this.AddrLines[this.AddrLines.Count - 1] = empty;
                            flag4 = true;
                        }
                    }
                    if (string.IsNullOrEmpty(this.AddrLines[this.AddrLines.Count - 1].ToString().Trim()))
                    {
                        this.AddrLines.RemoveAt(this.AddrLines.Count - 1);
                    }
                    if (!this.AddrLines.Count.Equals(0))
                    {
                        flag5 = false;
                        empty = this.AddrLines[this.AddrLines.Count - 1].ToString().Trim();
                        if (empty.IndexOf(", ") < 0)
                        {
                            this.Prov = empty;
                        }
                        else
                        {
                            this.Prov = empty.Substring(empty.IndexOf(", ") + 2).Trim();
                            this.City = empty.Substring(0, empty.IndexOf(", "));
                            flag5 = true;
                        }
                        this.AddrLines.RemoveAt(this.AddrLines.Count - 1);
                        if (!this.AddrLines.Count.Equals(0))
                        {
                            if ((flag5 ? false : this.AddrLines.Count > 1))
                            {
                                this.City = this.AddrLines[this.AddrLines.Count - 1].ToString().Trim();
                                this.AddrLines.RemoveAt(this.AddrLines.Count - 1);
                            }
                            switch (this.AddrLines.Count)
                            {
                                case 0:
                                    {
                                        break;
                                    }
                                case 1:
                                    {
                                        this.Addr1 = this.AddrLines[0].ToString().Trim();
                                        break;
                                    }
                                case 2:
                                    {
                                        this.Addr1 = this.AddrLines[0].ToString().Trim();
                                        this.Addr2 = this.AddrLines[1].ToString().Trim();
                                        break;
                                    }
                                case 3:
                                    {
                                        this.Addr1 = string.Concat(this.AddrLines[0].ToString().Trim(), " - ", this.AddrLines[1].ToString().Trim());
                                        this.Addr2 = this.AddrLines[2].ToString().Trim();
                                        break;
                                    }
                                case 4:
                                    {
                                        this.Addr1 = string.Concat(this.AddrLines[0].ToString().Trim(), " - ", this.AddrLines[1].ToString().Trim());
                                        this.Addr2 = string.Concat(this.AddrLines[2].ToString().Trim(), " - ", this.AddrLines[3].ToString().Trim());
                                        break;
                                    }
                                case 5:
                                    {
                                        this.Addr1 = string.Concat(this.AddrLines[0].ToString().Trim(), " - ", this.AddrLines[1].ToString().Trim());
                                        strArrays = new string[] { this.AddrLines[2].ToString().Trim(), " - ", this.AddrLines[3].ToString().Trim(), " - ", this.AddrLines[4].ToString().Trim() };
                                        this.Addr2 = string.Concat(strArrays);
                                        break;
                                    }
                                default:
                                    {
                                        this.Addr1 = string.Concat(this.AddrLines[0].ToString().Trim(), " - ", this.AddrLines[1].ToString().Trim());
                                        strArrays = new string[] { this.AddrLines[2].ToString().Trim(), " - ", this.AddrLines[3].ToString().Trim(), " - ", this.AddrLines[4].ToString().Trim() };
                                        this.Addr2 = string.Concat(strArrays);
                                        break;
                                    }
                            }
                            this.AddrLines.Clear();
                        }
                    }
                }
            }
        }

        private static void ReadTable()
        {
        }

        public override void Send()
        {
        }

        public void SetFieldValues(string address1, string address2, string city, string province, string postal, string country, string attention)
        {
            this.Addr1 = address1;
            this.Addr2 = address2;
            this.City = city;
            this.Prov = province;
            this.Postal = postal;
            this.Country = country;
            this.Attn = attention;
        }

        public enum eAddType : byte
        {
            NotSet,
            CLIENT,
            CLNT_onMAT,
            MAT_BILL1,
            MAT_BILL2,
            VENDOR,
            CONT_MainADDR,
            CONT_OthADDR
        }
    }
}