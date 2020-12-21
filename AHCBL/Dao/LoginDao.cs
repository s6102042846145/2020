using AHCBL.Component.Common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dao
{
    public class LoginDao : BaseDao<LoginDao>
    {
        public Boolean isAdmin(string vUser)
        {
            Boolean flg = false;
            if (vUser.IndexOf("@ahc", 1) > 0)
            {
                flg = true;
            }
            return flg;
        }
        public bool ChkAuthDB(string vUser, ref int member_id, ref string vUName, ref string vCenter, ref string vChannel)
        {
            try
            {

                string sql = "PD013_GET_CHK_AUTH_DB";
                DataTable dt = GetStoredProc(sql, new string[] { "@username" }, new string[] { vUser });
                //DataTable dt = GetDataTable(sql, "@USER_ID", vUser);
                if (dt.Rows.Count > 0)
                {
                    member_id = Util.NVLInt(dt.Rows[0]["id"]);
                    vUName = Util.NVLString(dt.Rows[0]["username"]);
                    vCenter = Util.NVLString(dt.Rows[0]["fullname"]);
                    vChannel = Util.NVLString(dt.Rows[0]["member_level"]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw ex;
            }
        }
        public bool ChkAuthDB(string vUser, string password, ref int member_id, ref string vUName, ref string vCenter, ref string vChannel)
        {
            try
            {
                string sql = "PD014_GET_CHK_AUTH_PASS";
                DataTable dt = GetStoredProc(sql, new string[] { "@username", "@password" }, new object[] { vUser, password });
                if (dt.Rows.Count > 0)
                {
                    member_id = Util.NVLInt(dt.Rows[0]["id"]);
                    vUName = Util.NVLString(dt.Rows[0]["username"]);
                    vCenter = Util.NVLString(dt.Rows[0]["fullname"]);
                    vChannel = Util.NVLString(dt.Rows[0]["member_level"]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw ex;
            }
        }
        public DataRow GetUserByID(string userID)
        {
            try
            {
                string sql = "PD013_GET_CHK_AUTH_DB";
                DataTable dt = GetStoredProc(sql, new string[] { "@username" }, new string[] { userID });
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw ex;
            }
        }
    }
}
