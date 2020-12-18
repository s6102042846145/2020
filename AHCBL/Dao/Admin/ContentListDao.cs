using AHCBL.Component.Common;
using AHCBL.Dto.Admin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHCBL.Dao.Admin
{
    public class ContentListDao : BaseDao<ContentListDao>
    {
        private MySqlConnection conn;
        private DataTable dt;
        public List<ContentListDto> GetContentList()
        {
            try
            {
                dt = new DataTable();
                List<ContentListDto> list = new List<ContentListDto>();
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD006_GET_CONTENTS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameterCollection param = cmd.Parameters;
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                param.Clear();
                AddSQLParam(param, "@member_id", Util.NVLString(1));
                conn.Open();
                cmd.ExecuteNonQuery();
                sd.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                    new ContentListDto
                    {
                        id = Util.NVLInt(dr["id"]),
                        code = Util.NVLString(dr["code"]),
                        name = Util.NVLString(dr["name"]),
                        contents = Util.NVLString(dr["contents"]),
                        contents_mobile = Util.NVLString(dr["contents_mobile"]),
                        skin_directory = Util.NVLInt(dr["skin_directory"]),
                        skin_directory_mobile = Util.NVLInt(dr["skin_directory_mobile"]),
                        include_head = Util.NVLString(dr["include_head"]),
                        include_tail = Util.NVLString(dr["include_tail"]),
                        img_head = Util.NVLString(dr["img_head"]),
                        img_tail = Util.NVLString(dr["img_tail"])

                    });
                }

                return list;
            }
            catch (Exception ex)
            {
                //logger.Error(ex);
                throw ex;
            }
        }


        public string SaveContentList(ContentListDto model, string action)
        {
            string result = "OK";
            try
            {
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD004_SAVE_CONTENTS", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameterCollection param = cmd.Parameters;
                param.Clear();
                AddSQLParam(param, "@p_id", Util.NVLInt(model.id));
                AddSQLParam(param, "@code", Util.NVLString(model.code));
                AddSQLParam(param, "@name", Util.NVLString(model.name));
                AddSQLParam(param, "@contents", Util.NVLString(model.contents));
                AddSQLParam(param, "@contents_mobile", Util.NVLString(model.contents_mobile));
                AddSQLParam(param, "@skin_directory", Util.NVLInt(model.skin_directory));
                AddSQLParam(param, "@skin_directory_mobile", Util.NVLInt(model.skin_directory_mobile));
                AddSQLParam(param, "@include_head", Util.NVLString(model.include_head));
                AddSQLParam(param, "@include_tail", Util.NVLString(model.include_tail));
                AddSQLParam(param, "@img_head", Util.NVLString(model.img_head));
                AddSQLParam(param, "@img_tail", Util.NVLString(model.img_tail));

                AddSQLParam(param, "@member_id", Util.NVLInt(1));
                AddSQLParam(param, "@active", Util.NVLInt(model.active));
                AddSQLParam(param, "@status", action);

                conn.Open();
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    result = read.GetString(0).ToString();
                }
                conn.Close();
            }
            catch (Exception e)
            {
                result = e.Message.ToString();
            }
            return result;
        }
    }
}
