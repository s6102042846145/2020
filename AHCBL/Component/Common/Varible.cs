using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;

namespace AHCBL.Component.Common
{
    public class Varible
    {
        #region for print report excel invoice

        public const string ANUAL_EXCEL = "AnualFee_{0}.xls";
        public const string IPOFEE_EXCEL = "IPOFee_{0}.xls";
        public const string OUTOFPOCKET_EXCEL = "OutOfPocket_{0}.xls";

        public static EUser _user;
        #endregion

        public static EUser User
        {
            get
            {
                if (HttpRuntime.AppDomainAppId != null)
                {
                    //is web app
                    return (EUser)HttpContext.Current.Session["User"];
                }
                else
                {
                    //is windows app
                    if (_user == null)
                    {
                        _user = new EUser
                        {
                            //member_id
                            UserID = Environment.UserName,
                            UserIP = Environment.MachineName
                        };
                    }
                    return _user;
                }
            }
            set
            {
                if (HttpRuntime.AppDomainAppId != null)
                {
                    HttpContext.Current.Session["User"] = value;
                }
                else
                {
                    _user = value;
                }
            }
        }

        public enum StatusCode : int
        {
            SaveData = 1,
            RequestApprove,
            Approved,
            Rejected,
            CancelByMaker,
            CancelByApprover
        }

        public static List<string> GetddlBranch()
        {
            var res = new List<string> {
                "สำนักงานใหญ่"
                ,"สาขา"

            };
            //res.Sort();
            return res;

        }

        public const string SUCCESS = "SUCCESS";
        public const string FAIL = "FAIL";
        //TRC_CODE
        public const string MDRCW = "MDRCW";
        public const string RFEOTT = "RFEOTT";
        public const string WTMDR = "WTMDR";
        public const string MCRCW = "MCRCW";
        public const string IUOMDR = "IUOMDR";
        public const string IOMDR = "IOMDR";
        public const string IORMDR = "IORMDR";
        public const string UM_DR = "UM_DR";
        public const string UM_CR = "UM_CR";
        public const string VATDR = "VATDR";
        public const string IUOMCR = "IUOMCR";
        public const string RFEOTH = "RFEOTH";
        public const string MSMDR = "MSMDR";
        public const string HOAFCR = "HOAFCR";
        //GL_DESC
        public const string RETURN = "RETURN";
        public const string CANCEL_CONTRACT = "CANCEL_CONTRACT";

        public static List<ListItem> GetStatus()
        {
            List<ListItem> listListItem = new List<ListItem>();

            ListItem li = new ListItem("บันทึก", "1");
            listListItem.Add(li);

            li = new ListItem("รออนุมัติ", "2");
            listListItem.Add(li);

            li = new ListItem("อนุมัติ", "3");
            listListItem.Add(li);

            li = new ListItem("ไม่อนุมัติ", "4");
            listListItem.Add(li);

            li = new ListItem("ยกเลิกรายการ", "5");
            listListItem.Add(li);

            li = new ListItem("พิมพ์", "6");
            listListItem.Add(li);


            return listListItem;

        }
    }
}