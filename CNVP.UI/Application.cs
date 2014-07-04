using CNVP.Framework.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

namespace CNVP.UI
{
    public class Application
    {
        #region 申请单状态
        public string ApplyState(string guid)
        {
            string rslt = string.Empty;
            DataTable dt = DataFactory.GetInstance().ExecuteTable("select AppState, Guid from CNVP_Application Where Guid='" + guid + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                rslt = dt.Rows[0]["AppState"].ToString();
            }
            return rslt;
        }
        #endregion

        #region 获取CheckboxList的值
        public string GetCheck(CheckBoxList checkList, string separator)
        {
            string selval = "";
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (checkList.Items[i].Selected)
                {
                    selval += checkList.Items[i].Text + separator;
                }
            }
            if (selval.Length > 1)
            {
                selval = selval.Substring(0, selval.Length - 1);
            }
            return selval;
        }
        #endregion

        #region 判断审批意见是否已存在
        /// <summary>
        /// 判断审批意见是否已存在
        /// </summary>
        /// <param name="appGuid">申请单Guid</param>
        /// <returns></returns>
        public bool IsOpinionExist(string appGuid)
        {
            Hashtable ht = new Hashtable();
            ht.Add("AppGuid", appGuid);

            Model.Accredit model = new Model.Accredit();

            return model.IsExist(ht);
        }
        #endregion
    }
}