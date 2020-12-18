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
    public class CategoryListDao : BaseDao<CategoryListDao>
    {
        private MySqlConnection conn;
        private DataTable dt;
        public List<CategoryListDto> GetCategoryList()
        {
            try
            {
                dt = new DataTable();
                List<CategoryListDto> list = new List<CategoryListDto>();
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD009_GET_CATEGORY", conn);
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
                    new CategoryListDto
                    {
                        id = Util.NVLInt(dr["id"]),
                        code = Util.NVLString(dr["code"]),
                        name = Util.NVLString(dr["name"]),
                        min_price = Util.NVLString(dr["min_price"]),
                        max_price = Util.NVLString(dr["max_price"]),
                        charging_time = Util.NVLString(dr["charging_time"]),
                        energy = Util.NVLInt(dr["energy"]),
                        revenue = Util.NVLInt(dr["revenue"]),
                        day = Util.NVLInt(dr["day"]),
                        win_count = Util.NVLInt(dr["win_count"]),
                        win_max_price = Util.NVLString(dr["win_max_price"]),
                        ca_order = Util.NVLString(dr["ca_order"]),
                        ca_use = Util.NVLInt(dr["ca_use"]) ==0 ? false : true
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


        public string SaveCategoryList(CategoryListDto model, string action)
        {
            string result = "OK";
            try
            {
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD010_SAVE_CATEGORY", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameterCollection param = cmd.Parameters;
                param.Clear();
                AddSQLParam(param, "@p_id", Util.NVLInt(model.id));
                AddSQLParam(param, "@code", Util.NVLString(model.code));
                AddSQLParam(param, "@name", Util.NVLString(model.name));
                AddSQLParam(param, "@min_price", Util.NVLString(model.min_price));
                AddSQLParam(param, "@max_price", Util.NVLString(model.max_price));
                AddSQLParam(param, "@charging_time", Util.NVLString(model.charging_time));
                AddSQLParam(param, "@energy", Util.NVLInt(model.energy));
                AddSQLParam(param, "@revenue", Util.NVLInt(model.revenue));
                AddSQLParam(param, "@day", Util.NVLInt(model.day));
                AddSQLParam(param, "@win_count", Util.NVLInt(model.win_count));
                AddSQLParam(param, "@win_max_price", Util.NVLString(model.win_max_price));
                AddSQLParam(param, "@ca_order", Util.NVLInt(model.ca_order));
                int ca_use = 1;
                if (model.ca_use != true)
                {
                    ca_use = 0;
                }
                AddSQLParam(param, "@ca_use", ca_use);

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
