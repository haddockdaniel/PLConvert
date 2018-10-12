using PLXMLLnkLib;
using System;
using System.Collections.Generic;

namespace PLConvert
{
    public class PLTimeEntry : TransactionData
    {
        private CPostItem m_InvoiceID;

        private CPostItem m_MatterID;

        private CPostItem m_HoldFlag;

        private CPostItem m_ActivityID;

        private CPostItem m_TaskID;

        private CPostItem m_LawyerID;

        private CPostItem m_UserID;

        private CPostItem m_Seconds;

        private CPostItem m_RateInternal;

        private CPostItem m_RateBilling;

        private CPostItem m_TaxStatus;

        private CPostItem m_Amount;

        private CPostItem m_Explanation;

        private CPostItem m_Date;

        private CPostItem m_DateEntered;

        private CPostItem m_InvDate;

        private CPostItem m_InvNumber;

        private CPostItem m_EntryType;

        public static bool m_bAllowEntOnClosedMtr;


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

        public int DateEntered
        {
            get
            {
                return this.m_DateEntered.nValue;
            }
            set
            {
                this.m_DateEntered.SetValue(value);
            }
        }

        public PLTimeEntry.eFeeEntryType EntryType
        {
            get
            {
                return (PLTimeEntry.eFeeEntryType)this.m_EntryType.nValue;
            }
            set
            {
                this.m_EntryType.SetValue((int)value);
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

        public int ExplCodeID
        {
            get
            {
                return this.m_ActivityID.nValue;
            }
            set
            {
                this.m_ActivityID.SetValue(value);
            }
        }

        public string ExplCodeNN
        {
            get
            {
                return PLExpCode.GetNNFromID(this.m_ActivityID.nValue);
            }
            set
            {
                this.m_ActivityID.SetValue(PLExpCode.GetIDFromNN(value));
            }
        }

        public PLTimeEntry.eFeeHoldFlag HoldFlag
        {
            get
            {
                return (PLTimeEntry.eFeeHoldFlag)this.m_HoldFlag.nValue;
            }
            set
            {
                this.m_HoldFlag.SetValue(Convert.ToInt32(value));
            }
        }

        public double Hours
        {
            get
            {
                double mSeconds = (double)((double)(this.m_Seconds.nValue / new decimal(3600)));
                return mSeconds;
            }
            set
            {
                this.m_Seconds.SetValue((int)(value * 3600));
            }
        }

        public int InvDate
        {
            get
            {
                return this.m_InvDate.nValue;
            }
            set
            {
                this.m_InvDate.SetValue(value);
            }
        }

        public int InvNumber
        {
            get
            {
                return this.m_InvNumber.nValue;
            }
            set
            {
                this.m_InvNumber.SetValue(value);
            }
        }

        public int InvoiceID
        {
            get
            {
                return this.m_InvoiceID.nValue;
            }
            set
            {
                this.m_InvoiceID.SetValue(value);
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

        public double Rate
        {
            get
            {
                return this.m_RateBilling.dValue;
            }
            set
            {
                this.m_RateInternal.SetValue(value);
                this.m_RateBilling.SetValue(value);
            }
        }

        public int Seconds
        {
            get
            {
                return this.m_Seconds.nValue;
            }
            set
            {
                this.m_Seconds.SetValue(value);
            }
        }

        public int TaskID
        {
            get
            {
                return this.m_TaskID.nValue;
            }
            set
            {
                this.m_TaskID.SetValue(value);
            }
        }

        public string TaskNN
        {
            get
            {
                return PLTask.GetNNFromID(this.m_TaskID.nValue);
            }
            set
            {
                this.m_TaskID.SetValue(PLTask.GetIDFromNN(value));
            }
        }

        public int TaxStatus
        {
            get
            {
                return this.m_TaxStatus.nValue;
            }
            set
            {
                this.m_TaxStatus.SetValue(value);
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

        public string UserNN
        {
            get
            {
                return PLUser.GetNNFromID(this.m_UserID.nValue);
            }
            set
            {
                this.m_UserID.SetValue(PLUser.GetIDFromNN(value));
            }
        }

        static PLTimeEntry()
        {
            PLTimeEntry.m_bAllowEntOnClosedMtr = false;
        }

        public PLTimeEntry()
        {
            this.Initialize();
        }


        public override void AddRecord()
        {
            if (this.m_hndPOST == 0)
            {
                this.m_hndPOST = base.GetLink().TablePOST_CreateHandle(this.m_sTableName, 0);
                base.GetLink().TablePOST_AddDirective(this.m_hndPOST, "allowentonclosedmtr", (PLTimeEntry.m_bAllowEntOnClosedMtr ? "1" : "0"));
            }
            if ((!this.m_LawyerID.m_bIsSet ? true : this.m_LawyerID.nValue == 0))
            {
                this.LawyerNN = "IT~";
            }
            this.m_LawyerID.AddField(this.m_hndPOST);
            foreach (CPostItem postItem in this.PostItems)
            {
                postItem.AddField(this.m_hndPOST);
            }
            base.GetLink().TablePOST_AddRecord(this.m_hndPOST);
            PLTimeEntry mLCounter = this;
            mLCounter.m_lCounter = mLCounter.m_lCounter + 1;
            if (this.m_lCounter >= PLXMLData.m_nMaxCounter)
            {
                this.Send();
            }
        }

        protected override bool GetAllowEntOnClosedMtr()
        {
            return PLTimeEntry.m_bAllowEntOnClosedMtr;
        }

        protected override void Initialize()
        {
            this.m_sTableName = "TimeEnt";
            List<CPostItem> postItems = this.PostItems;
            CPostItem cPostItem = new CPostItem(CPostItem.DataType.LONG, "TimeEntStatus");
            CPostItem cPostItem1 = cPostItem;
            this.m_Status = cPostItem;
            postItems.Add(cPostItem1);
            List<CPostItem> cPostItems = this.PostItems;
            CPostItem cPostItem2 = new CPostItem(CPostItem.DataType.LONG, "TimeEntID");
            cPostItem1 = cPostItem2;
            this.m_ID = cPostItem2;
            cPostItems.Add(cPostItem1);
            List<CPostItem> postItems1 = this.PostItems;
            CPostItem cPostItem3 = new CPostItem(CPostItem.DataType.LONG, "InvoiceID");
            cPostItem1 = cPostItem3;
            this.m_InvoiceID = cPostItem3;
            postItems1.Add(cPostItem1);
            List<CPostItem> cPostItems1 = this.PostItems;
            CPostItem cPostItem4 = new CPostItem(CPostItem.DataType.LONG, "MatterID");
            cPostItem1 = cPostItem4;
            this.m_MatterID = cPostItem4;
            cPostItems1.Add(cPostItem1);
            List<CPostItem> postItems2 = this.PostItems;
            CPostItem cPostItem5 = new CPostItem(CPostItem.DataType.LONG, "TimeEntHoldFlag");
            cPostItem1 = cPostItem5;
            this.m_HoldFlag = cPostItem5;
            postItems2.Add(cPostItem1);
            List<CPostItem> cPostItems2 = this.PostItems;
            CPostItem cPostItem6 = new CPostItem(CPostItem.DataType.LONG, "ActivityID");
            cPostItem1 = cPostItem6;
            this.m_ActivityID = cPostItem6;
            cPostItems2.Add(cPostItem1);
            List<CPostItem> postItems3 = this.PostItems;
            CPostItem cPostItem7 = new CPostItem(CPostItem.DataType.LONG, "TaskID");
            cPostItem1 = cPostItem7;
            this.m_TaskID = cPostItem7;
            postItems3.Add(cPostItem1);
            List<CPostItem> cPostItems3 = this.PostItems;
            CPostItem cPostItem8 = new CPostItem(CPostItem.DataType.LONG, "LawyerID");
            cPostItem1 = cPostItem8;
            this.m_LawyerID = cPostItem8;
            cPostItems3.Add(cPostItem1);
            List<CPostItem> postItems4 = this.PostItems;
            CPostItem cPostItem9 = new CPostItem(CPostItem.DataType.LONG, "SecUserID");
            cPostItem1 = cPostItem9;
            this.m_UserID = cPostItem9;
            postItems4.Add(cPostItem1);
            List<CPostItem> cPostItems4 = this.PostItems;
            CPostItem cPostItem10 = new CPostItem(CPostItem.DataType.LONG, "TimeEntSecondsIncurred");
            cPostItem1 = cPostItem10;
            this.m_Seconds = cPostItem10;
            cPostItems4.Add(cPostItem1);
            List<CPostItem> postItems5 = this.PostItems;
            CPostItem cPostItem11 = new CPostItem(CPostItem.DataType.DOUBLE, "TimeEntRateActual");
            cPostItem1 = cPostItem11;
            this.m_RateInternal = cPostItem11;
            postItems5.Add(cPostItem1);
            List<CPostItem> cPostItems5 = this.PostItems;
            CPostItem cPostItem12 = new CPostItem(CPostItem.DataType.DOUBLE, "TimeEntRateBilled");
            cPostItem1 = cPostItem12;
            this.m_RateBilling = cPostItem12;
            cPostItems5.Add(cPostItem1);
            List<CPostItem> postItems6 = this.PostItems;
            CPostItem cPostItem13 = new CPostItem(CPostItem.DataType.DOUBLE, "TimeEntAmount");
            cPostItem1 = cPostItem13;
            this.m_Amount = cPostItem13;
            postItems6.Add(cPostItem1);
            List<CPostItem> cPostItems6 = this.PostItems;
            CPostItem cPostItem14 = new CPostItem(CPostItem.DataType.STRING, "TimeEntExplanation");
            cPostItem1 = cPostItem14;
            this.m_Explanation = cPostItem14;
            cPostItems6.Add(cPostItem1);
            List<CPostItem> postItems7 = this.PostItems;
            CPostItem cPostItem15 = new CPostItem(CPostItem.DataType.LONG, "TimeEntDate");
            cPostItem1 = cPostItem15;
            this.m_Date = cPostItem15;
            postItems7.Add(cPostItem1);
            List<CPostItem> cPostItems7 = this.PostItems;
            CPostItem cPostItem16 = new CPostItem(CPostItem.DataType.LONG, "TimeEntDateEntered");
            cPostItem1 = cPostItem16;
            this.m_DateEntered = cPostItem16;
            cPostItems7.Add(cPostItem1);
            List<CPostItem> postItems8 = this.PostItems;
            CPostItem cPostItem17 = new CPostItem(CPostItem.DataType.LONG, "InvoiceDate");
            cPostItem1 = cPostItem17;
            this.m_InvDate = cPostItem17;
            postItems8.Add(cPostItem1);
            List<CPostItem> cPostItems8 = this.PostItems;
            CPostItem cPostItem18 = new CPostItem(CPostItem.DataType.LONG, "InvoiceNumber");
            cPostItem1 = cPostItem18;
            this.m_InvNumber = cPostItem18;
            cPostItems8.Add(cPostItem1);
            List<CPostItem> postItems9 = this.PostItems;
            CPostItem cPostItem19 = new CPostItem(CPostItem.DataType.LONG, "TimeEntEntryType");
            cPostItem1 = cPostItem19;
            this.m_EntryType = cPostItem19;
            postItems9.Add(cPostItem1);
            List<CPostItem> cPostItems9 = this.PostItems;
            CPostItem cPostItem20 = new CPostItem(CPostItem.DataType.STRING, "TimeEntQuickBooksID");
            cPostItem1 = cPostItem20;
            this.m_QuickBooksID = cPostItem20;
            cPostItems9.Add(cPostItem1);
            List<CPostItem> postItems10 = this.PostItems;
            CPostItem cPostItem21 = new CPostItem(CPostItem.DataType.LONG, "TimeEntTaxStatus");
            cPostItem1 = cPostItem21;
            this.m_TaxStatus = cPostItem21;
            postItems10.Add(cPostItem1);
            List<CPostItem> cPostItems10 = this.PostItems;
            CPostItem cPostItem22 = new CPostItem(CPostItem.DataType.LONG, "TimeEntReverseID");
            cPostItem1 = cPostItem22;
            this.m_ReverseEntryID = cPostItem22;
            cPostItems10.Add(cPostItem1);
        }

        public enum eFeeEntryType : short
        {
            TimeEnt = 2,
            FEE_ENTRY = 3,
            FEE_SPLITBILL_TRANSFER = 100,
            FEE_BILL_ADJ = 200,
            FEE_BILLED_IN_ADVANCE = 202,
            FEE_BILLED_IN_ADVANCE_USED = 203,
            FEE_COB = 300,
            FEE_GST_COB = 301,
            FEE_STAX_COB = 302,
            FEE_GST = 400,
            FEE_STAX = 401,
            FEE_WO_STAX_ADJ = 800,
            FEE_WO_STAX_BADDEBT = 801,
            FEE_WO_GST_ADJ = 802,
            FEE_WO_GST_BADDEBT = 803,
            FEE_WO_ADJ = 998,
            FEE_WO_BADDEBT = 999
        }

        public enum eFeeHoldFlag : byte
        {
            NO_HOLD,
            HOLD,
            SHOW_TEXT_ONLY,
            INCLUDE_IN_TOTAL_ONLY,
            NEVER_BILL
        }
    }
}