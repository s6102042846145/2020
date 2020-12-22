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
    public class BoardListDao : BaseDao<BoardListDao>
    {
        private MySqlConnection conn;
        private DataTable dt;
        public List<BoardListDto> GetDataList()
        {
            try
            {
                dt = new DataTable();
                List<BoardListDto> list = new List<BoardListDto>();
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD015_GET_BOARD", conn);
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
                    new BoardListDto
                    {
                        id = Util.NVLInt(dr["id"]),
                        bo_table   = Util.NVLString(dr["bo_table"]),
                        grp_id = Util.NVLInt(dr["grp_id"]),
                        bo_subject = Util.NVLString(dr["bo_subject"]),
                        bo_mobile_subject  = Util.NVLString(dr["bo_mobile_subject"]),
                        bo_device  = Util.NVLString(dr["bo_device"]),
                        grp_device = Util.NVLString(dr["grp_device"]),
                        all_device = Util.NVLString(dr["all_device"]),
                        category_list  = Util.NVLString(dr["category_list"]),
                        use_category   = Util.NVLString(dr["use_category"]),
                        grp_category_list  = Util.NVLString(dr["grp_category_list"]),
                        all_category_list  = Util.NVLString(dr["all_category_list"]),
                        bo_admin   = Util.NVLString(dr["bo_admin"]),
                        grp_admin  = Util.NVLString(dr["grp_admin"]),
                        all_admin  = Util.NVLString(dr["all_admin"]),
                        bo_list_level  = Util.NVLString(dr["bo_list_level"]),
                        grp_list_level = Util.NVLString(dr["grp_list_level"]),
                        all_list_level = Util.NVLString(dr["all_list_level"]),
                        bo_read_level  = Util.NVLString(dr["bo_read_level"]),
                        grp_read_level = Util.NVLString(dr["grp_read_level"]),
                        all_read_level = Util.NVLString(dr["all_read_level"]),
                        bo_write_level = Util.NVLString(dr["bo_write_level"]),
                        grp_write_level = Util.NVLString(dr["grp_write_level"]),
                        all_write_level = Util.NVLString(dr["all_write_level"]),
                        reply_level = Util.NVLString(dr["reply_level"]),
                        grp_reply_level = Util.NVLString(dr["grp_reply_level"]),
                        all_reply_level = Util.NVLString(dr["all_reply_level"]),
                        comment_level  = Util.NVLString(dr["comment_level"]),
                        grp_comment_level  = Util.NVLString(dr["grp_comment_level"]),
                        all_comment_level  = Util.NVLString(dr["all_comment_level"]),
                        link_level = Util.NVLString(dr["link_level"]),
                        grp_link_level = Util.NVLString(dr["grp_link_level"]),
                        all_link_level = Util.NVLString(dr["all_link_level"]),
                        upload_level   = Util.NVLString(dr["upload_level"]),
                        grp_upload_level   = Util.NVLString(dr["grp_upload_level"]),
                        all_upload_level   = Util.NVLString(dr["all_upload_level"]),
                        download_level = Util.NVLString(dr["download_level"]),
                        grp_download_level = Util.NVLString(dr["grp_download_level"]),
                        all_download_level = Util.NVLString(dr["all_download_level"]),
                        html_level = Util.NVLString(dr["html_level"]),
                        grp_html_level = Util.NVLString(dr["grp_html_level"]),
                        all_html_level = Util.NVLString(dr["all_html_level"]),
                        count_modify   = Util.NVLString(dr["count_modify"]),
                        grp_count_modify   = Util.NVLString(dr["grp_count_modify"]),
                        all_count_modify   = Util.NVLString(dr["all_count_modify"]),
                        count_delete   = Util.NVLString(dr["count_delete"]),
                        grp_count_delete   = Util.NVLString(dr["grp_count_delete"]),
                        all_count_delete   = Util.NVLString(dr["all_count_delete"]),
                        use_sideview   = Util.NVLString(dr["use_sideview"]),
                        grp_use_sideview   = Util.NVLString(dr["grp_use_sideview"]),
                        all_use_sideview   = Util.NVLString(dr["all_use_sideview"]),
                        use_secret = Util.NVLString(dr["use_secret"]),
                        grp_use_secret = Util.NVLString(dr["grp_use_secret"]),
                        all_use_secret = Util.NVLString(dr["all_use_secret"]),
                        use_dhtml_editor   = Util.NVLString(dr["use_dhtml_editor"]),
                        grp_use_dhtml_editor   = Util.NVLString(dr["grp_use_dhtml_editor"]),
                        all_use_dhtml_editor   = Util.NVLString(dr["all_use_dhtml_editor"]),
                        use_rss_view   = Util.NVLString(dr["use_rss_view"]),
                        grp_use_rss_view   = Util.NVLString(dr["grp_use_rss_view"]),
                        all_use_rss_view   = Util.NVLString(dr["all_use_rss_view"]),
                        use_good   = Util.NVLString(dr["use_good"]),
                        grp_use_good   = Util.NVLString(dr["grp_use_good"]),
                        all_use_good   = Util.NVLString(dr["all_use_good"]),
                        use_nogood = Util.NVLString(dr["use_nogood"]),
                        grp_use_nogood = Util.NVLString(dr["grp_use_nogood"]),
                        use_name   = Util.NVLString(dr["use_name"]),
                        grp_use_name   = Util.NVLString(dr["grp_use_name"]),
                        all_use_name   = Util.NVLString(dr["all_use_name"]),
                        use_signature  = Util.NVLString(dr["use_signature"]),
                        grp_use_signature  = Util.NVLString(dr["grp_use_signature"]),
                        all_use_signature  = Util.NVLString(dr["all_use_signature"]),
                        use_ip_view = Util.NVLString(dr["use_ip_view"]),
                        grp_use_ip_view = Util.NVLString(dr["grp_use_ip_view"]),
                        all_use_ip_view = Util.NVLString(dr["all_use_ip_view"]),
                        use_list_content   = Util.NVLString(dr["use_list_content"]),
                        grp_use_list_content   = Util.NVLString(dr["grp_use_list_content"]),
                        all_use_list_content   = Util.NVLString(dr["all_use_list_content"]),
                        use_list_file  = Util.NVLString(dr["use_list_file"]),
                        grp_use_list_file  = Util.NVLString(dr["grp_use_list_file"]),
                        all_use_list_file  = Util.NVLString(dr["all_use_list_file"]),
                        use_list_view  = Util.NVLString(dr["use_list_view"]),
                        grp_use_list_view  = Util.NVLString(dr["grp_use_list_view"]),
                        all_use_list_view  = Util.NVLString(dr["all_use_list_view"]),
                        use_email  = Util.NVLString(dr["use_email"]),
                        grp_use_email  = Util.NVLString(dr["grp_use_email"]),
                        all_use_email  = Util.NVLString(dr["all_use_email"]),
                        use_cert   = Util.NVLString(dr["use_cert"]),
                        grp_use_cert   = Util.NVLString(dr["grp_use_cert"]),
                        all_use_cert   = Util.NVLString(dr["all_use_cert"]),
                        upload_count   = Util.NVLString(dr["upload_count"]),
                        grp_upload_count   = Util.NVLString(dr["grp_upload_count"]),
                        all_upload_count   = Util.NVLString(dr["all_upload_count"]),
                        upload_size = Util.NVLString(dr["upload_size"]),
                        grp_upload_size = Util.NVLString(dr["grp_upload_size"]),
                        all_upload_size = Util.NVLString(dr["all_upload_size"]),
                        use_file_content   = Util.NVLString(dr["use_file_content"]),
                        grp_use_file_content   = Util.NVLString(dr["grp_use_file_content"]),
                        all_use_file_content   = Util.NVLString(dr["all_use_file_content"]),
                        write_min  = Util.NVLString(dr["write_min"]),
                        grp_write_min  = Util.NVLString(dr["grp_write_min"]),
                        all_write_min  = Util.NVLString(dr["all_write_min"]),
                        write_max  = Util.NVLString(dr["write_max"]),
                        grp_write_max  = Util.NVLString(dr["grp_write_max"]),
                        all_write_max  = Util.NVLString(dr["all_write_max"]),
                        comment_min = Util.NVLString(dr["comment_min"]),
                        grp_comment_min = Util.NVLString(dr["grp_comment_min"]),
                        all_comment_min = Util.NVLString(dr["all_comment_min"]),
                        comment_max = Util.NVLString(dr["comment_max"]),
                        grp_comment_max = Util.NVLString(dr["grp_comment_max"]),
                        all_comment_max = Util.NVLString(dr["all_comment_max"]),
                        use_sns = Util.NVLString(dr["use_sns"]),
                        grp_use_sns = Util.NVLString(dr["grp_use_sns"]),
                        all_use_sns = Util.NVLString(dr["all_use_sns"]),
                        use_search = Util.NVLString(dr["use_search"]),
                        grp_use_search = Util.NVLString(dr["grp_use_search"]),
                        all_use_search = Util.NVLString(dr["all_use_search"]),
                        bo_order   = Util.NVLString(dr["bo_order"]),
                        grp_order  = Util.NVLString(dr["grp_order"]),
                        all_order  = Util.NVLString(dr["all_order"]),
                        use_captcha = Util.NVLString(dr["use_captcha"]),
                        grp_use_captcha = Util.NVLString(dr["grp_use_captcha"]),
                        all_use_captcha = Util.NVLString(dr["all_use_captcha"]),
                        skin_id = Util.NVLInt(dr["skin_id"]),
                        grp_skin   = Util.NVLString(dr["grp_skin"]),
                        all_skin   = Util.NVLString(dr["all_skin"]),
                        skin_mobile_id = Util.NVLInt(dr["skin_mobile_id"]),
                        grp_mobile_skin = Util.NVLString(dr["grp_mobile_skin"]),
                        all_mobile_skin = Util.NVLString(dr["all_mobile_skin"]),
                        include_head   = Util.NVLString(dr["include_head"]),
                        grp_include_head   = Util.NVLString(dr["grp_include_head"]),
                        all_include_head   = Util.NVLString(dr["all_include_head"]),
                        include_tail   = Util.NVLString(dr["include_tail"]),
                        grp_include_tail   = Util.NVLString(dr["grp_include_tail"]),
                        all_include_tail   = Util.NVLString(dr["all_include_tail"]),
                        detail_hots = Util.NVLString(dr["detail_hots"]),
                        grp_detail_hots = Util.NVLString(dr["grp_detail_hots"]),
                        all_detail_hots = Util.NVLString(dr["all_detail_hots"]),
                        detail_tail = Util.NVLString(dr["detail_tail"]),
                        grp_detail_tail = Util.NVLString(dr["grp_detail_tail"]),
                        all_detail_tail = Util.NVLString(dr["all_detail_tail"]),
                        detail_mobile_hots = Util.NVLString(dr["detail_mobile_hots"]),
                        grp_detail_mobile_hots = Util.NVLString(dr["grp_detail_mobile_hots"]),
                        all_detail_mobile_hots = Util.NVLString(dr["all_detail_mobile_hots"]),
                        detail_mobile_tail = Util.NVLString(dr["detail_mobile_tail"]),
                        grp_detail_mobile_tail = Util.NVLString(dr["grp_detail_mobile_tail"]),
                        all_detail_mobile_tail = Util.NVLString(dr["all_detail_mobile_tail"]),
                        insert_content = Util.NVLString(dr["insert_content"]),
                        grp_insert_content = Util.NVLString(dr["grp_insert_content"]),
                        all_insert_content = Util.NVLString(dr["all_insert_content"]),
                        subject_len = Util.NVLString(dr["subject_len"]),
                        grp_subject_len = Util.NVLString(dr["grp_subject_len"]),
                        all_subject_len = Util.NVLString(dr["all_subject_len"]),
                        mobile_subject_len = Util.NVLString(dr["mobile_subject_len"]),
                        grp_mobile_subject_len = Util.NVLString(dr["grp_mobile_subject_len"]),
                        all_mobile_subject_len = Util.NVLString(dr["all_mobile_subject_len"]),
                        page_rows  = Util.NVLString(dr["page_rows"]),
                        grp_page_rows  = Util.NVLString(dr["grp_page_rows"]),
                        all_page_rows  = Util.NVLString(dr["all_page_rows"]),
                        mobile_page_rows   = Util.NVLString(dr["mobile_page_rows"]),
                        grp_mobile_page_rows   = Util.NVLString(dr["grp_mobile_page_rows"]),
                        all_mobile_page_rows   = Util.NVLString(dr["all_mobile_page_rows"]),
                        gallery_cols   = Util.NVLString(dr["gallery_cols"]),
                        grp_gallery_cols   = Util.NVLString(dr["grp_gallery_cols"]),
                        all_gallery_cols   = Util.NVLString(dr["all_gallery_cols"]),
                        gallery_width  = Util.NVLString(dr["gallery_width"]),
                        grp_gallery_width  = Util.NVLString(dr["grp_gallery_width"]),
                        all_gallery_width  = Util.NVLString(dr["all_gallery_width"]),
                        gallery_height = Util.NVLString(dr["gallery_height"]),
                        grp_gallery_height = Util.NVLString(dr["grp_gallery_height"]),
                        all_gallery_height = Util.NVLString(dr["all_gallery_height"]),
                        mobile_gallery_width   = Util.NVLString(dr["mobile_gallery_width"]),
                        grp_mobile_gallery_width   = Util.NVLString(dr["grp_mobile_gallery_width"]),
                        all_mobile_gallery_width   = Util.NVLString(dr["all_mobile_gallery_width"]),
                        mobile_gallery_height  = Util.NVLString(dr["mobile_gallery_height"]),
                        grp_mobile_gallery_height  = Util.NVLString(dr["grp_mobile_gallery_height"]),
                        all_mobile_gallery_height  = Util.NVLString(dr["all_mobile_gallery_height"]),
                        table_width = Util.NVLString(dr["table_width"]),
                        grp_table_width = Util.NVLString(dr["grp_table_width"]),
                        all_table_width = Util.NVLString(dr["all_table_width"]),
                        image_width = Util.NVLString(dr["image_width"]),
                        grp_image_width = Util.NVLString(dr["grp_image_width"]),
                        all_image_width = Util.NVLString(dr["all_image_width"]),
                        icon_new   = Util.NVLString(dr["icon_new"]),
                        grp_icon_new   = Util.NVLString(dr["grp_icon_new"]),
                        all_icon_new   = Util.NVLString(dr["all_icon_new"]),
                        icon_hot   = Util.NVLString(dr["icon_hot"]),
                        grp_icon_hot   = Util.NVLString(dr["grp_icon_hot"]),
                        all_icon_hot   = Util.NVLString(dr["all_icon_hot"]),
                        reply_order = Util.NVLString(dr["reply_order"]),
                        grp_reply_order = Util.NVLString(dr["grp_reply_order"]),
                        all_reply_order = Util.NVLString(dr["all_reply_order"]),
                        sort_field = Util.NVLInt(dr["sort_field"]),
                        grp_sort_field = Util.NVLString(dr["grp_sort_field"]),
                        all_sort_field = Util.NVLString(dr["all_sort_field"]),
                        grp_point  = Util.NVLString(dr["grp_point"]),
                        read_point = Util.NVLString(dr["read_point"]),
                        write_point = Util.NVLString(dr["write_point"]),
                        comment_point  = Util.NVLString(dr["comment_point"]),
                        download_point = Util.NVLString(dr["download_point"]),
                        subj1  = Util.NVLString(dr["subj1"]),
                        txt1   = Util.NVLString(dr["txt1"]),
                        grp_1  = Util.NVLInt(dr["grp_1"]),
                        all_1  = Util.NVLInt(dr["all_1"]),
                        subj2  = Util.NVLString(dr["subj2"]),
                        txt2   = Util.NVLString(dr["txt2"]),
                        grp_2  = Util.NVLInt(dr["grp_2"]),
                        all_2  = Util.NVLInt(dr["all_2"]),
                        subj3  = Util.NVLString(dr["subj3"]),
                        txt3   = Util.NVLString(dr["txt3"]),
                        grp_3  = Util.NVLInt(dr["grp_3"]),
                        all_3  = Util.NVLInt(dr["all_3"]),
                        subj4  = Util.NVLString(dr["subj4"]),
                        txt4   = Util.NVLString(dr["txt4"]),
                        grp_4  = Util.NVLInt(dr["grp_4"]),
                        all_4  = Util.NVLInt(dr["all_4"]),
                        subj5  = Util.NVLString(dr["subj5"]),
                        txt5   = Util.NVLString(dr["txt5"]),
                        grp_5  = Util.NVLInt(dr["grp_5"]),
                        all_5  = Util.NVLInt(dr["all_5"]),
                        subj6  = Util.NVLString(dr["subj6"]),
                        txt6   = Util.NVLString(dr["txt6"]),
                        grp_6  = Util.NVLInt(dr["grp_6"]),
                        all_6  = Util.NVLInt(dr["all_6"]),
                        subj7  = Util.NVLString(dr["subj7"]),
                        txt7   = Util.NVLString(dr["txt7"]),
                        grp_7  = Util.NVLInt(dr["grp_7"]),
                        all_7  = Util.NVLInt(dr["all_7"]),
                        subj8  = Util.NVLString(dr["subj8"]),
                        txt8   = Util.NVLString(dr["txt8"]),
                        grp_8  = Util.NVLInt(dr["grp_8"]),
                        all_8  = Util.NVLInt(dr["all_8"]),
                        subj9  = Util.NVLString(dr["subj9"]),
                        txt9   = Util.NVLString(dr["txt9"]),
                        grp_9  = Util.NVLInt(dr["grp_9"]),
                        all_9  = Util.NVLInt(dr["all_9"]),
                        subj10 = Util.NVLString(dr["subj10"]),
                        txt10  = Util.NVLString(dr["txt10"]),
                        grp_10 = Util.NVLInt(dr["grp_10"]),
                        all_10 = Util.NVLInt(dr["all_10"])
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


        public string SaveDataList(BoardListDto model, string action)
        {
            string result = "OK";
            try
            {
                //Varible.User.UserID
                conn = CreateConnection();
                MySqlCommand cmd = new MySqlCommand("PD010_SAVE_CATEGORY", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameterCollection param = cmd.Parameters;
                param.Clear();

                AddSQLParam(param, "@id", Util.NVLInt(model.id));
                AddSQLParam(param, "@bo_table", Util.NVLString(model.bo_table));
                AddSQLParam(param, "@grp_id", Util.NVLInt(model.grp_id));
                AddSQLParam(param, "@bo_subject", Util.NVLString(model.bo_subject));
                AddSQLParam(param, "@bo_mobile_subject", Util.NVLString(model.bo_mobile_subject));
                AddSQLParam(param, "@bo_device", Util.NVLString(model.bo_device));
                AddSQLParam(param, "@grp_device", Util.NVLString(model.grp_device));
                AddSQLParam(param, "@all_device", Util.NVLString(model.all_device));
                AddSQLParam(param, "@category_list", Util.NVLString(model.category_list));
                AddSQLParam(param, "@use_category", Util.NVLString(model.use_category));
                AddSQLParam(param, "@grp_category_list", Util.NVLString(model.grp_category_list));
                AddSQLParam(param, "@all_category_list", Util.NVLString(model.all_category_list));
                AddSQLParam(param, "@bo_admin", Util.NVLString(model.bo_admin));
                AddSQLParam(param, "@grp_admin", Util.NVLString(model.grp_admin));
                AddSQLParam(param, "@all_admin", Util.NVLString(model.all_admin));
                AddSQLParam(param, "@bo_list_level", Util.NVLString(model.bo_list_level));
                AddSQLParam(param, "@grp_list_level", Util.NVLString(model.grp_list_level));
                AddSQLParam(param, "@all_list_level", Util.NVLString(model.all_list_level));
                AddSQLParam(param, "@bo_read_level", Util.NVLString(model.bo_read_level));
                AddSQLParam(param, "@grp_read_level", Util.NVLString(model.grp_read_level));
                AddSQLParam(param, "@all_read_level", Util.NVLString(model.all_read_level));
                AddSQLParam(param, "@bo_write_level", Util.NVLString(model.bo_write_level));
                AddSQLParam(param, "@grp_write_level", Util.NVLString(model.grp_write_level));
                AddSQLParam(param, "@all_write_level", Util.NVLString(model.all_write_level));
                AddSQLParam(param, "@reply_level", Util.NVLString(model.reply_level));
                AddSQLParam(param, "@grp_reply_level", Util.NVLString(model.grp_reply_level));
                AddSQLParam(param, "@all_reply_level", Util.NVLString(model.all_reply_level));
                AddSQLParam(param, "@comment_level", Util.NVLString(model.comment_level));
                AddSQLParam(param, "@grp_comment_level", Util.NVLString(model.grp_comment_level));
                AddSQLParam(param, "@all_comment_level", Util.NVLString(model.all_comment_level));
                AddSQLParam(param, "@link_level", Util.NVLString(model.link_level));
                AddSQLParam(param, "@grp_link_level", Util.NVLString(model.grp_link_level));
                AddSQLParam(param, "@all_link_level", Util.NVLString(model.all_link_level));
                AddSQLParam(param, "@upload_level", Util.NVLString(model.upload_level));
                AddSQLParam(param, "@grp_upload_level", Util.NVLString(model.grp_upload_level));
                AddSQLParam(param, "@all_upload_level", Util.NVLString(model.all_upload_level));
                AddSQLParam(param, "@download_level", Util.NVLString(model.download_level));
                AddSQLParam(param, "@grp_download_level", Util.NVLString(model.grp_download_level));
                AddSQLParam(param, "@all_download_level", Util.NVLString(model.all_download_level));
                AddSQLParam(param, "@html_level", Util.NVLString(model.html_level));
                AddSQLParam(param, "@grp_html_level", Util.NVLString(model.grp_html_level));
                AddSQLParam(param, "@all_html_level", Util.NVLString(model.all_html_level));
                AddSQLParam(param, "@count_modify", Util.NVLString(model.count_modify));
                AddSQLParam(param, "@grp_count_modify", Util.NVLString(model.grp_count_modify));
                AddSQLParam(param, "@all_count_modify", Util.NVLString(model.all_count_modify));
                AddSQLParam(param, "@count_delete", Util.NVLString(model.count_delete));
                AddSQLParam(param, "@grp_count_delete", Util.NVLString(model.grp_count_delete));
                AddSQLParam(param, "@all_count_delete", Util.NVLString(model.all_count_delete));
                AddSQLParam(param, "@use_sideview", Util.NVLString(model.use_sideview));
                AddSQLParam(param, "@grp_use_sideview", Util.NVLString(model.grp_use_sideview));
                AddSQLParam(param, "@all_use_sideview", Util.NVLString(model.all_use_sideview));
                AddSQLParam(param, "@use_secret", Util.NVLString(model.use_secret));
                AddSQLParam(param, "@grp_use_secret", Util.NVLString(model.grp_use_secret));
                AddSQLParam(param, "@all_use_secret", Util.NVLString(model.all_use_secret));
                AddSQLParam(param, "@use_dhtml_editor", Util.NVLString(model.use_dhtml_editor));
                AddSQLParam(param, "@grp_use_dhtml_editor", Util.NVLString(model.grp_use_dhtml_editor));
                AddSQLParam(param, "@all_use_dhtml_editor", Util.NVLString(model.all_use_dhtml_editor));
                AddSQLParam(param, "@use_rss_view", Util.NVLString(model.use_rss_view));
                AddSQLParam(param, "@grp_use_rss_view", Util.NVLString(model.grp_use_rss_view));
                AddSQLParam(param, "@all_use_rss_view", Util.NVLString(model.all_use_rss_view));
                AddSQLParam(param, "@use_good", Util.NVLString(model.use_good));
                AddSQLParam(param, "@grp_use_good", Util.NVLString(model.grp_use_good));
                AddSQLParam(param, "@all_use_good", Util.NVLString(model.all_use_good));
                AddSQLParam(param, "@use_nogood", Util.NVLString(model.use_nogood));
                AddSQLParam(param, "@grp_use_nogood", Util.NVLString(model.grp_use_nogood));
                AddSQLParam(param, "@use_name", Util.NVLString(model.use_name));
                AddSQLParam(param, "@grp_use_name", Util.NVLString(model.grp_use_name));
                AddSQLParam(param, "@all_use_name", Util.NVLString(model.all_use_name));
                AddSQLParam(param, "@use_signature", Util.NVLString(model.use_signature));
                AddSQLParam(param, "@grp_use_signature", Util.NVLString(model.grp_use_signature));
                AddSQLParam(param, "@all_use_signature", Util.NVLString(model.all_use_signature));
                AddSQLParam(param, "@use_ip_view", Util.NVLString(model.use_ip_view));
                AddSQLParam(param, "@grp_use_ip_view", Util.NVLString(model.grp_use_ip_view));
                AddSQLParam(param, "@all_use_ip_view", Util.NVLString(model.all_use_ip_view));
                AddSQLParam(param, "@use_list_content", Util.NVLString(model.use_list_content));
                AddSQLParam(param, "@grp_use_list_content", Util.NVLString(model.grp_use_list_content));
                AddSQLParam(param, "@all_use_list_content", Util.NVLString(model.all_use_list_content));
                AddSQLParam(param, "@use_list_file", Util.NVLString(model.use_list_file));
                AddSQLParam(param, "@grp_use_list_file", Util.NVLString(model.grp_use_list_file));
                AddSQLParam(param, "@all_use_list_file", Util.NVLString(model.all_use_list_file));
                AddSQLParam(param, "@use_list_view", Util.NVLString(model.use_list_view));
                AddSQLParam(param, "@grp_use_list_view", Util.NVLString(model.grp_use_list_view));
                AddSQLParam(param, "@all_use_list_view", Util.NVLString(model.all_use_list_view));
                AddSQLParam(param, "@use_email", Util.NVLString(model.use_email));
                AddSQLParam(param, "@grp_use_email", Util.NVLString(model.grp_use_email));
                AddSQLParam(param, "@all_use_email", Util.NVLString(model.all_use_email));
                AddSQLParam(param, "@use_cert", Util.NVLString(model.use_cert));
                AddSQLParam(param, "@grp_use_cert", Util.NVLString(model.grp_use_cert));
                AddSQLParam(param, "@all_use_cert", Util.NVLString(model.all_use_cert));
                AddSQLParam(param, "@upload_count", Util.NVLString(model.upload_count));
                AddSQLParam(param, "@grp_upload_count", Util.NVLString(model.grp_upload_count));
                AddSQLParam(param, "@all_upload_count", Util.NVLString(model.all_upload_count));
                AddSQLParam(param, "@upload_size", Util.NVLString(model.upload_size));
                AddSQLParam(param, "@grp_upload_size", Util.NVLString(model.grp_upload_size));
                AddSQLParam(param, "@all_upload_size", Util.NVLString(model.all_upload_size));
                AddSQLParam(param, "@use_file_content", Util.NVLString(model.use_file_content));
                AddSQLParam(param, "@grp_use_file_content", Util.NVLString(model.grp_use_file_content));
                AddSQLParam(param, "@all_use_file_content", Util.NVLString(model.all_use_file_content));
                AddSQLParam(param, "@write_min", Util.NVLString(model.write_min));
                AddSQLParam(param, "@grp_write_min", Util.NVLString(model.grp_write_min));
                AddSQLParam(param, "@all_write_min", Util.NVLString(model.all_write_min));
                AddSQLParam(param, "@write_max", Util.NVLString(model.write_max));
                AddSQLParam(param, "@grp_write_max", Util.NVLString(model.grp_write_max));
                AddSQLParam(param, "@all_write_max", Util.NVLString(model.all_write_max));
                AddSQLParam(param, "@comment_min", Util.NVLString(model.comment_min));
                AddSQLParam(param, "@grp_comment_min", Util.NVLString(model.grp_comment_min));
                AddSQLParam(param, "@all_comment_min", Util.NVLString(model.all_comment_min));
                AddSQLParam(param, "@comment_max", Util.NVLString(model.comment_max));
                AddSQLParam(param, "@grp_comment_max", Util.NVLString(model.grp_comment_max));
                AddSQLParam(param, "@all_comment_max", Util.NVLString(model.all_comment_max));
                AddSQLParam(param, "@use_sns", Util.NVLString(model.use_sns));
                AddSQLParam(param, "@grp_use_sns", Util.NVLString(model.grp_use_sns));
                AddSQLParam(param, "@all_use_sns", Util.NVLString(model.all_use_sns));
                AddSQLParam(param, "@use_search", Util.NVLString(model.use_search));
                AddSQLParam(param, "@grp_use_search", Util.NVLString(model.grp_use_search));
                AddSQLParam(param, "@all_use_search", Util.NVLString(model.all_use_search));
                AddSQLParam(param, "@bo_order", Util.NVLString(model.bo_order));
                AddSQLParam(param, "@grp_order", Util.NVLString(model.grp_order));
                AddSQLParam(param, "@all_order", Util.NVLString(model.all_order));
                AddSQLParam(param, "@use_captcha", Util.NVLString(model.use_captcha));
                AddSQLParam(param, "@grp_use_captcha", Util.NVLString(model.grp_use_captcha));
                AddSQLParam(param, "@all_use_captcha", Util.NVLString(model.all_use_captcha));
                AddSQLParam(param, "@skin_id", Util.NVLInt(model.skin_id));
                AddSQLParam(param, "@grp_skin", Util.NVLString(model.grp_skin));
                AddSQLParam(param, "@all_skin", Util.NVLString(model.all_skin));
                AddSQLParam(param, "@skin_mobile_id", Util.NVLInt(model.skin_mobile_id));
                AddSQLParam(param, "@grp_mobile_skin", Util.NVLString(model.grp_mobile_skin));
                AddSQLParam(param, "@all_mobile_skin", Util.NVLString(model.all_mobile_skin));
                AddSQLParam(param, "@include_head", Util.NVLString(model.include_head));
                AddSQLParam(param, "@grp_include_head", Util.NVLString(model.grp_include_head));
                AddSQLParam(param, "@all_include_head", Util.NVLString(model.all_include_head));
                AddSQLParam(param, "@include_tail", Util.NVLString(model.include_tail));
                AddSQLParam(param, "@grp_include_tail", Util.NVLString(model.grp_include_tail));
                AddSQLParam(param, "@all_include_tail", Util.NVLString(model.all_include_tail));
                AddSQLParam(param, "@detail_hots", Util.NVLString(model.detail_hots));
                AddSQLParam(param, "@grp_detail_hots", Util.NVLString(model.grp_detail_hots));
                AddSQLParam(param, "@all_detail_hots", Util.NVLString(model.all_detail_hots));
                AddSQLParam(param, "@detail_tail", Util.NVLString(model.detail_tail));
                AddSQLParam(param, "@grp_detail_tail", Util.NVLString(model.grp_detail_tail));
                AddSQLParam(param, "@all_detail_tail", Util.NVLString(model.all_detail_tail));
                AddSQLParam(param, "@detail_mobile_hots", Util.NVLString(model.detail_mobile_hots));
                AddSQLParam(param, "@grp_detail_mobile_hots", Util.NVLString(model.grp_detail_mobile_hots));
                AddSQLParam(param, "@all_detail_mobile_hots", Util.NVLString(model.all_detail_mobile_hots));
                AddSQLParam(param, "@detail_mobile_tail", Util.NVLString(model.detail_mobile_tail));
                AddSQLParam(param, "@grp_detail_mobile_tail", Util.NVLString(model.grp_detail_mobile_tail));
                AddSQLParam(param, "@all_detail_mobile_tail", Util.NVLString(model.all_detail_mobile_tail));
                AddSQLParam(param, "@insert_content", Util.NVLString(model.insert_content));
                AddSQLParam(param, "@grp_insert_content", Util.NVLString(model.grp_insert_content));
                AddSQLParam(param, "@all_insert_content", Util.NVLString(model.all_insert_content));
                AddSQLParam(param, "@subject_len", Util.NVLString(model.subject_len));
                AddSQLParam(param, "@grp_subject_len", Util.NVLString(model.grp_subject_len));
                AddSQLParam(param, "@all_subject_len", Util.NVLString(model.all_subject_len));
                AddSQLParam(param, "@mobile_subject_len", Util.NVLString(model.mobile_subject_len));
                AddSQLParam(param, "@grp_mobile_subject_len", Util.NVLString(model.grp_mobile_subject_len));
                AddSQLParam(param, "@all_mobile_subject_len", Util.NVLString(model.all_mobile_subject_len));
                AddSQLParam(param, "@page_rows", Util.NVLString(model.page_rows));
                AddSQLParam(param, "@grp_page_rows", Util.NVLString(model.grp_page_rows));
                AddSQLParam(param, "@all_page_rows", Util.NVLString(model.all_page_rows));
                AddSQLParam(param, "@mobile_page_rows", Util.NVLString(model.mobile_page_rows));
                AddSQLParam(param, "@grp_mobile_page_rows", Util.NVLString(model.grp_mobile_page_rows));
                AddSQLParam(param, "@all_mobile_page_rows", Util.NVLString(model.all_mobile_page_rows));
                AddSQLParam(param, "@gallery_cols", Util.NVLString(model.gallery_cols));
                AddSQLParam(param, "@grp_gallery_cols", Util.NVLString(model.grp_gallery_cols));
                AddSQLParam(param, "@all_gallery_cols", Util.NVLString(model.all_gallery_cols));
                AddSQLParam(param, "@gallery_width", Util.NVLString(model.gallery_width));
                AddSQLParam(param, "@grp_gallery_width", Util.NVLString(model.grp_gallery_width));
                AddSQLParam(param, "@all_gallery_width", Util.NVLString(model.all_gallery_width));
                AddSQLParam(param, "@gallery_height", Util.NVLString(model.gallery_height));
                AddSQLParam(param, "@grp_gallery_height", Util.NVLString(model.grp_gallery_height));
                AddSQLParam(param, "@all_gallery_height", Util.NVLString(model.all_gallery_height));
                AddSQLParam(param, "@mobile_gallery_width", Util.NVLString(model.mobile_gallery_width));
                AddSQLParam(param, "@grp_mobile_gallery_width", Util.NVLString(model.grp_mobile_gallery_width));
                AddSQLParam(param, "@all_mobile_gallery_width", Util.NVLString(model.all_mobile_gallery_width));
                AddSQLParam(param, "@mobile_gallery_height", Util.NVLString(model.mobile_gallery_height));
                AddSQLParam(param, "@grp_mobile_gallery_height", Util.NVLString(model.grp_mobile_gallery_height));
                AddSQLParam(param, "@all_mobile_gallery_height", Util.NVLString(model.all_mobile_gallery_height));
                AddSQLParam(param, "@table_width", Util.NVLString(model.table_width));
                AddSQLParam(param, "@grp_table_width", Util.NVLString(model.grp_table_width));
                AddSQLParam(param, "@all_table_width", Util.NVLString(model.all_table_width));
                AddSQLParam(param, "@image_width", Util.NVLString(model.image_width));
                AddSQLParam(param, "@grp_image_width", Util.NVLString(model.grp_image_width));
                AddSQLParam(param, "@all_image_width", Util.NVLString(model.all_image_width));
                AddSQLParam(param, "@icon_new", Util.NVLString(model.icon_new));
                AddSQLParam(param, "@grp_icon_new", Util.NVLString(model.grp_icon_new));
                AddSQLParam(param, "@all_icon_new", Util.NVLString(model.all_icon_new));
                AddSQLParam(param, "@icon_hot", Util.NVLString(model.icon_hot));
                AddSQLParam(param, "@grp_icon_hot", Util.NVLString(model.grp_icon_hot));
                AddSQLParam(param, "@all_icon_hot", Util.NVLString(model.all_icon_hot));
                AddSQLParam(param, "@reply_order", Util.NVLString(model.reply_order));
                AddSQLParam(param, "@grp_reply_order", Util.NVLString(model.grp_reply_order));
                AddSQLParam(param, "@all_reply_order", Util.NVLString(model.all_reply_order));
                AddSQLParam(param, "@sort_field", Util.NVLInt(model.sort_field));
                AddSQLParam(param, "@grp_sort_field", Util.NVLString(model.grp_sort_field));
                AddSQLParam(param, "@all_sort_field", Util.NVLString(model.all_sort_field));
                AddSQLParam(param, "@grp_point", Util.NVLString(model.grp_point));
                AddSQLParam(param, "@read_point", Util.NVLString(model.read_point));
                AddSQLParam(param, "@write_point", Util.NVLString(model.write_point));
                AddSQLParam(param, "@comment_point", Util.NVLString(model.comment_point));
                AddSQLParam(param, "@download_point", Util.NVLString(model.download_point));
                AddSQLParam(param, "@subj1", Util.NVLString(model.subj1));
                AddSQLParam(param, "@txt1", Util.NVLString(model.txt1));
                AddSQLParam(param, "@grp_1", Util.NVLInt(model.grp_1));
                AddSQLParam(param, "@all_1", Util.NVLInt(model.all_1));
                AddSQLParam(param, "@subj2", Util.NVLString(model.subj2));
                AddSQLParam(param, "@txt2", Util.NVLString(model.txt2));
                AddSQLParam(param, "@grp_2", Util.NVLInt(model.grp_2));
                AddSQLParam(param, "@all_2", Util.NVLInt(model.all_2));
                AddSQLParam(param, "@subj3", Util.NVLString(model.subj3));
                AddSQLParam(param, "@txt3", Util.NVLString(model.txt3));
                AddSQLParam(param, "@grp_3", Util.NVLInt(model.grp_3));
                AddSQLParam(param, "@all_3", Util.NVLInt(model.all_3));
                AddSQLParam(param, "@subj4", Util.NVLString(model.subj4));
                AddSQLParam(param, "@txt4", Util.NVLString(model.txt4));
                AddSQLParam(param, "@grp_4", Util.NVLInt(model.grp_4));
                AddSQLParam(param, "@all_4", Util.NVLInt(model.all_4));
                AddSQLParam(param, "@subj5", Util.NVLString(model.subj5));
                AddSQLParam(param, "@txt5", Util.NVLString(model.txt5));
                AddSQLParam(param, "@grp_5", Util.NVLInt(model.grp_5));
                AddSQLParam(param, "@all_5", Util.NVLInt(model.all_5));
                AddSQLParam(param, "@subj6", Util.NVLString(model.subj6));
                AddSQLParam(param, "@txt6", Util.NVLString(model.txt6));
                AddSQLParam(param, "@grp_6", Util.NVLInt(model.grp_6));
                AddSQLParam(param, "@all_6", Util.NVLInt(model.all_6));
                AddSQLParam(param, "@subj7", Util.NVLString(model.subj7));
                AddSQLParam(param, "@txt7", Util.NVLString(model.txt7));
                AddSQLParam(param, "@grp_7", Util.NVLInt(model.grp_7));
                AddSQLParam(param, "@all_7", Util.NVLInt(model.all_7));
                AddSQLParam(param, "@subj8", Util.NVLString(model.subj8));
                AddSQLParam(param, "@txt8", Util.NVLString(model.txt8));
                AddSQLParam(param, "@grp_8", Util.NVLInt(model.grp_8));
                AddSQLParam(param, "@all_8", Util.NVLInt(model.all_8));
                AddSQLParam(param, "@subj9", Util.NVLString(model.subj9));
                AddSQLParam(param, "@txt9", Util.NVLString(model.txt9));
                AddSQLParam(param, "@grp_9", Util.NVLInt(model.grp_9));
                AddSQLParam(param, "@all_9", Util.NVLInt(model.all_9));
                AddSQLParam(param, "@subj10", Util.NVLString(model.subj10));
                AddSQLParam(param, "@txt10", Util.NVLString(model.txt10));
                AddSQLParam(param, "@grp_10", Util.NVLInt(model.grp_10));
                AddSQLParam(param, "@all_10", Util.NVLInt(model.all_10));

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
