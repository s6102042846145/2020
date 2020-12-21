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
    public class ItemListDao : BaseDao<ItemListDao>
    {
        private MySqlConnection conn;
        private DataTable dt;
        public List<ItemListDto> GetData()
        {
            try
            {
                dt = new DataTable();
                List<ItemListDto> list = new List<ItemListDto>();
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD011_GET_ITEM", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameterCollection param = cmd.Parameters;
                MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
                param.Clear();
                AddSQLParam(param, "@member_id", Util.NVLInt(1));
                conn.Open();
                cmd.ExecuteNonQuery();
                sd.Fill(dt);
                conn.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                    new ItemListDto
                    {
                        id = Util.NVLInt(dr["id"]),
                        category_id = Util.NVLInt(dr["category_id"]),
                        code = Util.NVLString(dr["code"]),
                        name = Util.NVLString(dr["name"]),
                        price_win = Util.NVLString(dr["price_win"]),
                        buy_name = Util.NVLString(dr["buy_name"]),
                        //win_date = Util.NVLString(dr["win_date"])
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


        public string SaveData(ItemListDto model, string action)
        {
            string result = "OK";
            try
            {
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD012_SAVE_ITEM", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameterCollection param = cmd.Parameters;
                param.Clear();
                AddSQLParam(param, "@p_id", Util.NVLInt(model.id));
                AddSQLParam(param, "@category_id", Util.NVLInt(model.category_id));
                AddSQLParam(param, "@code", Util.NVLString(model.code));
                AddSQLParam(param, "@name", Util.NVLString(model.name));
                AddSQLParam(param, "@buy_name", Util.NVLString(model.buy_name));
                AddSQLParam(param, "@win_date", Util.NVLString(model.win_date));

                AddSQLParam(param, "@member_id", Util.NVLInt(1));
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